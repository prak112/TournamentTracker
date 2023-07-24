using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class MatchModel
    {
        /// <summary>
        /// Represents names of competing teams for the current match
        /// </summary>
        public List<MatchRegistryModel> Entries { get; set; } = new List<MatchRegistryModel>();
        
        /// <summary>
        /// Represents winner team of the current match
        /// </summary>
        public TeamModel Winner { get; set; }
        
        /// <summary>
        /// Represents current round of match
        /// </summary>
        public int MatchRound { get; set; }
    }
}
