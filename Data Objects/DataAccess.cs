using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//like proxy
namespace Data_Objects
{
    public static class DataAccess
    {
        private static readonly string connectionStringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
        //private static readonly IDaoFactory factory = DaoFactories.GetFactory(connectionStringName);
    }
}
