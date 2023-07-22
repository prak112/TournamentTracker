using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
