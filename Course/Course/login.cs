using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Course
{
    class User
    {
        public int Id { get; set; }


        public string login, email, password, role;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public User()
        {

        }

        public User(string login, string email, string password, string role)
        {
            this.login = login;
            this.email = email;
            this.password = password;
            this.role = role;

        }

    }

    class Handball
    {
        public int Id { get; set; }

        public string league;



        public string League
        {
            get { return league; }
            set { league = value; }
        }


        public Handball()
        {

        }

        public Handball(string league)
        {
            this.league = league;

        }

    }

    class Club
    {
        public int Id { get; set; }

        public string clubname;



        public string Clubname
        {
            get { return clubname; }
            set { clubname = value; }
        }


        public Club()
        {

        }

        public Club(string clubname)
        {
            this.clubname = clubname;

        }
    }

    public class Player
    {
        private string playerrole;
        private string person;
        private string currentclub;

        public int Id { get; set; }

        public string Playerrole
        {
            get { return playerrole; }
            set
            {
                playerrole = value;
                
            }
        }
        public string Person
        {
            get { return person; }
            set
            {
                person = value;
                
            }
        }
        public string Currentclub
        {
            get { return currentclub; }
            set
            {
                currentclub = value;
                
            }
        }

       
    }
}

