using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{

    public partial class TenPage : Page
    {
        private ReviewTableAdapter review = new ReviewTableAdapter();
        private Order_ItemTableAdapter order_Item = new Order_ItemTableAdapter();
        private int ReviewID;
        private DateTime dateTime;
        private int OrderItemID;
        public TenPage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = review.GetData();
            OrderItemIDBox.ItemsSource = order_Item.GetData();
            OrderItemIDBox.DisplayMemberPath = "order_id";
            EditBtn.IsEnabled = false;
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checktext.IsMatch(ReviewText.Text) & OrderItemID > 0 & dateTime.DayOfYear > 0)
                {
                    review.InsertQuery(ReviewText.Text, dateTime.ToString(), OrderItemID);
                    DataGridDB.ItemsSource = review.GetData();
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
                if (MainWindow.checktext.IsMatch(ReviewText.Text) & OrderItemID > 0 & dateTime.DayOfYear > 0)
                {
                    review.UpdateQuery(ReviewText.Text, dateTime.ToString(), OrderItemID, ReviewID);
                    DataGridDB.ItemsSource = review.GetData();
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
            OrderItemID = Convert.ToInt32((OrderItemIDBox.SelectedItem as DataRowView).Row[0]);
        }

        private void DataGridDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditBtn.IsEnabled = true;
            EditBtn.Background.Opacity = 100;

            if (DataGridDB.SelectedItem as DataRowView != null)
            {
                ReviewID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                PlacedDate.SelectedDate = (DateTime?)(DataGridDB.SelectedItem as DataRowView).Row[2];
                OrderItemIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[3];
                ReviewText.Text = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
            }
        }
    }
}
