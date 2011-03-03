using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Objects.ADO.NET.SqlServer;

namespace Data_Objects
{
    class DAOFactories
    {
        public static IDaoFactory GetFactory(string dataProvider)
        {
            // Return the requested DaoFactory
            switch (dataProvider)
            {
                //case "ADO.NET.Access": return new AdoNet.Access.AccessDaoFactory();
                //case "ADO.NET.Oracle": return new AdoNet.Oracle.OracleDaoFactory();

                case "ADO.NET.SqlExpress":
                case "ADO.NET.SqlServer": return new SQLDaoFactories();

                //case "LinqToSql.SqlExpress":
                //case "LinqToSql.SqlServer": return new LinqToSql.Implementation.LinqDaoFactory();

                //case "EntityFramework.SqlExpress":
                //case "EntityFramework.SqlServer": return new EntityFramework.Implementation.EntityDaoFactory();

                // Default: SqlExpress
                default: return new SQLDaoFactories();
            }
        }
    }
}
