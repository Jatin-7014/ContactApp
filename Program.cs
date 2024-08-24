using ContactApp.Controllers;
using ContactApp.Exceptions;
using ContactApp.Models;
using ContactApp.Repositories;

namespace ContactApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User admin1 = new User(1, "Jatin", "Kumar", true);
            User admin2 = new User(2, "Sachin", "Tendulkar", true);
            User admin3 = new User(3, "Rohit", "Sharma", true);
            User staff1 = new User(4, "Mary", "Kom", false);
            User staff2 = new User(5, "Alex", "Rai", false);

            AdminManagement.AddNewAdmin(admin1);
            AdminManagement.AddNewAdmin(admin2);
            AdminManagement.AddNewAdmin(admin3);
            StaffManagement.AddStaff(staff1);
            StaffManagement.AddStaff(staff2);

            Console.WriteLine("Enter the userId:");
            int id = Convert.ToInt32(Console.ReadLine());
            var user = AdminManagement.users.Where(user => user.UserId == id).FirstOrDefault();

            if (user == null)
                throw new UserNotFoundException("User doesn't exist");

            else if (user.IsAdmin)
                AdminPage.WelcomeMenuAdmin();

            else
                StaffPage.WelcomeMenuStaff();
        }
    }
}
