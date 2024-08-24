using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ContactApp.Exceptions;
using ContactApp.Models;

namespace ContactApp.Repositories
{
    internal class AdminManagement
    {
        public static List<User> users = new List<User>();
        public static void AddNewAdmin(User user)
        {
            users.Add(user);
        }
        public static void AddNewUser(int adminId,int id,string fname,string lname,bool isAdmin)
        {
            var admin = users.Where(user=>user.UserId==adminId).FirstOrDefault();
            if (admin == null || admin.IsAdmin != true)
                throw new AccessedByAdminException("Only admin can perform the actions");

            if (admin.IsActive != true)
                throw new TaskCannotPerformException("Cannot perform the task due to admin deactivation");

            User newUser = new User(id,fname,lname,isAdmin);
            users.Add(newUser);
        }
        public static List<User> DisplayAllUsers(int adminId)
        {
            var admin = users.Where(user => user.UserId == adminId).FirstOrDefault();
            if (admin == null || admin.IsAdmin != true)
                throw new AccessedByAdminException("Only admin can perform the actions");

            if (admin.IsActive != true)
                throw new TaskCannotPerformException("Cannot perform the task due to admin deactivation");

            if (users.Count == 0)
                throw new DatabaseIsEmptyException("User database is empty");
            return users;
        }
        public static void UpdateUser(int adminId, int id, string fname, string lname, bool isAdmin)
        {
            var admin = users.Where(user => user.UserId == adminId).FirstOrDefault();
            if (admin == null || admin.IsAdmin != true)
                throw new AccessedByAdminException("Only admin can perform the actions");

            if (admin.IsActive != true)
                throw new TaskCannotPerformException("Cannot perform the task due to admin deactivation");

            var userToUpdate = users.Where(user => user.UserId == id).FirstOrDefault();
            if (userToUpdate == null || userToUpdate.IsActive != true)
                throw new DatabaseIsEmptyException("User database is empty");

            userToUpdate.FName = fname;
            userToUpdate.LName = lname;
            userToUpdate.IsAdmin = isAdmin;

        }
        public static void DeleteUser(int adminId,int id)
        {
            var admin = users.Where(user => user.UserId == adminId).FirstOrDefault();
            if (admin == null || admin.IsAdmin != true)
                throw new AccessedByAdminException("Only admin can perform the actions");

            if (admin.IsActive != true)
                throw new TaskCannotPerformException("Cannot perform the task due to admin deactivation");

            var userToDelete = users.Where(user => user.UserId == id).FirstOrDefault();
            if (userToDelete != null || userToDelete.IsActive != false)
                userToDelete.IsActive = false;
            else
                throw new UserNotFoundException("User not found....");
                
        }
        public  static List<User> DisplayActiveUsers()
        {
            var activeUser = users.Where(user => user.IsActive).ToList(); 
            if (activeUser.Count == 0)
            {
                throw new DatabaseIsEmptyException("No active users found...");
            }

            return activeUser;
        }

        public  static List<User> DisplayInactiveUsers()
        {
            var inActiveUser = users.Where(user => (user.IsActive==false)).ToList();
            if (inActiveUser.Count == 0)
            {
                throw new DatabaseIsEmptyException("No inActive users found...");
            }

            return inActiveUser;
        }
    }
}
