using DungeonMaster.Enums;
using DungeonMaster.HeroBase;
using System.Text;

namespace DungeonMaster.HeroTypes
{
    public class Wizard : Hero
    {
        //Valid Weapon and Armor types for the Wizard class.
        private static readonly List<WeaponType> validWeaponTypes = new List<WeaponType> { WeaponType.Staff, WeaponType.Wand };
        private static readonly List<ArmorType> validArmorTypes = new List<ArmorType> { ArmorType.Cloth };

        //Initializes a new instance of the Wizard class. Takes name as parameter.
        public Wizard(string name) : base(name, validWeaponTypes, validArmorTypes)
        {
            LevelAttributes = new HeroAttribute(1, 1, 8);
        }

        //Returns the damaging attribute multiplier for the Wizard.
        public override double GetDamagingAttributeMultiplier()
        {
            return CalculateTotalAttributes().Intelligence;
        }

        //Increases the Wizard's level and adjusts attributes accordingly.
        public override void LevelUp()
        {
            Level++;

            LevelAttributes.Strength += 1;
            LevelAttributes.Dexterity += 1;
            LevelAttributes.Intelligence += 5;
        }

        /// <summary>
        /// Displays information about the Wizard.
        /// </summary>
        /// <returns>A string containing Wizard information.</returns>
        public override string Display()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Class: Wizard");
            stringBuilder.AppendLine($"Level: {Level}");
            stringBuilder.AppendLine($"Total Strength: {CalculateTotalAttributes().Strength}");
            stringBuilder.AppendLine($"Total Dexterity: {CalculateTotalAttributes().Dexterity}");
            stringBuilder.AppendLine($"Total Intelligence: {CalculateTotalAttributes().Intelligence}");
            stringBuilder.AppendLine($"Damage: {CalculateDamage()}");
            stringBuilder.Append(ListEquippedItems());

            return stringBuilder.ToString();
        }
    }
}
