using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class TextFileConnector : IDataConnection
    {
        // TODO - Implement method and use Linq to save CreatePrize information to text file
        /// <summary>
        /// Stores prize information to text file 
        /// </summary>
        /// <param name="model">saves prize information</param>
        /// <returns>prize information including unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // sample code
            model.Id = 1;
            
            return model;
        }
    }
}
