using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab.Tools
{
    public class LicenseTool : BaseTool<LicenseSwitchCtrl, LicenseSwitchViewModel>
    {
        public LicenseTool() : base(name: "License")
        {
        }

        public override bool IsVisible => LicenseData != null && LicenseData.LicenseType == LicenseType.Experimental;
        public override bool IsEnabled => true;
    }

    public class LicenseSwitchViewModel : BaseViewModel
    {

    }
}
