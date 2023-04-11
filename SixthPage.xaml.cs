using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{

    public partial class SixthPage : Page
    {
        private IngredientTableAdapter ingredient = new IngredientTableAdapter();
        private int IngrID;
        public SixthPage()
        {
            InitializeComponent();
            DataGridDB.ItemsSource = ingredient.GetData();
            EditBtn.IsEnabled = false;
        }

        private void EditBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (MainWindow.checktext.IsMatch(IngrName.Text) & 
                    MainWindow.checktext.IsMatch(UnitMeas.Text))
                {
                    ingredient.UpdateQuery(IngrName.Text, UnitMeas.Text, IngrID);
                    DataGridDB.ItemsSource = ingredient.GetData();
                    EditBtn.IsEnabled = false;
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
                if (MainWindow.checktext.IsMatch(IngrName.Text) & 
                    MainWindow.checktext.IsMatch(UnitMeas.Text))
                {
                    ingredient.InsertQuery(IngrName.Text, UnitMeas.Text);
                    DataGridDB.ItemsSource = ingredient.GetData();
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

            if (DataGridDB.SelectedItem as DataRowView != null)
            {
                IngrID = Convert.ToInt32((DataGridDB.SelectedItem as DataRowView).Row[0]);
                IngrName.Text = (DataGridDB.SelectedItem as DataRowView).Row[1].ToString();
                UnitMeas.Text = (DataGridDB.SelectedItem as DataRowView).Row[2].ToString();
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            List<ClassToImport> importList = JsonConverter.DeserializeObject<List<ClassToImport>>();
            foreach (var item in importList) 
            {
                ingredient.InsertQuery(item.ingredient_name, item.unit_of_meas);
            }
            DataGridDB.ItemsSource = null;
            DataGridDB.ItemsSource = ingredient.GetData();
        }
    }
}
