using DungeonMaster.Enums;
using DungeonMaster.HeroBase;
using System.Text;

namespace DungeonMaster.HeroTypes
{
    public class Archer : Hero
    {
        //Valid Weapon and Armor types for the Archer class.
        private static readonly List<WeaponType> validWeaponTypes = new List<WeaponType> { WeaponType.Bow };
        private static readonly List<ArmorType> validArmorTypes = new List<ArmorType> { ArmorType.Leather, ArmorType.Mail };

        //Initializes a new instance of the Archer class. Takes name as parameter.
        public Archer(string name) : base(name, validWeaponTypes, validArmorTypes)
        {
            LevelAttributes = new HeroAttribute(1, 7, 1);
        }

        //Returns the damaging attribute multiplier for the Archer.
        public override double GetDamagingAttributeMultiplier()
        {
            return CalculateTotalAttributes().Dexterity;
        }

        //Increases the Archer's level and adjusts attributes accordingly.
        public override void LevelUp()
        {
            Level++;

            LevelAttributes.Strength += 1;
            LevelAttributes.Dexterity += 5;
            LevelAttributes.Intelligence += 1;
        }

        /// <summary>
        /// Displays information about the Archer.
        /// </summary>
        /// <returns>A string containing Archer information.</returns>
        public override string Display()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Class: Archer");
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
