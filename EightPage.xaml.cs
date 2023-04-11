using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{

    public partial class EightPage : Page
    {
        private OrdersTableAdapter orders = new OrdersTableAdapter();
        private CustomerTableAdapter customer = new CustomerTableAdapter();
        private int OrderID;
        private int CustomerID;
        private DateTime dateTime;
        public EightPage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = orders.GetData();
            CustomerIDBox.ItemsSource = customer.GetData();
            CustomerIDBox.DisplayMemberPath = "last_name";
            EditBtn.IsEnabled = false;
        }

        private void DataGridDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditBtn.IsEnabled = true;
            EditBtn.Background.Opacity = 100;

            if (DataGridDB.SelectedItem != null)
            {
                OrderID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                CustomerIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
                PlacedDate.SelectedDate = Convert.ToDateTime((DataGridDB.SelectedItem as DataRowView).Row[2]);
                OrderStatus.Text = (DataGridDB.SelectedItem as DataRowView).Row[3].ToString();
            }
        }

        private void EditBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checktext.IsMatch(OrderStatus.Text) & CustomerID > 0 & dateTime.DayOfYear > 0)
                {
                    orders.UpdateQuery(CustomerID, dateTime.ToString(), OrderStatus.Text, OrderID);
                    DataGridDB.ItemsSource = orders.GetData();
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
                if (MainWindow.checktext.IsMatch(OrderStatus.Text) & CustomerID > 0 & dateTime.DayOfYear > 0)
                {
                    orders.InsertQuery(CustomerID, dateTime.ToString(), OrderStatus.Text);
                    DataGridDB.ItemsSource = orders.GetData();
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

        private void PlacedDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dateTime = (DateTime)PlacedDate.SelectedDate;
        }

        private void CustomerIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomerID = Convert.ToInt32((CustomerIDBox.SelectedItem as DataRowView).Row[0]);
        }
    }
}
