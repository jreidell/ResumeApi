using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RdlNet2018.Common.Models
{
    public class CareerInfo
    {
        [JsonProperty("CareerInfoId")]
        public Guid? CareerInfoId { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("MiddleName")]
        public string MiddleName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Suffix")]
        public string Suffix { get; set; }

        [JsonProperty("EmailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("Address1")]
        public string Address1 { get; set; }

        [JsonProperty("Address2")]
        public string Address2 { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Mobile")]
        public string Mobile { get; set; }

        [JsonProperty("CareerInfoTitle")]
        public string CareerInfoTitle { get; set; }

        [JsonProperty("Summary")]
        public string Summary { get; set; }

        [JsonProperty("Enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("JobSkills")]
        public virtual List<JobSkill> JobSkills { get; set; }

        [JsonProperty("WorkHistory")]
        public virtual List<WorkHistory> WorkHistory { get; set; }

    }
}
