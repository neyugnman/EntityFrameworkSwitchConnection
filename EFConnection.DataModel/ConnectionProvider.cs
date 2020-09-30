using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConnection.DataModel
{
    enum DBType
    {
        Development,
        Qa
    }
    public class SingleConnection

    {

        private SingleConnection() { }

        private static SingleConnection _ConsString = null;
        private static DBType _DbType = DBType.Development;

        private String _String = null;

        public static string ConString

        {
            get
            {

                if (_ConsString == null)

                {

                    _ConsString = new SingleConnection { _String = SingleConnection.Connect() };

                    return _ConsString._String;

                }

                else

                    return _ConsString._String;

            }

        }


        public static void SetDBType(string type)
        {
            _DbType = DBType.Development;
            if (type == "2")
            {
                _DbType = DBType.Qa;
            }
            if (_ConsString == null)
            {
                _ConsString = new SingleConnection { _String = Connect() };
            }else
            {
                _ConsString._String = Connect();
            }

        }
        public static string Connect()
        {
            SqlConnectionStringBuilder sqlString;
            EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder () ;
            switch (_DbType)
            {
                case DBType.Development:
                    //Build an SQL connection string
                     sqlString = new SqlConnectionStringBuilder()

                    {
                        DataSource = "YOUR_DEV_SERVER", // Server name

                        InitialCatalog = "YOUR_DEV_DB",  //Database

                        UserID = "YOUR_DEV_USER",         //Username

                        Password = "YOUR_DEV_PASS",  //Password

                    };

                    //Build an Entity Framework connection string
                    entityString = new EntityConnectionStringBuilder()
                    {

                        Provider = "System.Data.SqlClient",

                        Metadata = "res://*/Safework.csdl|res://*/Safework.ssdl|res://*/Safework.msl",

                        ProviderConnectionString = sqlString.ToString()

                    };
                    break;
                case DBType.Qa:
                    //Build an SQL connection string
                    sqlString = new SqlConnectionStringBuilder()

                    {
                        DataSource = "YOUR_QA_SEVER", // Server name

                        InitialCatalog = "YOUR_QA_DB",  //Database

                        UserID = "YOUR_DEV_USER",         //Username

                        Password = "YOUR_DEV_PASS",  //Password

                    };

                    //Build an Entity Framework connection string
                    entityString = new EntityConnectionStringBuilder()
                    {

                        Provider = "System.Data.SqlClient",

                        Metadata = "res://*/Safework.csdl|res://*/Safework.ssdl|res://*/Safework.msl",

                        ProviderConnectionString = sqlString.ToString()

                    };

                    break;
            }

            return entityString.ConnectionString;

        }


    }

    public partial class SafeworkEntities : DbContext
    {

        public SafeworkEntities(string connectionString) : base(connectionString)
        {
        }

    }
}
