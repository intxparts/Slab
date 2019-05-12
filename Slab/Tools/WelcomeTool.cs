using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab.Tools
{
    public class WelcomeTool : BaseTool<Welcome, WelcomeViewModel>
    {
        public WelcomeTool() : base(name: "Welcome")
        {
        }

        public override bool IsVisible => true;
        public override bool IsEnabled => true;
    }

    public class WelcomeViewModel : BaseViewModel
    {
    }
}
