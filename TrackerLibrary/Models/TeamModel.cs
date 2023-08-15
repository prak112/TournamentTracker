using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TeamModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Represents list of member Ids in team
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();
        
        /// <summary>
        /// Represents name of team
        /// </summary>
        public string TeamName { get; set; }
    }
}
