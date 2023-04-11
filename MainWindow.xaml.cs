using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using FinalWPF.BeerDBDataSetTableAdapters;

namespace FinalWPF
{
    public partial class MainWindow : Window
    {
        public static Regex checktext = new Regex("^[a-zA-Zа-яА-Я]+$");
        public static Regex checkLandN = new Regex(@"^[\p{L}\p{N}]+$");
        private List<Page> pages = new List<Page>();
        private List<string> TableNames = new List<string>();
        private int index = 0;

        private BeerTableAdapter beer = new BeerTableAdapter();
        private Beer_IngredientTableAdapter beer_Ingredient = new Beer_IngredientTableAdapter();
        private BreweryTableAdapter brewery = new BreweryTableAdapter();
        private CustomerTableAdapter customer = new CustomerTableAdapter();
        private EmployeeTableAdapter employee = new EmployeeTableAdapter();
        private IngredientTableAdapter ingredient = new IngredientTableAdapter();
        private Order_ItemTableAdapter order_item = new Order_ItemTableAdapter();
        private OrdersTableAdapter orders = new OrdersTableAdapter();
        private ProductionTableAdapter production = new ProductionTableAdapter();
        private ReviewTableAdapter review = new ReviewTableAdapter();
        private billsTableAdapter bills = new billsTableAdapter();
        private usersTableAdapter users = new usersTableAdapter();
        private rolesTableAdapter roles = new rolesTableAdapter();
        private bill_itemTableAdapter bill_Item = new bill_itemTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
            pages.Add(new FirstPage());
            pages.Add(new SecondPage());
            pages.Add(new ThirdPage());
            pages.Add(new FourthPage());
            pages.Add(new FifthPage());
            pages.Add(new SixthPage());
            pages.Add(new SeventhPage());
            pages.Add(new EightPage());
            pages.Add(new NinePage());
            pages.Add(new TenPage());
            pages.Add(new ElevenPage());
            pages.Add(new TwelvePage());
            pages.Add(new RolePage());
            pages.Add(new Bill_itemPage());

            TableNames.Add("Beer");
            TableNames.Add("Beer Ingredient");
            TableNames.Add("Brewery");
            TableNames.Add("Customers");
            TableNames.Add("Employees");
            TableNames.Add("Ingredients");
            TableNames.Add("Order item");
            TableNames.Add( "Orders");
            TableNames.Add("Productions");
            TableNames.Add("Reviews");
            TableNames.Add("Bills");
            TableNames.Add("Users");
            TableNames.Add("Roles");
            TableNames.Add("Bill items");

            ShowPage(index);
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var page = pages.ElementAt(index);
            var dataGrid = (DataGrid)page.FindName("DataGridDB");

            if (dataGrid.SelectedItem != null)
            {
                int id = Convert.ToInt32((dataGrid.SelectedItem as DataRowView).Row[0]);
                DeleteDB(index, id, dataGrid);
            }
            else MessageBox.Show("Запись не выбрана");
        }

        private void PreviousBtn_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                ShowPage(index);
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (index < pages.Count - 1)
            {
                index++;
                ShowPage(index);
            }
        }

        private void ShowPage(int index)
        {
            PageFrame.Content = pages.ElementAt(index);
            TableName.Text = "Table: " + TableNames.ElementAt(index);
        }

        private void DeleteDB(int index, int id, DataGrid dataGrid) 
        {
            switch (index)
            {
                case 0:
                    beer.DeleteQuery(id);
                    dataGrid.ItemsSource = beer.GetData();
                    break;
                case 1:
                    beer_Ingredient.DeleteQuery(id);
                    dataGrid.ItemsSource = beer_Ingredient.GetData();
                    break;
                case 2:
                    brewery.DeleteQuery(id);
                    dataGrid.ItemsSource = brewery.GetData();
                    break;
                case 3:
                    customer.DeleteQuery(id);
                    dataGrid.ItemsSource = customer.GetData();
                    break;
                case 4:
                    employee.DeleteQuery(id);
                    dataGrid.ItemsSource = employee.GetData();
                    break;
                case 5:
                    ingredient.DeleteQuery(id);
                    dataGrid.ItemsSource = ingredient.GetData();
                    break;
                case 6:
                    order_item.DeleteQuery(id);
                    dataGrid.ItemsSource = order_item.GetData();
                    break;
                case 7:
                    orders.DeleteQuery(id);
                    dataGrid.ItemsSource = orders.GetData();
                    break;
                case 8:
                    production.DeleteQuery(id);
                    dataGrid.ItemsSource = production.GetData();
                    break;
                case 9:
                    review.DeleteQuery(id);
                    dataGrid.ItemsSource = review.GetData();
                    break;
                case 10:
                    bills.DeleteQuery(id);
                    dataGrid.ItemsSource = bills.GetData();
                    break;
                case 11:
                    users.DeleteQuery(id);
                    dataGrid.ItemsSource = users.GetData();
                    break;
                case 12:
                    roles.DeleteQuery(id);
                    dataGrid.ItemsSource = roles.GetData();
                    break;
                case 13:
                    bill_Item.DeleteQuery(id);
                    dataGrid.ItemsSource = bill_Item.GetData();
                    break;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }
    }
}
