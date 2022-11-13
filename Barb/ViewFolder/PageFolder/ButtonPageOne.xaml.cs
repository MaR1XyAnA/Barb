using System.Windows;
using System.Windows.Controls;

namespace Barb.ViewFolder.PageFolder
{
    public partial class ButtonPageOne : Page
    {
        public ButtonPageOne()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            ClassFolder.FrameClass.FrameMenu.Navigate(new ButtonPageTho());
        }
    }
}
