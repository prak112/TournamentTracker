using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// Store connection strings of storage units (databases, csv)
        /// </summary>
        public static List<IDatatConnection> Connections { get; private set; } = new List<IDatatConnection>();

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
    }
}
