using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SeleniumRecorder.Models
{
    public class SeleniumTestRecordedModel
    {
        public class Command
        {
            [Key]
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("comment")]
            public string Comment { get; set; }

            [JsonProperty("command")]
            public string Comm { get; set; }

            [JsonProperty("target")]
            public string Target { get; set; }

            [JsonProperty("targets")]
            public List<Dictionary<string, string>> Targets { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }

        }
        public class Root
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("tests")]
            public List<Test> Tests { get; set; }

            [JsonProperty("suites")]
            public List<Suite> Suites { get; set; }

            [JsonProperty("urls")]
            public List<string> Urls { get; set; }

            [JsonProperty("plugins")]
            public List<object> Plugins { get; set; }
        }

        public class Suite
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("persistSession")]
            public bool PersistSession { get; set; }

            [JsonProperty("parallel")]
            public bool Parallel { get; set; }

            [JsonProperty("timeout")]
            public int Timeout { get; set; }

            [JsonProperty("tests")]
            public List<object> Tests { get; set; }
        }

        public class Test
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("commands")]
            public List<Command> Commands { get; set; }
        }


    }
}
