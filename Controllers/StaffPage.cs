using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Repositories;

namespace ContactApp.Controllers
{
    internal class StaffPage
    {
        public static void WelcomeMenuStaff()
        {
            while (true)
            {
                Console.WriteLine($"Welcome to Staff Page...\n" +
                    $"1.Create new Contact\n" +
                    $"2.Display all contact information \n" +
                    $"3.Update contact information\n" +
                    $"4.Delete contact\n" +
                    $"5.Create new contact detail\n" +
                    $"6.Display all contact details\n" +
                    $"7.Update contact details\n" +
                    $"8.Delete contact details\n" +
                    $"9.Exit Staff Page\n");

                Console.WriteLine("Enter your choice:\n");
                int choice = Convert.ToInt32(Console.ReadLine());

                DoTask(choice);
            }
        }
        public static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddContact();
                    break;
                case 2:
                    DisplayContact();
                    break;
                case 3:
                    UpdateContact();
                    break;
                case 4:
                    DeleteContact();
                    break;
                case 5:
                    AddContactDetail();
                    break;
                case 6:
                    DisplayContactDetails();
                    break;
                case 7:
                    UpdateContactDetails();
                    break;
                case 8:
                    DeleteContactDetails();
                    break;
                case 9:
                        Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Enter a valid choice");
                    break;
            }
        }
        public static void AddContact()
        {

            Console.WriteLine("Enter your User Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your contact ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            StaffManagement.AddContact(userId, id);
            Console.WriteLine("Contact Added Successfully");
        }

        public static void DisplayContact()
        {
            Console.WriteLine("Enter the user Id");
            int id = Convert.ToInt32(Console.ReadLine());
            var contacts = StaffManagement.DisplayContacts(id);
            contacts.ForEach(contact => Console.WriteLine(contact));
        }

        public static void UpdateContact()
        {
            Console.WriteLine("Enter the user Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the last name");
            string lname = Console.ReadLine();
            StaffManagement.UpdateContact(userId, contactId, lname);
            Console.WriteLine("Updation Successful!!!");
        }

        public static void DeleteContact()
        {
            Console.WriteLine("Enter the user Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            StaffManagement.DeleteContact(userId, contactId);
            Console.WriteLine("Deletion Successful!!");
        }

        public static void AddContactDetail()
        {
            Console.WriteLine("Enter the user Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact detail Id");
            int detailId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the type of detail(Number/Email)?");
            string type = Console.ReadLine();
            StaffManagement.AddContactDetails(userId, contactId, detailId, type);
            Console.WriteLine("Contact Detail Added Successfully!!!");
        }

        public static void DisplayContactDetails()
        {
            Console.WriteLine("Enter the user Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            var contactDetails = StaffManagement.DisplayDetails(userId, contactId);
            contactDetails.ForEach(details => Console.WriteLine(details));

        }

        public static void UpdateContactDetails()
        {
            Console.WriteLine("Enter the user Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Detail Id");
            int detailId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the type of Detail");
            string type = Console.ReadLine();
            StaffManagement.UpdateDetails(userId, contactId, detailId, type);
            Console.WriteLine("Successful Updation of Contact Details");
        }

        public static void DeleteContactDetails()
        {
            Console.WriteLine("Enter the user Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Detail Id");
            int detailId = Convert.ToInt32(Console.ReadLine());
            StaffManagement.DeleteDetails(userId, contactId, detailId);
            Console.WriteLine("Successful Deletion Of Details");
        }
    }
}
