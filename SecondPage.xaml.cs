using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{
    public partial class SecondPage : Page
    {
        private Beer_IngredientTableAdapter beer_Ingredient = new Beer_IngredientTableAdapter();
        private IngredientTableAdapter ingredient = new IngredientTableAdapter();
        private BeerTableAdapter beer = new BeerTableAdapter();
        private int Beer_ingrID;
        private int IngredientID;
        private int BeerID;
        public SecondPage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = beer_Ingredient.GetData();
            IngredientIDBox.ItemsSource = ingredient.GetData();
            IngredientIDBox.DisplayMemberPath = "Ingredient_name";
            BeerIDBox.ItemsSource = beer.GetData();
            BeerIDBox.DisplayMemberPath = "Beer_name";
            EditBtn.IsEnabled = false;
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (Quantity.Text != "" & BeerID > 0 & IngredientID > 0
                    & Convert.ToInt32(Quantity.Text) > 0)
                {
                    beer_Ingredient.InsertQuery(BeerID, IngredientID, Convert.ToInt32(Quantity.Text));
                    DataGridDB.ItemsSource = beer_Ingredient.GetData();
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
                if (Quantity.Text != "" & BeerID > 0 & IngredientID > 0
                    & Convert.ToInt32(Quantity.Text) > 0)
                {
                    beer_Ingredient.UpdateQuery(BeerID, IngredientID, Convert.ToInt32(Quantity.Text), Beer_ingrID);
                    DataGridDB.ItemsSource = beer_Ingredient.GetData();
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

        private void DataGridDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditBtn.IsEnabled = true;
            EditBtn.Background.Opacity = 100;

            if (DataGridDB.SelectedItem as DataRowView != null)
            {
                Beer_ingrID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                BeerIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
                IngredientIDBox.SelectedItem = (DataGridDB.SelectedItem as DataRowView).Row[2].ToString();
                Quantity.Text = (DataGridDB.SelectedItem as DataRowView).Row[3].ToString();
            }
        }

        private void BeerIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BeerID = Convert.ToInt32((BeerIDBox.SelectedItem as DataRowView).Row[0]);
        }

        private void IngredientIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IngredientID = Convert.ToInt32((IngredientIDBox.SelectedItem as DataRowView).Row[0]);
        }
    }
}
