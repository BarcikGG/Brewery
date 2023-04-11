using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{
    public partial class BillsPage : Page
    {
        private billsTableAdapter bills = new billsTableAdapter();
        private BeerTableAdapter beer = new BeerTableAdapter();
        private usersTableAdapter users = new usersTableAdapter();
        private bill_itemTableAdapter bill_Item = new bill_itemTableAdapter();
        
        private List<Bill> goods = new List<Bill>();
        private List<int> bills_itemsID = new List<int>();
        private List<int> beers_itemsID = new List<int>();

        private int BillID;
        private int Bill_itemID;
        private int UserID;
        
        private string UserName;
        private string Date;
        private string Amount;
        private string Path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public BillsPage()
        {
            InitializeComponent();
            BillInfoBlock.Text = "Сотрудник\nДата чека\nСумма";
            BillsBox.ItemsSource = bills.GetData();
            BillsBox.DisplayMemberPath = "bill_date";
        }

        private void GetBill_Click(object sender, RoutedEventArgs e)
        {
            List<string> billtext = new List<string>();

            if (BillsBox.SelectedItem != null)
            {
                BillID = Convert.ToInt32((BillsBox.SelectedItem as DataRowView).Row[0]);

                billtext.Add("\tПивоварня Дергачева");
                billtext.Add("\t Кассовый чек №" + BillID);
                foreach (var item in goods)
                {
                    billtext.Add("\t" + item.Beer_name + ": 1 *" + item.Price);
                }
                billtext.Add("Итог: " + Amount);

                File.WriteAllLines(Path + "\\Копия_Чек_№_" + BillID + ".txt", billtext);
                MessageBox.Show("Копия чека готова!");
            }
        }

        private void BillsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            goods.Clear();
            bills_itemsID.Clear();
            beers_itemsID.Clear();
            BillGrid.ItemsSource = null;

            BillID = Convert.ToInt32((BillsBox.SelectedItem as DataRowView).Row[0]);
            Date = ((BillsBox.SelectedItem as DataRowView).Row[2]).ToString();
            UserID = Convert.ToInt32((BillsBox.SelectedItem as DataRowView).Row[3]);
            Amount = ((BillsBox.SelectedItem as DataRowView).Row[4]).ToString();

            var AllWorkers = users.GetData().Rows;
            for (int i = 0; i < AllWorkers.Count; i++)
            {
                if ((int)AllWorkers[i][0] == UserID)
                {
                    UserName = AllWorkers[i][1].ToString(); 
                    break; 
                }
            }
            BillInfoBlock.Text = $"Сотрудник: {UserName}\nДата: {Date}\nСумма: {Amount}";

            var AllItems = bill_Item.GetData().Rows;
            for (int i = 0; i < AllItems.Count; i++)
            {
                if ((int)AllItems[i][1] == BillID)
                {
                    bills_itemsID.Add((int)AllItems[i][1]);
                    beers_itemsID.Add((int)AllItems[i][2]);
                }
            }

            var Beers = beer.GetData().Rows;
            for (int i = 0; i < Beers.Count; i++)
            {
                foreach(var item in beers_itemsID)
                {
                    if ((int)Beers[i][0] == item)
                    {
                        Bill bill = new Bill(item, (string)Beers[i][1], 1, (decimal)Beers[i][5]);
                        goods.Add(bill);
                    }
                }
            }

            BillGrid.ItemsSource = goods;
        }
    }

    public class Bill
    {
        public int ItemID { get; set; }
        public string Beer_name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Bill(int itemID, string beer_name, int quantity, decimal price) 
        {
            ItemID = itemID;
            Beer_name = beer_name;
            Quantity = quantity;
            Price = price;
        }
    }
}
