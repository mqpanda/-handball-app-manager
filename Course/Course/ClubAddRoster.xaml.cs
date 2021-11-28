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
using System.Data.Entity;

namespace Course
{
    /// <summary>
    /// Логика взаимодействия для ClubAddRoster.xaml
    /// </summary>

    public partial class ClubAddRoster : Window
    {
        public Player Player { get; private set; }

        ApplicationContext db;

        public ClubAddRoster(Player p)
        {
            InitializeComponent();
            ApplicationContext db = new ApplicationContext();
            Player = p;
            this.DataContext = Player;
            
        }
        private void Button_addClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_backClick(object sender, RoutedEventArgs e)
        {
            ClubRoster clubRoster = new ClubRoster();
            clubRoster.Show();
            this.Hide();
        }
    }
}
