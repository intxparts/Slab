using Slab.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Slab
{
    public sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        private GLDataContext _glDataContext;
        private DataModel _dataModel;
        private LicenseData _licenseData;

        public DataModel DataModel { get { return _dataModel; } }
        public LicenseData LicenseData { get { return _licenseData; } }
        public GLDataContext GLDataContext { get { return _glDataContext; } }
        public List<ITool> Tools { get; private set; }

        private ITool _selectedTool;
        public ITool SelectedTool
        {
            get
            {
                return _selectedTool;
            }
            set
            {
                if (_selectedTool != value)
                {
                    _selectedTool = value;
                    OnSelectedToolChanged();
                    NotifyPropertyChanged(nameof(SelectedTool));
                }
            }
        }

        public DelegateCommand Window_OnLoaded { get; private set; }

        public void OnWindowLoaded()
        {
            SelectedTool = Tools.First();
        }

        public void OnSelectedToolChanged()
        {
            // instantiate its view and view model using the activator
            var viewModel = Activator.CreateInstance(SelectedTool.DefinedViewModelType);
            var view = Activator.CreateInstance(SelectedTool.DefinedViewType);
            var usrCtrl = view as UserControl;
            var vm = viewModel as IViewModel;
            if (vm == null || usrCtrl == null)
                return;

            vm.Initialize(_glDataContext, _dataModel, _licenseData);

            // bind the view data context to the view model
            usrCtrl.DataContext = vm;

            // raise request load tool and pass in the view as an argument to the event
            RequestLoadTool?.Invoke(this, usrCtrl);
        }

        public event EventHandler<UserControl> RequestLoadTool;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            Window_OnLoaded = new DelegateCommand(OnWindowLoaded);

            _glDataContext = new GLDataContext()
            {
                BackgroundColor = new Color()
                {
                    Red = 0,
                    Blue = 0,
                    Green = 0
                }
            };
            _dataModel = new DataModel();
            _licenseData = new LicenseData() { LicenseType = LicenseType.Experimental };

            Tools = new List<ITool>();
            Tools.Add(new WelcomeTool());
            Tools.Add(new SwatchTool());
            Tools.Add(new LicenseTool());
            Tools.Add(new WelcomeTool());
            Tools.Add(new WelcomeTool());
            Tools.Add(new WelcomeTool());
            Tools.Add(new WelcomeTool());
            Tools.Add(new WelcomeTool());
            Tools.Add(new WelcomeTool());

            foreach (var tool in Tools)
                tool.Initialize(_dataModel, _licenseData);

        }
    }
}
