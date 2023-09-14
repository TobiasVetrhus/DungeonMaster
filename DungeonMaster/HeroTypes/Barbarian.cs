using DungeonMaster.Enums;
using DungeonMaster.HeroBase;
using System.Text;

namespace DungeonMaster.HeroTypes
{
    public class Barbarian : Hero
    {
        //Valid Weapom amd Armor for the Barbarian class.
        private static readonly List<WeaponType> validWeaponTypes = new List<WeaponType> { WeaponType.Mace, WeaponType.Sword, WeaponType.Hatchet };
        private static readonly List<ArmorType> validArmorTypes = new List<ArmorType> { ArmorType.Mail, ArmorType.Plate };

        //Initializes a new instance of the Barbarian class. Takes name as parameter.
        public Barbarian(string name) : base(name, validWeaponTypes, validArmorTypes)
        {
            LevelAttributes = new HeroAttribute(5, 2, 1);
        }

        //Returns the damaging attribute multiplier for the Barbarian.
        public override double GetDamagingAttributeMultiplier()
        {
            return CalculateTotalAttributes().Strength;
        }

        //Increases the Barbarian's level and adjusts attributes accordingly.
        public override void LevelUp()
        {
            Level++;

            LevelAttributes.Strength += 3;
            LevelAttributes.Dexterity += 2;
            LevelAttributes.Intelligence += 1;
        }

        /// <summary>
        /// Displays information about the Barbarian.
        /// </summary>
        /// <returns>A string containing Barbarian information.</returns>
        public override string Display()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Class: Barbarian");
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
