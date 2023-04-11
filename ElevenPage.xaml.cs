using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{
    public partial class ElevenPage : Page
    {
        private billsTableAdapter bills = new billsTableAdapter();
        private CustomerTableAdapter customer = new CustomerTableAdapter();
        private int BillID;
        private int UserID;
        private DateTime dateTime;
        public ElevenPage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = bills.GetData();
            UserIDBox.ItemsSource = customer.GetData();
            UserIDBox.DisplayMemberPath = "last_name";
            EditBtn.IsEnabled = false;
        }

        private void DataGridDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditBtn.IsEnabled = true;
            EditBtn.Background.Opacity = 100;

            if (DataGridDB.SelectedItem as DataRowView != null)
            {
                BillID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                PlacedDate.SelectedDate = (DateTime?)(DataGridDB.SelectedItem as DataRowView).Row[2];
                UserIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[3];
                BillAmount.Text = ((DataGridDB.SelectedItem as DataRowView).Row[4]).ToString();
                BillText.Text = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
            }
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checkLandN.IsMatch(BillText.Text) & UserID > 0 & dateTime.DayOfYear > 0 & BillAmount.Text != ""
                    & Convert.ToDecimal(BillAmount.Text) > 0)
                {
                    bills.InsertQuery(BillText.Text, dateTime.ToString(), UserID, 
                        Convert.ToDecimal(BillAmount.Text));
                    DataGridDB.ItemsSource = bills.GetData();
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
                if (MainWindow.checkLandN.IsMatch(BillText.Text) & UserID > 0 & dateTime.DayOfYear > 0 & BillAmount.Text != ""
                    & Convert.ToDecimal(BillAmount.Text) > 0)
                {
                    bills.UpdateQuery(BillText.Text, dateTime.ToString(), 
                        UserID, Convert.ToDecimal(BillAmount.Text), BillID);
                    DataGridDB.ItemsSource = bills.GetData();
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

        private void OrderItemIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserID = Convert.ToInt32((UserIDBox.SelectedItem as DataRowView).Row[0]);
        }
    }
}
