using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Repositories;

namespace ContactApp.Controllers
{
    internal class AdminPage
    {
        public static void WelcomeMenuAdmin()
        {
            while (true)
            {
                Console.WriteLine($"Welcome to Admin Page...\n" +
                    $"1.Create new User\n" +
                    $"2.Display all user details\n" +
                    $"3.Update user details\n" +
                    $"4.Delete user details\n" +
                    $"5.Display all Active Users\n" +
                    $"6.Display All InActive Uers\n" +
                    $"7.Exit Admin Page\n");

                Console.WriteLine("Enter your choice:\n");
                int choice=Convert.ToInt32( Console.ReadLine() );

                DoTask(choice); 
            }
        }
        public static void DoTask(int choice)
        {
            switch(choice)
            {
                case 1:
                    AddUser();
                    break;
                case 2:
                    DisplayUser();
                    break;
                case 3:
                    UpdateUser();
                    break;
                case 4:
                    DeleteUser();
                    break;
                case 5:
                    DisplayActiveUsers();
                    break;
                case 6:
                    DisplayInactiveUsers();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Enter a valid choice");
                    break;
            }
        }
        public static void AddUser()
        {
            Console.WriteLine("Enter admin Id");
            int adminId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your user ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name :");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lname = Console.ReadLine();
            Console.WriteLine("User Admin ?");
            bool isAdmin = Convert.ToBoolean(Console.ReadLine());
            AdminManagement.AddNewUser(adminId, id, fname, lname, isAdmin);
            Console.WriteLine("User Added Successfully");
        }
        public static void DisplayUser()
        {
            Console.WriteLine("Enter admin Id");
            int adminId = Convert.ToInt32(Console.ReadLine());
            var users = AdminManagement.DisplayAllUsers(adminId);
            users.ForEach(user => Console.WriteLine(user));
        }

        public static void UpdateUser()
        {
            Console.WriteLine("Enter admin Id");
            int adminId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the id of the user to be updated");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the first name");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter the last name");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter the admin status");
            bool isAdmin = Convert.ToBoolean(Console.ReadLine());
            AdminManagement.UpdateUser(adminId, id, fname, lname, isAdmin);
            Console.WriteLine("Successful Updation!");
        }

        public static void DeleteUser()
        {
            Console.WriteLine("Enter admin Id");
            int adminId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            AdminManagement.DeleteUser(adminId, id);
            Console.WriteLine("Successful Deletion!!");
        }

        public static void DisplayActiveUsers()
        {
            var active = AdminManagement.DisplayActiveUsers();
            active.ForEach(user => Console.WriteLine(user));
        }

        public static void DisplayInactiveUsers()
        {
            var inactive = AdminManagement.DisplayInactiveUsers();
            inactive.ForEach(user => Console.WriteLine(user));
        }


    }

}
