using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Slab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GLControl _glControl;
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            _viewModel.RequestLoadTool += _viewModel_RequestLoadTool;
            _viewModel.GLDataContext.RequestGLInvalidate += GLContext_RequestGLInvalidate;

            DataContext = _viewModel;
        }

        private void GLContext_RequestGLInvalidate(object sender, EventArgs e)
        {
            this._glControl.Invalidate();
        }

        private void _viewModel_RequestLoadTool(object sender, System.Windows.Controls.UserControl e)
        {
            if (e == null)
                return;

            CommandPane_StkPnl.Children.Clear();
            CommandPane_StkPnl.Children.Add(e);
        }

        private void WindowsFormsHost_Initialized(object sender, EventArgs e)
        {

            var flags = GraphicsContextFlags.Default;
            _glControl = new GLControl(new GraphicsMode(32, 24), 2, 0, flags);
            _glControl.MakeCurrent();
            _glControl.Paint += GLControl_Paint;
            _glControl.Dock = DockStyle.Fill;
            (sender as WindowsFormsHost).Child = _glControl;
        }

        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(
                _viewModel.GLDataContext.BackgroundColor.Red,
                _viewModel.GLDataContext.BackgroundColor.Green,
                _viewModel.GLDataContext.BackgroundColor.Blue,
                1
            );
            GL.Clear(
                ClearBufferMask.ColorBufferBit |
                ClearBufferMask.DepthBufferBit |
                ClearBufferMask.StencilBufferBit
            );

            _glControl.SwapBuffers();
        }
    }
}
