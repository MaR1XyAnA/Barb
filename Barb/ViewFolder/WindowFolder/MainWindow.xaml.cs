using Barb.ViewFolder.PageFolder;
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

namespace Barb.ViewFolder.WindowFolder
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConnectFrame();
            GetFrame();
        }
        public void ConnectFrame()
        {
            ClassFolder.FrameClass.FrameMenu = MenuFrame;
            ClassFolder.FrameClass.FrameTitle = MainFrame;
        }
        public void GetFrame()
        {
            MenuFrame.Navigate(new ButtonPageOne());
            MainFrame.Navigate(new StartPage());
        }
    }
}
