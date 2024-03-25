using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console
{
    public class AgeCalc
    {
        public AgeCalc() {

            GetDate();
        }

        public void GetDate()
        {
            string agestring;
            Console.WriteLine("#############################################################");
            Console.WriteLine("Age Calculator");
            Console.WriteLine("Please enter your date of birth on the format: MM/dd/yyyy");
            agestring = Console.ReadLine();
            DateTime tmpDate;
            try
            {
                tmpDate = DateTime.ParseExact(agestring, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
                CalcAge(tmpDate);
            }
            catch (Exception e)
            {
                Console.WriteLine("Input format invalid, please try again");
                GetDate();
            }

        }

        public void CalcAge(DateTime dateInput)
        {
            TimeSpan ageCalc = DateTime.Now - dateInput;
            Console.WriteLine($"Age Calculated: {ageCalc.Days / 365}, today date: {DateTime.Now}");
            GetDate();
        }

    }
}
