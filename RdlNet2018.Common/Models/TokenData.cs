using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RdlNet2018.Common.Models
{
    public class TokenData
    {
        [JsonProperty("access_token")]
        public string access_token { get; set; }
        [JsonProperty("expires_in")]
        public string expires_in { get; set; }
        [JsonProperty("token_type")]
        public string token_type { get; set; }

    }
}
