using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class PrizeModel
    {
        /// <summary>
        /// Represents position of team
        /// </summary>
        public int Position { get; set; }
        
        /// <summary>
        /// Represents label of the position of team
        /// </summary>
        public string PositionName { get; set; }
        
        /// <summary>
        /// Represents prize money for team
        /// </summary>
        public decimal PrizeAmount { get; set; }
        
        /// <summary>
        /// Represents percentage of prize money for team
        /// </summary>
        public string PrizePercentage { get;set; }
    }
}
