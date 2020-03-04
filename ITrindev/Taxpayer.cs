using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrindev
{
    class Taxpayer
    {
        // fields
        private string name;
        private double salary;
        private double investmentIncome;
        private int exemptions;
        private bool married;

        // constructor
        public Taxpayer(string name, double salary, double investmentIncome, int exemptions, bool married)
        {
            this.name = name;
            this.salary = salary;
            this.investmentIncome = investmentIncome;
            this.exemptions = exemptions;
            this.married = married;
        }

        public Taxpayer()
        {
            // default constructor 

            this.name = "No name";
            this.salary = 0;
            this.investmentIncome = 0;
            this.exemptions = 0;
            this.married = false;
        }

        // computational methods

        // output methods
        public string Info()
        {
            string marriedString;

            if (married)
            { marriedString = "Married"; }
            else
            { marriedString = "Unmarried"; }

            return name + "," + salary.ToString("C") + "," + investmentIncome.ToString("C") + "," 
                + exemptions.ToString() + "," + marriedString + Environment.NewLine;
        }

    }
}
