using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CRUDuser
{
    internal class User
    {
        private  int id;
        private string username;
        private string password;
        public  int idrole;

        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }
        public string getUsername()
        {
            return this.username;
        }
        public void setUsername(string username)
        {
            this.username = username;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
        public string getPassword()
        {
            return this.password;
        }
        public void setIdrole(int idrole)
        {
            this.idrole = idrole;
        }
        public int getIdrole()
        {
            return this.idrole;
        }
        public string render()
        {
            return "ID : " + id + " UserName : " + username + " Password : " + password + " Idrole : " + idrole;
        }
    }
}
