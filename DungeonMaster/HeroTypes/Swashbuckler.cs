using DungeonMaster.Enums;
using DungeonMaster.HeroBase;
using System.Text;

namespace DungeonMaster.HeroTypes
{
    public class Swashbuckler : Hero
    {
        //Valid Weapon and Armor types for the Swashbuckler class.
        private static readonly List<WeaponType> validWeaponTypes = new List<WeaponType> { WeaponType.Dagger, WeaponType.Sword };
        private static readonly List<ArmorType> validArmorTypes = new List<ArmorType> { ArmorType.Leather, ArmorType.Mail };

        //Initializes a new instance of the Swashbuckler class. Takes name as parameter.
        public Swashbuckler(string name) : base(name, validWeaponTypes, validArmorTypes)
        {
            LevelAttributes = new HeroAttribute(2, 6, 1);
        }

        //Returns the damaging attribute multiplier for the Swashbuckler.
        public override double GetDamagingAttributeMultiplier()
        {
            return CalculateTotalAttributes().Dexterity;
        }

        //Increases the Swashbuckler's level and adjusts attributes accordingly.
        public override void LevelUp()
        {
            Level++;

            LevelAttributes.Strength += 1;
            LevelAttributes.Dexterity += 4;
            LevelAttributes.Intelligence += 1;
        }

        /// <summary>
        /// Displays information about the Swashbuckler.
        /// </summary>
        /// <returns>A string containing Swashbuckler information.</returns>
        public override string Display()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Class: Swashbuckler");
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
