using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab
{
    public class WelcomeTool : ITool
    {
        public string Name => "Welcome";

        public string Icon => "<Placeholder>";

        public bool IsVisible => false;

        public bool IsEnabled => false;

        public Type ViewType => typeof(Welcome);

        public Type ViewModelType => typeof(WelcomeTool);
    }
}
