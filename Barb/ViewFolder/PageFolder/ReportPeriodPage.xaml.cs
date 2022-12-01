using Barb.ClassFolder;
using Barb.ModelFolder;
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

namespace Barb.ViewFolder.PageFolder
{
    public partial class ReportPeriodPage : Page
    {
        public ReportPeriodPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new HypperXEntities();
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            //string Getmessage = "";
            //if (string.IsNullOrWhiteSpace(StartDatePicker.Text))
            //    Getmessage += "Не указано начало периуда\n";
            //if (string.IsNullOrWhiteSpace(EndDatePicker.Text))
            //    Getmessage += " не указан конец периуда\n";
            //if (Getmessage != null)
            //{
            //    MessageBox.Show(Getmessage, "Пустые поля");
            //    Getmessage = null;
            //    return;
            //}

            var StartPeriod = (DateTime)StartDatePicker.SelectedDate;
            var EndPeriod = (DateTime)EndDatePicker.SelectedDate;

            var Sweep = AppConnectClass.DataBase.RequestWorker.Where
                (data => data.Datelspol >= StartPeriod && data.Datelspol <= EndPeriod).GroupBy
                (fluttershy => fluttershy.Name).Select
                (twilight => new {Сотрудник = twilight.Key, Сумма = twilight.Sum(jack => jack.Summa)})
                .OrderBy(pinc => pinc.Сотрудник);
            ListAccountingDataGrid.ItemsSource = Sweep.ToList();
        }
    }
}
