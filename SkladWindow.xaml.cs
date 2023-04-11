using System.Windows;

namespace FinalWPF
{
    public partial class SkladWindow : Window
    {
        public SkladWindow()
        {
            InitializeComponent();
            PageFrameKassa.Content = new KassaPage().Content;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }

        private void Kassa_Click(object sender, RoutedEventArgs e)
        {
            PageFrameKassa.Content = new KassaPage().Content;
        }

        private void Bills_Click(object sender, RoutedEventArgs e)
        {
            PageFrameKassa.Content = new BillsPage().Content;
        }
    }
}
