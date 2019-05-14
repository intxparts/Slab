using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab.Tools
{
    public sealed class SwatchTool : BaseTool<Swatch, SwatchViewModel>
    {
        public SwatchTool() : base(name: "Swatch")
        {
        }

        public override bool IsEnabled
        {
            get
            {

                bool always = true;
                return always;
            }
        }

        public override bool IsVisible
        {
            get
            {
                bool always = true;
                return LicenseData != null && LicenseData.LicenseType == LicenseType.Experimental;
            }
        }
    }

    public sealed class SwatchViewModel : BaseViewModel
    {
        public DelegateCommand ApplyBtn_OnClick { get; private set; }

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

        protected override void OnInitialize()
        {
            _red = _glDataContext.BackgroundColor.Red;
            _blue = _glDataContext.BackgroundColor.Blue;
            _green = _glDataContext.BackgroundColor.Green;
        }

        private void RefreshSwatch()
        {
            _glDataContext.RequestInvalidate();
        }

        private void UpdateDataContext()
        {
            _glDataContext.BackgroundColor.Red = (float)Red;
            _glDataContext.BackgroundColor.Blue = (float)Blue;
            _glDataContext.BackgroundColor.Green = (float)Green;
        }

        private void OnApply()
        {
            UpdateDataContext();
            RefreshSwatch();
        }
    }
}
