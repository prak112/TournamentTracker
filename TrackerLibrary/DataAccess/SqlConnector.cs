using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private const string db = "Tournaments";


        // INSERT DATA TO TABLES

        #region INSERT DATA TO TABLE methods
        /// <summary>
        /// Inserts new member information to People table 
        /// </summary>
        /// <param name="model">personal information of member</param>
        /// <returns>Id and Registration date of inserted personal information</returns>
        public PersonModel CreatePerson(PersonModel model)
        {
            // interface template to open-close database connection
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnString(db)))
            {
                // declare parameters with value and add as list items
                var personData = new DynamicParameters();
                personData.Add("@FirstName", model.FirstName);
                personData.Add("@LastName", model.LastName);
                personData.Add("@Phone", model.PhoneNumber);
                personData.Add("@Email", model.Email);
                // id, RegistrationDate columns to be populated by SQL Server
                personData.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                personData.Add("@RegistrationDate", DateTime.Now, dbType: DbType.DateTime2, direction: ParameterDirection.Output);

                // execute stored procedure
                conn.Execute("dbo.spPeople_InsertData", personData, commandType: CommandType.StoredProcedure);

                // retrieve set id, RegistrationDate
                model.Id = personData.Get<int>("@id");
                model.RegistrationDate = personData.Get<DateTime>("@RegistrationDate");

            }// prevents memory leaks, i.e., connection closes after block executed

            return model;
        }


        /// <summary>
        /// Inserts new prize information to Prizes table
        /// </summary>
        /// <param name="model">prize information</param>
        /// <returns>prize information including unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // interface template to open-close database connection
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnString(db)))
            {
                // declare parameters with value and add as list items
                var prizeData = new DynamicParameters();
                prizeData.Add("@Position", model.Position);
                prizeData.Add("@PositionName", model.PositionName);
                prizeData.Add("@PrizeAmount", model.PrizeAmount);
                prizeData.Add("@PrizePercentage", model.PrizePercentage);
                // unique identifier set by SQL Server 
                prizeData.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // execute stored procedure
                conn.Execute("dbo.spPrizes_InsertData", prizeData, commandType: CommandType.StoredProcedure);

                // retrieve set id
                model.Id = prizeData.Get<int>("@id");
            }// prevents memory leaks, i.e., connection closes after block executed

            return model;
        }

        /// <summary>
        /// Insert Team information to Teams and TeamMembers tables
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TeamModel CreateTeam(TeamModel model)
        {
            // interface template to open-close database connection
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnString(db)))
            {
                // declare parameters with values to be stored in Teams table
                var teamData = new DynamicParameters();
                teamData.Add("@TeamName", model.TeamName);
                // unique identifier set by SQL Server 
                teamData.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // execute stored procedure
                conn.Execute("dbo.spTeams_InsertData", teamData, commandType: CommandType.StoredProcedure);

                // retrieve set id
                model.Id = teamData.Get<int>("@id");

                // loop the TeamMembers list to be stored in TeamMembers table
                foreach (PersonModel member in model.TeamMembers)
                {
                    teamData = new DynamicParameters();
                    teamData.Add("@TeamId", model.Id);
                    teamData.Add("@PersonId", member.Id);
                    teamData.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);

                    conn.Execute("dbo.spTeamMembers_InsertData", teamData, commandType: CommandType.StoredProcedure);
                }

            }// prevents memory leaks, i.e., connection closes after block executed
            return model;
        }


        /// <summary>
        /// Insert Tournament data to Tournaments, TournamentEntries and TournamentPrizes tables
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public TournamentModel CreateTournament(TournamentModel model)
        {
            // interface template to open-close database connection
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnString(db)))
            {
                // Insert to Tournaments table
                // id, TournamentName, EntryFee
                SaveTournament(conn, model);

                // Insert to TournamentEntries table
                // id, TournamentId, TeamId
                SaveTournamentEntries(conn, model);

                // Insert to TournamentPrizes table
                // id, TournamentId, PrizeId
                SaveTournamentPrizes(conn, model);

            }
            return model;
        } 

        /// <summary>
        /// CreateTournament helper method-to save basic data
        /// </summary>
        /// <param name="conn">db connection string</param>
        /// <param name="model">tournament form data</param>
        private void SaveTournament(IDbConnection conn, TournamentModel model)
        {
            // Insert to Tournaments table
            // id, TournamentName, EntryFee
            var tournamentData = new DynamicParameters();
            tournamentData.Add("@TournamentName", model.TournamentName);
            tournamentData.Add("@EntryFee", model.EntryFee);
            tournamentData.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            conn.Execute("dbo.spTournaments_InsertData", tournamentData, commandType: CommandType.StoredProcedure);

            model.Id = tournamentData.Get<int>("@id");
        }
        
        /// <summary>
        /// CreateTournament helper method-to save teams data
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="model"></param>
        private void SaveTournamentEntries(IDbConnection conn, TournamentModel model)
        {
            foreach (TeamModel team in model.Teams)
            {
                var tournamentData = new DynamicParameters();
                tournamentData.Add("@TournamentId", model.Id);
                tournamentData.Add("@TeamId", team.Id);
                tournamentData.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                conn.Execute("dbo.spTournamentEntries_InsertData", tournamentData, commandType: CommandType.StoredProcedure);
            }
        }
        
        /// <summary>
        /// CreateTournament helper method-to save prizes data
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="model"></param>
        private void SaveTournamentPrizes(IDbConnection conn, TournamentModel model)
        {
            // Insert to TournamentPrizes table
            // id, TournamentId, PrizeId
            foreach (PrizeModel prize in model.Prizes)
            {
                var tournamentData = new DynamicParameters();
                tournamentData.Add("@TournamentId", model.Id);
                tournamentData.Add("@PrizeId", prize.Id);
                tournamentData.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                conn.Execute("dbo.spTournamentPrizes_InsertData", tournamentData, commandType: CommandType.StoredProcedure);
            }
        }
        
        #endregion


        // GET DATA FROM TABLES

        #region GET DATA FROM TABLE methods
        /// <summary>
        /// Activate stored procedure to retrieve data from People table
        /// </summary>
        /// <returns>query result with all data of Persons</returns>
        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output = new List<PersonModel>();

            // interface template to open-close database connection
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnString(db)))
            {
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").AsList();
            }// prevents memory leaks, i.e., connection closes after block executed
            return output;
        }

        /// <summary>
        /// Activate stored procedure to retrieve data from Prizes table
        /// </summary>
        /// <returns>query result with all data of Prizes</returns>
        public List<PrizeModel> GetPrize_All()
        {
            List<PrizeModel> output = new List<PrizeModel>();

            // interface template to open-close database connection
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnString(db)))
            {
                output = connection.Query<PrizeModel>("dbo.spPrizes_GetAll").AsList();
            }
            return output;
        }

        /// <summary>
        /// Activate stored procedure to retrieve data from Teams table
        /// </summary>
        /// <returns>Query result with all data of Teams</returns>        
        public List<TeamModel> GetTeam_All()
        {
            List<TeamModel> output = new List<TeamModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnString(db)))
            {
                output = connection.Query<TeamModel>("dbo.spTeams_GetAll").AsList();
            }
            return output;
        } 
        #endregion
    }        

}
