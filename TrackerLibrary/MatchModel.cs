using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class MatchModel
    {
        public List<MatchRegistry> Entries { get; set; } = new List<MatchRegistry>();
        public TeamModel Winner { get; set; }
        public int MatchRound { get; set; }
    }
}
