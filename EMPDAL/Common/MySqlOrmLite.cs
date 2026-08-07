using MySql.Data.MySqlClient;
using ServiceStack.OrmLite;

namespace EMPDAL
{
    public class MySqlOrmLite : OrmLiteConnectionFactory
    {
        public MySqlOrmLite()
         : base(GetConnection(), MySqlDialect.Provider)
        {
        }

        public MySqlOrmLite(string DBName)
          : base(GetConnection(DBName), MySqlDialect.Provider)
        {
        }

        private static string GetConnection()
        {
            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder(ConfigHelper.GetConfiguration("ConnectionStrings", "Constr"));
            connectionStringBuilder.Password = Cipher.Decrypt(connectionStringBuilder.Password);
            return connectionStringBuilder.ConnectionString;
        }

        private static string GetConnection(string DBName)
        {
            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder(ConfigHelper.GetConfiguration("ConnectionStrings", "Constr").Replace("~DBNAME~", DBName));
            connectionStringBuilder.Database = DBName;
            connectionStringBuilder.Password = Cipher.Decrypt(connectionStringBuilder.Password);
            return connectionStringBuilder.ConnectionString;
        }
    }
}

