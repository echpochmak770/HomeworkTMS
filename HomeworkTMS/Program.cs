using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTMS
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string folder = "B:\\JsonHomework";
            Squad squad = await JsonParser.LoadAsync<Squad>(folder);

            string xmlPath = $"B:\\JsonHomework\\{squad.SquadName}.xml";
            XmlParser.SaveToXml(squad, xmlPath);
        }
    }
}
