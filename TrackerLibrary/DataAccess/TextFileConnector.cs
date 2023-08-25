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
        private const string PrizesDataFile = "PrizesData.csv";
        private const string PeopleDataFile = "PersonsData.csv";
        private const string TeamsDataFile = "TeamsData.csv";
        private const string TournamentsDataFile = "TournamentsData.csv";


        #region PROCESS MODEL DATA AND SAVE TO FILE methods
        /// <summary>
        /// Process Team member information and save to PeopleDataFile
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
        /// Process Tournament Prize information and save to PrizesDataFile
        /// </summary>
        /// <param name="model">saves prize information</param>
        /// <returns>prize information including unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // read text file, convert list data to List<PrizeModel>
            List<PrizeModel> prizeModels = PrizesDataFile.GetFilePath().ReadFileToList().LoadDataToPrizeModel();

            // scan for max(Id), add 1, assign max(Id)+1 to next record
            int currentId = 1;
            if (prizeModels.Count > 0)
            {
                currentId = prizeModels.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            model.Id = currentId;

            // add new record to Model
            prizeModels.Add(model);

            // save Model data to PrizesDataFile
            prizeModels.SaveDataToPrizeFile(PrizesDataFile);

            // updated model for reference
            return model;
        }

        /// <summary>
        /// Process Team data and save to TeamsDataFile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TeamModel CreateTeam(TeamModel model)
        {
            // read text file, convert list data to List<TeamModel>
            List<TeamModel> teamModels = TeamsDataFile.GetFilePath().ReadFileToList().LoadDataToTeamModel(PeopleDataFile);

            // scan for max(Id), add 1, assign max(Id)+1 to next record
            int currentId = 1;
            if (teamModels.Count > 0)
            {
                currentId = teamModels.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            model.Id = currentId;

            // add new record to Model
            teamModels.Add(model);

            // save Model data to TeamsDataFile
            teamModels.SaveDataToTeamsFile(TeamsDataFile);

            return model;
        }


        /// <summary>
        /// Process Tournament data and save to TournamentsDataFile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public TournamentModel CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournamentModels = TournamentsDataFile
                .GetFilePath()
                .ReadFileToList()
                .LoadDataToTournamentModel(PeopleDataFile, TeamsDataFile, PrizesDataFile);

            // scan for max(Id), add 1, assign max(Id)+1 to next record
            int currentId = 1;
            if (tournamentModels.Count > 0)
            {
                currentId = tournamentModels.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            model.Id = currentId;

            // add new record to Model
            tournamentModels.Add(model);

            // save Model data to TournamentsDataFile
            tournamentModels.SaveDataToTournamentsFile(TournamentsDataFile);

            return model; // not neccessary in all methods so far in TextFileConnector, to be changed from IDataConnection
        } 
        #endregion


        #region GET DATA FROM FILE methods
        /// <summary>
        /// Retrieve all people data from PersonsData.csv
        /// </summary>
        /// <returns></returns>
        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> persons = PeopleDataFile.GetFilePath().ReadFileToList().LoadDataToPersonModel();
            return persons;
        }

        public List<PrizeModel> GetPrize_All()
        {
            List<PrizeModel> prizes = PrizesDataFile.GetFilePath().ReadFileToList().LoadDataToPrizeModel();
            return prizes;
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
        #endregion
    }
}
