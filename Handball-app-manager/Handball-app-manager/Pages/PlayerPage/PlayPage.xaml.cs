using System.Windows;
using System.Data.Entity;
using System.Linq;

namespace Handball_app_manager.Pages.PlayerPage
{
    /// <summary>
    /// Логика взаимодействия для PlayPage.xaml
    /// </summary>
    public partial class PlayPage : Window
    {
        ApplicationContext db;
        public string selectedClub { get; set; }

        public PlayPage(string selectedClub = null)
        {
            InitializeComponent();

            if (selectedClub != null)
            {
                this.selectedClub = selectedClub;
            }

            db = new ApplicationContext();

            db.Players.Where(c => c.Clubname == this.selectedClub).Load();



            this.DataContext = db.Players.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PlayAddPage playAddPage = new PlayAddPage(new Player());
            if (playAddPage.ShowDialog() == true)
            {
                Player player = playAddPage.Player;
                db.Players.Add(player);
                db.SaveChanges();

                


            }
            PlayPage playPage = new PlayPage();
            this.Hide();
            playPage.Show();
            

        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            // если ни одного объекта не выделено, выходим
            if (leagList.SelectedItem == null) return;
            // получаем выделенный объект
            Player player = leagList.SelectedItem as Player;

            PlayAddPage playAddPage = new PlayAddPage(new Player
            {
                Id = player.Id,
                Playerrole = player.Playerrole,
                Person = player.Person,
                Clubname = player.Clubname
            });
           
            this.Hide();
            // получаем измененный объект
            if (playAddPage.ShowDialog() == true)
            {
                player = db.Players.Find(playAddPage.Player.Id);
                if (player != null)
                {
                    player.Playerrole = playAddPage.Player.Playerrole;
                    db.Entry(player).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }

            PlayPage playPage = new PlayPage();
            this.Hide();
            playPage.Show();
            

        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (leagList.SelectedItem == null) return;
            // получаем выделенный объект
            Player player = leagList.SelectedItem as Player;
            db.Players.Remove(player);
            db.SaveChanges();
        }

        private void Button_BackClick(object sender, RoutedEventArgs e)
        {
            LeaguePage.LeagPage leagPage = new LeaguePage.LeagPage();
            this.Hide();
            leagPage.Show();

        }

        private void Button_clubClick(object sender, RoutedEventArgs e)
        {
            ClubPage.ClubPage clubPage = new ClubPage.ClubPage();
            this.Hide();
            clubPage.Show();
            


        }
    }
}