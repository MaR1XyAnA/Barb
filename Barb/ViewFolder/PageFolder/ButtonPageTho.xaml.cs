using System.Windows;
using System.Windows.Controls;

namespace Barb.ViewFolder.PageFolder
{
    public partial class ButtonPageTho : Page
    {
        public ButtonPageTho()
        {
            InitializeComponent();
        }

        private void NewProductsButton_Click(object sender, RoutedEventArgs e)
        {
            ClassFolder.FrameClass.FrameTitle.Navigate(new NewProductPage());
        }

        private void NewWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            ClassFolder.FrameClass.FrameTitle.Navigate(new NewWorkerPage());
        }

        private void NewManufacturerButton_Click(object sender, RoutedEventArgs e)
        {
            ClassFolder.FrameClass.FrameTitle.Navigate(new NewManufacturerPage());
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            ClassFolder.FrameClass.FrameTitle.Navigate(new AccountingPage());
        }

        private void IntroductionAccountingButton_Click(object sender, RoutedEventArgs e)
        {
            ClassFolder.FrameClass.FrameTitle.Navigate(new NewAccountingPage());
        }

        private void ReportPeriodButton_Click(object sender, RoutedEventArgs e)
        {
            ClassFolder.FrameClass.FrameTitle.Navigate(new ReportPeriodPage());
        }
    }
}
