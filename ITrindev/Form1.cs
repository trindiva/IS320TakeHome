/* Created by Ivan Trindev - Take Home, 3/11/2020
    An app that caluclates the tax based on salary, investment income, exemption count, and marital status
 
    Enter Data:
        Inputs: name, salary, investment income, exemption count, marital status

    Load Data:
        Load data from an outside source
 
    Save:
        Save all unsaved data to a chosen file.
        Allows to change the file that you save to.

    Summary:
        - Married taxpayer count
        - Unmarried taxpayer count
        - Average Tax

    Display:
        For each married taxpayer and then each unmarried taxpayer:
        - Name
        - Total income
        - Tax
    Reset:
        Reset data for new batch of inputs; asks whether to save if there is unsaved data

    Exit:
        Exits the app; asks whether to save if there is unsaved data
    
 */

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


        public Form1()
        {
            InitializeComponent();
        }

        private void enterDataButton_Click( object sender, EventArgs e )
        {
            // Activate controls to enter data

            ActivateEnterDataControls();
        }

        private void loadButton_Click( object sender, EventArgs e )
        {
            // try to load data from outside source

            String taxpayerFile;

            try
            {
                OpenFileDialog taxpayerFileChooser = new OpenFileDialog();
                taxpayerFileChooser.Filter = "All text files|*.txt";
                taxpayerFileChooser.ShowDialog();
                taxpayerFile = taxpayerFileChooser.FileName;
                taxpayerFileChooser.Dispose();


                using (StreamReader fileReader = new StreamReader(taxpayerFile))
                {
                    while (fileReader.EndOfStream == false)
                    {
                        String[] properties;
                        String line;
                        string name;
                        double salary;
                        double investmentIncome;
                        int exemptions;
                        bool married;

                        line = fileReader.ReadLine();
                        properties = line.Split(',');

                        name = properties[0];
                        salary = double.Parse(properties[1]);
                        investmentIncome = double.Parse(properties[2]);
                        exemptions = int.Parse(properties[3]);
                        married = bool.Parse(properties[4]);

                        Taxpayer taxpayer;
                        taxpayer = new Taxpayer(name, salary, investmentIncome, exemptions, married);
                        ListSort(married, taxpayer);
                    }
                }
            }

            // if there is an error in the loading (user cancels load or the data is not in the proper format, dispaly message saying that data wasn't loaded
            catch
            {
                MessageBox.Show("No Data Imported");
            }

        }

        private void saveButton_Click( object sender, EventArgs e )
        {
            // Save data if there is unsaved data

            SaveData();
        }

        private void displayButton_Click( object sender, EventArgs e )
        {
            // if there is nothing to display, then say that there is no data

            if (ListsAreEmpty())
            { NoDataAvailable(); }

            else
            {
                outputTextBox.AppendText("Married Taxpayers:" + Environment.NewLine);
                DisplayAllTaxpayers(marriedTaxpayers);
                outputTextBox.AppendText(Environment.NewLine);

                outputTextBox.AppendText("Unmarried Taxapyers:" + Environment.NewLine);
                DisplayAllTaxpayers(unmarriedTaxpayers);
                outputTextBox.AppendText(Environment.NewLine);
            }
        }

        private void summaryButton_Click( object sender, EventArgs e )
        {
            // display the number of married and unmarried taxpayers and average tax or say there is no data

            if (ListsAreEmpty())
            { NoDataAvailable(); }

            else
            { 
                outputTextBox.AppendText(Taxpayer.Summary());
            }
        }

        private void resetButton_Click( object sender, EventArgs e )
        {
            // ask whether to save and then reset for new input; say there is no data if there is none

            if (ListsAreEmpty())
            { NoDataAvailable(); }
            else
            {
                AskWhetherToSave();
                ClearLists();
                outputTextBox.Clear();
            }
        }

        private void exitButton_Click( object sender, EventArgs e )
        {
            // exit application after asking whether to save unsaved data
            AskWhetherToSave();

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

            if (validExemptionCount(exemptions))
            {
                // create object
                taxpayer = new Taxpayer(name, salary, investmentIncome, exemptions, married);

                // add object to list
                ListSort(married, taxpayer);

                // outputs - COMMENTED OUT FOR FINAL VERSION
                //outputTextBox.AppendText(taxpayer.Info());

                // form maintenance
                DeactivateEnterDataControls();
                GetReadyForNewInput();
            }
            else
            {
                MessageBox.Show("Please enter a valid number of exemptions (0 - 3).");
                exemptionTextBox.Clear();
                exemptionTextBox.Focus();
            }
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
            // clear lists and binding source

            marriedTaxpayers.Clear();
            unmarriedTaxpayers.Clear();
            ResetSaveTrackers();
            taxpayerBindingSource.Clear();
        }

        private void DisplayAllTaxpayers(List<Taxpayer> taxpayerList)
        {
            // for each taxpayer in a list, display their information

            foreach (Taxpayer taxpayer in taxpayerList)
            {
                outputTextBox.AppendText(taxpayer.Display());
            }
        }

        private void NoDataAvailable()
        {
            // write that there is no data available
            outputTextBox.AppendText("No data available." + Environment.NewLine + Environment.NewLine);
        }

        private bool ListsAreEmpty()
        {
            // check whether the data lists are empty

            if (marriedTaxpayers.Count() == 0 && unmarriedTaxpayers.Count() == 0)
            {
                return true;
            }
            return false;
        }

        private void SaveData()
        {
            // check if there is data to save. if there is, then try to save it; if there is an exception (user cancels) then say that the data was not saved

            String taxpayerLine;
            SaveFileDialog taxpayerFileChooser;

            StreamWriter fileWriter;

            if (ListsAreEmpty())
            { NoDataAvailable(); }

            else if (unsavedMarriedTaxpayers.Count() > 0 || unsavedUnmarriedTaxpayers.Count() > 0)
            {
                try
                {
                    if (taxpayerFile == "")
                    {
                        taxpayerFileChooser = new SaveFileDialog();
                        taxpayerFileChooser.Filter = "All text files|*.txt"; //*.txt;*.csv
                        taxpayerFileChooser.ShowDialog();
                        taxpayerFile = taxpayerFileChooser.FileName;
                        taxpayerFileChooser.Dispose();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Would you like to save to a different file?", "New Output File?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            taxpayerFileChooser = new SaveFileDialog();
                            taxpayerFileChooser.Filter = "All text files|*.txt"; //*.txt;*.csv
                            taxpayerFileChooser.ShowDialog();
                            taxpayerFile = taxpayerFileChooser.FileName;
                            taxpayerFileChooser.Dispose();
                        }
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
                catch
                {
                    MessageBox.Show("Data Not Saved");
                }
            }
        }

        private void ResetSaveTrackers()
        {
            // clear only the lists that check if something has been saved

            unsavedMarriedTaxpayers.Clear();
            unsavedUnmarriedTaxpayers.Clear();
        }

        private bool validExemptionCount(int exemptionCount)
        {
            // check if the user has inputed a valid exemption count

            if (exemptionCount >= 0 && exemptionCount <= 2)
            { return true; }
            return false;
        }

        private void ListSort(bool isMarried, Taxpayer newTaxpayer)
        {
            // sort the objects into the proper list based off marital status

            if (isMarried)
            {
                marriedTaxpayers.Add(newTaxpayer);
                unsavedMarriedTaxpayers.Add(newTaxpayer);
            }
            else
            {
                unmarriedTaxpayers.Add(newTaxpayer);
                unsavedUnmarriedTaxpayers.Add(newTaxpayer);
            }

            taxpayerBindingSource.Add(newTaxpayer);
        }

        private void AskWhetherToSave()
        {
            // ask the user if they want to save before reseting or exiting

            if (unsavedMarriedTaxpayers.Count() + unsavedUnmarriedTaxpayers.Count() > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to save?", "Save Data?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SaveData();
                }
                else
                {
                    MessageBox.Show("Data Not Saved");
                }
            }
        }

        // ------------------------------------- end ---------------------------------------------
    }
}
