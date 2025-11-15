
using Microsoft.VisualBasic.FileIO;
using MyFunctions;
using static MyFunctions.Tools;
using Lab.Class;
using Lab.Interface;

namespace Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool exit = false;
            bool changeUser = false;
            string name = InputString("Company name: ");
            string CEOName = InputString("CEO name: ");

            Menu.SelectedItemColor = ConsoleColor.DarkCyan;

            User user = new CEO(CEOName);
            Company company = new Company(user, name);

            CompanyProjectsAppSession companyProjectsApp = new CompanyProjectsAppSession(company, user);
            companyProjectsApp.DisplayMenu();
        }
    }
}
