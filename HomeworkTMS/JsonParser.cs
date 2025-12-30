using System.Text.Json;
using System.Text.RegularExpressions;

namespace HomeworkTMS
{
    internal static class JsonParser
    {
        public static async Task<T> LoadAsync<T>(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*.json");

            if (files.Length == 0)
            {
                throw new FileNotFoundException("В папке нет json-файлов");
            }

            if (files.Length > 1)
            {
                throw new ArgumentException("В папке более одного json-файла");
            }

            using var stream = File.OpenRead(files[0]);
            return await JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true 
            });
        }
    }
}