using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        /* Logic Items :
            X Team lists randomization - to prevent systematic or biased match modeling
            X Verify Randomized team lists for match modeling, IF insufficient add Byes - 2^n Teams required for smooth match modeling
            X Create 1st MatchRound
            X Create every round with Match Ids from MatchRound 1, ex. 8teams : 8-4-2-1
         */

        /// <summary>
        /// Create rounds of matches from information in TournamentModel
        /// </summary>
        /// <param name="model">object with Tournament information</param>
        public static void CreateRounds(TournamentModel model)
        {
            // team list randomization
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.Teams);

            // calculate rounds required based on total teams
            int rounds = FindTotalRounds(randomizedTeams.Count);

            // calculate byes
            int byes = FindTotalByes(rounds, randomizedTeams.Count);

            // create first round match
            List<MatchModel> matches = CreateFirstRound(randomizedTeams, byes);
            model.Rounds.Add(matches);

            // create matches for rest of the rounds
            CreateOtherRounds(model, rounds);
        }


        /// <summary>
        /// create other rounds after round 1
        /// </summary>
        /// <param name="model">TournamentModel with rounds and first round information</param>
        /// <param name="rounds">total rounds in tournament</param>
        private static void CreateOtherRounds(TournamentModel model, int rounds)
        {
            // initalize match round
            int round = 2;
            List<MatchModel> previousRound = model.Rounds[0];
            List<MatchModel> currentRound = new List<MatchModel>();
            MatchModel currentMatch = new MatchModel();

            // add ParentMatch, MatchRound to currentMatch from previousRound
            while (round <= rounds)
            {
                foreach (MatchModel match in previousRound)
                {
                    currentMatch.Entries.Add(new MatchRegistryModel { ParentMatch = match });

                    if (currentMatch.Entries.Count > 1)
                    {
                        currentMatch.MatchRound = round;
                        currentRound.Add(currentMatch);
                        currentMatch = new MatchModel();
                    }
                }
                // reinitialize previousRound, currentRound, round
                model.Rounds.Add(currentRound);
                previousRound = currentRound;

                currentRound = new List<MatchModel>();
                round += 1;
            }            
        }



        /// <summary>
        /// create first round of matches
        /// </summary>
        /// <param name="teams">list of randomized teams</param>
        /// <param name="byes">calculated byes based on rounds and teams</param>
        /// <returns>list of matches amongst given teams and byes</returns>
        private static List<MatchModel> CreateFirstRound(List<TeamModel> teams, int byes)
        {
            List<MatchModel> output = new List<MatchModel>();
            MatchModel match = new MatchModel();

            // start pairing with byes until byes=0, then pair with teams
            foreach (TeamModel team in teams)
            {
                // add current team to CompetingTeam prop in Entries prop in MatchModel
                match.Entries.Add(new MatchRegistryModel { CompetingTeam = team });

                // create round 1 match for every team with bye/team
                if(byes > 0 || match.Entries.Count > 1)
                {
                    match.MatchRound = 1;
                    output.Add(match);
                    match = new MatchModel();   // renew match after matching team with bye/team

                    if (byes > 0)   // decrement byes after matching with team
                    {
                        byes -= 1;
                    }
                }
            }
            return output;
        }


        /// <summary>
        /// Calculate byes required for round 1 in tournament 
        /// </summary>
        /// <param name="totalRounds">Total rounds of matches</param>
        /// <param name="teamCount">Total teams playing in tournament</param>
        /// <returns>Byes required for round 1</returns>
        private static int FindTotalByes(int totalRounds, int teamCount)
        {
            int output;
            int calculatedTeamCount = 1;    // calculating approximated teams count- requiredTeams in FindTotalRounds

            for (int i = totalRounds; i != 0; i--)  // alternative for Math.Pow since type casting double to int NOT Valid/Recommended
            {
                calculatedTeamCount *= 2;
            }
            output = calculatedTeamCount - teamCount;

            return output;
        }

        /// <summary>
        /// Calculate rounds required for tournament
        /// </summary>
        /// <param name="teamCount">Total teams playing in tournament</param>
        /// <returns>Total rounds required for tournament</returns>
        private static int FindTotalRounds(int teamCount)
        {
            // Tim's logic - simplified from logs and pows
            int output = 1;
            int requiredTeams = 2;
            
            while(requiredTeams < teamCount)
            {
                output += 1;   // add additional round to output
                requiredTeams *= 2; // raise threshold for requiredTeams to equate to 2^n
            }

            return output;
        }

        /// <summary>
        /// Randomize list of teams
        /// </summary>
        /// <param name="teamsList">List of teams playing in tournament</param>
        /// <returns>Randomized list of teams</returns>
        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teamsList)
        {
            List<TeamModel> randomizedTeams = teamsList.OrderBy(t => Guid.NewGuid()).ToList(); // Logic inspired from https://stackoverflow.com/questions/273313/randomize-a-listt

            return randomizedTeams;
        }
    }
}
