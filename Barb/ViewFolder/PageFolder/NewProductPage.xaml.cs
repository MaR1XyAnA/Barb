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
    public partial class NewProductPage : Page
    {
        public NewProductPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new HypperXEntities();
            NameManufacturerComboBox.ItemsSource = AppConnectClass.DataBase.ProizvoditelTable.ToList();
        }

        private void NewProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameProductTextBox.Text == "" || NameManufacturerComboBox.Text == "") { MessageBox.Show("ПОЛЕ НЕ ДОЛЖНО БЫТЬ ПУСТЫМ"); }
            else
            {
                if (AppConnectClass.DataBase.MaterialTible.Count(Data => Data.Name == NameProductTextBox.Text) > 0) { MessageBox.Show("ДАННЫЙ ПРОДУКТ УЖЕ СУШЕСТВУЕТ"); }
                else
                {
                    try
                    {
                        MaterialTible materialTible = new MaterialTible()
                        { Name = NameProductTextBox.Text, ProizvoditelTable = NameManufacturerComboBox.SelectedItem as ProizvoditelTable };
                        AppConnectClass.DataBase.MaterialTible.Add(materialTible);
                        AppConnectClass.DataBase.SaveChanges();
                        NameProductTextBox.Text = "";
                        NameManufacturerComboBox.Text = "";
                        MessageBox.Show("НОВЫЙ ТОВАР ДОБАВЛЕН");
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.ToString(), "ERROR Exception"); }
                }
            }
        }
    }
}
