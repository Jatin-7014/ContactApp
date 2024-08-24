using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class ContactDetail
    {
        public int ContactDetailsId {  get; set; }
        public string Type {  get; set; }
        public ContactDetail(int id,string type)
        {
            ContactDetailsId=id;
            Type=type;
        }
        public override string ToString()
        {
            return $"Contact Details Id: {ContactDetailsId}\n" +
                $"Type:{Type}\n";
        }
    }
}
