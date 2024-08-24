using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class Contact
    {
        public int ContactId {  get; set; }
        public string FName { get; set; } 
        public string LName { get; set; } 
        public bool IsActive {  get; set; }

        public List<ContactDetail> ContactDetail { get; set; }
        public Contact(int contactId,string fname,string lname,bool isActive)
        {
            ContactId = contactId;
            FName = fname;
            LName = lname;
            IsActive = true;
        }
        public override string ToString()
        {
            return $"Contact ID:{ContactId}\n" +
                $"First Name:{FName}\n" +
                $"Last Name:{LName}\n" +
                $"Contact Active Status:{IsActive}\n";
        }
    }
}
