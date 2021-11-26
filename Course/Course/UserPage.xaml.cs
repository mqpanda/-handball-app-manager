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
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        public UserPage()
        {
            InitializeComponent();

            ApplicationContext db = new ApplicationContext();
            List<User> users = db.Users.ToList();

            listOfClubs.ItemsSource = users;
        }

        private void Button_AddClick(object sender, RoutedEventArgs e)
        {
            AddUsers addusers = new AddUsers();
            addusers.Show();
            this.Hide();
        }

        private void Button_BackClick(object sender, RoutedEventArgs e)
        {
            AutoWIN autowin = new AutoWIN();
            autowin.Show();
            this.Hide();
        }

        private void Button_delClick(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
