using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Objects.ADO.NET.SqlServer
{
    class SQLDaoFactories : IDaoFactory
    {
        public IMapImage MapImage
        {
            get { return new SQLServerMapImageDAO(); }
        }
    }
}
