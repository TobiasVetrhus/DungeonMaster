using DungeonMaster.Enums;
using DungeonMaster.Equipment;
using DungeonMaster.HeroBase;

namespace DungeonMaster.Tests
{
    public class ArmorTests
    {
        [Fact]
        public void Armor_Creation_Test()
        {
            //Arrange
            string name = "Common Plate Chest";
            int requiredLevel = 1;
            ArmorType armorType = ArmorType.Plate;
            HeroAttribute armorAttribute = new HeroAttribute(1, 0, 0);
            Slot equipmentSlot = Slot.Body;

            //Act
            Armor armor = new Armor(name, requiredLevel, armorType, armorAttribute, equipmentSlot);

            //Assert
            Assert.Equal(name, armor.Name);
            Assert.Equal(requiredLevel, armor.RequiredLevel);
            Assert.Equal(armorType, armor.ArmorType);
            Assert.Equal(armorAttribute, armor.ArmorAttributes);
            Assert.Equal(equipmentSlot, armor.EquipmentSlot);
        }
    }
}

