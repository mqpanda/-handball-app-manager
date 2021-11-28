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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace Course
{
    /// <summary>
    /// Логика взаимодействия для AddUsers.xaml
    /// </summary>
    public partial class addClubWin : Window
    {
        ApplicationContext db;
        public addClubWin()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Button_backClick(object sender, RoutedEventArgs e)
        {
            Clubpick clubpick = new Clubpick();
            clubpick.Show();
            this.Hide();
        }

        private void Button_addClick(object sender, RoutedEventArgs e)
        {
            string clubname = TextBoxClubName.Text.Trim();
            Club club = new Club(clubname);
            //Вносим в базу данных
            db.Clubs.Add(club);
            db.SaveChanges();

            UserPage userpage= new UserPage();
            userpage.Show();
            this.Hide();
        }
    }
}

