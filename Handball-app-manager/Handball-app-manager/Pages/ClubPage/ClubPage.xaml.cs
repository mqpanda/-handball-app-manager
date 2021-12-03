
using System.Data.Entity;
using System.Windows;



namespace Handball_app_manager.Pages.ClubPage
{

    public partial class ClubPage : Window
    {
        ApplicationContext db;

        
        public ClubPage()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.Clubs.Load();
            
                



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
            clubPage.Show();
            this.Close();

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
            clubPage.Show();
            this.Close();

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
            leagPage.Show();
            this.Close();
        }

        private void Button_clubClick(object sender, RoutedEventArgs e)
        {
            ClubPage clubPage = new ClubPage();
            clubPage.Show();
            this.Close();


        }
    }
}
