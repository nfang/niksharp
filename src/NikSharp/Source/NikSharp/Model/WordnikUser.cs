using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NikSharp.Model
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WordnikUser : WordnikResponseModel
    {
        /// <summary>
        /// Unique idenitifier for a user
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }
        /// <summary>
        /// Display name
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }
        /// <summary>
        /// Account status (0,1,2,3)
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        [JsonProperty(PropertyName = "userName")]
        public string Username { get; set; }
        /// <summary>
        /// Email address
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        /// <summary>
        /// Facebook ID
        /// </summary>
        [JsonProperty(PropertyName = "faceBookId")]
        public string FacebookId { get; set; }
    }
}
