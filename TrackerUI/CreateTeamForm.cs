﻿using System;
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
    public partial class CreateTeamForm : Form
    {
        // List of selected and available Team Members
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        public CreateTeamForm()
        {
            InitializeComponent();

            //CreateSampleData();

            WireUpLists();
        }

        /// <summary>
        /// Create sample data to test functionality of team members dropdown list and list box
        /// </summary>
        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName="Pika", LastName="Pikachu"});
            availableTeamMembers.Add(new PersonModel { FirstName = "Bulba", LastName = "Bulbasaur" });

            selectedTeamMembers.Add(new PersonModel { FirstName="Charu", LastName="Charmander" });
            selectedTeamMembers.Add(new PersonModel { FirstName="Onyx", LastName="Lachamma"});
        }

        /// <summary>
        /// Synchronize list of available and selected team members
        /// </summary>
        private void WireUpLists()
        {            
            teamMemberDropDown.DataSource = availableTeamMembers;
            teamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }



        /// <summary>
        /// Event generated function for Create Member button in CreateTeamForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                // assign form data to Model
                PersonModel person = new PersonModel();
                person.FirstName = firstNameText.Text;
                person.LastName = lastNameText.Text;
                person.PhoneNumber = phoneText.Text;
                person.Email = emailText.Text;
                person.RegistrationDate = DateTime.Now;

                // pass it onto data storage
                GlobalConfig.Connection.CreatePerson(person);
                
                // clear data in form
                firstNameText.Text = "";
                lastNameText.Text = "";
                phoneText.Text = "+358";
                emailText.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid Information. Please fill required (marked with *) details.");
            }
        }

        /// <summary>
        /// Validation of all data fields in CreateMember section of CreateTeamForm
        /// </summary>
        /// <returns>Boolean value to indicate validation pass or fail</returns>
        private bool ValidateForm()
        {
            // TODO - Add advanced CreateMember section data Validation, ex. email and phone
            
            if(firstNameText.Text.Length == 0)
            {
                return false;
            }

            if(lastNameText.Text.Length == 0)
            {
                return false;
            }

            if(emailText.Text.Length == 0)
            {
                return false;
            }

            return true;
        }


    }
}
