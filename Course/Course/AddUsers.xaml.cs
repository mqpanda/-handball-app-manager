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
            db = new ApplicationContext();
        }

        private void Button_backClick(object sender, RoutedEventArgs e)
        {
            Clubpick clubpick = new Clubpick();
            clubpick.Show();
            this.Hide();
        }

        private void Button_addClick(object sender, RoutedEventArgs e)
        {
            string league = TextBoxLeague.Text.Trim();
            Handball handball = new Handball(league);
            //Вносим в базу данных
            db.Handballs.Add(handball);
            db.SaveChanges();

            Clubpick clubpick = new Clubpick();
            clubpick.Show();
            this.Hide();
        }
    }
}
