using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EMPMAL
{
    /// <summary>
    /// Employee Designation 
    /// </summary>
    public class DTOT02
    {
        /// <summary>
        /// Employee Designation Id
        /// </summary>
        [Required(ErrorMessage = "Employee Designation Id Required.")]
        [JsonProperty("T02X01")]
        public int T02F01 { get; set; } = 0;

        /// <summary>
        /// Employee Designation Name 
        /// </summary>
        [StringLength(60 ,ErrorMessage = "Employee Designation Name Is Must Be At Most 60 Characters.")]
        [Required(ErrorMessage = "Employee Designation Name Required.")]
        [JsonProperty("T02X02")]
        public string T02F02 { get; set; } = string.Empty;
    }
}
