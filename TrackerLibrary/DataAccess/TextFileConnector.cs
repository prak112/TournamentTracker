using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextDataProcessors;

namespace TrackerLibrary.DataAccess
{
    public class TextFileConnector : IDataConnection
    {
        private const string PrizeDataFile = "PrizeModels.csv";

        /// <summary>
        /// Stores prize information to text file 
        /// </summary>
        /// <param name="model">saves prize information</param>
        /// <returns>prize information including unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // read text file, convert list data to List<PrizeModel>
            List<PrizeModel> prizeModels = PrizeDataFile.GetFilePath().ReadFileToList().LoadDataToModel();

            // scan for max(Id), add 1, assign max(Id)+1 to next record
            int currentId = 1;
            if (prizeModels.Count > 0)
            {
                currentId = prizeModels.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            model.Id = currentId;
            
            // add record with new Id to Model
            prizeModels.Add(model);

            // save Models data to Text File
            prizeModels.SaveDataToPrizesFile(PrizeDataFile);

            // updated Id value for reference
            return model;
        }
    }
}
