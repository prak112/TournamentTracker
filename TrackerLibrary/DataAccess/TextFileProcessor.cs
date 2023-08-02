using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextFileConnector
{
    // load text file --V
    // convert data to list<PrizeModel> --V
    // read and check id,
    // assign id = max+1 for new prize
    // save model,
    // convert list<PrizeModel> to text file



    /// <summary>
    /// Different levels of processing data from text files
    /// </summary>
    public static class TextFileProcessor
    {
        /// <summary>
        /// Get full filepath using filename
        /// </summary>
        /// <param name="fileName">text file name like, PrizeModel.csv</param>
        /// <returns>Concatenated filepath like, D:\GitHub_Projects\TournamentTracker\data\PrizeModel.csv</returns>
        public static string GetFilePath(this string fileName)
        {   
            string filePath = $"{ConfigurationManager.AppSettings["filepath"]}\\{fileName}";
            return filePath;
        }

        /// <summary>
        /// Load existing file to list, if not exist create new list
        /// </summary>
        /// <param name="file">Full filepath</param>
        /// <returns>textfile converted to list or empty list</returns>
        public static List<string> LoadFileToList(this string file) 
        {
            if (!File.Exists(file)) 
            {
                return new List<string>();
            }
            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// read and load data to list
        /// </summary>
        /// <param name="textData"></param>
        /// <returns></returns>
        public static List<PrizeModel> LoadDataToList(this List<string> textData)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in textData)
            {
                // split lines
                string[] columns = line.Split(',');

                // pack split data
                PrizeModel prizeData = new PrizeModel();                
                prizeData.Id = int.Parse(columns[0]);
                prizeData.Position = int.Parse(columns[1]);
                prizeData.PositionName = columns[2];
                prizeData.PrizeAmount = decimal.Parse(columns[3]);
                prizeData.PrizePercentage = double.Parse(columns[4]);

                output.Add(prizeData);
            }
            return output;
        }

    }
}

