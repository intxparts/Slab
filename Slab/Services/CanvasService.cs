using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab.Services
{
    public interface ICanvasService
    {
        GLDataContext GLDataContext { get; set; }

        event EventHandler RequestGLInvalidate;

        void RequestInvalidate();
    }


    class CanvasService : ICanvasService
    {
        private GLDataContext _glDataContext;
        public GLDataContext GLDataContext
        {
            get { return _glDataContext; }
            set
            {
                _glDataContext = value;
                RequestInvalidate();
            }
        }

        public event EventHandler RequestGLInvalidate;

        public void RequestInvalidate()
        {
            RequestGLInvalidate?.Invoke(this, EventArgs.Empty);
        }
    }
}
