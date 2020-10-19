using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovernmentData.Models
{
    public class AwardRecipient
    {
        [JsonProperty("_id")]
        public int Id { get; set; }

        public string  Name { get; set; }

        [JsonProperty("Baccalaureate Institution")]
        public string BaccalaureateInstitution { get; set; }

        [JsonProperty("Field of Study")]
        public string FieldOfStudy { get; set; }

        [JsonProperty("Current Institution")]
        public string CurrentInstitution { get; set; }
    }
}