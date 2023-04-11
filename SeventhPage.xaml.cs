using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{

    public partial class SeventhPage : Page
    {
        private Order_ItemTableAdapter order_Item = new Order_ItemTableAdapter();
        private BeerTableAdapter beer = new BeerTableAdapter();
        private OrdersTableAdapter orders = new OrdersTableAdapter();

        private int Order_itemID;
        private int Order_orderID;
        private int BeerID;
        public SeventhPage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = order_Item.GetData();

            OrderIDBox.ItemsSource = orders.GetData();
            OrderIDBox.DisplayMemberPath = "date_placed";
            BeerIDBox.ItemsSource = beer.GetData();
            BeerIDBox.DisplayMemberPath = "Beer_name";
            EditBtn.IsEnabled = false;
        }

        private void DataGridDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditBtn.IsEnabled = true;
            EditBtn.Background.Opacity = 100;

            if (DataGridDB.SelectedItem as DataRowView != null)
            {
                Order_itemID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                OrderIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
                BeerIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[2].ToString();
                Quantity.Text = (DataGridDB.SelectedItem as DataRowView).Row[3].ToString();
            }
        }

        private void BeerIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BeerID = Convert.ToInt32((BeerIDBox.SelectedItem as DataRowView).Row[0]);
        }

        private void OrderIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Order_itemID = Convert.ToInt32((OrderIDBox.SelectedItem as DataRowView).Row[0]);
        }

        private void EditBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (Quantity.Text != "" & Convert.ToInt32(Quantity.Text) > 0 & BeerID > 0 & Order_itemID > 0)
                {
                    order_Item.UpdateQuery(Order_itemID, BeerID, Convert.ToInt32(Quantity.Text), Order_itemID);
                    DataGridDB.ItemsSource = order_Item.GetData();
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
                if (Quantity.Text != "" & Convert.ToInt32(Quantity.Text) > 0 & BeerID > 0 & Order_itemID > 0)
                {
                    order_Item.InsertQuery(Order_itemID, BeerID,  Convert.ToInt32(Quantity.Text));
                    DataGridDB.ItemsSource = order_Item.GetData();
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
    }
}
