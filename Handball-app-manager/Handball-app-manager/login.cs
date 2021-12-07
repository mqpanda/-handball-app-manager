namespace Handball_app_manager
{
    public class User
    {
        public int id { get; set; }


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

    public class Handball
    {
        public int Id { get; set; }

        public string league, region;



        public string League
        {
            get { return league; }
            set { league = value; }
        }

        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        public Handball()
        {

        }

        public Handball(string league)
        {
            this.league = league;
        }

    }

    public class Club
    {
        public int Id { get; set; }

        public string clubname, region;



        public string Clubname
        {
            get { return clubname; }
            set { clubname = value; }
        }
        public string Region
        {
            get { return region; }
            set { region = value; }
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
        private string clubname;

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
        public string Clubname
        {
            get { return clubname; }
            set
            {
                clubname = value;

            }
        }
    }
}
