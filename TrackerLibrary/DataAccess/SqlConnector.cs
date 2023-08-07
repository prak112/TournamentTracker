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

        // TODO - Stored Procedures for all tables

        /// <summary>
        /// Inserts new prize information to Prizes table in Tournaments database 
        /// </summary>
        /// <param name="model">personal information of member</param>
        /// <returns>Id and Registration date of inserted personal information</returns>
        public PersonModel CreatePerson(PersonModel model)
        {
            // interface template to open database connection
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnString("Tournaments")))
            {
                // declare parameters with value and add as list items
                var personData = new DynamicParameters();
                personData.Add("@FirstName", model.FirstName);
                personData.Add("@LastName", model.LastName);
                personData.Add("@Phone", model.PhoneNumber);
                personData.Add("@Email", model.Email);
                // id, RegistrationDate columns to be populated by SQL Server
                personData.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                personData.Add("@RegistrationDate", DateTime.Now, dbType: DbType.DateTime2, direction:ParameterDirection.Output);

                // execute stored procedure
                conn.Execute("dbo.spPeople_InsertData", personData, commandType: CommandType.StoredProcedure);

                // retrieve set id, RegistrationDate
                model.Id = personData.Get<int>("@id");
                model.RegistrationDate = personData.Get<DateTime>("@RegistrationDate");

            }// prevents memory leaks, i.e., connection closes after block executed

            return model;
        }


        /// <summary>
        /// Inserts new prize information to Prizes table in Tournaments database
        /// </summary>
        /// <param name="model">prize information</param>
        /// <returns>prize information including unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // interface template to open database connection
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnString("Tournaments")))
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


    }        

}
