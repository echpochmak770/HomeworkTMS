using HomeworkTMS;
using System.Text.Json.Serialization;

namespace HomeworkTMS
{
    public class Squad
    {
        private string _squadName;
        private string _homeTown;
        private string _secretBase;

        [JsonPropertyName("squadName")]
        public string SquadName
        {
            get => _squadName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Имя отряда не может быть пустым");
                }
                _squadName = value;
            }
        }

        [JsonPropertyName("homeTown")]
        public string HomeTown
        {
            get => _homeTown;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Название города не может быть пустым");
                }
                _homeTown = value;
            }
        }

        [JsonPropertyName("secretBase")]
        public string SecretBase
        {
            get => _secretBase;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("База не может быть пустой");
                }
                _secretBase = value;
            }
        }

        [JsonPropertyName("formed")]
        public int Formed { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("members")]
        public SquadMember[] Members { get; set; }

        public Squad(string squadName, string homeTown, int formed, string secretBase, bool active, SquadMember[] members)
        {
            SquadName = squadName;
            HomeTown = homeTown;
            Formed = formed;
            SecretBase = secretBase;
            Active = active;
            Members = members;
        }

        [Obsolete("Only for XmlSerializer", true)]
        public Squad() { }
    }
}