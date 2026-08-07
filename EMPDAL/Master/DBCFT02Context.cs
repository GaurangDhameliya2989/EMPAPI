using EMPMAL;
using ServiceStack.OrmLite;

namespace EMPDAL
{
    public class DBCFT02Context
    {
        public List<CFT02> GetDesignation()
        {
            using (var db = new MySqlOrmLite().Open())
            {
                return db.Select<CFT02>(@"
                   Select
                        T02.T02F01,
                        T02.T02F02
                   From
                        CFT02 T02;"
                );
            }
        }
    }
}
