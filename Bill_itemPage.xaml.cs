using FinalWPF.BeerDBDataSetTableAdapters;
using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{
    public partial class Bill_itemPage : Page
    {
        private bill_itemTableAdapter bill_Item = new bill_itemTableAdapter();
        private billsTableAdapter bills = new billsTableAdapter();
        private BeerTableAdapter beer = new BeerTableAdapter();

        private int Bill_itemID;
        private int BeerID;
        private int BillID;
        public Bill_itemPage()
        {
            InitializeComponent();

            DataGridDB.ItemsSource = bill_Item.GetData();
            EditBtn.IsEnabled = false;

            BreweryIDBox.ItemsSource = bills.GetData();
            BreweryIDBox.DisplayMemberPath = "bill_date";
            BeerIDBox.ItemsSource = beer.GetData();
            BeerIDBox.DisplayMemberPath = "Beer_name";
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BillID > 0 & BeerID > 0)
                {
                    bill_Item.UpdateQuery(BillID, BeerID, Bill_itemID);
                    DataGridDB.ItemsSource = bill_Item.GetData();
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BillID > 0 & BeerID > 0)
                {
                    bill_Item.InsertQuery(BillID, BeerID);
                    DataGridDB.ItemsSource = bill_Item.GetData();
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
            BillID = Convert.ToInt32((BreweryIDBox.SelectedItem as DataRowView).Row[0]);
        }

        private void BeerIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BeerID = Convert.ToInt32((BeerIDBox.SelectedItem as DataRowView).Row[0]);
        }

        private void DataGridDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditBtn.IsEnabled = true;
            EditBtn.Background.Opacity = 100;

            if (DataGridDB.SelectedItem as DataRowView != null)
            {
                Bill_itemID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                BeerIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
                BreweryIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[2].ToString();
            }
        }
    }
}
