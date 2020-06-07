using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab.Tools
{
    public interface ITool
    {
        string Name { get; }
        Type DefinedViewType { get; }
        Type DefinedViewModelType { get; }
        bool IsVisible { get; }
        bool IsEnabled { get; }
        void Initialize(IServiceContainer container);
    }

    public abstract class BaseTool<TView, TViewModel> : ITool, INotifyPropertyChanged 
        where TView : System.Windows.Controls.UserControl
        where TViewModel : BaseViewModel
    {
        protected readonly string _name;
        //protected readonly Icon _icon;

        public BaseTool(string name)
        {
            _name = name;
        }

        public string Name { get { return _name; } }
        public Type DefinedViewType { get { return typeof(TView); } }
        public Type DefinedViewModelType { get { return typeof(TViewModel); } }

        public virtual void Initialize(IServiceContainer container)
        {
            Services.ILicenseService licenseService = container.LicenseService;
            Services.IDataModelService dataModelService = container.DataModelService;

            _licenseData = licenseService.LicenseData;
            _dataModel = dataModelService.DataModel; 
        }

        protected LicenseData _licenseData;
        public LicenseData LicenseData
        {
            get { return _licenseData; }
            set
            {
                _licenseData = value;
                NotifyPropertyChanged(nameof(LicenseData));
                CheckVisibilityAndAccessibility();
            }
        }

        protected DataModel _dataModel;
        public DataModel DataModel
        {
            get { return _dataModel; }
            set
            {
                _dataModel = value;
                NotifyPropertyChanged(nameof(DataModel));
                CheckVisibilityAndAccessibility();
            }
        }

        public abstract bool IsVisible { get; }
        public abstract bool IsEnabled { get; }

        protected void CheckVisibilityAndAccessibility()
        {
            NotifyPropertyChanged(nameof(IsVisible));
            NotifyPropertyChanged(nameof(IsEnabled));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string property_name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }

    public interface IViewModel
    {
        void Initialize(IServiceContainer container);
    }

    public abstract class BaseViewModel : IViewModel, INotifyPropertyChanged
    {
        protected LicenseData _licenseData;
        protected DataModel _dataModel;

        public virtual void Initialize(IServiceContainer container)
        {
            Services.ICanvasService canvasService = container.CanvasService;
            Services.IDataModelService dataModelService = container.DataModelService;
            Services.ILicenseService licenseService = container.LicenseService;

            _licenseData = licenseService.LicenseData;
            _dataModel = dataModelService.DataModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string property_name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
}
