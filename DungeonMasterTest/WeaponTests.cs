
using DungeonMaster.Enums;
using DungeonMaster.Equipment;

namespace DungeonMaster.Tests
{
    public class WeaponTests
    {
        [Fact]
        public void Test_Weapon_Creation()
        {
            //Arrange
            string name = "Common Hatchet";
            int requiredLevel = 1;
            WeaponType weaponType = WeaponType.Hatchet;
            int weaponDamage = 2;

            //Act
            Weapon weapon = new Weapon(name, requiredLevel, weaponType, weaponDamage);

            //Assert
            Assert.Equal(name, weapon.Name);
            Assert.Equal(requiredLevel, weapon.RequiredLevel);
            Assert.Equal(Slot.Weapon, weapon.Slot);
            Assert.Equal(weaponType, weapon.WeaponType);
            Assert.Equal(weaponDamage, weapon.WeaponDamage);
        }
    }
}
