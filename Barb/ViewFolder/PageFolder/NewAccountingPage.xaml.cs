using Barb.ClassFolder;
using Barb.ModelFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Barb.ViewFolder.PageFolder
{
    public partial class NewAccountingPage : Page
    {
        public NewAccountingPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new HypperXEntities();
            NameWorkerComboBox.ItemsSource = AppConnectClass.DataBase.SotrudnikTable.ToList();
            NameProductComboBox.ItemsSource = AppConnectClass.DataBase.MaterialTible.ToList();
            NameProizvoditelComboBox.ItemsSource = AppConnectClass.DataBase.ProizvoditelTable.ToList();
        }

        private void NewAccountingButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameManufacturerTextBox.Text == "" || NameWorkerComboBox.Text == "" || NameProductComboBox.Text == "" || QuantityTextBox.Text == "" || PriceTextBox.Text == "") { MessageBox.Show("ПОЛЕ НЕ ДОЛЖНО БЫТЬ ПУСТЫМ"); }
            else
            {
                try
                {
                    int Price = Convert.ToInt32(PriceTextBox.Text);
                    int Quantity = Convert.ToInt32(QuantityTextBox.Text);
                    UcherTable ucherTable = new UcherTable()
                    {
                        Datelspol = (DateTime)NameManufacturerTextBox.SelectedDate,
                        SotrudnikTable = NameWorkerComboBox.SelectedItem as SotrudnikTable,
                        MaterialTible = NameProductComboBox.SelectedItem as MaterialTible,
                        Zana = Price,
                        Kolvo = Quantity
                    };
                    AppConnectClass.DataBase.UcherTable.Add(ucherTable);
                    AppConnectClass.DataBase.SaveChanges();
                    NameWorkerComboBox.Text = "";
                    NameProductComboBox.Text = "";
                    QuantityTextBox.Text = "";
                    PriceTextBox.Text = "";
                    MessageBox.Show("НОВЫЙ ТОВАР ДОБАВЛЕН");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.ToString(), "ERROR Exception"); }
            }
        }

        private void NameProizvoditelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Sweep = Convert.ToInt32(NameProizvoditelComboBox.SelectedValue);
            NameProductComboBox.ItemsSource = AppConnectClass.DataBase.MaterialTible.
                Where(data => data.IDProizvoditel == Sweep).ToList();
        }
    }
}
