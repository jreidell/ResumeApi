using Newtonsoft.Json;
using System;

namespace RdlNet2018.Common.Models
{
    public class WorkHistoryDetail
    {
        [JsonProperty("WorkHistoryDetailId")]
        public Guid? WorkHistoryDetailId { get; set; }

        [JsonProperty("WorkHistoryId")]
        public Guid WorkHistoryId { get; set; }

        [JsonProperty("Sequence")]
        public int Sequence { get; set; }

        [JsonProperty("ContentBody")]
        public string ContentBody { get; set; }

        [JsonProperty("Enabled")]
        public bool Enabled { get; set; }

    }
}
