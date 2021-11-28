using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Course
{
    public partial class AutoWIN : Window
    {
        public AutoWIN()
        {
            InitializeComponent();
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
                Clubpick clubpick = new Clubpick();
                clubpick.Show();
                this.Hide();

            }



        }

        private void Button_WinRegClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Hide();
        }

        private void Button_adminClick(object sender, RoutedEventArgs e)
        {
            Clubpick clubpick = new Clubpick();
            clubpick.Show();
            this.Hide();
        }

        

        
    }
} 