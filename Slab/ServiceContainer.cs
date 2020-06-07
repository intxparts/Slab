using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slab.Services;

namespace Slab
{
    public interface IServiceContainer
    {
        Services.ILicenseService LicenseService { get; }
        Services.IDataModelService DataModelService { get; }

        Services.ICanvasService CanvasService { get; }
    }

    public class ServiceContainer : IServiceContainer
    {
        private static readonly Lazy<ILicenseService> _licenseServiceInstance = new Lazy<ILicenseService>(() => new LicenseService());
        private static readonly Lazy<IDataModelService> _dataModelServiceInstance = new Lazy<IDataModelService>(() => new DataModelService());
        private static readonly Lazy<ICanvasService> _canvasServiceInstance = new Lazy<ICanvasService>(() => new CanvasService());

        public ILicenseService LicenseService => _licenseServiceInstance.Value;

        public IDataModelService DataModelService => _dataModelServiceInstance.Value;

        public ICanvasService CanvasService => _canvasServiceInstance.Value;
    }
}
