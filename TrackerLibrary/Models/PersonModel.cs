using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents a single person in team
    /// </summary>
    public class PersonModel
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Represent name of team member
        /// </summary>
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        /// <summary>
        /// Represent contact details of team member
        /// </summary>
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
