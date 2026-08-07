using EMPMAL;
using ServiceStack.OrmLite;

namespace EMPDAL
{
    public class DBCFT03Context
    {
        public List<CFT03> GetEmployee()
        {
            using (var db = new MySqlOrmLite().Open())
            {
                return db.Select<CFT03>(@"
                    Select
                        T03.T03F01,
                        T03.T03F02,
                        T03.T03F03,
                        T03.T03F04,
                        T03.T03F05,
                        T03.T03F06,
                        T03.T03F07,
                        T03.T03F08,
                        T03.T03F09,
                        T03.T03F10,
                        T03.T03F11
                    From
                        CFT03 T03;"
                    );
            }
        }
    }
}
