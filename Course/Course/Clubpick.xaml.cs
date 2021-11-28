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
    /// Логика взаимодействия для Clubpick.xaml
    /// </summary>
    public partial class Clubpick : Window
    {
        ApplicationContext db;
        public Clubpick()
        {
            InitializeComponent();
            

            ApplicationContext db = new ApplicationContext();
            List<Handball> handballs = db.Handballs.ToList();

            listOfClubs.ItemsSource = handballs;
            
        }

        private void Button_addClick(object sender, RoutedEventArgs e)
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

        private void Button_clubClick(object sender, RoutedEventArgs e)
        {
            UserPage userpage = new UserPage();
            userpage.Show();
            this.Hide();

        }
    }
}
