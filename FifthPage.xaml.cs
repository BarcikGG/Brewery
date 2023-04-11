using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{

    public partial class FifthPage : Page
    {
        private EmployeeTableAdapter employee = new EmployeeTableAdapter();
        private BreweryTableAdapter brewery = new BreweryTableAdapter();
        private int BreweryID;
        private int EmployeeID;
        public FifthPage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = employee.GetData();
            BreweryIDBox.ItemsSource = brewery.GetData();
            BreweryIDBox.DisplayMemberPath = "Brewery_name";
            EditBtn.IsEnabled = false;
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checktext.IsMatch(Name.Text) & 
                    MainWindow.checktext.IsMatch(Surname.Text) & 
                    MainWindow.checktext.IsMatch(Position.Text)
                    & Salary.Text != "" & BreweryID > 0 & Convert.ToDecimal(Salary.Text) > 0)
                {
                    employee.InsertQuery(Name.Text, Surname.Text, Position.Text,
                Convert.ToDecimal(Salary.Text), BreweryID);
                    DataGridDB.ItemsSource = employee.GetData();
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
                if (MainWindow.checktext.IsMatch(Name.Text) &
                    MainWindow.checktext.IsMatch(Surname.Text) &
                    MainWindow.checktext.IsMatch(Position.Text)
                    & Salary.Text != "" & BreweryID > 0 & Convert.ToDecimal(Salary.Text) > 0)
                {
                    employee.UpdateQuery(Name.Text, Surname.Text, Position.Text,
                Convert.ToDecimal(Salary.Text), BreweryID, EmployeeID);
                    DataGridDB.ItemsSource = employee.GetData();
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

        private void BreweryIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BreweryID = Convert.ToInt32((BreweryIDBox.SelectedItem as DataRowView).Row[0]);
        }

        private void DataGridDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditBtn.IsEnabled = true;
            EditBtn.Background.Opacity = 100;

            if (DataGridDB.SelectedItem != null)
            {
                EmployeeID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                Name.Text = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
                Surname.Text = (DataGridDB.SelectedItem as DataRowView).Row[2].ToString();
                Position.Text = (DataGridDB.SelectedItem as DataRowView).Row[3].ToString();
                Salary.Text = (DataGridDB.SelectedItem as DataRowView).Row[4].ToString();
                BreweryIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[5].ToString();
            }
        }
    }
}
