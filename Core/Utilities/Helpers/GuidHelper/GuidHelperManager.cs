using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.GuidHelper
{
    public class GuidHelperManager
    {
        public static string CreateGuid()
        {   //File name create
            return Guid.NewGuid().ToString();
        }
    }
}
