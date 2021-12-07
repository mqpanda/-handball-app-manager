using System.Windows;

namespace Handball_app_manager.Pages.LeaguePage
{
    /// <summary>
    /// Логика взаимодействия для ClubAddRoster.xaml
    /// </summary>

    public partial class LeagAddPage : Window
    {
        public Handball Handball { get; private set; }

        public LeagAddPage(Handball h)
        {
            InitializeComponent();
            Handball = h;
            this.DataContext = Handball;
        }


        private void Button_addClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public void Button_backClick(object sender, RoutedEventArgs e)
        {
            LeaguePage.LeagPage leagPage = new LeaguePage.LeagPage();
            this.Hide();
            leagPage.Show();

        }
    }
}