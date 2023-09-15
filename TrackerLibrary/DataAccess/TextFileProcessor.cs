using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextDataProcessors
{
    /// <summary>
    /// Different levels of processing data from text files
    /// </summary>
    public static class TextFileProcessor
    {
        #region PROCEDURAL STORAGE METHODS
        
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

        #endregion

        // LOAD DATA TO MODEL OBJECT

        #region LOAD TEXT FILE DATA TO MODEL methods
        
        /// <summary>
        /// Read textData from List, load prizes data to Model
        /// </summary>
        /// <param name="textData">data retrieved from PrizeModels.csv to List</param>
        /// <returns>Model object with data, or empty Model object if no data to load</returns>
        public static List<PrizeModel> LoadDataToPrizeModel(this List<string> textData)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in textData)
            {
                // split lines
                string[] columns = line.Split(',');

                // pack split entries into Model's properties
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
        /// <param name="textData">data read from PersonModels.csv to List</param>
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
        /// Read textData from List, load teams data to Model
        /// </summary>
        /// <param name="textData">data from TeamModels.csv to List</param>
        /// <param name="peopleFileName">PersonModels.csv to retrieve personId</param>
        /// <returns>Model with updated data, empty object if no data</returns>
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

              
        /// <summary>
        /// Read textData from List, load matches data to Model
        /// </summary>
        /// <param name="textData">data from MatchModels.csv to List</param>
        /// <returns>Model with updated data, empty object if no data</returns>
        public static List<MatchModel> LoadDataToMatchModel(this List<string> textData)
        {
            List<MatchModel> output = new List<MatchModel>();
            
            // loop through textData entries
            foreach (string line in textData)
            {
                // split entries
                string[] columns = line.Split(',');

                // pack split entries into Model's properties
                MatchModel matchData = new MatchModel();
                matchData.Id = int.Parse(columns[0]);
                matchData.Entries = ConvertMatchRegistryStringToList(columns[1]);   // String-To-List conversion
                matchData.Winner = LookUpTeamById(int.Parse(columns[2]));       // TeamModel data
                matchData.MatchRound = int.Parse(columns[3]);
                
                output.Add(matchData);
            }
            return output;
        }
        
        /// <summary>
        /// Read textData from List, load match entries data to Model
        /// </summary>
        /// <param name="textData">data from MatchRegistryModels.csv to List</param>
        /// <returns>Model with updated data, empty object if no data</returns>
        public static List<MatchRegistryModel> LoadDataToMatchRegistryModel(this List<string> textData)
        {
            List<MatchRegistryModel> output = new List<MatchRegistryModel>();

            foreach (string line in textData)
            {
                string[] columns = line.Split(',');
                
                MatchRegistryModel matchEntry = new MatchRegistryModel();
                matchEntry.Id = int.Parse(columns[0]);
                int competingTeam = 0;
                if (int.TryParse(columns[1], out competingTeam))     // CompetingTeam could be null, due to lack of knowledge about future matches
                {
                    matchEntry.CompetingTeam = LookUpTeamById(competingTeam); // TeamModel data
                }
                else
                {
                    matchEntry.CompetingTeam = null;
                }
                
                matchEntry.Score = int.Parse(columns[2]);

                int parentMatchId = 0;
                if (int.TryParse(columns[3], out parentMatchId))
                {
                    matchEntry.ParentMatch = LookUpMatchById(parentMatchId);    // MatchModel data
                }
                else
                {
                    matchEntry.ParentMatch = null;
                }
                output.Add(matchEntry);
            }
            return output;
        }


        /// <summary>
        /// Read textData from TournamentModels.csv to List, load tournaments data to Model
        /// </summary>
        /// <param name="textData">data read from TournamentModels.csv</param>
        /// <param name="peopleFileName">PersonModels.csv to read person data</param>
        /// <param name="TeamsFile">TeamModels.csv to read team data</param>
        /// <param name="PrizesFile">PrizeModels.csv to read prize data</param>
        /// <returns>Model with updated data, empty object if no data</returns>
        public static List<TournamentModel> LoadDataToTournamentModel
            (this List<string> textData, string peopleFileName, string TeamsFile, string PrizesFile)
        {
            // data layout
            // column Index - 0          1            2           3                   4                   5 
            // column name - id, TournamentName, EntryFee, (Teams-Id|Id|Id), (Prizes-Id|Id|Id), (Rounds-id^id^id|id^id^id|id^id^id|)
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = TeamsFile.GetFilePath().ReadFileToList().LoadDataToTeamModel(peopleFileName);
            List<PrizeModel> prizes = PrizesFile.GetFilePath().ReadFileToList().LoadDataToPrizeModel();
            List<MatchModel> matches = GlobalConfig.MatchDataFile.GetFilePath().ReadFileToList().LoadDataToMatchModel();

            foreach (string line in textData)
            {
                string[] columns = line.Split(',');
                TournamentModel tournamentData = new TournamentModel();

                // Tournament data
                tournamentData.Id = int.Parse(columns[0]);
                tournamentData.TournamentName = columns[1];
                tournamentData.EntryFee = decimal.Parse(columns[2]);

                // Teams data
                string[] teamIds = columns[3].Split('|');
                foreach (string teamId in teamIds)
                {
                    tournamentData.Teams.Add(teams.Where(x => x.Id == int.Parse(teamId)).FirstOrDefault());
                }

                // Prizes data
                string[] prizeIds = columns[4].Split('|');
                foreach (string prizeId in prizeIds)
                {
                    tournamentData.Prizes.Add(prizes.Where(x => x.Id == int.Parse(prizeId)).FirstOrDefault());
                }

                // Rounds data
                // split rounds
                string[] rounds = columns[5].Split('|');

                foreach (string round in rounds)
                {
                    // assign matchId to MatchModel object,
                    List<MatchModel> matchesInRound = new List<MatchModel>();
                    // split matches
                    string[] matchIds = round.Split('^');
                    // add object to matchesInRound,
                    foreach (string matchId in matchIds)
                    {
                        MatchModel match = new MatchModel();
                        matchesInRound.Add(matches.Where(x => x.Id == int.Parse(matchId)).FirstOrDefault());
                    }
                    // add matchesInRound to tournamentData
                    tournamentData.Rounds.Add(matchesInRound);
                }
                output.Add(tournamentData);
            }
            return output;
        }


        #endregion



        // SAVE DATA TO TEXT FILE

        #region SAVE MODEL DATA TO TEXT FILE methods


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
                modelsData.Add($"{model.Id},{model.Position},{model.PositionName},{model.PrizeAmount},{model.PrizePercentage}");
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
                modelsData.Add($"{model.Id},{model.FirstName},{model.LastName},{model.Email},{model.PhoneNumber},{model.RegistrationDate}");
            }
            // write data from modelsData to fileName
            File.WriteAllLines(fileName.GetFilePath(), modelsData);
        }

        /// <summary>
        /// Save updated TeamModel data to text file
        /// </summary>
        /// <param name="models">All Teams data packed in Model</param>
        /// <param name="fileName">File to update or overwrite</param>
        public static void SaveDataToTeamsFile(this List<TeamModel> models, string fileName)
        {
            List<string> modelsData = new List<string>();

            foreach (var model in models)
            {
                modelsData.Add($"{model.Id},{model.TeamName},{ConvertTeamMembersListToString(model.TeamMembers)}");
            }
            // write data from modelsData to fileName
            File.WriteAllLines(fileName.GetFilePath(), modelsData);

        }


        // TOURNAMENT DATA - (Matches, MatchEntries, MatchRounds)

        /// <summary>
        /// Save updated TournamentModel data to TournamentsData.csv
        /// </summary>
        /// <param name="models">all tournaments data packed in TournamentModel</param>
        public static void SaveDataToTournamentsFile(this List<TournamentModel> models, string fileName)
        {
            List<string> modelsData = new List<string>();

            // data layout
            // column Index - 0          1            2           3                   4                   5 
            // column name - id, TournamentName, EntryFee, (Teams-Id|Id|Id), (Prizes-Id|Id|Id), (Rounds-id^id|id^id|id^id|)
            foreach (TournamentModel model in models)
            {
                modelsData.Add($@"{model.Id},{model.TournamentName},{model.EntryFee},{ConvertTeamsListToString(model.Teams)},{ConvertPrizesListToString(model.Prizes)},{ConvertRoundsListToString(model.Rounds)}");
            }
            File.WriteAllLines(fileName.GetFilePath(), modelsData);
        }

        /// <summary>
        /// Save Match rounds data to TournamentModels.csv
        /// </summary>
        /// <param name="model">TournamentModel object</param>
        /// <param name="MatchDataFile">MatchModels.csv file</param>
        /// <param name="MatchRegistryDataFile">MatchRegistryModels.csv file</param>
        public static void SaveRoundsToTournamentsFile(this TournamentModel model, string MatchDataFile, string MatchRegistryDataFile)
        {
            foreach (List<MatchModel> round in model.Rounds)
            {
                foreach (MatchModel match in round)
                {
                    // performed by Helper Methods- SaveMatchToMatchesFile, SaveEntryToMatchRegistryFile
                    // (and their subsequent Helper Methods)
                    match.SaveMatchToMatchesFile(MatchDataFile, MatchRegistryDataFile);
                }
            }
        }

        /// <summary>
        /// SaveRoundsToTournamentsFile Helper Method-
        /// save matches to MatchModels.csv, 
        /// save match entries to MatchRegistryModels.csv
        /// </summary>
        /// <param name="match">MatchModel object of the TournamentModel object</param>
        /// <param name="MatchDataFile">MatchModels.csv</param>
        /// <param name="MatchRegistryDataFile">MatchRegistryModels.csv</param>
        public static void SaveMatchToMatchesFile(this MatchModel match, string MatchDataFile, string MatchRegistryDataFile)
        {
            List<MatchModel> matches = GlobalConfig.MatchDataFile.
                                        GetFilePath().ReadFileToList().
                                        LoadDataToMatchModel();
            // scan for max(Id), add 1, assign max(Id)+1 to next record
            int currentId = 1;
            if (matches.Count > 0)
            {
                currentId = matches.OrderByDescending(x => x.Id).First().Id + 1;
            }
            match.Id = currentId;


            // TODO - Resolve ISSUE ChickenFirst-EggFirst problem
            // MatchModel (save matches) needs to be executed before MatchModel-Entries (save match entries)
            // To debug "Sequence contains no elements" ERROR
            // Check below for implementation of SaveMatchesInSequence method

            // save matches and match entries in sequence
            //match.Entries = SaveMatchesInSequence(match.Entries);


            // Save matches
            List<string> modelsData = new List<string>();
            foreach (MatchModel m in matches)
            {
                // verify Winner for Round 1 matches
                string winner = string.Empty;
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                modelsData.Add($"{m.Id},{""},{winner},{m.MatchRound}");
            }
            // write data to MatchDataFile
            File.WriteAllLines(MatchDataFile.GetFilePath(), modelsData);

            //save match entries
            foreach (MatchRegistryModel entry in match.Entries)
            {
                entry.SaveEntryToMatchRegistryFile(MatchRegistryDataFile);
            }
            
            // Save matches again -- overwrite MatchModel-Entries
            modelsData = new List<string>();
            foreach (MatchModel m in matches)
            {
                // verify Winner for Round 1 matches
                string winner = string.Empty;
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                modelsData.Add($"{m.Id},{ConvertMatchEntriesListToString(match.Entries)},{winner},{m.MatchRound}");
            }
            // write data to MatchDataFile
            File.WriteAllLines(MatchDataFile.GetFilePath(), modelsData);
        }


        // TODO - Resolve ISSUE ChickenFirst-EggFirst problem
        // MatchModel (save matches) needs to be executed before MatchModel-Entries (save match entries)
        // To debug "Sequence contains no elements" ERROR
        /* create method to save entry at the same time as match is created
         * call method from SaveMatchToMatchesFile method
         * loop through each entry in match.Entries
         * save entry
         * return saved entry to ConvertMatchEntriesListToString method
         */
        //public static List<MatchRegistryModel> SaveMatchesInSequence(List<MatchRegistryModel> matchEntries)
        //{
        //    foreach (MatchRegistryModel entry in matchEntries)
        //    {
        //        entry.SaveEntryToMatchRegistryFile(GlobalConfig.MatchRegistryDataFile);
        //    }
        //    return matchEntries;
        //}


        /// <summary>
        /// SaveRoundsToTournamentsFile Helper Method-
        /// save match entries to MatchRegistryModels.csv
        /// </summary>
        /// <param name="entry">MatchRegistryModel list from MatchModel</param>
        /// <param name="MatchRegistryDataFile">MatchRegistryModels.csv</param>
        public static void SaveEntryToMatchRegistryFile(this MatchRegistryModel entry, string MatchRegistryDataFile) 
        {
            List<MatchRegistryModel> matchEntries = GlobalConfig.MatchRegistryDataFile.
                                                        GetFilePath().ReadFileToList().
                                                        LoadDataToMatchRegistryModel();
            // scan for max(Id), add 1, assign max(Id)+1 to next record
            int currentId = 1;
            if (matchEntries.Count > 0)
            {
                currentId = matchEntries.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            entry.Id = currentId;
            matchEntries.Add(entry);

            // Save matchEntries
            List<string> modelsData = new List<string>();
            foreach (MatchRegistryModel mE in matchEntries)
            {
                // verify ParentMatch for Round 1 matches
                string parentMatch = string.Empty;
                if (mE.ParentMatch != null)
                {
                    parentMatch = mE.ParentMatch.Id.ToString();
                }
                string teamCompeting = string.Empty;
                if (mE.CompetingTeam != null)
                {
                    teamCompeting = mE.CompetingTeam.Id.ToString();
                }
                modelsData.Add($"{mE.Id},{teamCompeting},{mE.Score},{parentMatch}");
            }
            // write all data to MatchRegistryDataFile
            File.WriteAllLines(MatchRegistryDataFile.GetFilePath(), modelsData);
        }


        #endregion



        #region HELPER methods

        // LOOKUP METHODS
        
        /// <summary>
        /// Lookup by MatchId for ParentMatch in MatchRegistryModel
        /// </summary>
        /// <param name="matchId">filter condition</param>
        /// <returns>filtered MatchModel data by matchId</returns>
        private static MatchModel LookUpMatchById(int matchId)
        {
            // Get all Matches data
            List<MatchModel> matches = GlobalConfig.MatchDataFile.
                                        GetFilePath().ReadFileToList().LoadDataToMatchModel();

            // filter by matchId in textData for MatchRegistryModel
            MatchModel match = matches.Where(x => x.Id == matchId).FirstOrDefault();     //"Sequence contains no elements"-- InvalidOperation Exception
            return match;
        }

        /// <summary>
        /// Lookup by TeamId for Winner in MatchModel
        /// </summary>
        /// <param name="teamId">filter condition</param>
        /// <returns>filtered TeamModel data by TeamId</returns>
        private static TeamModel LookUpTeamById(int teamId)
        {
            // Get all teams data
            List<TeamModel> teams = GlobalConfig.TeamsDataFile.
                                        GetFilePath().ReadFileToList().
                                        LoadDataToTeamModel(GlobalConfig.PeopleDataFile);

            // scan through for teamId
            TeamModel lookUpTeam = teams.Where(x => x.Id == teamId).First();

            return lookUpTeam;
        }


        // STRING-TO-LIST METHOD

        /// <summary>
        /// Convert MatchRegistryModel data from string to List to load MatchModel
        /// </summary>
        /// <param name="textData">data retrieved from MatchRegistryModels.csv</param>
        /// <returns>Sorted data into MatchRegistryModel by MatchId</returns>
        private static List<MatchRegistryModel> ConvertMatchRegistryStringToList(this string textData)
        {
            string[] matchIds = textData.Split('|');

            List<MatchRegistryModel> output = new List<MatchRegistryModel>();
            List<MatchRegistryModel> matchEntries = GlobalConfig.MatchRegistryDataFile.
                                                        GetFilePath().ReadFileToList().LoadDataToMatchRegistryModel();

            foreach (string matchId in matchIds)
            {
                // filter registry entry for specific matchId 
                MatchRegistryModel entry = matchEntries.Where(x => x.Id == int.Parse(matchId)).First();
                output.Add(entry);
            }
            return output;
        }


        // LIST-TO-STRING METHODS

        /// <summary>
        /// Helper method to extract ids and delimt with ^ and rounds with  '|'
        /// </summary>
        /// <param name="rounds">Nested list MatchModel with match ids </param>
        /// <returns>formatted string with match ids delimited by '^' and rounds delimited by '|'</returns>
        private static string ConvertRoundsListToString(List<List<MatchModel>> rounds)
        {
            // data layout to follow - (Rounds-id^id^id|id^id^id|id^id^id|)
            if (rounds.Count == 0)
            {
                return string.Empty;
            }

            string output = string.Empty;
            // nested foreach loop to extract Id element from rounds 
            foreach (List<MatchModel> round in rounds)
            {
                foreach (MatchModel match in round)
                {
                    output += $"{match.Id}^";       // match was null - NullReferenceException
                }
                // remove excess '^' after last match id 
                output = output.Substring(0, output.Length - 1);
                output += "|";
            }
            // remove excess '|' after round match ids
            output = output.Substring(0, output.Length - 1);
            return output;
        }

        /// <summary>
        /// Helper method to delimit MatchRegistry ids with '|'
        /// </summary>
        /// <param name="matchEntries">list of Entries in MatchModel</param>
        /// <returns>Entries ids string delimited with '|'</returns>
        private static string ConvertMatchEntriesListToString(List<MatchRegistryModel> matchEntries)
        {
            if (matchEntries.Count == 0)
            {
                return string.Empty;
            }

            string output = string.Empty;
            foreach (MatchRegistryModel entry in matchEntries)
            {
                output += $"{entry.Id}|";
            }
            output = output.Substring(0, output.Length - 1); // unappend '|' for last item
            return output;
        }

        /// <summary>
        /// Helper method to delimit TeamMembers ids with '|'
        /// </summary>
        /// <param name="people">TeamMembers data in PersonModel</param>
        /// <returns>TeamMember Ids concat with '|' as string</returns>
        private static string ConvertTeamMembersListToString(List<PersonModel> people)
        {
            if (people.Count == 0)
            {
                return string.Empty;
            }

            // if people is NOT empty
            string output = string.Empty;
            foreach (PersonModel person in people)      // loop to append each personId with '|'
            {
                output += $"{person.Id}|";
            }
            output = output.Substring(0, output.Length - 1);    // unappend '|' for last item
            return output;
        }

        /// <summary>
        /// Helper method to delimit Team ids with '|'
        /// </summary>
        /// <param name="teams">Teams data in TeamModel</param>
        /// <returns>Team Ids concat with '|' as string</returns>
        private static string ConvertTeamsListToString(List<TeamModel> teams)
        {
            if (teams.Count == 0)
            {
                return string.Empty;
            }

            string output = string.Empty;
            foreach (var team in teams)
            {
                output += $"{team.Id}|";
            }
            output = output.Substring(0, output.Length-1);
            return output;
        }

        /// <summary>
        /// Helper method to delimit Prize ids with '|'
        /// </summary>
        /// <param name="prizes">Prizes data in PrizeModel</param>
        /// <returns>Prize Ids concat with '|' as string</returns>
        private static string ConvertPrizesListToString(List<PrizeModel> prizes)
        {
            if(prizes.Count == 0) { return string.Empty; }

            string output = string.Empty;
            foreach (PrizeModel prize in prizes) 
            {
                output += $"{prize.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }


        #endregion
    }


}

