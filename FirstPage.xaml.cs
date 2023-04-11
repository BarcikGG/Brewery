using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace FinalWPF
{
    public partial class FirstPage : Page
    {
        private BeerTableAdapter beer = new BeerTableAdapter();
        private BreweryTableAdapter brewery = new BreweryTableAdapter();
        private int BreweryID;
        private int BeerID;
        public FirstPage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = beer.GetData();
            BreweryIDBox.ItemsSource = brewery.GetData();
            BreweryIDBox.DisplayMemberPath = "Brewery_name";
            EditBtn.IsEnabled = false;
        }

        private void BreweryIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BreweryID = Convert.ToInt32((BreweryIDBox.SelectedItem as DataRowView).Row[0]);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checkLandN.IsMatch(BeerName.Text) & MainWindow.checktext.IsMatch(BeerType.Text) 
                    & Alchohol.Text != ""
                    & Volume.Text != "" & Price.Text != "" & BreweryID > 0 & 
                    Convert.ToInt32(Volume.Text) > 0 & Convert.ToInt32(Price.Text) > 0 & Convert.ToInt32(Alchohol.Text) > 0)
                {
                    beer.InsertQuery(BeerName.Text.ToString(), BeerType.Text.ToString(), Convert.ToDecimal(Alchohol.Text),
                Convert.ToInt32(Volume.Text), Convert.ToDecimal(Price.Text), BreweryID);
                    DataGridDB.ItemsSource = beer.GetData();
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

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checkLandN.IsMatch(BeerName.Text) & MainWindow.checktext.IsMatch(BeerType.Text)
                    & Alchohol.Text != ""
                    & Volume.Text != "" & Price.Text != "" & BreweryID > 0 &
                    Convert.ToInt32(Volume.Text) > 0 & Convert.ToInt32(Price.Text) > 0 & Convert.ToInt32(Alchohol.Text) > 0)
                {
                    beer.UpdateQuery(BeerName.Text.ToString(), BeerType.Text.ToString(), Convert.ToDecimal(Alchohol.Text),
                        Convert.ToInt32(Volume.Text), Convert.ToDecimal(Price.Text), BreweryID, BeerID);
                    DataGridDB.ItemsSource = beer.GetData();
                    EditBtn.IsEnabled = false;
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

            if (DataGridDB.SelectedItem != null)
            {
                BeerID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                BeerName.Text = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
                BeerType.Text = (DataGridDB.SelectedItem as DataRowView).Row[2].ToString();
                Alchohol.Text = (DataGridDB.SelectedItem as DataRowView).Row[3].ToString();
                Volume.Text = (DataGridDB.SelectedItem as DataRowView).Row[4].ToString();
                Price.Text = (DataGridDB.SelectedItem as DataRowView).Row[5].ToString();
                BreweryIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[6].ToString();
            }
        }
    }
}
