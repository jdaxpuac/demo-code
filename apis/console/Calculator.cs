using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console
{
    public class Calculator
    {
        public Calculator()
        {
            Console.WriteLine("Calculadora Test");

            string num1, num2, op;
            decimal result = 0;
            // ask 1st number
            Console.WriteLine("Ingresar primer numero");
            num1 = Console.ReadLine();

            //ask 2nd number
            Console.WriteLine("Ingresar segundo numero");
            num2 = Console.ReadLine();
            //ask operation

            Console.WriteLine("Ingresar operacion:");
            Console.WriteLine("1 - suma");
            Console.WriteLine("2 - resta");
            Console.WriteLine("3 - multiplicacion");
            Console.WriteLine("4 - division");
            op = Console.ReadLine();

            //operate and print
            switch (op)
            {
                case "1": result = decimal.Parse(num1) + decimal.Parse(num2); break;
                case "2": result = decimal.Parse(num1) - decimal.Parse(num2); break;
                case "3": result = decimal.Parse(num1) * decimal.Parse(num2); break;
                case "4": result = decimal.Parse(num1) / decimal.Parse(num2); break;
            }

            Console.WriteLine($"El resultado es: {result}");
        }
    }
}
