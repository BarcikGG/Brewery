using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{

    public partial class NinePage : Page
    {
        private ProductionTableAdapter production = new ProductionTableAdapter();
        private BeerTableAdapter beer = new BeerTableAdapter();
        private BreweryTableAdapter brewery = new BreweryTableAdapter();
        private int ProductionID;
        private int BeerID;
        private int BreweryID;
        private DateTime dateTime;
        public NinePage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = production.GetData();

            BreweryIDBox.ItemsSource = brewery.GetData();
            BreweryIDBox.DisplayMemberPath = "Brewery_name";
            BeerIDBox.ItemsSource = beer.GetData();
            BeerIDBox.DisplayMemberPath = "Beer_name";
            EditBtn.IsEnabled = false;
        }

        private void ProductionDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dateTime = (DateTime)ProductionDate.SelectedDate;
        }

        private void EditBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (Quantity.Text != ""& Convert.ToInt32(Quantity.Text) > 0 & BeerID > 0 & BreweryID > 0 & dateTime.DayOfYear > 0)
                {
                    production.UpdateQuery(BeerID, BreweryID, dateTime.ToString(), 
                        Convert.ToInt32(Quantity.Text), ProductionID);
                    DataGridDB.ItemsSource = production.GetData();
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

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (Quantity.Text != "" & Convert.ToInt32(Quantity.Text) > 0 & BeerID > 0 & BreweryID > 0 & dateTime.DayOfYear > 0)
                {
                    production.InsertQuery(BeerID, BreweryID, dateTime.ToString(), Convert.ToInt32(Quantity.Text));
                    DataGridDB.ItemsSource = production.GetData();
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

        private void BeerIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BeerID = Convert.ToInt32((BeerIDBox.SelectedItem as DataRowView).Row[0]);
        }

        private void BreweryIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BreweryID = Convert.ToInt32((BreweryIDBox.SelectedItem as DataRowView).Row[0]);
        }

        private void DataGridDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditBtn.IsEnabled = true;
            EditBtn.Background.Opacity = 100;

            if (DataGridDB.SelectedItem as DataRowView != null)
            {
                ProductionID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                BeerIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
                BreweryIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[2].ToString();
                ProductionDate.SelectedDate = Convert.ToDateTime((DataGridDB.SelectedItem as DataRowView).Row[3]);
                Quantity.Text = (DataGridDB.SelectedItem as DataRowView).Row[4].ToString();
            }
        }
    }
}
