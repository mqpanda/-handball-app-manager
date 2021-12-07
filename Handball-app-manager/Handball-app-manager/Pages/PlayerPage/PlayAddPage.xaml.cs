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

namespace Handball_app_manager.Pages.PlayerPage
{
    /// <summary>
    /// Логика взаимодействия для PlayAddPage.xaml
    /// </summary>
    public partial class PlayAddPage : Window
    {
        public Player Player { get; private set; }

        public PlayAddPage(Player p)
        {
            InitializeComponent();
            Player = p;
            this.DataContext = Player;
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
