// Ivan Trindev - Taxpayer Class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrindev
{
    class Taxpayer
    {
        // properties
        public string Name { get; private set; }
        public double Salary { get; private set; }
        public double InvestmentIncome { get; private set; }
        public int Exemptions { get; private set; }
        public bool Married { get; private set; }
        public double TaxableIncome { get; private set; }
        public double TaxRate { get; private set; }

        // statics
        public static int MarriedTaxpayerCount { get; private set; }
        public static int UnmarriedTaxpayerCount { get; private set; }
        public static double TotalTax { get; private set; }

        // constructor
        public Taxpayer(string name, double salary, double investmentIncome, int exemptions, bool married)
        {
            this.Name = name;
            this.Salary = salary;
            this.InvestmentIncome = investmentIncome;
            this.Exemptions = exemptions;
            this.Married = married;

            UpdateTaxpayerCount();

            TaxableIncome = ComputeTotalIncome() - ComputeDeductions();
            if (TaxableIncome < 0)
            { TaxableIncome = 0; }

            TaxRate = ComputeTaxRate();

            TotalTax += ComputeTax();
        }

        // computational methods
        public static void ResetStatics()
        {
            // reset the static properties

            MarriedTaxpayerCount = 0;
            UnmarriedTaxpayerCount = 0;
            TotalTax = 0;
        }

        private string FormatMarriedString()
        {
            // change the bool to a string for whether the taxpayer is married

            if (Married)
            { return "Married"; }
            else
            { return "Not Married"; }
        }

        private void UpdateTaxpayerCount()
        {
            // update the number of unmarried and married taxpayers

            if (Married)
            { MarriedTaxpayerCount++; }
            else
            { UnmarriedTaxpayerCount++; }
        }

        private double ComputeTotalIncome()
        {
            // compute total income

            return Salary + InvestmentIncome;
        }

        private double ComputeDeductions()
        {
            // compute the total deductions

            double standardDeduction, perExemptionDeduction;

            if (Married)
            {
                standardDeduction = 400;
                perExemptionDeduction = 300;
            }
            else
            {
                standardDeduction = 200;
                perExemptionDeduction = 125;
            }

            return standardDeduction + perExemptionDeduction * Exemptions;
        }

        private double ComputeTaxRate()
        {
            // find the tax rate based off marital status and taxable income

            if (TaxableIncome == 0)
            {
                return 0;
            }
            else if (Married)
            {
                if (TaxableIncome > 100000)
                {
                    return 0.2;
                }
                return 0.15;
            }
            else
            {
                if (TaxableIncome > 70000)
                {
                    return 0.15;
                }
                return 0.1;
            }

        }

        private double ComputeTax()
        {
            // compute the tax

            return TaxableIncome * TaxRate;
        }

        public string FormatTaxRate()
        {
            // format tax rate as a string

            return (TaxRate * 100).ToString("N");
        }

        private static double ComputeAverageTax()
        {
            // compute the average tax

            if (UnmarriedTaxpayerCount + MarriedTaxpayerCount > 0)
            {
                return TotalTax / (UnmarriedTaxpayerCount + MarriedTaxpayerCount);
            }
            return -1;
        }

        // output methods
        public string Info()
        {
            // this is what USED to be displayed by the submit button

            return "Name: "  + Name + ", Salary: " + Salary.ToString("C") + ", Investment Income: " + InvestmentIncome.ToString("C") 
                + ", Exemptions: " + Exemptions.ToString() + ", Marital Status: " + FormatMarriedString() + Environment.NewLine;
        }

        public static string Summary()
        {
            // summary output

            return "Summary: " + Environment.NewLine
                + "Married Taxpayers: " + MarriedTaxpayerCount.ToString() + Environment.NewLine
                + "Unmarried Taxpayers: " + UnmarriedTaxpayerCount.ToString() + Environment.NewLine
                + "Average Tax: " + ComputeAverageTax().ToString("C") + Environment.NewLine;
        }

        public string Save()
        {
            // csv format that will be saved

            return Name + "," + Salary.ToString("N") + "," + InvestmentIncome.ToString("N") + ","
                + TaxableIncome.ToString("N") + "," + FormatTaxRate() + "," + ComputeTax().ToString("N");
        }

        public string Display()
        {
            // display output

            return "Name: " + Name + ", Income: " + ComputeTotalIncome().ToString("C") 
                + ", Tax: " + ComputeTax().ToString("C") + Environment.NewLine;
        }

    }
}
