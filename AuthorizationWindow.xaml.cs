using System.Configuration;
using System.Windows;
using FinalWPF.BeerDBDataSetTableAdapters;

namespace FinalWPF
{
    public partial class AuthorizationWindow : Window
    {
        private usersTableAdapter users = new usersTableAdapter();
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var AllLogins = users.GetData().Rows;

            for (int i = 0; i < AllLogins.Count;  i++) 
            {
                if (AllLogins[i][1].ToString() == LoginBox.Text
                    & AllLogins[i][2].ToString() == PasswordBox.Password)
                {
                    int RoleID = (int)AllLogins[i][3];

                    switch (RoleID)
                    {
                        case 1:
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                            break;
                        case 2:
                            UserWindow userWindow = new UserWindow();
                            userWindow.Show();
                            this.Close();
                            break;
                        case 3:
                            SkladWindow skladWindow = new SkladWindow();
                            skladWindow.Show();
                            int id = (int)AllLogins[i][0];
                            ((App)Application.Current).ID = id;
                            this.Close();
                            break;
                    }
                    Error1.Visibility = Visibility.Hidden;
                    Error2.Visibility = Visibility.Hidden;
                }
                else
                {
                    Error1.Visibility = Visibility.Visible;
                    Error2.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
