using System.Text.Json;
using System.Text.Encodings.Web;

namespace EFCore_Code_First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new LibraryDbContext();
            var service = new LibraryService(context);

            Print("Книги, изданные после 2010 года", service.GetBooksAfter2010());
            Print("Авторы без биографии", service.GetAuthorsWithoutBio());
            Print("Читатели с просроченными книгами", service.GetMembersWithOverdues());
            Print("Книги по категориям", service.GetBooksFromEachCategory());
            Print("Издательства без книг", service.GetPublishersWithoutBooks());
            Print("Книги с несколькими категориями", service.GetBooksWithManyCategories());
            Print("Авторы и количество книг", service.GetAuthorsWithBooksCount());
            Print("Читатели, берущие только фантастику", service.GetMembersWithFantasyOnly());
            Print("Полная информация о книгах", service.GetBooksInformation());
            Print("Сведения об издательствах", service.GetPublisherDetails());
            Print("Выдачи книг по месяцам", service.GetLoansGroupedByDates());
            Print("Топ-3 авторов по суммарному числу страниц", service.GetTopTotalPageCountAuthors());
            Print("Категории и авторы", service.GetCategoriesWithAuthors());
            Print("Информация о читателях", service.GetMembersInformation());
            Print("Книги без выдач", service.GetBooksWithoutLoans());
            Print("Книги дороже среднего по издательству", service.GetBooksWithAboveAveragePrice());
            Print("Книги, выдававшиеся в 2023 году", service.GetBooksLoanedIn2023());
            Print("Активные читатели", service.GetActiveMembers());
            Print("Авторы и их категории", service.GetAuthorsWithCategories());
            Print("Популярность категорий за последние 4 месяца", service.GetCategoriesPopularityReport());
        }

        static void Print(string title, object data)
        {
            Console.WriteLine($"\n===== {title} =====");

            Console.WriteLine(
                JsonSerializer.Serialize(
                    data,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    }
                )
            );
        }

    }
}
