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
        /// <summary>
        /// Stores new prize information to database
        /// </summary>
        /// <param name="model">prize information</param>
        /// <returns>prize information including unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // interface template to open connection to Database server
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
    }        // TODO - Stored Procedures for all tables

}
