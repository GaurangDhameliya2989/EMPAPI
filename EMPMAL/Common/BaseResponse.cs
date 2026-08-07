using Newtonsoft.Json;

namespace EMPMAL
{
    public class BaseResponse
    {
        /// <summary>
        /// Error Status
        /// </summary>
        [JsonIgnore]
        public bool IsError { get; set; }

        /// <summary>
        /// Status Code
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
    }
}
