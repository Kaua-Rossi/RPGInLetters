using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RPGInLetters.Data;
using RPGInLetters.Models;
using System.ComponentModel.DataAnnotations;

namespace RPGInLetters
{
    internal enum MenuChoices
    {
        REGISTER = 1,
        LOGIN = 2
    }

    internal class Program
    {
        internal static User? loggedUser = default;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome.");
            Console.WriteLine("Would you like to... ");
            Console.WriteLine("1. Register (TODO)");
            Console.WriteLine("2. Login (TODO)");

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
                    Console.WriteLine("Username: ");
                    string username = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine() ?? string.Empty;

                    using (var context = CreateDbContext())
                    {
                        context.Database.EnsureCreated();

                        loggedUser = context.Users.Include(u => u.UserCharacter).FirstOrDefault(u => u.Username == username && u.Password == password);

                        if (loggedUser != default)
                        {
                            Console.WriteLine($"Welcome back, {loggedUser.Username}!");

                            if (loggedUser.UserCharacter == default)
                            {
                                Console.WriteLine("You don't have a character yet. Please create one.");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("This is your character: ");

                                var userCharacter = loggedUser.UserCharacter!;

                                var properties = userCharacter.GetType().GetProperties();

                                foreach (var property in properties)
                                {
                                    if (property.Name == "User" || property.Name == "Id" || property.Name == "UserId")
                                        continue;
                                    var value = property.GetValue(userCharacter);
                                    Console.WriteLine($"{property.Name}: {value}");

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid username or password.");
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private static ApplicationDbContext CreateDbContext()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("SupabaseConnection");
            optionsBuilder.UseNpgsql(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}