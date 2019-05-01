using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Slab
{
    /// <summary>
    /// Interaction logic for Swatch.xaml
    /// </summary>
    public partial class Swatch : UserControl
    {
        public Swatch()
        {
            InitializeComponent();
            // todo - automatically register viewmodels with their views
            DataContext = new SwatchViewModel();
        }
    }
}
