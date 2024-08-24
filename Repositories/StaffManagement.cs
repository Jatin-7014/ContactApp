using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Exceptions;
using ContactApp.Models;

namespace ContactApp.Repositories
{
    internal class StaffManagement
    {
        public static void AddStaff(User user)
        {
            AdminManagement.users.Add(user);
        }

        public static void AddContact(int userId, int contactId)
        {
            var user = AdminManagement.users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null || user.IsActive == false)
                throw new TaskCannotPerformException("Cannot perform the task due to user deactivation");
            Contact newContacts = new Contact(contactId, user.FName, user.LName,user.IsActive);
            user.Contacts.Add(newContacts);

        }

        public static List<Contact> DisplayContacts(int id)
        {
            var user = AdminManagement.users.Where(user => user.UserId == id).FirstOrDefault();
            if (user == null)
            {
                throw new UserNotFoundException("User does not exist");
            }
            if (user.Contacts.Count == 0)
                throw new DatabaseIsEmptyException("Contact List is Empty");
            return user.Contacts;
        }

        public static void UpdateContact(int userId, int contactId, string lname)
        {
            var user = AdminManagement.users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null)
                throw new UserNotFoundException("User does not exist");
            if (user.IsActive == false)
                throw new TaskCannotPerformException("User is Deactivated");
            var contact = user.Contacts.Where(contact => contact.ContactId == contactId).FirstOrDefault();
            if (contact.IsActive == false)
                throw new TaskCannotPerformException("User is Deactivated can't perform any task");
            if (contact == null)
                Console.WriteLine("Contact doesn't exist");
            contact.LName = lname;
        }

        public static void DeleteContact(int userId, int contactId)
        {
            var user = AdminManagement.users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null)
                throw new UserNotFoundException("User does not exist");
            if (user.IsActive != true)
            {
                throw new TaskCannotPerformException("User has been Deactivated");
            }
            var contact = user.Contacts.Where(contact => contact.ContactId == contactId).FirstOrDefault();
            if (contact == null)
                Console.WriteLine("Contact doesn't exist");
            contact.IsActive = false;
        }

        public static void AddContactDetails(int userId, int contactId, int detailId, string type)
        {
            var user = AdminManagement.users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null || user.IsActive == false)
                throw new TaskCannotPerformException("Contact has been Deactivated");
            var contact = user.Contacts.Where(contact => contact.ContactId == contactId).FirstOrDefault();
            if (contact == null || contact.IsActive == false)
                throw new TaskCannotPerformException("Contact has been Deactivated");
            var newContactDetails = new ContactDetail(detailId, type);
            contact.ContactDetail.Add(newContactDetails);
        }

        public static List<ContactDetail> DisplayDetails(int userId, int contactId)
        {
            var user = AdminManagement.users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null || user.IsActive == false)
                throw new TaskCannotPerformException("User has been Deactivated");
            var contact = user.Contacts.Where(contact => contact.ContactId == contactId).FirstOrDefault();
            if (contact == null || contact.IsActive == false)
                throw new TaskCannotPerformException("Contact has been Deactivated");
            if (contact.ContactDetail.Count == 0)
                throw new DatabaseIsEmptyException("Contact List Is Empty");
            return contact.ContactDetail;
        }

        public static void UpdateDetails(int userId, int contactId, int detailId, string type)
        {
            var user = AdminManagement.users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null || user.IsActive == false)
                throw new TaskCannotPerformException("User has been Deactivated");
            var contact = user.Contacts.Where(contact => contact.ContactId == contactId).FirstOrDefault();
            if (contact == null || contact.IsActive == false)
                throw new TaskCannotPerformException("Contact has been Deactivated");
            var details = contact.ContactDetail.
                Where(detail => detail.ContactDetailsId == detailId).FirstOrDefault();
            if (details == null)
            {
                Console.WriteLine("Contact Details Not Found");
            }

            details.Type = type;

        }

        public static void DeleteDetails(int userId, int contactId, int detailId)
        {
            var user = AdminManagement.users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null || user.IsActive == false)
                throw new TaskCannotPerformException("User has been Deactivated");
            var contact = user.Contacts.Where(contact => contact.ContactId == contactId).FirstOrDefault();
            if (contact == null || contact.IsActive == false)
                throw new TaskCannotPerformException("Contact has been Deactivated");
            var details = contact.ContactDetail.
                Where(detail => detail.ContactDetailsId == detailId).FirstOrDefault();
            if (details == null)
            {
                Console.WriteLine("Contact Details Not Found");
            }

            contact.ContactDetail.Remove(details);
        }
    }
}
