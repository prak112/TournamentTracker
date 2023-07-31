using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        public PrizeModel()
        {
            
        }

        public PrizeModel(string position, string positionName, string prizeAmount, string prizePercentage)
        {

            int positionValue = 0;
            int.TryParse(position, out positionValue);
            Position = positionValue;

            PositionName = positionName;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;

        }

        /// <summary>
        /// Represents unique identifier for every prize
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents position of team
        /// </summary>
        public int Position { get; set; }
        
        /// <summary>
        /// Represents label of the position of team
        /// </summary>
        public string PositionName { get; set; }
        
        /// <summary>
        /// Represents prize money for team, either 0 or some amount
        /// </summary>
        public decimal PrizeAmount { get; set; }
        
        /// <summary>
        /// Percentage of prize money for team, represented as fraction of 1, i.e., 0.1 is 10%
        /// It is either 0 or some fraction
        /// </summary>
        public double PrizePercentage { get;set; }
    }
}
