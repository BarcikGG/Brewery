using FinalWPF.BeerDBDataSetTableAdapters;
using System.Data;
using System;
using System.Windows.Controls;
using System.Windows;

namespace FinalWPF
{
    public partial class RolePage : Page
    {
        private rolesTableAdapter role = new rolesTableAdapter();
        private int RoleID;
        public RolePage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = role.GetData();
            EditBtn.IsEnabled = false;
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checktext.IsMatch(RoleName.Text))
                {
                    role.InsertQuery(RoleName.Text);
                    DataGridDB.ItemsSource = role.GetData();
                    EditBtn.IsEnabled = false;
                    EditBtn.Background.Opacity = 0;
                }
                else MessageBox.Show("Не все поля заполнены");
            }
            catch
            {
                MessageBox.Show("В полях с числами должны быть цифры!");
            }
        }

        private void EditBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checktext.IsMatch(RoleName.Text))
                {
                    role.UpdateQuery(RoleName.Text, RoleID);
                    DataGridDB.ItemsSource = role.GetData();
                    EditBtn.IsEnabled = false;
                    EditBtn.Background.Opacity = 0;
                }
                else MessageBox.Show("Не все поля заполнены");
            }
            catch
            {
                MessageBox.Show("В полях с числами должны быть цифры!");
            }
        }

        private void DataGridDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditBtn.IsEnabled = true;
            EditBtn.Background.Opacity = 100;

            if (DataGridDB.SelectedItem as DataRowView != null)
            {
                RoleID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                RoleName.Text = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
            }
        }
    }
}
