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
        /// Unique identifier for every tournament entry
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// tournament name with sport-gender such as volleyball-women
        /// </summary>
        public string TournamentName { get; set; }
        
        /// <summary>
        /// amount charged to team to enter tournament
        /// </summary>
        public decimal EntryFee { get; set; }
        
        /// <summary>
        /// list of teams entered
        /// </summary>
        public List<TeamModel> Teams { get; set; } = new List<TeamModel>();
        
        //public List<MatchModel> Matches { get; set; } = new List<MatchModel>();
        
        /// <summary>
        /// list of prizes for winner or podium positions
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        
        /// <summary>
        /// list of matches in current round
        /// </summary>
        public List<List<MatchModel>> Rounds { get; set; } = new List<List<MatchModel>>(); 
    }
}
