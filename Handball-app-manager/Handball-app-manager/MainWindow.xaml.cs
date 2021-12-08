using System.Linq;
using System.Windows;
using System.Data.Entity;

namespace Handball_app_manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.Users.Load();
        }

        private void Button_AuthClick(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();

            string password = PassBoxFirst.Password.Trim();




            User authUser = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                authUser = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
            }


            
            if (authUser != null)
            {
                if (login == "Superadmin" || password == "superadmin")
                {
                    Pages.AdminLogin.AdminLogin adminLogin = new Pages.AdminLogin.AdminLogin();
                    this.Close();
                    adminLogin.Show();
                }
                else
                {
                    Pages.LeaguePage.LeagPage leagPage = new Pages.LeaguePage.LeagPage();
                    this.Close();
                    leagPage.Show();
                }
                
            }
           



        }



        private void Button_WinRegClick(object sender, RoutedEventArgs e)
        {
            Handball_app_manager.Pages.RegisterPage.RegPage regPage = new Handball_app_manager.Pages.RegisterPage.RegPage();
            this.Close();
            regPage.Show();
            
        }

        

        private void TextBoxLogin_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
