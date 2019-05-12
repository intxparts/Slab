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
        void Initialize(DataModel dataModel, LicenseData licenseData);
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

        public void Initialize(DataModel dataModel, LicenseData licenseData)
        {
            _dataModel = dataModel;
            _licenseData = licenseData;
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

    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected LicenseData _licenseData;
        protected DataModel _dataModel;
        protected GLDataContext _glDataContext;

        /// <summary>
        /// Occurs prior to DataBinding
        /// </summary>
        protected virtual void OnInitialize()
        {
        }

        public void Initialize(GLDataContext glDataContext, DataModel dataModel, LicenseData licenseData)
        {
            _licenseData = licenseData;
            _dataModel = dataModel;
            _glDataContext = glDataContext;
            OnInitialize();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string property_name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
}
