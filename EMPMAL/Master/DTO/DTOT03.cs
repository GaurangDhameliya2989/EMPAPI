using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EMPMAL
{
    /// <summary>
    /// Employee Master 
    /// </summary>
    public class DTOT03
    {
        /// <summary>
        /// Employee Id 
        /// </summary>
        [Required(ErrorMessage = "employee Id Required.")]
        [JsonProperty("T03X01")]
        public int T03F01 { get; set; } = 0;

        /// <summary>
        /// Employee Name 
        /// </summary>
        [StringLength(60 ,ErrorMessage = "Employee Name Is Must Be At Most 60 Characters.")]
        [Required(ErrorMessage = "Employee Name Is Required.")]
        [JsonProperty("T03X02")]
        public string T03F02 { get; set; } = string.Empty;

        /// <summary>
        /// Departments Id 
        /// </summary>
        [JsonProperty("T03X03")]
        public int T03F03 { get; set;} = 0;

        /// <summary>
        /// DOB
        /// </summary>
        [JsonProperty("T03X04")]
        public DateOnly T03F04 { get; set; }

        /// <summary>
        /// Mobile No
        /// </summary>
        [StringLength(10 ,MinimumLength = 10,ErrorMessage = "10 Digit Mobile No Is Mendatory.")]
        [JsonProperty("T03X05")]
        public string T03F05 { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(60 ,ErrorMessage = "Email Is Required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Format.")]
        [JsonProperty("T03X06")]
        public string T03F06 { get; set; } = string.Empty;

        /// <summary>
        /// Gender
        /// </summary>
        [StringLength(10 ,ErrorMessage = "Gender Required.")]
        [RegularExpression("^(Male|Female)$" ,ErrorMessage = "Gender Must Be Male Or Female.")]
        [JsonProperty("T03X07")]
        public string T03F07 { get; set; } = string.Empty;

        /// <summary>
        /// Designation Id 
        /// </summary>
        [JsonProperty("T03X08")]
        public int T03F08 { get; set; } = 0;

        /// <summary>
        /// Join Date
        /// </summary>
        [JsonProperty("T03X09")]
        public DateOnly T03F09 {  get; set; }

        /// <summary>
        /// Salary
        /// </summary>
        [JsonProperty("T03X10")]
        public decimal T03F10 { get; set; } = 0;

        /// <summary>
        /// TDS
        /// </summary>
        [JsonProperty("T03X11")]
        public decimal T03F11 { get; set; } = 0;
    }
}
