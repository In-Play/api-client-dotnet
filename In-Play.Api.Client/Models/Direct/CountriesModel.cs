using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace In_Play.Api.Client.Models.Direct
{
   
        public class CountryCollection
        {
            private List<Country> countries;

            public List<Country> Countries { get => countries; set => countries = value; }
        }

        public class Country
        {
            public string Code { get; set; }

            [JsonProperty(PropertyName = "Country")]

            public string Name { get; set; }
            public int AgeRestrict { get; set; }
            public List<State> States { get; set; }
            public int Index { get; set; }
            public List<PhoneCode> PhoneCodes { get; set; }
        }

        public class State
        {
            public string Code { get; set; }

            [JsonProperty(PropertyName = "State")]
            public string Name { get; set; }
            public int AgeRestrict { get; set; }
        }

        public class PhoneCode
        {
            public int Code { get; set; }
        }
    
}
