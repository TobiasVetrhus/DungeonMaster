
using DungeonMaster.Enums;
using DungeonMaster.Equipment;
using DungeonMaster.HeroBase;
using DungeonMaster.HeroTypes;

namespace DungeonMaster.Tests
{
    public class DisplayTest
    {
        [Fact]
        public void Barbarian_Display_Test()
        {
            // Arrange
            string name = "Tommy";
            Barbarian barbarian = new Barbarian(name);
            barbarian.EquipWeapon(new Weapon("Common Hatchet", 1, WeaponType.Hatchet, 2));
            barbarian.EquipArmor(new Armor("Common Plate Chest", 1, ArmorType.Plate, new HeroAttribute(1, 0, 0), Slot.Body));

            // Act
            string displayResult = barbarian.Display();

            // Assert
            string expectedDisplay = "Name: Tommy\r\nClass: Barbarian\r\nLevel: 1\r\nTotal Strength: 6\r\nTotal Dexterity: 2\r\nTotal Intelligence: 1\r\nDamage: 2.12\r\nEquipped Weapons:\r\n Weapon: Common Hatchet\r\n     Damage: 2\r\nEquipped Armor:\r\n Body: Common Plate Chest\r\n     Armor Attributes:\r\n         Strength: 1\r\n         Dexterity: 0\r\n         Intelligence: 0\r\n";
            Assert.Equal(expectedDisplay, displayResult);
        }
    }
}
