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

namespace Handball_app_manager.Pages.ClubPage
{
    /// <summary>
    /// Логика взаимодействия для ClubAddPage.xaml
    /// </summary>
    public partial class ClubAddPage : Window
    {
        public Club Club { get; private set; }

        public ClubAddPage(Club c)
        {
            InitializeComponent();
            Club = c;
            this.DataContext = Club;
        }


        private void Button_addClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public void Button_backClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
            
        }
    }
}
