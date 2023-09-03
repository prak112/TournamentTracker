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
            * Create 1st MatchRound
            *Create every round with Match Ids from MatchRound 1, ex. 8teams : 8-4-2-1
         */

        public static void CreateRounds(TournamentModel model)
        {
            // team list randomization
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.Teams);
            
            // calculate rounds required based on total teams
            int rounds = FindTotalRounds(randomizedTeams.Count);

            // calculate byes
            int byes = FindTotalByes(rounds, randomizedTeams.Count);

            // create first match


        }

        // find byes required for totalRounds;
        private static int FindTotalByes(int totalRounds, int teamCount)
        {
            int totalByes;
            int calculatedTeamCount = 1;    // calculating approximated teams count- requiredTeams in FindTotalRounds

            for (int i = totalRounds; i != 0; i--)  // alternative for Math.Pow since type casting double to int NOT Valid/Recommended
            {
                calculatedTeamCount *= 2;
            }
            totalByes = calculatedTeamCount - teamCount;

            return totalByes;
        }


        // find rounds required for randomizedTeams
        private static int FindTotalRounds(int teamCount)
        {
            // Tim's logic - simplified from logs and pows
            int totalRounds = 1;
            int requiredTeams = 2;
            
            while(requiredTeams < teamCount)
            {
                totalRounds += 1;   // add additional round to totalRounds
                requiredTeams *= 2; // raise threshold for requiredTeams to equate to 2^n
            }

            return totalRounds;
        }

        // team list randomization
        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teamsList)
        {
            List<TeamModel> randomizedTeams = teamsList.OrderBy(t => Guid.NewGuid()).ToList(); // Logic inspired from https://stackoverflow.com/questions/273313/randomize-a-listt

            return randomizedTeams;
        }
    }
}
