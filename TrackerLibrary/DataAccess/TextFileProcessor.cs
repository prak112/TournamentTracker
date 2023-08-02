using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextDataProcessors
{
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
        public static List<string> ReadFileToList(this string file) 
        {
            if (!File.Exists(file)) 
            {
                return new List<string>();
            }
            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// Read and load data to Model object
        /// </summary>
        /// <param name="textData">text retrieved from file</param>
        /// <returns>Model object with data, or empty Model object if no data to load</returns>
        public static List<PrizeModel> LoadDataToModel(this List<string> textData)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in textData)
            {
                // split lines
                string[] columns = line.Split(',');

                // pack split data into Model
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

        /// <summary>
        /// Save updated PrizeModel data to text file
        /// </summary>
        /// <param name="models">All PrizeModel data packed</param>
        /// <param name="fileName">File to be updated</param>
        public static void SaveDataToPrizesFile(this List<PrizeModel> models, string fileName)
        {
            List<string> modelsData = new List<string>();

            foreach (var model in models)
            {
                modelsData.Add($"{ model.Id }, { model.Position }, { model.PositionName }, { model.PrizeAmount }, { model.PrizePercentage }");
            }
            File.WriteAllLines(fileName.GetFilePath(), modelsData);
        }




    }
}

