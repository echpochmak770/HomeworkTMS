using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;

namespace HomeworkTMS
{
    internal class ApiResponse
    {
        private string id;
        private string url;
        private int width;
        private int height;

        [JsonPropertyName("id")]
        public string Id { get => id; set { id = value; } }

        [JsonPropertyName("url")]
        public string Url { get => url; set { url = value; } }

        [JsonPropertyName("width")]
        public int Width { get => width; set { width = value; } }

        [JsonPropertyName("height")]
        public int Height { get => height; set { height = value; } }

        public ApiResponse(string id, string url, int width, int height)
        {
            Id = id;
            Url = url;
            Width = width;
            Height = height;
        }
    }
}
