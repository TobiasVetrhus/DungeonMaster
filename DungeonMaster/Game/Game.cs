using DungeonMaster.CustomExceptions;
using DungeonMaster.Enums;
using DungeonMaster.Equipment;
using DungeonMaster.HeroBase;

namespace DungeonMaster.Game
{
    public class Game
    {
        private Hero? selectedHero;

        //Predefined List of available Weapons for the user to choose.
        readonly List<Weapon> availableWeapons = new()
        {
                new Weapon("Wooden Bow", 1, WeaponType.Bow, 15),
                new Weapon("Common Hatchet", 1, WeaponType.Hatchet, 10),
                new Weapon("Oak Staff", 2, WeaponType.Staff, 20),
                new Weapon("Bronze Mace", 3, WeaponType.Mace, 25),
                new Weapon("Iron Hatchet", 3, WeaponType.Hatchet, 20),
                new Weapon("Crystal Wand", 4, WeaponType.Wand, 30),
                new Weapon("Steel Dagger", 4, WeaponType.Dagger, 15),
                new Weapon("Silver Sword", 5, WeaponType.Sword, 35),
                new Weapon("Longbow", 6, WeaponType.Bow, 30),
                new Weapon("Enchanted Staff", 7, WeaponType.Staff, 40),
                new Weapon("Serpent's Bite", 8, WeaponType.Mace, 50),
                new Weapon("Dwarven Axe", 8, WeaponType.Hatchet, 45),
                new Weapon("Phoenix Feather Wand", 9, WeaponType.Wand, 60),
                new Weapon("Assassin's Dagger", 9, WeaponType.Dagger, 35),
                new Weapon("Excalibur", 10, WeaponType.Sword, 70),
                new Weapon("Recurve Bow", 11, WeaponType.Bow, 45),
                new Weapon("Elder Staff", 12, WeaponType.Staff, 60),
                new Weapon("War Hammer", 12, WeaponType.Mace, 65),
                new Weapon("Double-Bladed Axe", 13, WeaponType.Hatchet, 55),
                new Weapon("Scepter of the Archmage", 14, WeaponType.Wand, 80),
                new Weapon("Shadowstrike Dagger", 14, WeaponType.Dagger, 45),
                new Weapon("Dragon Slayer", 15, WeaponType.Sword, 90)
        };

        //Predefined List of available Armor for the user to choose. 
        readonly List<Armor> availableArmor = new()
        {
                new Armor("Leather Vest", 1, ArmorType.Leather, new HeroAttribute(1, 3, 1), Slot.Body),
                new Armor("Chainmail Coif", 2, ArmorType.Mail, new HeroAttribute(2, 1, 1), Slot.Head),
                new Armor("Cloth Hood", 2, ArmorType.Cloth, new HeroAttribute(1, 2, 3), Slot.Head),
                new Armor("Iron Greaves", 3, ArmorType.Plate, new HeroAttribute(3, 2, 2), Slot.Legs),
                new Armor("Steel Helmet", 3, ArmorType.Plate, new HeroAttribute(2, 3, 2), Slot.Head),
                new Armor("Dragon Scale Armor", 4, ArmorType.Leather, new HeroAttribute(4, 3, 4), Slot.Body),
                new Armor("Wizard Robe", 4, ArmorType.Cloth, new HeroAttribute(2, 3, 5), Slot.Body),
                new Armor("Silver Circlet", 5, ArmorType.Mail, new HeroAttribute(1, 4, 3), Slot.Head),
                new Armor("Plate Legplates", 5, ArmorType.Plate, new HeroAttribute(4, 2, 4), Slot.Legs),
                new Armor("Golden Crown", 6, ArmorType.Mail, new HeroAttribute(3, 3, 4), Slot.Head),
                new Armor("Shadow Cloak", 7, ArmorType.Cloth, new HeroAttribute(2, 5, 6), Slot.Body),
                new Armor("Obsidian Greaves", 8, ArmorType.Plate, new HeroAttribute(4, 3, 5), Slot.Legs),
                new Armor("Elven Tunic", 8, ArmorType.Leather, new HeroAttribute(3, 4, 3), Slot.Body),
                new Armor("Mithril Helm", 9, ArmorType.Mail, new HeroAttribute(2, 4, 4), Slot.Head),
                new Armor("Platinum Breastplate", 10, ArmorType.Plate, new HeroAttribute(5, 3, 5), Slot.Body),
                new Armor("Fiery Cloak", 13, ArmorType.Cloth, new HeroAttribute(3, 6, 7), Slot.Body),
                new Armor("Titanium Legguards", 15, ArmorType.Plate, new HeroAttribute(6, 4, 6), Slot.Legs)
        };

