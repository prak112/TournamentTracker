using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form, ICreateRequestor
    {
        // Initialize selectedTeams and availableTeams lists
        private List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();  // retrieve all teams data from storage
        private List<TeamModel> selectedTeams = new List<TeamModel>();
        private List<PrizeModel> selectedPrizes = GlobalConfig.Connection.GetPrize_All(); // retrieve all prize data from storage

        public CreateTournamentForm()
        {
            InitializeComponent();

            //CreateSampleData();

            WireUpLists();
        }


        /// <summary>
        /// Create sample data to test functionality of selectTeamDropDown and tournamentsListBox
        /// </summary>
        private void CreateSampleData()
        {
            availableTeams.Add(new TeamModel { TeamName = "Pikachu" });
            availableTeams.Add(new TeamModel { TeamName = "Bulbasaur" });

            selectedTeams.Add(new TeamModel { TeamName = "Charmander" });
            selectedTeams.Add(new TeamModel { TeamName = "Lachamma" });
        }


        /// <summary>
        /// Synchronize Teams availability between selectTeamDropDown and tournamentPlayersListBox
        /// </summary>
        private void WireUpLists()
        {
            // selectTeamDropDown
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";
            // tournamentPlayersListBox
            tournamentPlayersListBox.DataSource = null;
            tournamentPlayersListBox.DataSource = selectedTeams;
            tournamentPlayersListBox.DisplayMember = "TeamName";
            
            // prizesListBox
            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PositionName";

        }


        // TOURNAMENT PLAYERS

        #region  TEAMS - CRUD methods 
        /// <summary>
        /// Popup CreateTeamForm instance from CreateTournamentForm to create new team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // pass the current CreateTeam Form popup instance to CreateTournament Form
            CreateTeamForm teamForm = new CreateTeamForm(this);

            teamForm.ShowDialog();
        }

        /// <summary>
        /// Implement interface member to update tournamentPlayersListBox with new team
        /// </summary>
        /// <param name="model"></param>
        public void TeamComplete(TeamModel model)
        {
            // add teamRequestor object to availableTeams List
            availableTeams.Add(model);
            // update tournamentPlayersListBox
            WireUpLists();
        }

        /// <summary>
        /// Add selected/displayed team in selectTeamDropDown to tournamentsListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTeamButton_Click(object sender, EventArgs e)
        {
            // cast selected team from dropdown as TeamModel object
            TeamModel team = selectTeamDropDown.SelectedItem as TeamModel;

            if (team != null)
            {
                // update lists based on selection
                selectedTeams.Add(team);
                availableTeams.Remove(team);

                // refresh list items
                WireUpLists();
            }
        }

        /// <summary>
        /// Remove selected team in tournamentsListBox, add to selectTeamDropDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteTeamButton_Click(object sender, EventArgs e)
        {
            // cast selected team in listbox as TeamModel object
            TeamModel team = tournamentPlayersListBox.SelectedItem as TeamModel;

            // update lists based on selection
            if (team != null)
            {
                selectedTeams.Remove(team);
                availableTeams.Add(team);

                WireUpLists();
            }
        }

        #endregion


        // PRIZES 

        #region PRIZES - CRUD methods
        /// <summary>
        /// Popup CreatePrizeForm instance from CreateTournamentForm to create new prize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            // pass the current CreatePrize Form popup instance to CreateTournament Form
            CreatePrizeForm prizeForm = new CreatePrizeForm(this);
            // shows PrizeForm on top of TournamentForm
            prizeForm.ShowDialog();
        }

        /// <summary>
        /// Implement Interface member to update prizesListBox with new prize
        /// </summary>
        /// <param name="model"></param>
        public void PrizeComplete(PrizeModel model)
        {
            // add model data to selectedPrizes list
            selectedPrizes.Add(model);
            // update prizesListBox
            WireUpLists();
        }

        /// <summary>
        /// Remove selected prize in prizesListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletePrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel prize = prizesListBox.SelectedItem as PrizeModel;

            selectedPrizes.Remove(prize);

            WireUpLists();
        }
        #endregion


        /// <summary>
        /// validate form data, save Tournament data to storage unit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            bool dataValid = true; 

            // validate form data
            // TournamentName
            if (tournamentNameText.Text == string.Empty)
            {
                dataValid = false;
            }

            // EntryFee
            decimal fee = 0;
            if (!decimal.TryParse(entryFeeText.Text, out fee))
            {
                dataValid = false;
            }

            // save form data to model
            if (dataValid) 
            {
                TournamentModel tournament = new TournamentModel();
                tournament.TournamentName = tournamentNameText.Text;
                tournament.EntryFee = fee;
                tournament.Prizes = selectedPrizes;
                tournament.Teams = selectedTeams;

                // Wire MatchModels

                // pass model data to sql server
                GlobalConfig.Connection.CreateTournament(tournament);

            }
            else
            {
                MessageBox.Show("Please chekc and re-enter valid information for Tournament Name/Entry Fee/Prizes/Teams.",
                    "Invalid Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }



            // save name, entryfee, prizesListBox, tournamentPlayersListBox info to data storage
            // text - Tournaments data with PrizeId, TeamId
        }
    }
}
