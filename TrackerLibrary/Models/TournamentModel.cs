using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TournamentModel
    {
        /// <summary>
        /// Represents name of tournament, sport-gender such as volleyball-women
        /// </summary>
        public string TournamentName { get; set; }
        
        /// <summary>
        /// Represents amount charged to team to enter tournament
        /// </summary>
        public decimal EntryFee { get; set; }
        
        /// <summary>
        /// Represents list of teams entered
        /// </summary>
        public List<TeamModel> Teams { get; set; } = new List<TeamModel>();
        
        //public List<MatchModel> Matches { get; set; } = new List<MatchModel>();
        
        /// <summary>
        /// Represents list of prizes for winner or podium positions
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        
        /// <summary>
        /// Represents list of matches in current round
        /// </summary>
        public List<List<MatchModel>> Rounds { get; set; } = new List<List<MatchModel>>(); 
    }
}
