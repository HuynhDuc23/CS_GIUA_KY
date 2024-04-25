using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CRUDuser
{
    internal class UserService {

        SqlConnection connect = null;
        public UserService(SqlConnection sqlConnection) {
            connect = sqlConnection;
        }

    
        public List<User> getUsers()
        {
            List<User> users = new List<User>();
            users = [];
            string query = "SELECT * FROM users ";
            // truy van , ketnoidb
            SqlCommand cmd = new SqlCommand(query,connect);
            // select 
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = new User();
                    int id = Convert.ToInt32(reader["id"]);
                    user.setId(id);
                    string username = reader["username"].ToString();
                    user.setUsername(username);
                    string password = reader["password"].ToString();
                    user.setPassword(password);
                    int idrole = Convert.ToInt32(reader["idrole"]);
                    user.setIdrole(idrole);

                    users.Add(user);
                }
            }
            else
            {
                Console.WriteLine("Cant not get users! server 500");
            }
            reader.Close();
            return users;
        }
        public void insertUser(User user)
        {
            try
            {
                User user1 = new User();
                string query = "insert into users (username , password ,idrole) values (" + "'" + user.getUsername() + "' ," + "'" + user.getPassword() + "' ," + user.getIdrole() + ")";
                // Console.WriteLine(query);
                SqlCommand sql = new SqlCommand(query, connect);
                int rows = sql.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine("Ban Da Them Moi Thanh Cong!");
                }
                else
                {
                    Console.WriteLine("Ban Da Them That Bai!");
                }
                sql.Clone();
            }
            catch(Exception ex)
            {
                Console.WriteLine("---Vui Long Chon Dung theo danh sach hien thi --- : 1 ADMIN , 2 :MANAGER , 3 : TEACHER" + "Vui Long Nhap Lai Thong Tin 1 Lan Nua");
            }

        }
        public List<User> findUsersByName(string userName)
        {
            List<User> users = new List<User>();
            string result = "";
            try
            {
                string query = "select * from users where username = " + "'" + userName + "'";
              //  Console.WriteLine(query);
                SqlCommand sql = new SqlCommand(query, connect);
                SqlDataReader reader = sql.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        User user = new User();
                        int id = Convert.ToInt32(reader["id"]);
                        user.setId(id);
                        string username = reader["username"].ToString();
                        user.setUsername(username);
                        string password = reader["password"].ToString();
                        user.setPassword(password);
                        int idrole = Convert.ToInt32(reader["idrole"]);
                        user.setIdrole(idrole);

                        users.Add(user);
                    }
                }
                else
                {
                    Console.WriteLine("Ban khong tim thay user voi username tren");
                }
                reader.Close();
                if(users.Count > 0)
                {
                    return users;
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error !");
            }
            return users;
        }
        public void deleteUserById(int id)
           
        {
            SqlCommand cmd = null;
            try
            {
                string query = "delete users where id = " + id;
                cmd = new SqlCommand(query,connect);
                int row = cmd.ExecuteNonQuery();
                if(row > 0)
                {
                    Console.WriteLine("Ban da Xoa thanh Cong voi id tren !");
                   
                }
                else
                {
                    Console.WriteLine("Khong The Xoa Vi Id Nay Khong Ton Tai!");
                }
                cmd.Clone();

            }
            catch(Exception ex)
            {
                cmd.Clone();
                Console.WriteLine(" - Vui long chon dung du lieu yeu cau cua chuong trinh");
            }
        }
        public void updateUserById (User user)
        {
            SqlCommand cmd = null;
            try
            {

                //  update users set username = 'TranDuc', password = 123123, idrole = 1 where id = 1
                string query = " update users set username = " + "'" + user.getUsername() + "' ,"+"password = "+ "'" + user.getPassword() +"'" + ","+ " idrole = " + user.getIdrole()  + " where id = "+ user.getId();
                Console.WriteLine(query);
                cmd = new SqlCommand(query, connect);
                Console.WriteLine("ok");


                // sai
                int row = cmd.ExecuteNonQuery();
                Console.WriteLine(row);
                if(row > 0)
                {
                    Console.WriteLine("Cap Nhat Thanh Cong");
                }
                else
                {
                    Console.WriteLine("Cap nhat that bai");
                }
                cmd.ExecuteReader().Close();
            }
            catch (Exception ex)
            {
                //  cmd.ExecuteReader().Close();
                // Console.WriteLine(ex.Message);
                Console.WriteLine(" - Vui long chon dung du lieu yeu cau cua chuong trinh");
            }
        }
        public List<User> sortByUsername()
        {
            List<User> users = new List<User>();
            users = [];
            SqlCommand cmd = null;
            try
            {
                string query = "select * from users order by username asc";
                cmd = new SqlCommand(query,connect);
                SqlDataReader reader = cmd.ExecuteReader();
           
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        User user = new User();
                        int id = Convert.ToInt32(reader["id"]);
                        user.setId(id);
                        string username = reader["username"].ToString();
                        user.setUsername(username);
                        string password = reader["password"].ToString();
                        user.setPassword(password);
                        int idrole = Convert.ToInt32(reader["idrole"]);
                        user.setIdrole(idrole);

                        users.Add(user);
                     
                    }
                }
                else
                {

                    Console.WriteLine("Khong The Sap Xep....!");
                }
                reader.Close();
            }
           
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            return users;
        }
        public User findUserById(int idN)
        {
            User user = new User();
           
            try
            {
                string query = "select * from users where id = " + idN;
                SqlCommand cmd = new SqlCommand(query,connect);
                SqlDataReader reader = cmd.ExecuteReader(); 
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
         
                        int id = Convert.ToInt32(reader["id"]);
                        user.setId(id);
                        string username = reader["username"].ToString();
                        user.setUsername(username);
                        string password = reader["password"].ToString();
                        user.setPassword(password);
                        int idrole = Convert.ToInt32(reader["idrole"]);
                        user.setIdrole(idrole);
                    }
                }
                else
                {
                    Console.WriteLine("Cant not find username by id");
                }
               reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
        }

    }
}
