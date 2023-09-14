using DungeonMaster.HeroBase;
using DungeonMaster.HeroTypes;
using System.Globalization;

namespace DungeonMaster.Game
{
    public class CharacterCreation
    {
        /// <summary>
        /// Creates a new Hero based on the user input for class and name.
        /// </summary>
        /// <returns>The created Hero.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an invalid class choice is made.</exception>
        public static Hero CreateNewHero()
        {
            //Prints options for the UI for the user to choose from.
            Console.WriteLine("Choose a class for your Hero:");
            Console.WriteLine("- - - - - - - - - - - - - - - -");
            Console.WriteLine("1. Wizard");
            Console.WriteLine("2. Archer");
            Console.WriteLine("3. Barbarian");
            Console.WriteLine("4. Swashbuckler\n");

            //Check if the user input is valid.
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid input. Please enter a number from 1-4:");
            }

            string heroName;

            //Prints a message to the user as long as the user input for Hero name is shorter than 3.
            do
            {
                Console.WriteLine("Enter the name for your hero:");
                Console.WriteLine("- - - - - - - - - - - - - - - -");
                heroName = Console.ReadLine();

                //Converts the name to Title Case.
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                heroName = textInfo.ToTitleCase(heroName);

                if (heroName.Length < 3)
                {
                    Console.WriteLine("Hero name must be at least 3 characters. Please try again.\n");
                }
            } while (heroName.Length < 3);


            //Creates an object of a specific Hero subclass depending on the user input. 
            Hero newHero;
            switch (choice)
            {
                case 1:
                    newHero = new Wizard(heroName); break;
                case 2:
                    newHero = new Archer(heroName); break;
                case 3:
                    newHero = new Barbarian(heroName); break;
                case 4:
                    newHero = new Swashbuckler(heroName); break;
                default:
                    throw new InvalidOperationException("Invalid hero class choice.");
            }

            Console.WriteLine($"\nYour hero, {heroName}, has been created!\n");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            return newHero;
        }
    }
}
