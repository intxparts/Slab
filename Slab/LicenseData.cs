using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab
{
    public enum LicenseType
    {
        None,
        Basic,
        Premium,
        Experimental
    }

    public class LicenseData
    {
        public LicenseType LicenseType { get; set; }
    }
}
