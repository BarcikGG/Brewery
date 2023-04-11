using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{
    public partial class ThirdPage : Page
    {
        private BreweryTableAdapter brewery = new BreweryTableAdapter();
        private int BreweryID;
        Regex phoneCheck = new Regex(@"^\d{10}$");
        Regex mailCheck = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public ThirdPage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = brewery.GetData();
            EditBtn.IsEnabled = false;
        }

        private void DataGridDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditBtn.IsEnabled = true;
            EditBtn.Background.Opacity = 100;

            if (DataGridDB.SelectedItem as DataRowView != null)
            {
                BreweryID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                BreweryName.Text = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
                BreweryAddress.Text = (DataGridDB.SelectedItem as DataRowView).Row[2].ToString();
                Phone.Text = (DataGridDB.SelectedItem as DataRowView).Row[3].ToString();
                Email.Text = (DataGridDB.SelectedItem as DataRowView).Row[4].ToString();
            }
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checktext.IsMatch(BreweryName.Text) & MainWindow.checktext.IsMatch(BreweryAddress.Text) 
                    & phoneCheck.IsMatch(Phone.Text)
                    & mailCheck.IsMatch(Email.Text))
                {
                    brewery.InsertQuery(BreweryName.Text, BreweryAddress.Text,
                        Phone.Text, Email.Text);
                    DataGridDB.ItemsSource = brewery.GetData();
                    EditBtn.IsEnabled = false;
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
                if (MainWindow.checktext.IsMatch(BreweryName.Text) & MainWindow.checktext.IsMatch(BreweryAddress.Text)
                    & phoneCheck.IsMatch(Phone.Text)
                    & mailCheck.IsMatch(Email.Text))
                {
                    brewery.UpdateQuery(BreweryName.Text, BreweryAddress.Text, 
                        Phone.Text, Email.Text, BreweryID);
                    DataGridDB.ItemsSource = brewery.GetData();
                    EditBtn.IsEnabled = false;
                }
                else MessageBox.Show("Не все поля заполнены");
            }
            catch
            {
                MessageBox.Show("В полях с числами должны быть цифры!");
            }
        }
    }
}
