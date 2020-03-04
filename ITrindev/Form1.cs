using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITrindev
{
    public partial class Form1 : Form
    {
        List<Taxpayer> marriedTaxpayers = new List<Taxpayer>(); // list of married taxpayers
        List<Taxpayer> unmarriedTaxpayers = new List<Taxpayer>(); // list of unmarried taxpayers


        public Form1()
        {
            InitializeComponent();
        }

        private void enterDataButton_Click( object sender, EventArgs e )
        {
            ActivateEnterDataControls();
        }

        private void loadButton_Click( object sender, EventArgs e )
        {

        }

        private void saveButton_Click( object sender, EventArgs e )
        {

        }

        private void displayButton_Click( object sender, EventArgs e )
        {
            outputTextBox.AppendText("Married Taxpayers:" + Environment.NewLine);
            DisplayAllTaxpayers(marriedTaxpayers);

            outputTextBox.AppendText(Environment.NewLine + "Unmarried Taxapyers:" + Environment.NewLine);
            DisplayAllTaxpayers(unmarriedTaxpayers);
        }

        private void summaryButton_Click( object sender, EventArgs e )
        {
            int marriedTaxpayerCount, unmarriedTaxpayerCount;

            marriedTaxpayerCount = marriedTaxpayers.Count();
            unmarriedTaxpayerCount = unmarriedTaxpayers.Count();
            DisplaySummary(marriedTaxpayerCount, unmarriedTaxpayerCount);
        }

        private void resetButton_Click( object sender, EventArgs e )
        {

        }

        private void exitButton_Click( object sender, EventArgs e )
        {
            // exit application
            marriedTaxpayers.Clear();
            unmarriedTaxpayers.Clear();
            Application.Exit();
        }

        private void submitButton_Click( object sender, EventArgs e )
        {
            // declarations
            string name;
            double salary;
            double investmentIncome;
            int exemptions;
            bool married;

            Taxpayer taxpayer;

            // inputs
            name = nameTextBox.Text;
            salary = double.Parse(salaryTextBox.Text);
            investmentIncome = double.Parse(investmentTextBox.Text);
            exemptions = int.Parse(exemptionTextBox.Text);
            married = marriedCheckBox.Checked;

            // create object
            taxpayer = new Taxpayer(name, salary, investmentIncome, exemptions, married);

            // add object to list
            if (married)
            { marriedTaxpayers.Add(taxpayer); }
            else
            { unmarriedTaxpayers.Add(taxpayer); }

            // outputs
            outputTextBox.AppendText(taxpayer.Info());

            // form maintenance
            DeactivateEnterDataControls();
            GetReadyForNewInput();
        }

        // ----------------------------------- my methods ----------------------------------------
        private void ActivateEnterDataControls()
        {
            // activate all the controls allowing the user to add in data

            nameTextBox.Visible = true;
            nameLabel.Visible = true;
            
            salaryLabel.Visible = true;
            salaryTextBox.Visible = true;

            investmentTextBox.Visible = true;
            investmentLabel.Visible = true;

            exemptionTextBox.Visible = true;
            exemptionLabel.Visible = true;

            marriedCheckBox.Visible = true;
            marriedLabel.Visible = true;

            submitButton.Visible = true;

            nameTextBox.Focus();
        }

        private void DeactivateEnterDataControls()
        {
            // deactivate all the controls allowing the user to add in data

            nameTextBox.Visible = false;
            nameLabel.Visible = false;

            salaryLabel.Visible = false;
            salaryTextBox.Visible = false;

            investmentTextBox.Visible = false;
            investmentLabel.Visible = false;

            exemptionTextBox.Visible = false;
            exemptionLabel.Visible = false;

            marriedCheckBox.Visible = false;
            marriedLabel.Visible = false;

            submitButton.Visible = false;
        }

        private void GetReadyForNewInput()
        {
            // clear input textboxes and checkbox and focus on the Enter Data Button

            nameTextBox.Clear();
            salaryTextBox.Clear();
            investmentTextBox.Clear();
            exemptionTextBox.Clear();

            marriedCheckBox.Checked = false;

            enterDataButton.Focus();
        }

        private void DisplaySummary(int marriedTaxpayerCount, int unmarriedTaxpayerCount)
        {
            // display the number of married and unmarried taxpayers

            outputTextBox.AppendText("Summary: " + Environment.NewLine
                            + "Married Taxpayers: " + marriedTaxpayerCount.ToString() + Environment.NewLine
                            + "Unmarried Taxpayers: " + unmarriedTaxpayerCount.ToString() + Environment.NewLine);
        }

        private void DisplayAllTaxpayers(List<Taxpayer> taxpayerList)
        {
            // for each taxpayer in a list, display their information

            foreach (Taxpayer taxpayer in taxpayerList)
            {
                outputTextBox.AppendText(taxpayer.Info());
            }
        }

        // ------------------------------------- end ---------------------------------------------
    }
}
