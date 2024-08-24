using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class User
    {
        public int UserId {  get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive {  get; set; }
        public List<Contact> Contacts { get; set; }=new List<Contact>();

        public User(int id,string fname,string lname, bool isAdmin)
        {
            UserId = id;
            FName = fname;
            LName = lname;
            IsAdmin = isAdmin;
            IsActive = true;
        }
        public override string ToString()
        {
            return $"User ID:{UserId}\n" +
                $"First Name:{FName}\n" +
                $"Last Name:{LName}\n" +
                $"User Active Status:{IsActive}\n" +
                $"User Admin Status:{IsAdmin}\n";
        }
    }
}
