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

                // pack split data into Model's variables
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
        /// Read textData from List, load persons data to Model
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

                // pack split data into Model's variables
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

        /// <summary>
        /// Read text data from List, load teams data to Model
        /// </summary>
        /// <param name="textData">data from text file, TeamsDataFile.csv</param>
        /// <param name="peopleFileName">text file to retrieve personId</param>
        /// <returns>Model object with updated data, empty object if no data</returns>
        public static List<TeamModel> LoadDataToTeamModel(this List<string> textData, string peopleFileName)
        {
            // pack split data into Model's variables
            // Example : data format -> id, name, team members' id seperated by '|'
            // Example : data ->        3, Revengers, 1|3|4
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = peopleFileName.GetFilePath().ReadFileToList().LoadDataToPersonModel();

            foreach (string line in textData)
            {
                // split data
                string[] columns = line.Split(',');
                TeamModel teamData = new TeamModel();

                // load text data into model properties
                teamData.Id = int.Parse(columns[0]);
                teamData.TeamName = columns[1];

                // load personId from people List
                string[] personIds = columns[2].Split('|');
                foreach (string personId in personIds)
                {
                    // verify TeamMember Ids with people List
                    teamData.TeamMembers.Add(people.Where(x => x.Id == int.Parse(personId)).FirstOrDefault());
                }
                // load packed data to Model
                output.Add(teamData);
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
                modelsData.Add($"{model.Id}, {model.Position}, {model.PositionName}, {model.PrizeAmount}, {model.PrizePercentage}");
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
                modelsData.Add($"{model.Id}, {model.FirstName}, {model.LastName}, {model.Email}, {model.PhoneNumber}, {model.RegistrationDate}");
            }
            // write data from modelsData to fileName
            File.WriteAllLines(fileName.GetFilePath(), modelsData);
        }

        /// <summary>
        /// Save updated TeamModel data to text file
        /// </summary>
        /// <param name="models">All Teams data packed to Model</param>
        /// <param name="fileName">File to update or overwrite</param>
        public static void SaveDataToTeamsFile(this List<TeamModel> models, string fileName)
        {
            List<string> modelsData = new List<string>();

            foreach (var model in models)
            {
                modelsData.Add($"{model.Id}, {model.TeamName}, {ConvertTeamMembersListToString(model.TeamMembers)}");
            }
            // write data from modelsData to fileName
            File.WriteAllLines (fileName.GetFilePath(), modelsData);

        }
        /// <summary>
        /// Helper method to delimit TeamMembers list with '|'
        /// </summary>
        /// <param name="people">TeamMembers data saved in PersonModel format</param>
        /// <returns>TeamMember Ids concat with '|' as string</returns>
        private static string ConvertTeamMembersListToString(List<PersonModel> people)
        {
            if (people.Count == 0)
            {
                return string.Empty;
            }
            
            // if people is NOT empty
            string output = "";
            foreach (var person in people)      // loop to append each personId with '|'
            {
                output += $"{person.Id}|";
            }
            output = output.Substring(0, output.Length - 1);    // un-append '|' for last item
            return output;
        }
    }
}

