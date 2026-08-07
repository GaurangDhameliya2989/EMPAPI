using ServiceStack.DataAnnotations;

namespace EMPMAL
{
    public class CFT02
    {
        /// <summary>
        /// Employee Designation Unique Id
        /// </summary>
        [PrimaryKey]
        public int T02F01 { get; set; }

        /// <summary>
        /// Employee Designation Name
        /// </summary>
        public string T02F02 { get; set; } = string.Empty;
    }
}
