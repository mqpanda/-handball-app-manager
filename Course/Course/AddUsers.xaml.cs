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
    public partial class AddUsers : Window
    {
        ApplicationContext db;
        public AddUsers()
        {
            InitializeComponent();

        }

        private void Button_backClick(object sender, RoutedEventArgs e)
        {
            UserPage userpage = new UserPage();
            userpage.Show();
            this.Hide();
        }

        private void Button_addClick(object sender, RoutedEventArgs e)
        {

            string name = TextBoxName.Text.Trim();
            string country = TextBoxCountry.Text.Trim();

            if (name.Length < 2)
            {
                TextBoxName.ToolTip = "...";
                TextBoxName.Background = Brushes.DarkRed;
            }
            else if (country.Length < 2)
            {
                TextBoxCountry.ToolTip = "...";
                TextBoxCountry.Background = Brushes.DarkRed;
            }
            else
            {
                TextBoxName.ToolTip = "";
                TextBoxName.Background = Brushes.Transparent;
                TextBoxCountry.ToolTip = "";
                TextBoxCountry.Background = Brushes.Transparent;

                
            }
        }
    }
}
