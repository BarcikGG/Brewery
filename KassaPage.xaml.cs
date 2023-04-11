using FinalWPF.BeerDBDataSetTableAdapters;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FinalWPF
{
    public partial class KassaPage : Page
    {
        private BeerTableAdapter beer = new BeerTableAdapter();
        private billsTableAdapter bills = new billsTableAdapter();
        private bill_itemTableAdapter bill_Item = new bill_itemTableAdapter();
        private List<Stuff> stuffs = new List<Stuff>();
        private int BeerID;
        private string beer_name;
        private int volume;
        private decimal price;
        private decimal amount = 0;

        private string Path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private string bill_text = "";

        public KassaPage()
        {
            InitializeComponent();
            GoodsGrid.ItemsSource = beer.GetData();
            Back.IsEnabled = false;
        }

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GoodsGrid.SelectedItem != null)
            {
                BeerID = Convert.ToInt32((GoodsGrid.SelectedItem as DataRowView).Row[0]);
                beer_name = (string)(GoodsGrid.SelectedItem as DataRowView).Row[1];
                volume = 1;
                price = Convert.ToDecimal((GoodsGrid.SelectedItem as DataRowView).Row[5]);

                Stuff stuff = new Stuff(BeerID, beer_name, volume, price);
                stuffs.Add(stuff);
                Add.IsEnabled = true;

                BillGrid.ItemsSource = null;
                BillGrid.ItemsSource = stuffs;

                amount += volume * price;
                Amount.Text = "Товары в чеке: " + amount.ToString();
                Back.IsEnabled = true;
            }
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (BillGrid.SelectedItem != null)
            {
                Stuff selected = BillGrid.SelectedItem as Stuff;

                volume = selected.Volume;
                price = selected.Price;

                stuffs.Remove(selected);
                Add.IsEnabled = true;

                BillGrid.ItemsSource = null;
                BillGrid.ItemsSource = stuffs;

                amount -= volume * price;
                Amount.Text = "Товары в чеке: " + amount.ToString();
            }
        }

        private void GetBill_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (stuffs.Count > 0 & amount <= Convert.ToInt32(GetMoneyBox.Text))
                {
                    List<string> goods = new List<string>();
                    int bill_id = (Convert.ToInt32(bills.GetData().Last()[0]) + 1);

                    goods.Add("\tПивоварня Дергачева");
                    goods.Add("\t Кассовый чек №" + bill_id);
                    foreach (var item in stuffs)
                    {
                        goods.Add("\t" + item.Beer_name + ": 1 *" + item.Price);
                    }
                    goods.Add("Итог: " + amount);
                    goods.Add("Оплата: " + GetMoneyBox.Text);
                    goods.Add("Сдача: " + (Convert.ToInt32(GetMoneyBox.Text) - amount));

                    bills.InsertQuery(bill_text, DateTime.Today.ToString(),
                        ((App)Application.Current).ID, amount);

                    foreach (var item in stuffs)
                    {
                        bill_Item.InsertQuery(bill_id, item.Beer_ID);
                    }

                    stuffs.Clear();
                    amount = 0;

                    File.WriteAllLines(Path + "\\Чек_№_" + bill_id + ".txt", goods);
                    MessageBox.Show("Чек создан! \nСпасибо за покупку");
                    BillGrid.ItemsSource = null;
                    BillGrid.ItemsSource = stuffs;
                }
                else if (amount > Convert.ToInt32(GetMoneyBox.Text))
                {
                    MessageBox.Show("Недостаточно средств");
                }
                else
                {
                    MessageBox.Show("Нет товаров");
                }
            }
            catch { MessageBox.Show("Вы ввели не число!"); }
        }
    }

    public class Stuff
    {
        public int Beer_ID { get; set; }
        public string Beer_name { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }

        public Stuff(int beer_id, string name, int volume, decimal price) 
        {
            Beer_ID = beer_id;
            Beer_name = name;
            Volume = volume;
            Price = price;
        }
    }
}
