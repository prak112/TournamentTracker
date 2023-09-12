using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;


namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// Store connection strings of storage units (databases, csv)
        /// </summary>
        public static IDataConnection Connection { get; private set; }

        /// <summary>
        /// Textfile storage for each Model
        /// </summary>
        public const string PrizesDataFile = "PrizeModels.csv";
        public const string PeopleDataFile = "PersonModels.csv";
        public const string TeamsDataFile = "TeamModels.csv";
        public const string TournamentsDataFile = "TournamentModels.csv";
        public const string MatchDataFile = "MatchModels.csv";
        public const string MatchRegistryDataFile = "MatchRegistryModels.csv";

        /// <summary>
        /// To intialize all possible data source Connection for data storage
        /// </summary>
        /// <param name="database">Enable if saving to Database</param>
        /// <param name="textFiles">Enable if saving to Text File</param>
        public static void InitializeConnection(DatabaseType db)
        {
            switch (db)
            {
                case DatabaseType.SqlDb:
                    // create SQL connection object
                    SqlConnector sql = new SqlConnector();
                    Connection = sql;
                    break;

                case DatabaseType.TextFile:
                    // setup text file connection
                    TextFileConnector text = new TextFileConnector();
                    Connection = text;
                    break;

                default:
                    break;
            }
        }

        
        /// <summary>
        /// To connect to specific database
        /// </summary>
        /// <param name="name">Name of the database</param>
        /// <returns>Connection string to connect with the database</returns>
        public static string ConnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;

        }
    }

    
}
