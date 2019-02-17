using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RdlNet2018.Common.Models
{
    public class WorkHistory
    {
        [JsonProperty("WorkHistoryId")]
        public Guid? WorkHistoryId { get; set; }

        [JsonProperty("CareerInfoId")]
        public Guid CareerInfoId { get; set; }

        [JsonProperty("Sequence")]
        public int Sequence { get; set; }

        [JsonProperty("Employer")]
        public string Employer { get; set; }

        [JsonProperty("JobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty("JobDescription")]
        public string JobDescription { get; set; }

        [DataType(DataType.Date)]
        [JsonProperty("StartDate")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [JsonProperty("EndDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty("Enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("WorkHistoryDetails")]
        public virtual List<WorkHistoryDetail> WorkHistoryDetails { get; set; }

    }
}
