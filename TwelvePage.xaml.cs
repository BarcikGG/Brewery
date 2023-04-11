using FinalWPF.BeerDBDataSetTableAdapters;
using System.Data;
using System;
using System.Windows.Controls;
using System.Windows;

namespace FinalWPF
{
    public partial class TwelvePage : Page
    {
        private usersTableAdapter users = new usersTableAdapter();
        private rolesTableAdapter role = new rolesTableAdapter();
        private int RoleID;
        private int UserID;
        public TwelvePage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = users.GetData();
            RoleIDBox.ItemsSource = role.GetData();
            RoleIDBox.DisplayMemberPath = "role_name";
            EditBtn.IsEnabled = false;
        }

        private void RoleIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RoleID = Convert.ToInt32((RoleIDBox.SelectedItem as DataRowView).Row[0]);
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checkLandN.IsMatch(Login.Text) 
                    & MainWindow.checkLandN.IsMatch(Password.Password) & RoleID > 0)
                {
                    users.InsertQuery(Login.Text, Password.Password, RoleID);
                    DataGridDB.ItemsSource = users.GetData();
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
                if (MainWindow.checkLandN.IsMatch(Login.Text)
                    & MainWindow.checkLandN.IsMatch(Password.Password) & RoleID > 0)
                {
                    users.UpdateQuery(Login.Text, Password.Password, RoleID, UserID);
                    DataGridDB.ItemsSource = users.GetData();
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
                UserID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                Login.Text = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
                Password.Password = (DataGridDB.SelectedItem as DataRowView).Row[2].ToString();
                RoleIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[3].ToString();
            }
        }
    }
}
