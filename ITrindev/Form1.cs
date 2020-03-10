using System.IO;
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
        private List<Taxpayer> marriedTaxpayers = new List<Taxpayer>(); // list of married taxpayers
        private List<Taxpayer> unmarriedTaxpayers = new List<Taxpayer>(); // list of unmarried taxpayers

        private List<Taxpayer> unsavedMarriedTaxpayers = new List<Taxpayer>(); // list of unsaved married taxpayers
        private List<Taxpayer> unsavedUnmarriedTaxpayers = new List<Taxpayer>(); // list of unsaved unmarried taxpayers

        private string taxpayerFile = ""; // the name of the file where taxpayers will be saved
        private bool newDataHasBeenAdded = false; // tracks whether we have the most recent data saved


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
            SaveData();
        }

        private void displayButton_Click( object sender, EventArgs e )
        {
            if (ListsAreEmpty())
            { NoDataAvailable(); }

            else
            {
                outputTextBox.AppendText("Married Taxpayers:" + Environment.NewLine);
                DisplayAllTaxpayers(marriedTaxpayers);

                outputTextBox.AppendText(Environment.NewLine + "Unmarried Taxapyers:" + Environment.NewLine);
                DisplayAllTaxpayers(unmarriedTaxpayers);
            }
        }

        private void summaryButton_Click( object sender, EventArgs e )
        {
            if (ListsAreEmpty())
            { NoDataAvailable(); }

            else
            {
                // display the number of married and unmarried taxpayers

                outputTextBox.AppendText(Taxpayer.Summary());
            }
        }

        private void resetButton_Click( object sender, EventArgs e )
        {
            if (ListsAreEmpty())
            { NoDataAvailable(); }
            else
            {
                SaveData();
                ClearLists();
                outputTextBox.Clear();
            }
            DeactivateEnterDataControls();
            GetReadyForNewInput();
        }

        private void exitButton_Click( object sender, EventArgs e )
        {
            // exit application
            SaveData();

            ClearLists();
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
            {
                marriedTaxpayers.Add(taxpayer);
                unsavedMarriedTaxpayers.Add(taxpayer);
            }
            else
            {
                unmarriedTaxpayers.Add(taxpayer);
                unsavedUnmarriedTaxpayers.Add(taxpayer);
            }

            // outputs
            outputTextBox.AppendText(taxpayer.Info());

            // form maintenance
            newDataHasBeenAdded = true;
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

        private void ClearLists()
        {
            marriedTaxpayers.Clear();
            unmarriedTaxpayers.Clear();
        }

        private void DisplayAllTaxpayers(List<Taxpayer> taxpayerList)
        {
            // for each taxpayer in a list, display their information

            foreach (Taxpayer taxpayer in taxpayerList)
            {
                outputTextBox.AppendText(taxpayer.Info());
            }
        }

        private void NoDataAvailable()
        {
            outputTextBox.AppendText("No data available." + Environment.NewLine);
        }

        private bool ListsAreEmpty()
        {
            if (marriedTaxpayers.Count() == 0 && unmarriedTaxpayers.Count() == 0)
            {
                return true;
            }
            return false;
        }

        private void SaveData()
        {
            String taxpayerLine;
            SaveFileDialog taxpayerFileChooser;

            StreamWriter fileWriter;

            if (ListsAreEmpty())
            { NoDataAvailable(); }

            else if (newDataHasBeenAdded == true)
            {
                if (taxpayerFile == "")
                {
                    taxpayerFileChooser = new SaveFileDialog();
                    taxpayerFileChooser.Filter = "All text files|*.txt"; //*.txt;*.csv
                    taxpayerFileChooser.ShowDialog();
                    taxpayerFile = taxpayerFileChooser.FileName;
                    taxpayerFileChooser.Dispose();
                }

                fileWriter = new StreamWriter(taxpayerFile, true);

                foreach (Taxpayer taxpayer in unsavedMarriedTaxpayers)
                {
                    taxpayerLine = taxpayer.Save();

                    fileWriter.WriteLine(taxpayerLine);
                }

                foreach (Taxpayer taxpayer in unsavedUnmarriedTaxpayers)
                {
                    taxpayerLine = taxpayer.Save();

                    fileWriter.WriteLine(taxpayerLine);
                }

                fileWriter.Close();
                fileWriter.Dispose();  //Destructor

                MessageBox.Show("Data has been saved to " + taxpayerFile);
                ResetSaveTrackers();
            }
        }

        private void ResetSaveTrackers()
        {
            newDataHasBeenAdded = false;
            unsavedMarriedTaxpayers.Clear();
            unsavedUnmarriedTaxpayers.Clear();
        }

        // ------------------------------------- end ---------------------------------------------
    }
}
