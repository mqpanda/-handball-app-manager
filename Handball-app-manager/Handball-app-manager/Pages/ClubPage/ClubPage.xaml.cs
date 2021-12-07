using System.Linq;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;



namespace Handball_app_manager.Pages.ClubPage
{

    public partial class ClubPage : Window
    {
        ApplicationContext db;
        public string selectedRegion { get; set; }

        public ClubPage(string selectedRegion = null)
        {
            InitializeComponent();

            if(selectedRegion != null)
            {
                this.selectedRegion = selectedRegion;
            }

            db = new ApplicationContext();
            
            db.Clubs.Where(c => c.Region == this.selectedRegion).Load();
            

            this.DataContext = db.Clubs.Local.ToBindingList();



        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ClubAddPage clubAddPage = new ClubAddPage(new Club());
            if (clubAddPage.ShowDialog() == true)
            {
                Club club = clubAddPage.Club;
                db.Clubs.Add(club);
                db.SaveChanges();


            }
            ClubPage clubPage = new ClubPage();
            this.Hide();
            clubPage.Show();
            

        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            // если ни одного объекта не выделено, выходим
            if (clubList.SelectedItem == null) return;
            // получаем выделенный объект
            Club club = clubList.SelectedItem as Club;
           

            ClubAddPage clubAddPage = new ClubAddPage(new Club
            {
            
                Id = club.Id,
                Clubname = club.Clubname,
                Region = club.Region
            })
            {

            };
            this.Hide();
            // получаем измененный объект
            if (clubAddPage.ShowDialog() == true)
            {
                club = db.Clubs.Find(clubAddPage.Club.Id);
                if (club != null)
                {
                    club.Clubname = clubAddPage.Club.Clubname;
                    club.Region = clubAddPage.Club.Region;
                    db.Entry(club).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }

            ClubPage clubPage = new ClubPage();
            this.Hide();
            clubPage.Show();
            

        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (clubList.SelectedItem == null) return;
            // получаем выделенный объект
            Club club = clubList.SelectedItem as Club;
            db.Clubs.Remove(club);
            db.SaveChanges();
        }

        private void Button_BackClick(object sender, RoutedEventArgs e)
        {
            LeaguePage.LeagPage leagPage = new LeaguePage.LeagPage();
            this.Hide();
            leagPage.Show();

        }

        

        private void Button_playClick(object sender, RoutedEventArgs e)
        {

            Button selectedButton = (Button)e.Source;
            string flowClub = (string)selectedButton.Tag;
            PlayerPage.PlayPage playPage = new PlayerPage.PlayPage(flowClub);
            this.Hide();
            playPage.Show();
            
        }
    }
}
