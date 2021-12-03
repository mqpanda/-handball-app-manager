using System.Data.Entity;
using System.Windows;


namespace Handball_app_manager.Pages.AdminLogin
{
    /// <summary>
    /// Логика взаимодействия для AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        ApplicationContext db;


        public AdminLogin()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.Users.Load();





            this.DataContext = db.Users.Local.ToBindingList();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminAddPage adminAddPage = new AdminAddPage(new User());
            if (adminAddPage.ShowDialog() == true)
            {
                User user = adminAddPage.User;
                db.Users.Add(user);
                db.SaveChanges();


            }
            AdminLogin adminLogin = new AdminLogin();
            this.Close();
            adminLogin.Show();
            

        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            // если ни одного объекта не выделено, выходим
            if (LoginList.SelectedItem == null) return;
            // получаем выделенный объект
            User user = LoginList.SelectedItem as User ;


            AdminAddPage adminAddPage = new AdminAddPage(new User
            {

                id = user.id,
                Login= user.Login,
                password = user.Password,
                email = user.Email,
                role = user.Role
            });
            
            this.Hide();
            // получаем измененный объект
            if (adminAddPage.ShowDialog() == true)
            {
                user = db.Users.Find(adminAddPage.User.id);
                if (user != null)
                {
                    user.login = adminAddPage.User.login;
                    user.password = adminAddPage.User.password;
                    user.email = adminAddPage.User.email;
                    user.role = adminAddPage.User.role;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }

            AdminLogin adminLogin = new AdminLogin();
            this.Close();
            adminLogin.Show();
            

        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (LoginList.SelectedItem == null) return;
            // получаем выделенный объект
            User user = LoginList.SelectedItem as User;
            db.Users.Remove(user);
            db.SaveChanges();
        }

        private void Button_BackClick(object sender, RoutedEventArgs e)
        {
            LeaguePage.LeagPage leagPage = new LeaguePage.LeagPage();
            this.Close();
            leagPage.Show();
            
        }

       
    }
}
