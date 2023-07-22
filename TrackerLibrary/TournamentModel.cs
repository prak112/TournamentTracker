using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class TournamentModel
    {
        public string TournamentName { get; set; }
        public decimal EntryFee { get; set; }
        public List<TeamModel> Teams { get; set; } = new List<TeamModel>();
        //public List<MatchModel> Matches { get; set; } = new List<MatchModel>();
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        public List<List<MatchModel>> Rounds { get; set; } = new List<List<MatchModel>>(); 
    }
}
