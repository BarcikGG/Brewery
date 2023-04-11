using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{

    public partial class FourthPage : Page
    {
        private CustomerTableAdapter customer = new CustomerTableAdapter();
        private int CustomerID;
        Regex mailCheck = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        public FourthPage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = customer.GetData();
            EditBtn.IsEnabled = false;
        }

        private void DataGridDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditBtn.IsEnabled = true;
            EditBtn.Background.Opacity = 100;

            if (DataGridDB.SelectedItem != null)
            {
                CustomerID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                Name.Text = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
                Surname.Text = (DataGridDB.SelectedItem as DataRowView).Row[2].ToString();
                Email.Text = (DataGridDB.SelectedItem as DataRowView).Row[3].ToString();
            }
        }

        private void EditBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checktext.IsMatch(Name.Text) & 
                    MainWindow.checktext.IsMatch(Surname.Text) & mailCheck.IsMatch(Email.Text))
                {
                    customer.UpdateQuery(Name.Text, Surname.Text,
                        Email.Text, CustomerID);
                    DataGridDB.ItemsSource = customer.GetData();
                    EditBtn.IsEnabled = false;
                }
                else MessageBox.Show("Не все поля заполнены");
            }
            catch
            {
                MessageBox.Show("В полях с числами должны быть цифры!");
            }
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checktext.IsMatch(Name.Text) &
                    MainWindow.checktext.IsMatch(Surname.Text) & mailCheck.IsMatch(Email.Text))
                {
                    customer.InsertQuery(Name.Text, Surname.Text,
                        Email.Text);
                    DataGridDB.ItemsSource = customer.GetData();
                    EditBtn.IsEnabled = false;
                }
                else MessageBox.Show("Не все поля заполнены");
            }
            catch
            {
                MessageBox.Show("В полях с числами должны быть цифры!");
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            List<ClassToImportCustomer> importList = JsonConverter.DeserializeObject<List<ClassToImportCustomer>>();
            foreach (var item in importList)
            {
                customer.InsertQuery(item.first_name, item.last_name, item.email);
            }
            DataGridDB.ItemsSource = null;
            DataGridDB.ItemsSource = customer.GetData();
        }
    }
}
