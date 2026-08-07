using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EMPMAL
{
    /// <summary>
    /// Employee Department
    /// </summary>
    public class DTOT01
    {
        /// <summary>
        /// Employee Department Unique Id (Auto)
        /// </summary>
        [Required(ErrorMessage = "The Employee Department Id Is Mendatory")]
        [JsonProperty("T01X01")]
        public int T01F01 { get; set; } = 0;

        /// <summary>
        /// Employee Department Name 
        /// </summary>
        [StringLength(60 ,ErrorMessage = "The Department Name Is Must Be At Most 60 Characters.")]
        [Required(ErrorMessage = "The Employee Department Name is Required")]
        [JsonProperty("T01X02")]
        public string T01F02 { get; set; } = string.Empty;
    }
}
