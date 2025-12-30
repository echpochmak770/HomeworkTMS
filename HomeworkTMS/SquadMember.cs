using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace HomeworkTMS
{
    public class SquadMember
    {
        private string _name;
        private string _secretIdentity;
        private string[] _powers;

        [JsonPropertyName("name")]
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Имя члена отряда не может быть null, пустым или состоять из пробелов");
                }
                _name = value;
            }
        }

        [JsonPropertyName("age")]
        public uint Age { get; set; }

        [JsonPropertyName("secretIdentity")]
        public string SecretIdentity
        {
            get => _secretIdentity;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Секретная личность не может быть null, пустой или состоять из пробелов");
                }
                _secretIdentity = value;
            }
        }

        [JsonPropertyName("powers")]
        public string[] Powers
        {
            get => _powers;
            set
            {
                if (value == null || value.Any(x => string.IsNullOrWhiteSpace(x)))
                {
                    throw new ArgumentException("Сверхспособность не может быть null, пустой или состоять из пробелов");
                }
                _powers = value;
            }
        }

        public SquadMember(string name, uint age, string secretIdentity, string[] powers)
        {
            Name = name;
            Age = age;
            SecretIdentity = secretIdentity;
            Powers = powers;
        }

        [Obsolete("Only for XmlSerializer", true)]
        public SquadMember() { }
    }
}