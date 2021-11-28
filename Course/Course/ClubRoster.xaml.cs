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
    /// Логика взаимодействия для ClubRoster.xaml
    /// </summary>
    public partial class ClubRoster : Window
    {
        ApplicationContext db;
        public ClubRoster()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.Players.Load();
            this.DataContext = db.Players.Local.ToBindingList();
        }
        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ClubAddRoster clubaddroster = new ClubAddRoster(new Player());
            Player player = clubaddroster.Player ;
            db.Players.Add(player);
            db.SaveChanges();
            clubaddroster.Show();
            this.Hide();
            
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (playersList.SelectedItem == null) return;
            // получаем выделенный объект
            Player player = playersList.SelectedItem as Player ;

            ClubAddRoster clubaddroster = new ClubAddRoster(new Player
            {
                Id = player.Id,
                Playerrole = player.Playerrole,
                Person = player.Person,
                Currentclub = player.Currentclub
            });

           
                // получаем измененный объект
            player = db.Players.Find(clubaddroster.Player.Id);
            if (player != null)
            {
                player.Playerrole = clubaddroster.Player.Playerrole;
                player.Person = clubaddroster.Player.Person;
                player.Currentclub = clubaddroster.Player.Currentclub;
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                clubaddroster.Show();
                this.Hide();
            }
            
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (playersList.SelectedItem == null) return;
            // получаем выделенный объект
            Player player = playersList.SelectedItem as Player;
            db.Players.Remove(player);
            db.SaveChanges();
        }
    }
}

