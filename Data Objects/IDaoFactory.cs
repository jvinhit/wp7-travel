using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Objects
{
    public interface IDaoFactory
    {
        IMapImage MapImage { get; }
    }
}
