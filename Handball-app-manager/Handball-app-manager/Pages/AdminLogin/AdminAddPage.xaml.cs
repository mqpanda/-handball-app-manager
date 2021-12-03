
using System.Windows;


namespace Handball_app_manager.Pages.AdminLogin
{
    /// <summary>
    /// Логика взаимодействия для ClubAddPage.xaml
    /// </summary>
    public partial class AdminAddPage : Window
    {
        public User User{ get; private set; }

        public AdminAddPage(User u)
        {
            InitializeComponent();
            User = u;
            this.DataContext = User;
        }


        private void Button_addClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public void Button_backClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
           
        }
    }
}
