using Newtonsoft.Json;

namespace EMPMAL
{
    public class User
    {

        /// <summary>
        /// User Id
        /// </summary>
        public int U01F01 { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        public string U01F02 { get; set; }

        /// <summary>
        /// Login Id
        /// </summary>
        public string U01F03 { get; set; }

        /// <summary>
        /// User Role (FranchiseOwner, OutletOwner, Captain, User, Cook, Rider)
        /// </summary>
        public string U01F05 { get; set; }

        /// <summary>
        /// A - Active, D - Deactivate
        /// </summary>
        [JsonIgnore]
        public string U01F08 { get; set; } = string.Empty;

        /// <summary>
        /// Last Login OTP
        /// </summary>
        [JsonIgnore]
        public string U01F09 { get; set; } = string.Empty;

        /// <summary>
        /// Last Login OTP Send Date Time
        /// </summary>
        [JsonIgnore]
        public DateTime U01F10 { get; set; }

        /// <summary>
        /// Country Code
        /// </summary>
        public string U01F11 { get; set; }
        /// <summary>
        /// Access Token
        /// </summary>
        public string U01X01 { get; set; }
    }
}
