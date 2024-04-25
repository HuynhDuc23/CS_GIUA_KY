using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CRUDuser
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string url = @"Data Source=LAPTOP-J3UT2RTG\SQLEXPRESS;Initial Catalog=DB_MANAGER;Integrated Security=True;TrustServerCertificate=True";
            ConnectionDB cnn = null;
            try
            {
                cnn = new ConnectionDB(url);
                Console.WriteLine("Connect Database is sucessfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            ConnectionDB connect = new ConnectionDB(url);
            ConnectionDB.conect(); // khong return 


            SqlConnection sqlConnection = ConnectionDB.get();


            Console.WriteLine(" Conect !");
            Program cs = new Program();
            bool isCheck = true;
            int count = 0;
            while (count!=5)
            {
                cs.menu();
                int choose = 0;
                Console.WriteLine("-----------------Khoi tao Chuong Trinh -----------------");
                choose = Convert.ToInt32(Console.ReadLine());
                UserService userService = new UserService(sqlConnection);
                switch (choose)
                {
                    case 1:
                        {
                            Console.WriteLine("1 : Lay Tat Ca Danh Sach Cua Nguoi Dung");
                           
                            List<User> users = userService.getUsers();
                            foreach (User user in users)
                            {
                               Console.WriteLine(user.render());
                           }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("2 : Them Mot Nguoi Dung ");
                            User user = new User();


                            try
                            {
                                Console.WriteLine("Vui long lai Nhap user voi do dai quy dinh < 10 va  > 3 ");
                                string data = Console.ReadLine();
                                 if (data.Length > 10 || data.Length < 3)
                                {
                                    data = "MacDinh";
                                    Console.WriteLine(data +  "Vi user khong nhap dung yeu cau nen la : Mac Dinh ");
                                }
                                 user.setUsername(data);
                                 Console.WriteLine("Vui long lai Nhap password voi do dai quy dinh > 3 va < 20");
                                string data2 = Console.ReadLine();
                                if(data2.Length< 3 || data2.Length > 20)
                                {
                                    data2 = "MacDinh";
                                    Console.WriteLine(data + "Vi user khong nhap dung yeu cau nen la : Mac Dinh ");
                                }
                                 user.setPassword(data2);
                                int result = 0;
                                try
                                {
                                    Console.WriteLine("Vui long lai Nhap lai idrole :  1 ADMIN, 2 MANAGER, 3 TEACHER");
                                   result = Convert.ToInt32(Console.ReadLine());
                                }
                                catch(Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                 user.setIdrole(result);
                                 userService.insertUser(user);
                             }
                             catch(Exception ex)
                             {
                                 
                                 Console.WriteLine(ex.Message);
                             }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("3 : Lay Nguoi Dung Boi username");
                            string username = "";
                            try
                            {
                                username =  Console.ReadLine();
                               List<User> users =  userService.findUsersByName(username);
                                foreach (User user in users)
                                {
                                    Console.WriteLine(user.render());
                                }

                            }
                            catch (Exception ex)
                            {

                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("4 : Delete Nguoi dung Boi 1 Id ");
                            int print = 0;
                            try
                            {
                                 print = Convert.ToInt32(Console.ReadLine());
                                userService.deleteUserById(print);
                            }catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("5 : Update Nguoi Dung Boi 1 Id");
                            try
                            {
                                int print = Convert.ToInt32(Console.ReadLine());
                                User user = userService.findUserById(print);
                                
                               if(user == null)
                                {
                                    Console.WriteLine("Error!");
                                    break;
                                }
                                else
                                {

                                    Console.WriteLine("Vui long nhap lai user name ");
                                    string username = Convert.ToString(Console.ReadLine());
                                    Console.WriteLine("Vui long nhap lai pass name ");
                                    string password = Convert.ToString(Console.ReadLine());
                                    int chosse = 0;
                                    try
                                    {
                                        User userNew = new User();

                                        userNew.setUsername(username);
                                        userNew.setPassword(password);
                                        Console.WriteLine("Vui long chon chon 1 : ADMIN , 2 : MANAGER  , 3:TEACHER ");
                                        chosse = Convert.ToInt32(Console.ReadLine());
                                        userNew.setIdrole(chosse);
                                        userNew.setId(user.getId());
                                        userService.updateUserById(userNew);
                                    }catch(Exception ex)
                                    {
                                        Console.WriteLine("Error!");
                                    }

                                }
                            }catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("6 : Sort Nguoi dung theo tieu chi username , tang dan ");
                            try
                            {
                                List<User> users = userService.sortByUsername();
                                foreach (User user in users)
                                {
                                    Console.WriteLine(user.render());
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("7 : Thoat Khoi Chuong Trinh");
                            return ;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Chuong Trinh Se Dung Neu Ban Sai Qua 5 lan");
                            count++;
                            break;

                        }
                }
                
            }
            ConnectionDB.disConect();
            

        }
        public void menu()
        {
            Console.WriteLine("Danh Sach Lua Chon Cua Nguoi Dung");
            Console.WriteLine("1 : Lay Tat Ca Danh Sach Cua Nguoi Dung");
            Console.WriteLine("2 : Them Mot Nguoi Dung ");
            Console.WriteLine("3 : Lay Nguoi Dung Boi username");
            Console.WriteLine("4 : Delete Nguoi dung Boi 1 Id ");
            Console.WriteLine("5 : Update Nguoi Dung Boi 1 Id");
            Console.WriteLine("6 : Sort Nguoi dung theo tieu chi username ");
            Console.WriteLine("7 : Thoat Khoi Chuong Trinh");
        }

    }
    
}
