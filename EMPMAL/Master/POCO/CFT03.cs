using ServiceStack.DataAnnotations;

namespace EMPMAL
{
    public class CFT03
    {
        /// <summary>
        /// Employee Unique Id
        /// </summary>
        [PrimaryKey]
        public int T03F01 { get; set; }

        /// <summary>
        /// Employee Name
        /// </summary>
        public string T03F02 { get; set; } = string.Empty;

        /// <summary>
        /// departments Id
        /// </summary>
        public int T03F03 { get; set; }

        /// <summary>
        /// dtae Only
        /// </summary>
        public DateOnly T03F04 { get; set; }

        /// <summary>
        /// Mobile
        /// </summary>
        public string T03F05 { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        public string T03F06 { get; set; } = string.Empty;

        /// <summary>
        /// Gender
        /// </summary>
        public string T03F07 { get; set; } = string.Empty;

        /// <summary>
        /// Designation Id T02F01
        /// </summary>
        public int T03F08 { get; set; }

        /// <summary>
        /// Join Date
        /// </summary>
        public DateOnly T03F09 { get; set; }

        /// <summary>
        /// Salary
        /// </summary>
        public decimal T03F10 {  get; set; } 

        /// <summary>
        /// TDS
        /// </summary>
        public decimal T03F11 { get; set; }
    }
}
