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
        private const string PrizeDataFile = "PrizesData.csv";
        private const string PeopleDataFile = "PersonsData.csv";

        /// <summary>
        /// Process Team member information and store to PeopleDataFile.csv
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PersonModel CreatePerson(PersonModel model)
        {
            // read text file, convert list data to List<PersonModel>
            List<PersonModel> personsModel = PeopleDataFile.GetFilePath().ReadFileToList().LoadDataToPersonModel();

            // scan for max(Id), add 1, assign max(Id)+1 to next record
            int currentId = 1;
            if (personsModel.Count > 0)
            {
                currentId = personsModel.OrderByDescending(p => p.Id).FirstOrDefault().Id + 1;
            }
            model.Id = currentId;

            // add record with new Id to Model
            personsModel.Add(model);

            // save Models data to PeopleDataFile
            personsModel.SaveDataToPeopleFile(PeopleDataFile);

            // updated model for reference
            return model;
        }


        /// <summary>
        /// Process Tournament Prize information and store to PrizeDataFile.csv
        /// </summary>
        /// <param name="model">saves prize information</param>
        /// <returns>prize information including unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // read text file, convert list data to List<PrizeModel>
            List<PrizeModel> prizeModels = PrizeDataFile.GetFilePath().ReadFileToList().LoadDataToPrizeModel();

            // scan for max(Id), add 1, assign max(Id)+1 to next record
            int currentId = 1;
            if (prizeModels.Count > 0)
            {
                currentId = prizeModels.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            model.Id = currentId;
            
            // add record with new Id to Model
            prizeModels.Add(model);

            // save Models data to PrizeDataFile
            prizeModels.SaveDataToPrizeFile(PrizeDataFile);

            // updated model for reference
            return model;
        }
    }
}
