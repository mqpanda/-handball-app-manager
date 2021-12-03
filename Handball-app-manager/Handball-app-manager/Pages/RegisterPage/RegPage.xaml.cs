using System.Windows;
using System.Windows.Media;

namespace Handball_app_manager.Pages.RegisterPage
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Window
    {
        ApplicationContext db;
        public RegPage()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }
        private void Button_RegClick(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();

            string password = PassBoxFirst.Password.Trim();

            string password_second = PassBoxSecond.Password.Trim();

            string email = TextBoxEmail.Text.Trim();

            string role = "user";

            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Ваш логин некорректен!";
                TextBoxLogin.Background = Brushes.DarkRed;
            }
            else if (password.Length < 8)
            {
                PassBoxFirst.ToolTip = "Ваш пароль имеет длину менее 8 символов!";
                PassBoxFirst.Background = Brushes.DarkRed;
            }
            else if (password_second != password)
            {
                PassBoxSecond.ToolTip = "Пароли не совпадают";
                PassBoxSecond.Background = Brushes.DarkRed;
            }
            else if (email.Length < 8 || !email.Contains("@") || !email.Contains("."))
            {
                TextBoxEmail.ToolTip = "Ваш email некорректен!";
                TextBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                PassBoxFirst.ToolTip = "";
                PassBoxFirst.Background = Brushes.Transparent;
                PassBoxSecond.ToolTip = "";
                PassBoxSecond.Background = Brushes.Transparent;
                TextBoxEmail.ToolTip = "";
                TextBoxEmail.Background = Brushes.Transparent;



                User user = new User(login, email, password, role);
                //Вносим в базу данных
                db.Users.Add(user);
                db.SaveChanges();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }


        }

        private void Button_WinAuthClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
