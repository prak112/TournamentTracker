using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchRegistryModel
    {
        /// <summary>
        /// unique identifier for each record
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Team data of one of the competing teams in the Match
        /// </summary>
        public TeamModel CompetingTeam { get; set; }

        /// <summary>
        /// score of the CompetingTeam
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// MatchId of the CompetingTeam which won previously
        /// </summary>
        public MatchModel ParentMatch { get; set; }


    }
}