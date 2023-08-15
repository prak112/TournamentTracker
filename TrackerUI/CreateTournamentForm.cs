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
    public partial class CreateTournamentForm : Form
    {
        // Initialize selectedTeams and availableTeams lists
        private List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();  // retrieve all data from storage
        private List<TeamModel> selectedTeams = new List<TeamModel>();

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
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";

            tournamentPlayersListBox.DataSource = null;
            tournamentPlayersListBox.DataSource = selectedTeams;
            tournamentPlayersListBox.DisplayMember = "TeamName";
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



        private void createNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void prizesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
