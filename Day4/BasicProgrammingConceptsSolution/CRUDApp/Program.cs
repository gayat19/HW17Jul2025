using CRUDApp.Models;

namespace CRUDApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            EmployeeInteraction employeeInteraction = new();
            employeeInteraction.StartInteraction();
        }
    }
}
