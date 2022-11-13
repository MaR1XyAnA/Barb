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
    public partial class NewManufacturerPage : Page
    {
        public NewManufacturerPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new HypperXEntities();
        }

        private void NewManufacturerButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameManufacturerTextBox.Text == "") { MessageBox.Show("ПОЛЕ НЕ ДОЛЖНО БЫТЬ ПУСТЫМ"); }
            else
            {
                if(AppConnectClass.DataBase.ProizvoditelTable.Count(Data => Data.Name == NameManufacturerTextBox.Text) > 0) { MessageBox.Show("ДАННЫЙ ПРОИЗВОДИТЕЛЬ УЖЕ СУШЕСТВУЕТ"); }
                else
                {
                    try
                    {
                        ProizvoditelTable proizvoditelTable = new ProizvoditelTable()
                        {Name = NameManufacturerTextBox.Text};
                        AppConnectClass.DataBase.ProizvoditelTable.Add(proizvoditelTable);
                        AppConnectClass.DataBase.SaveChanges();
                        NameManufacturerTextBox.Text = "";
                        MessageBox.Show("НОВЫЙ ПРОИЗВОДИТЕЛЬ ДОБАВЛЕН");
                    }
                    catch (Exception ex)
                    {MessageBox.Show(ex.Message.ToString(), "ERROR Exception");}
                }
            }
        }
    }
}
