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
        public MainWindowViewModel()
        {
            Window_OnLoaded = new DelegateCommand(OnWindowLoaded);

            var glDataContext = new GLDataContext()
            {
                BackgroundColor = new Color()
                {
                    Red = 0,
                    Blue = 0,
                    Green = 0
                }
            };
            var dataModel = new DataModel();
            _serviceContainer = new ServiceContainer();
            _canvasService = _serviceContainer.CanvasService;
            _canvasService.GLDataContext = glDataContext;
            _serviceContainer.DataModelService.DataModel = dataModel;
            var licenseData = new LicenseData() { LicenseType = LicenseType.Experimental };
            _serviceContainer.LicenseService.LicenseData = licenseData;

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
                tool.Initialize(_serviceContainer);

            _isPropertiesPaneExpanded = true;
            _onPropertiesPaneExpandCommand = new DelegateCommand(OnPropertiesPaneExpand);
            _onPropertiesPaneCollapseCommand = new DelegateCommand(OnPropertiesPaneCollapse);
        }

        private void OnPropertiesPaneCollapse()
        {
            IsPropertiesPaneExpanded = false;
        }

        private void OnPropertiesPaneExpand()
        {
            IsPropertiesPaneExpanded = true;
        }

        private readonly IServiceContainer _serviceContainer;
        private readonly Services.ICanvasService _canvasService;
        public Services.ICanvasService CanvasService { get { return _canvasService; } }

        private readonly DelegateCommand _onPropertiesPaneCollapseCommand;
        private readonly DelegateCommand _onPropertiesPaneExpandCommand;

        public DelegateCommand OnPropertiesPaneCollapseCommand => _onPropertiesPaneCollapseCommand;
        public DelegateCommand OnPropertiesPaneExpandCommand => _onPropertiesPaneExpandCommand;

        private bool _isPropertiesPaneExpanded;
        public bool IsPropertiesPaneExpanded
        {
            get
            {
                return _isPropertiesPaneExpanded;
            }
            set
            {
                _isPropertiesPaneExpanded = value;
                NotifyPropertyChanged(nameof(IsPropertiesPaneExpanded));
                NotifyPropertyChanged(nameof(IsPropertiesPaneCollapsed));
            }
        }
        public bool IsPropertiesPaneCollapsed
        {
            get
            {
                return !_isPropertiesPaneExpanded;
            }
        }

        public bool IsToolSelected
        {
            get
            {
                return _selectedTool != null;
            }
        }


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
                    NotifyPropertyChanged(nameof(IsToolSelected));
                }
            }
        }

        public DelegateCommand Window_OnLoaded { get; private set; }

        public void OnWindowLoaded()
        {
            SelectedTool = Tools[0];
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

            vm.Initialize(_serviceContainer);

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
    }
}
