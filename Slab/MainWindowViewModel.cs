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
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly GLDataContext _glDataContext;
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

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnWindowLoaded()
        {
            SelectedTool = Tools.First();
        }

        public void OnSelectedToolChanged()
        {
            // instantiate its view and view model using the activator
            var viewModel = Activator.CreateInstance(SelectedTool.ViewModelType);
            var view = Activator.CreateInstance(SelectedTool.ViewType);
            var usrCtrl = view as UserControl;
            if (viewModel == null || usrCtrl == null)
                return;

            InitVMWithGlobalDeps(viewModel);

            // bind the view data context to the view model
            usrCtrl.DataContext = viewModel;

            // raise request load tool and pass in the view as an argument to the event
            RequestLoadTool?.Invoke(this, usrCtrl);
        }

        private void InitVMWithGlobalDeps(object viewModel)
        {
            var viewModelAsIGLWidget = viewModel as IRequiresGLDataContext;
            if (viewModelAsIGLWidget != null)
                viewModelAsIGLWidget.Initialize(_glDataContext);
        }

        public event EventHandler<UserControl> RequestLoadTool;
        public event PropertyChangedEventHandler PropertyChanged;

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


            Tools = new List<ITool>();
            Tools.Add(new WelcomeTool());
            Tools.Add(new SwatchTool());
            Tools.Add(new WelcomeTool());
            Tools.Add(new WelcomeTool());
            Tools.Add(new WelcomeTool());
            Tools.Add(new WelcomeTool());
            Tools.Add(new WelcomeTool());
            Tools.Add(new WelcomeTool());
        }

    }
}
