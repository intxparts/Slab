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
        public LicenseSwitchViewModel()
        {
            _licenseTypes = Enum.GetValues(typeof(LicenseType))
                    .Cast<LicenseType>()
                    .ToList()
                    .ConvertAll(v => new LicenseTypeData(v));
        }

        public override void Initialize(IServiceContainer container)
        {
            base.Initialize(container);
            _selectedLicenseTypeData = _licenseTypes.FirstOrDefault(l => l.LicenseType == _licenseData.LicenseType);
        }

        public class LicenseTypeData
        {
            public string Name { get; private set; }
            public LicenseType LicenseType { get; private set; }

            public LicenseTypeData(LicenseType licenseType)
            {
                Name = Enum.GetName(typeof(LicenseType), licenseType);
                LicenseType = licenseType;
            }
        }

        private readonly List<LicenseTypeData> _licenseTypes;
        public List<LicenseTypeData> LicenseTypes { get { return _licenseTypes; } }

        private LicenseTypeData _selectedLicenseTypeData;
        public LicenseTypeData SelectedLicenseTypeData
        {
            get { return _selectedLicenseTypeData; }
            set
            {
                if (_selectedLicenseTypeData != value)
                {
                    _selectedLicenseTypeData = value;
                    NotifyPropertyChanged(nameof(SelectedLicenseTypeData));
                }
            }
        }
    }
}
