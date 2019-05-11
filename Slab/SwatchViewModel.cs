using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab
{
    public class SwatchViewModel : IRequiresGLDataContext, INotifyPropertyChanged
    {
        public DelegateCommand ApplyBtn_OnClick { get; private set; }

        private GLDataContext _glDataContext;

        private double _red;
        public double Red { get { return _red; } set { _red = value; NotifyPropertyChanged(nameof(Red)); } }

        private double _green;
        public double Green { get { return _green; } set { _green = value; NotifyPropertyChanged(nameof(Green)); } }

        private double _blue;
        public double Blue { get { return _blue; } set { _blue = value; NotifyPropertyChanged(nameof(Blue)); } }

        public SwatchViewModel()
        {
            ApplyBtn_OnClick = new DelegateCommand(OnApply);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Initialize(GLDataContext glDataContext)
        {
            _glDataContext = glDataContext;
            _red = _glDataContext.BackgroundColor.Red;
            _blue = _glDataContext.BackgroundColor.Blue;
            _green = _glDataContext.BackgroundColor.Green;
        }

        public void RefreshSwatch()
        {
            _glDataContext.RequestInvalidate();
        }

        public void UpdateBackground()
        {
            _glDataContext.BackgroundColor.Red = (float)Red;
            _glDataContext.BackgroundColor.Blue = (float)Blue;
            _glDataContext.BackgroundColor.Green = (float)Green;
        }

        public void OnApply()
        {
            UpdateBackground();
            RefreshSwatch();
        }
    }
}
