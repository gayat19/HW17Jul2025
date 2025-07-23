
using BasicProgrammingConceptsApp.Exceptions;

namespace BasicProgrammingConceptsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.BiggestOfTwo();

        }

        private void BiggestOfTwo()
        {
            try 
            { 
                BiggestOfNumbers biggestOfNumbers = new BiggestOfNumbers();
                biggestOfNumbers.TakeNumbersFromUser();
                int result = biggestOfNumbers.BiggestOfTwoNumbers();
                if(result != -1)
                    Console.WriteLine($"The biggest of {biggestOfNumbers.Number1} and {biggestOfNumbers.Number2} is {result}");
            }
            catch (FormatException formatException)
            {
                Console.WriteLine("Since the input was incorrect we are unable to process");
            }
            catch(EqualNumberException equalNumberException)
            {
                Console.WriteLine(equalNumberException.Message);
            }
        }
    }
}
