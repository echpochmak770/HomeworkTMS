using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Net.Http.Headers;
using System.Text;
using System.Security.Claims;

namespace HomeworkTMSWeb.BasicAuthentication
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
        {
        }

        //тестировал через DevTools путем добавления сконвертированных в Base 64 данных "admin:admin"
        //заголовок добавлял при помощи расширения google chrome "ModHeader"
        //Key: Authorization, Value: Basic YWRtaW46YWRtaW4=
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Отсутствует заголовок Authorization");
            }

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

                if (!"Basic".Equals(authHeader.Scheme, StringComparison.OrdinalIgnoreCase))
                {
                    return AuthenticateResult.Fail("Невалидная схема аутентификации");
                }

                var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(":", 2);

                var username = credentials[0];
                var password = credentials[1];

                if (username == "admin" && password == "admin")
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }

                return AuthenticateResult.Fail("Данные не валидны");
            }
            catch
            {
                return AuthenticateResult.Fail("Исключение при аутентификации");
            }
        }
    }
}
