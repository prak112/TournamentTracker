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
        /// Load existing file from data to List<>, if file doesn't exist creates new List<>
        /// </summary>
        /// <param name="file">Full filepath</param>
        /// <returns>textfile converted to List or empty List</returns>
        public static List<string> ReadFileToList(this string file) 
        {
            if (!File.Exists(file)) 
            {
                return new List<string>();
            }
            return File.ReadAllLines(file).ToList();
        }


        // LOAD DATA TO MODEL OBJECT

        /// <summary>
        /// Read textData from List, load data to Model object
        /// </summary>
        /// <param name="textData">text retrieved from file</param>
        /// <returns>Model object with data, or empty Model object if no data to load</returns>
        public static List<PrizeModel> LoadDataToPrizeModel(this List<string> textData)
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
        /// Read textData from List, load data to Model object
        /// </summary>
        /// <param name="textData">data read from file to List</param>
        /// <returns>Model object loaded with data, empty object if no data</returns>
        public static List<PersonModel> LoadDataToPersonModel(this List<string> textData)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in textData)
            {
                // split lines
                string[] columns = line.Split(',');

                // pack split data into Model
                PersonModel personData = new PersonModel();
                personData.Id = int.Parse(columns[0]);
                personData.FirstName = columns[1];
                personData.LastName = columns[2];
                personData.Email = columns[3];
                personData.PhoneNumber = columns[4];
                personData.RegistrationDate = DateTime.Parse(columns[5]);

                output.Add(personData);
            }
            return output;
        }


        // SAVE DATA TO TEXT FILE

        /// <summary>
        /// Save updated PrizeModel data to text file
        /// </summary>
        /// <param name="models">All Prizes data packed into Model</param>
        /// <param name="fileName">File to be updated</param>
        public static void SaveDataToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            // intialize List<string> to write Model data
            List<string> modelsData = new List<string>();

            // loop data of each Model, add to List<string>
            foreach (var model in models)
            {
                modelsData.Add($"{ model.Id },{ model.Position },{ model.PositionName },{ model.PrizeAmount },{ model.PrizePercentage }");
            }
            // write data from List<string> to given fileName
            File.WriteAllLines(fileName.GetFilePath(), modelsData);
        }

        /// <summary>
        /// Save updated PersonModel data to text file
        /// </summary>
        /// <param name="models">All Persons data packed into Model</param>
        /// <param name="fileName">File to be updated/overwritten</param>
        public static void SaveDataToPeopleFile(this List<PersonModel> models, string fileName)
        {
            // intialize List<string> to write Model data
            List<string> modelsData = new List<string>();

            // loop data of each Model, add to List<string>
            foreach (var model in models)
            {
                modelsData.Add($"{ model.Id },{ model.FirstName },{ model.LastName },{ model.Email },{ model.PhoneNumber },{ model.RegistrationDate }");
            }
            // write data from List<string> to given fileName
            File.WriteAllLines(fileName.GetFilePath(), modelsData);
        }
    }
}

