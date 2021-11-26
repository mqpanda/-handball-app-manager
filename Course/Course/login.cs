using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    class User
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

        /*public override string ToString()
        {
            return "Пользователь: " + Login + "; Пароль: " + Password;
        }*/
    }
}
