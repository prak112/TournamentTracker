using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchModel
    {
        /// <summary>
        /// unique identifier for every match
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// competing teams for the current match
        /// </summary>
        public List<MatchRegistryModel> Entries { get; set; } = new List<MatchRegistryModel>();
        
        /// <summary>
        /// winner team of the current match
        /// </summary>
        public TeamModel Winner { get; set; }
        
        /// <summary>
        /// current round of match
        /// </summary>
        public int MatchRound { get; set; }
    }
}
