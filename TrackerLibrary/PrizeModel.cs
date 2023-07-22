using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class PrizeModel
    {
        public int Position { get; set; }
        public string PositionName { get; set; }
        public decimal PrizeAmount { get; set; }
        public string PrizePercentage { get;set; }
    }
}
