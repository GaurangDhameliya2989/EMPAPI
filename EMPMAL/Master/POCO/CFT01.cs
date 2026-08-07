namespace EMPMAL
{
    /// <summary>
    /// Employee Department
    /// </summary>
    public class CFT01
    {
        /// <summary>
        /// Employee Department Unique Id (Auto)
        /// </summary>
        [ServiceStack.DataAnnotations.PrimaryKey]
        public int T01F01 { get; set; }

        /// <summary>
        /// Employee Department Name
        /// </summary>
        public string T01F02 { get; set; }
    }
}
