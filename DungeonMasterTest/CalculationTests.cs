
using DungeonMaster.Enums;
using DungeonMaster.Equipment;
using DungeonMaster.HeroBase;
using DungeonMaster.HeroTypes;

namespace DungeonMaster.Tests
{
    public class CalculationTests
    {
        [Fact]
        public void Calculate_Total_Attributes_No_Equipment()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Tommy");

            // Act
            HeroAttribute totalAttributes = barbarian.CalculateTotalAttributes();

            // Assert
            Assert.Equal(5, totalAttributes.Strength);
            Assert.Equal(2, totalAttributes.Dexterity);
            Assert.Equal(1, totalAttributes.Intelligence);
        }

        [Fact]
        public void Calculate_Total_Attributes_One_Piece_Of_Armor()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Tommy");
            Armor armor = new Armor("Common Plate Chest", 1, ArmorType.Plate, new HeroAttribute(1, 0, 0), Slot.Body);
            barbarian.EquipArmor(armor);

            // Act
            HeroAttribute totalAttributes = barbarian.CalculateTotalAttributes();

            // Assert
            Assert.Equal(6, totalAttributes.Strength);
            Assert.Equal(2, totalAttributes.Dexterity);
            Assert.Equal(1, totalAttributes.Intelligence);
        }

        [Fact]
        public void Calculate_Total_Attributes_Two_Pieces_Of_Armor()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Tommy");
            Armor armor1 = new Armor("Common Plate Chest", 1, ArmorType.Plate, new HeroAttribute(1, 0, 0), Slot.Body);
            Armor armor2 = new Armor("Common Plate Legs", 1, ArmorType.Plate, new HeroAttribute(1, 0, 0), Slot.Legs);
            barbarian.EquipArmor(armor1);
            barbarian.EquipArmor(armor2);

            // Act
            HeroAttribute totalAttributes = barbarian.CalculateTotalAttributes();

            // Assert
            Assert.Equal(7, totalAttributes.Strength);
            Assert.Equal(2, totalAttributes.Dexterity);
            Assert.Equal(1, totalAttributes.Intelligence);
        }

        [Fact]
        public void Calculate_Total_Attributes_Replaced_Armor()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Tommy");
            Armor armor1 = new Armor("Common Plate Chest", 1, ArmorType.Plate, new HeroAttribute(1, 0, 0), Slot.Body);
            Armor armor2 = new Armor("Common Plate Legs", 1, ArmorType.Plate, new HeroAttribute(1, 0, 0), Slot.Legs);
            barbarian.EquipArmor(armor1);
            barbarian.EquipArmor(armor2);

            // Replacing armor in the same slot
            Armor newArmor = new Armor("Improved Plate Chest", 1, ArmorType.Plate, new HeroAttribute(2, 0, 0), Slot.Body);
            barbarian.EquipArmor(newArmor);

            // Act
            HeroAttribute totalAttributes = barbarian.CalculateTotalAttributes();

            // Assert
            Assert.Equal(8, totalAttributes.Strength);
            Assert.Equal(2, totalAttributes.Dexterity);
            Assert.Equal(1, totalAttributes.Intelligence);
        }

        [Fact]
        public void Calculate_Damage_No_Weapon_Equipped()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Tommy");

            // Act
            double damage = barbarian.CalculateDamage();

            // Assert
            Assert.Equal(1.05, damage, 2);
        }

        [Fact]
        public void Calculate_Damage_With_Weapon_Equipped()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Tommy");
            Weapon weapon = new Weapon("Common Hatchet", 1, WeaponType.Hatchet, 2);
            barbarian.EquipWeapon(weapon);

            // Act
            double damage = barbarian.CalculateDamage();

            // Assert
            Assert.Equal(2.1, damage, 2);
        }

        [Fact]
        public void Calculate_Damage_Replaced_Weapon()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Conan");
            Weapon weapon1 = new Weapon("Common Hatchet", 1, WeaponType.Hatchet, 2);
            Weapon weapon2 = new Weapon("Improved Hatchet", 1, WeaponType.Hatchet, 3);
            barbarian.EquipWeapon(weapon1);

            // Replacing weapon
            barbarian.EquipWeapon(weapon2);

            // Act
            double damage = barbarian.CalculateDamage();

            // Assert
            Assert.Equal(3.15, damage, 2);
        }

        [Fact]
        public void Calculate_Damage_Weapon_And_Armor_Equipped()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Tommy");
            Weapon weapon = new Weapon("Common Hatchet", 1, WeaponType.Hatchet, 2);
            Armor armor = new Armor("Common Plate Chest", 1, ArmorType.Plate, new HeroAttribute(1, 0, 0), Slot.Body);
            barbarian.EquipWeapon(weapon);
            barbarian.EquipArmor(armor);

            // Act
            double damage = barbarian.CalculateDamage();

            // Assert
            Assert.Equal(2.12, damage, 2);
        }
    }
}

