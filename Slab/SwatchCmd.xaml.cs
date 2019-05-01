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
using System.Windows.Shapes;

namespace Slab
{
    /// <summary>
    /// Interaction logic for SwatchCmd.xaml
    /// </summary>
    public partial class SwatchCmd : Window
    {
        public SwatchCmd()
        {
            InitializeComponent();
            DataContext = new SwatchViewModel();
        }
    }
}
