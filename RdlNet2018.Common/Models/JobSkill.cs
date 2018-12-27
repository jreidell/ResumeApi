using Newtonsoft.Json;
using System;

namespace RdlNet2018.Common.Models
{
    public class JobSkill
    {

        [JsonProperty("JobSkillId")]
        public Guid JobSkillId { get; set; }

        [JsonProperty("CareerInfoId")]
        public Guid CareerInfoId { get; set; }

        [JsonProperty("Sequence")]
        public int Sequence { get; set; }

        [JsonProperty("JobSkillTitle")]
        public string JobSkillTitle { get; set; }

        [JsonProperty("Enabled")]
        public bool Enabled { get; set; }


    }
}
