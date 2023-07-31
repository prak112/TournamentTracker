using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents a single person in team
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Represent name of team member
        /// </summary>
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        
        /// <summary>
        /// Represent contact details OF team member
        /// </summary>
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
