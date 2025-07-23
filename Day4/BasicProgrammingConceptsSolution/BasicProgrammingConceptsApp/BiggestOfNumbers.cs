using BasicProgrammingConceptsApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicProgrammingConceptsApp
{
    class BiggestOfNumbers
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }


        public void TakeNumbersFromUser()
        {
            Console.WriteLine("Please enter teh value of first number");
            int n1 = 0, n2=0;
            while(Int32.TryParse(Console.ReadLine(), out n1) == false)
                Console.WriteLine("Incorrect entry for number 1. please try again");
            Number1 = n1;
            //Number1 = Convert.ToInt32(Console.ReadLine());//Unboxing- convert a refference type to value
            Console.WriteLine("Please enter teh value of second number");
            while (Int32.TryParse(Console.ReadLine(), out n2) == false)
                Console.WriteLine("Incorrect entry for number 1. please try again");
            Number2 = n2;
        }

        public int BiggestOfTwoNumbers()
        {
            if (Number1 == Number2)
            {
                throw new EqualNumberException($"Both the numbers are {Number1}");
            }
            else if (Number1 > Number2)
                return Number1;
            return Number2;
        }
    }
}
