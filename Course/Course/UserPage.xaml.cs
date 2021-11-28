﻿using System;
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

namespace Course
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        ApplicationContext db;
        public UserPage()
        {
            InitializeComponent();

            ApplicationContext db = new ApplicationContext();
            List<Club> clubs = db.Clubs.ToList();
            

            listOfClubs.ItemsSource = clubs;
        }

        private void Button_AddClick(object sender, RoutedEventArgs e)
        {
            addClubWin addclubwin = new addClubWin();
            addclubwin.Show();
            this.Hide();
        }

        private void Button_BackClick(object sender, RoutedEventArgs e)
        {
            Clubpick clubpick = new Clubpick();
            clubpick.Show();
            this.Hide();
        }

        private void Button_pickClub(object sender, RoutedEventArgs e)
        {
            ClubRoster clubRoster = new ClubRoster();
            clubRoster.Show();
            this.Hide();
        }
    }
}
