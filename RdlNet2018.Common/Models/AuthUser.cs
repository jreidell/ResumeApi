using Newtonsoft.Json;
using System;

namespace RdlNet2018.Common.Models
{
    public class AuthUser
    {
        [JsonProperty("AuthUserId")]
        public Guid? AuthUserId { get; set; }

        [JsonProperty("EmailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
