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
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();


        /// <summary>
        /// To intialize all possible data source connections for data storage
        /// </summary>
        /// <param name="database">Enable if saving to Database</param>
        /// <param name="textFiles">Enable if saving to Text File</param>
        public static void InitializeConnections(bool database, bool textFiles)
        {
            if (database)
            {
                // TODO - Setup SqlConnector
                SqlConnector sqlConnector = new SqlConnector();
                Connections.Add(sqlConnector);
            }
            if (textFiles)
            {
                // TODO - Setup TextFileConnector
                TextFileConnector textFileConnector = new TextFileConnector();
                Connections.Add(textFileConnector);
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
