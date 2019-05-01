using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab
{
    public class OGBackgroundColor
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
    }

    public class OGContext
    {
        public OGBackgroundColor Background { get; set; }
        public GLControl View { get; set; } 

        public void Invalidate()
        {
            View.Invalidate();
        }
    }
}