        /*
         * When the program runs the Start() method is invoked to give the user
         * the option to either create a hero or exit the program
         */
        public void Start()
        {
            Console.Clear();
            string title = @"
            ______                                     ___  ___          _            
            |  _  \                                    |  \/  |         | |           
            | | | |_   _ _ __   __ _  ___  ___  _ __   | .  . | __ _ ___| |_ ___ _ __ 
            | | | | | | | '_ \ / _` |/ _ \/ _ \| '_ \  | |\/| |/ _` / __| __/ _ \ '__|
            | |/ /| |_| | | | | (_| |  __/ (_) | | | | | |  | | (_| \__ \ ||  __/ |   
            |___/  \__,_|_| |_|\__, |\___|\___/|_| |_| \_|  |_/\__,_|___/\__\___|_|   
                                __/ |                                                 
                               |___/                                                  
            ";

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(title);
            Console.ResetColor();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Tip: Input a number and press Enter to confirm selection...");
            Console.ResetColor();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine("1. Create a New Hero");
            Console.WriteLine("2. Exit");
            int choice = GetUserChoice(1, 2);

            switch (choice)
            {
                case 1:
                    selectedHero = CharacterCreation.CreateNewHero();
                    MainMenu(); //Invokes the MainMenu method after a new hero is created.
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Exiting...");
                    Console.ResetColor();
                    Environment.Exit(0); //Closes the terminal.
                    break;
            }

        }

        /* Displays a menu with options for the user to
         * see details about their Hero, equip weapons and armor,
         * level up the Hero, or return to the Start menu.
         */
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("- - - - - - ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Main Menu");
            Console.ResetColor();
            Console.WriteLine("- - - - - - ");
            bool isMenuRunning = true;

            while (isMenuRunning)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Level Up");
                Console.ResetColor();
                Console.WriteLine("2. Display Hero");
                Console.WriteLine("3. Equip Weapon");
                Console.WriteLine("4. Equip Armor");
                Console.WriteLine("5. Return to start\n");

                int choice = GetUserChoice(1, 5);

                switch (choice)
                {
                    case 1:
                        LevelUpOption();
                        break;
                    case 2:
                        DisplayHeroOption();
                        break;
                    case 3:
                        EquipWeaponOption();
                        break;
                    case 4:
                        EquipArmorOption();
                        break;
                    case 5:
                        isMenuRunning = false;
                        Start();
                        break;
                }
            }
        }

        //Calls the LevelUp method to level up. 
        private void LevelUpOption()
        {
            if (selectedHero != null)
            {
                selectedHero.LevelUp();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{selectedHero.Name} has leveled up to level: {selectedHero.Level}.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("No hero.");
            }
        }

        //Calls Display method to display Hero.
        private void DisplayHeroOption()
        {
            if (selectedHero != null)
            {
                Console.WriteLine(selectedHero.Display());
            }
            else
            {
                Console.WriteLine("No hero.");
            }
        }

        /* Method that prints predefined list of available weapons for the user to choose.
         * Conditional statements check if the Hero is high enough level and that the
         * weapon type is valid, if not Throws InvalidWeaponException.
         */
        private void EquipWeaponOption()
        {
            bool returnToMainMenu = false;

            while (selectedHero != null && !returnToMainMenu)
            {
                Console.Clear();
                Console.WriteLine("Available Weapons:");
                Console.WriteLine("- - - - - - - -\n");
                for (int i = 0; i < availableWeapons.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableWeapons[i].Name}\n     Required level: {availableWeapons[i].RequiredLevel}\n     Damage: {availableWeapons[i].WeaponDamage}");
                    Console.WriteLine("----------------------------------------");
                }
                Console.WriteLine("0. Go back to Menu.\n");
                Console.WriteLine("Select a weapon to equip entering the corresponding number: ");
                string weaponInput = Console.ReadLine();

                if (int.TryParse(weaponInput, out int weaponChoice) && weaponChoice >= 1 && weaponChoice <= availableWeapons.Count)
                {
                    Weapon selectedWeapon = availableWeapons[weaponChoice - 1];

                    try
                    {
                        if (selectedHero.ValidWeaponTypes.Contains(selectedWeapon.WeaponType) && selectedHero.Level >= selectedWeapon.RequiredLevel)
                        {
                            selectedHero.EquipWeapon(selectedWeapon);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"You have equipped the {selectedWeapon.Name}.");
                            Console.ResetColor();
                            returnToMainMenu = true;
                            Console.Clear();
                        }
                        else
                        {
                            throw new InvalidWeaponException("The type cannot be used by this class or the weapon requires a higher level.\n");
                        }
                    }
                    catch (InvalidWeaponException ex)
                    {
                        Console.WriteLine($"Invalid weapon: {ex.Message}");
                        break;
                    }
                }
                else if (weaponInput == "0")
                {
                    returnToMainMenu = true;
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid weapon selection.");
                }
            }
        }

        /* Method that prints predefined list of available armor for the user to choose.
         * Conditional statements check if the Hero is high enough level and that the
         * armor type is valid, if not Throws InvalidArmorException.
         */
        private void EquipArmorOption()
        {
            bool returnToMainMenu = false;

            while (selectedHero != null && !returnToMainMenu)
            {
                Console.Clear();
                Console.WriteLine("Available Armor:");
                Console.WriteLine("- - - - - - - -\n");
                for (int i = 0; i < availableArmor.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableArmor[i].Name}\n     Required level: {availableArmor[i].RequiredLevel}");
                    Console.WriteLine("----------------------------------------");
                }
                Console.WriteLine("0. Go back to Menu.\n");
                Console.WriteLine("Select armor to equip entering the corresponding number: ");
                string armorInput = Console.ReadLine();

                if (int.TryParse(armorInput, out int armorChoice) && armorChoice >= 1 && armorChoice <= availableArmor.Count)
                {
                    Armor selectedArmor = availableArmor[armorChoice - 1];

                    try
                    {
                        if (selectedHero.ValidArmorTypes.Contains(selectedArmor.ArmorType) && selectedHero.Level >= selectedArmor.RequiredLevel)
                        {
                            selectedHero.EquipArmor(selectedArmor);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"You have equipped {selectedArmor.Name}.");
                            Console.ResetColor();
                            returnToMainMenu = true;
                        }
                        else
                        {
                            throw new InvalidArmorException("The type cannot be used by this class or the armor requires a higher level.\n");
                        }
                    }
                    catch (InvalidArmorException ex)
                    {
                        Console.WriteLine($"Invalid armor: {ex.Message}");
                        break;
                    }
                }
                else if (armorInput == "0")
                {
                    returnToMainMenu = true;
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid armor selection.");
                }
            }
        }

        //Method used to check if user input values are valid.
        private int GetUserChoice(int minVal, int maxVal)
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < minVal || choice > maxVal)
            {
                Console.WriteLine($"Invalid input. Please enter a number between {minVal} and {maxVal}:");
            }
            return choice;
        }
    }
}
