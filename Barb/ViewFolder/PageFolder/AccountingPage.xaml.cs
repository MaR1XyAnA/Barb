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
    public partial class AccountingPage : Page
    {
        public AccountingPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new HypperXEntities();
            
            ListAccountingDataGrid.ItemsSource = AppConnectClass.DataBase.UcherTable.ToList();
            WorkerCobmaBox.ItemsSource = AppConnectClass.DataBase.SotrudnikTable.ToList();
        }

        private void WorkerCobmaBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int GetWorker = Convert.ToInt32(WorkerCobmaBox.SelectedValue);
            ListAccountingDataGrid.ItemsSource = AppConnectClass.DataBase.UcherTable.
                Where(data => data.IDSotrudnik == GetWorker).ToList();

            var GetCount = AppConnectClass.DataBase.UcherTable.
                Where(data => data.IDSotrudnik == GetWorker).Count();
            RecordTextBox.Text = GetCount.ToString();

            var GetSumma = AppConnectClass.DataBase.UcherTable.
                Where(data => data.IDSotrudnik == GetWorker).
                Select(Sweep => Sweep.Summa).Sum();
            SummaTextBox.Text = GetSumma.ToString();
        }
    }
}
