using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab
{
    public class Color
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
    }

    public class GLDataContext
    {
        public event EventHandler RequestGLInvalidate;

        public Color BackgroundColor { get; set; }

        public void RequestInvalidate()
        {
            RequestGLInvalidate?.Invoke(this, EventArgs.Empty);
        }
    }
}
