using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RPGInLetters.Data;
using System.ComponentModel.DataAnnotations;

namespace RPGInLetters
{
    internal enum MenuChoices
    {
        REGISTER = 1,
        LOGIN = 2,
        CHECK_DATABASE = 3
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome.");
            Console.WriteLine("Would you like to... ");
            Console.WriteLine("1. Register (TODO)");
            Console.WriteLine("2. Login (TODO)");
            Console.WriteLine("3. Check Database (ADM ONLY)");

            if (!byte.TryParse(Console.ReadLine(), out byte menuChoice) || menuChoice < 1 || menuChoice > 3)
            {
                Console.WriteLine("Invalid option! Please enter 1, 2, or 3.");
                return;
            }

            switch (menuChoice)
            {
                case (byte)MenuChoices.REGISTER:
                    Console.WriteLine("To be implemented");
                    break;

                case (byte)MenuChoices.LOGIN:
                    Console.WriteLine("To be implemented");
                    break;

                case (byte)MenuChoices.CHECK_DATABASE:
                    Console.WriteLine("To be implemented");
                    break;

                default:
                    break;
            }
        }
    }
}