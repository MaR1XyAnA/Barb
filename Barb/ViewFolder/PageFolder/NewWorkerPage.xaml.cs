using Barb.ClassFolder;
using Barb.ModelFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Barb.ViewFolder.PageFolder
{
    public partial class NewWorkerPage : Page
    {
        public NewWorkerPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new HypperXEntities();
        }

        private void NewWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameSNMWorkerTextBox.Text == "") { MessageBox.Show("ПОЛЕ НЕ ДОЛЖНО БЫТЬ ПУСТЫМ"); }
            else
            {
                if (AppConnectClass.DataBase.SotrudnikTable.Count(Data => Data.Name == NameSNMWorkerTextBox.Text) > 0) { MessageBox.Show("ДАННЫЙ СОТРУДНИК УЖЕ СУШЕСТВУЕТ"); }
                else
                {
                    try
                    {
                        SotrudnikTable sotrudnikTable = new SotrudnikTable()
                        { Name = NameSNMWorkerTextBox.Text};
                        AppConnectClass.DataBase.SotrudnikTable.Add(sotrudnikTable);
                        AppConnectClass.DataBase.SaveChanges();
                        NameSNMWorkerTextBox.Text = "";
                        MessageBox.Show("НОВЫЙ СОТРУДНИК ДОБАВЛЕН");
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.ToString(), "ERROR Exception"); }
                }
            }
        }
    }
}
