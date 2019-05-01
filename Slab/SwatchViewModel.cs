using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab
{
    public class SwatchViewModel : IGLWidget, INotifyPropertyChanged
    {
        public DelegateCommand ApplyBtn_OnClick { get; private set; }
        public DelegateCommand SetBtn_OnClick { get; private set; }

        private OGContext _ogContext;

        private double _red;
        public double Red { get { return _red; } set { _red = value; NotifyPropertyChanged(nameof(Red)); } }

        private double _green;
        public double Green { get { return _green; } set { _green = value; NotifyPropertyChanged(nameof(Green)); } }

        private double _blue;
        public double Blue { get { return _blue; } set { _blue = value; NotifyPropertyChanged(nameof(Blue)); } }

        public SwatchViewModel()
        {
            ApplyBtn_OnClick = new DelegateCommand(OnApply);
            SetBtn_OnClick = new DelegateCommand(OnSet);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Initialize(OGContext context)
        {
            _ogContext = context;
            _red = _ogContext.Background.Red;
            _blue = _ogContext.Background.Blue;
            _green = _ogContext.Background.Green;
        }

        public void RefreshSwatch()
        {
            _ogContext.Invalidate();
        }

        public void UpdateBackground()
        {
            _ogContext.Background.Red = (float)Red;
            _ogContext.Background.Blue = (float)Blue;
            _ogContext.Background.Green = (float)Green;
        }

        public void OnApply()
        {
            UpdateBackground();
            RefreshSwatch();
        }

        public void OnSet()
        {
            UpdateBackground();
            RefreshSwatch();
            // Close();
        }
    }
}
