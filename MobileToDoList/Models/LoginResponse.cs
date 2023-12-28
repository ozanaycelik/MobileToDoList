using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MobileToDoList.Models
{
    public class LoginResponse
    {
        

            public string token { get; set; }
            public DateTime expires { get; set; }
            public string displayName { get; set; }
            public List<AppMenuYeni> appMenuYeni { get; set; }
            public List<string> mobileMenu { get; set; }
            public List<Company> companies { get; set; }
            public string defaultPage { get; set; }

    }

    public class AppMenuYeni
    {
        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name;

        [JsonProperty("Url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url;

        [JsonProperty("Caption", NullValueHandling = NullValueHandling.Ignore)]
        public string Caption;

        [JsonProperty("Icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon;

        [JsonProperty("InPage", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> InPage;
    }

    public class Company
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id;

        [JsonProperty("Company", NullValueHandling = NullValueHandling.Ignore)]
        public string Company_;

        [JsonProperty("IsIettEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsIettEnabled;
    }
}
