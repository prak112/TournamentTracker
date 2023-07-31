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
using TrackerLibrary.DataAccess;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    positionText.Text, 
                    positionNameText.Text, 
                    prizeAmountText.Text, 
                    prizePercentageText.Text);

                // save model data to storage units (database, text file)
                GlobalConfig.Connection.CreatePrize(model);

                // clear form data
                positionText.Text = "";
                positionNameText.Text = "";
                prizeAmountText.Text = "0";
                prizePercentageText.Text = "0";
            }
            // prompt message for invalid data or format
            else
            {
                MessageBox.Show("Invalid Information. Please try again.");
            }
        }

        /// <summary>
        /// Validation of all data fields in CreatePrizeForm
        /// </summary>
        /// <returns>Boolean value to indicate validation pass or fail</returns>
        private bool ValidateForm()
        {
            bool output = true;

            // validate Position
            int position = 0;
            bool positionValidNumber = int.TryParse(positionText.Text, out position);
            if (!positionValidNumber)
            {
                output = false;
            }
            if(position < 1)
            {
                output = false;
            }

            // validate Position Name 
            if (positionNameText.Text.Length < 0)
            {
                output = false;

            }

            // validate Prize Amount and Prize Percentage
            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountText.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(prizePercentageText.Text, out prizePercentage);

            if(!prizeAmountValid || !prizePercentageValid)
            {
                output = false;
            }            
            if(prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }
            if(prizePercentage < 0 || prizePercentage > 100) 
            {
                output = false;
            }

            
            return output;
        }
    }
}
