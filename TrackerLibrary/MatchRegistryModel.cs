using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class MatchRegistryModel
    {
        /// <summary>
        /// Represents one team in the Match
        /// </summary>
        public TeamModel CompetingTeam { get; set; }

        /// <summary>
        /// Represents score of the CompetingTeam
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Represents the Match the CompetingTeam won previously
        /// </summary>
        public MatchModel ParentMatch { get; set; }


    }
}
