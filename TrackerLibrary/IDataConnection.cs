using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public interface IDataConnection //every item inside Interface are public 
    {
        PrizeModel CreatePrize(PrizeModel model);
    }
}
