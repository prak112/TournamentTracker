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
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            InitializeComponent();
        }

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
            // TO DO - Add advanced CreateMember section data Validation, ex. email and phone
            
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
