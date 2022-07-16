using System.Collections.Generic;
using System.ComponentModel;
using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;

namespace GartnerApplication.Model
{
    public class SourceContent
    {
        public string Tags { get; set; }
        public string Name { get; set; }
        public string Twitter { get; set; }
    }

    public class JsonSourceContents
    {
        public List<JsonSourceContent> Products { get; set; }
    }

    public class JsonSourceContent
    {
        public List<string> Categories { get; set; }
        public string Title { get; set; }
        public string Twitter { get; set; }
    }
}
