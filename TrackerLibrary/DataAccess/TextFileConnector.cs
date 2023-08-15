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
        private const string TeamsDataFile = "TeamsData.csv";

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

            // add new record to Model
            personsModel.Add(model);

            // save Model data to PeopleDataFile
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
            
            // add new record to Model
            prizeModels.Add(model);

            // save Model data to PrizeDataFile
            prizeModels.SaveDataToPrizeFile(PrizeDataFile);

            // updated model for reference
            return model;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            // read text file, convert list data to List<TeamModel>
            List<TeamModel> teamModels  = TeamsDataFile.GetFilePath().ReadFileToList().LoadDataToTeamModel(PeopleDataFile);

            // scan for max(Id), add 1, assign max(Id)+1 to next record
            int currentId = 1;
            if (teamModels.Count > 0)
            {
                currentId = teamModels.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            model.Id= currentId;
            
            // add new record to Model
            teamModels.Add(model);
            
            // save Model data to TeamsDataFile
            teamModels.SaveDataToTeamsFile(TeamsDataFile);

            return model;
        }

        /// <summary>
        /// Retrieve all people data from PersonsData.csv
        /// </summary>
        /// <returns></returns>
        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> persons = PeopleDataFile.GetFilePath().ReadFileToList().LoadDataToPersonModel();
            return persons;
        }

        /// <summary>
        /// Retrieve all teams data from TeamsData.csv
        /// </summary>
        /// <returns></returns>
        public List<TeamModel> GetTeam_All()
        {
            List<TeamModel> teams = TeamsDataFile.GetFilePath().ReadFileToList().LoadDataToTeamModel(PeopleDataFile);
            return teams;
        }
    }
}
