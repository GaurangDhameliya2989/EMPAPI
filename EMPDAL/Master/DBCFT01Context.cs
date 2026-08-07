using EMPMAL;
using ServiceStack.OrmLite;

namespace EMPDAL
{
    public class DBCFT01Context
    {
        public List<CFT01> GetDepartment()
        {
            using (var db = new MySqlOrmLite().Open())
            {
                return db.Select<CFT01>(@"
                    Select 
                        T01.T01F01,
                        T01.T01F02
                    From 
                        CFT01 T01;"
                    );
            }
        }
    }
}
