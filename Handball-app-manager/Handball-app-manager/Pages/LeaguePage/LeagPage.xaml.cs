
using System.Windows;
using System.Data.Entity;
using System.Windows.Controls;

namespace Handball_app_manager.Pages.LeaguePage
{
    /// <summary>
    /// Логика взаимодействия для LeagPage.xaml
    /// </summary>
    public partial class LeagPage : Window
    {
        ApplicationContext db;


      
        public LeagPage()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.Handballs.Load();
            this.DataContext = db.Handballs.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LeagAddPage leagueAddPage = new LeagAddPage(new Handball());
            if (leagueAddPage.ShowDialog() == true)
            {
                Handball handball = leagueAddPage.Handball;
                db.Handballs.Add(handball);
                db.SaveChanges();


            }
            LeagPage leagPage = new LeagPage();
            this.Hide();
            leagPage.Show();
            

        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            // если ни одного объекта не выделено, выходим
            if (leagList.SelectedItem == null) return;
            // получаем выделенный объект
            Handball handball = leagList.SelectedItem as Handball;

            LeagAddPage leagAddPage = new LeagAddPage(new Handball
            {
                Id = handball.Id,
                League = handball.League,
                Region = handball.Region
            })
            {
                
            };
            this.Hide();
            // получаем измененный объект
            if (leagAddPage.ShowDialog() == true)
            {
                handball = db.Handballs.Find(leagAddPage.Handball.Id);
                if (handball != null)
                {
                    handball.League = leagAddPage.Handball.League;
                    db.Entry(handball).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }

            LeagPage leagPage = new LeagPage();
            this.Hide();
            leagPage.Show();
            

        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (leagList.SelectedItem == null) return;
            // получаем выделенный объект
            Handball handball= leagList.SelectedItem as Handball;
            db.Handballs.Remove(handball);
            db.SaveChanges();
        }

        private void Button_BackClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
            
        }

        private void Button_clubClick(object sender, RoutedEventArgs e)
        {
            Button selectedButton = (Button)e.Source;
            string flowRegion = (string)selectedButton.Tag;
            
            ClubPage.ClubPage clubPage = new ClubPage.ClubPage(flowRegion);


            this.Hide();
            clubPage.Show();
            


        }
    }
}
