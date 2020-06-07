using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab.Services
{
    public interface ILicenseService
    {
        LicenseData LicenseData { get; set; }
    }


    public class LicenseService : ILicenseService
    {
        private LicenseData _licenseData;
        public LicenseData LicenseData
        {
            get { return _licenseData; }
            set { _licenseData = value; }
        }
    }
}
