using DungeonMaster.CustomExceptions;
using DungeonMaster.Enums;
using DungeonMaster.Equipment;
using DungeonMaster.HeroBase;
using DungeonMaster.HeroTypes;


namespace DungeonMaster.Tests
{
    public class InvalidEquipmentTests
    {
        // Data for testing invalid weapon equipping for different hero types.
        public static IEnumerable<object[]> InvalidWeaponData()
        {
            yield return new object[] { typeof(Archer), new Weapon("Sword", 1, WeaponType.Sword, 10) };
            yield return new object[] { typeof(Archer), new Weapon("Bow", 2, WeaponType.Bow, 10) };

            yield return new object[] { typeof(Wizard), new Weapon("Sword", 1, WeaponType.Sword, 10) };
            yield return new object[] { typeof(Wizard), new Weapon("Wand", 2, WeaponType.Wand, 10) };

            yield return new object[] { typeof(Swashbuckler), new Weapon("Staff", 1, WeaponType.Staff, 10) };
            yield return new object[] { typeof(Swashbuckler), new Weapon("Dagger", 2, WeaponType.Dagger, 10) };

            yield return new object[] { typeof(Barbarian), new Weapon("Staff", 1, WeaponType.Staff, 10) };
            yield return new object[] { typeof(Barbarian), new Weapon("Sword", 2, WeaponType.Sword, 10) };
        }

        // Data for testing invalid armor equipping for different hero types.
        public static IEnumerable<object[]> InvalidArmorData()
        {
            yield return new object[] { typeof(Archer), new Armor("Cloth", 1, ArmorType.Cloth, new HeroAttribute(1, 1, 1), Slot.Body) };
            yield return new object[] { typeof(Archer), new Armor("Leather", 2, ArmorType.Leather, new HeroAttribute(1, 1, 1), Slot.Body) };

            yield return new object[] { typeof(Wizard), new Armor("Leather", 1, ArmorType.Leather, new HeroAttribute(1, 1, 1), Slot.Body) };
            yield return new object[] { typeof(Wizard), new Armor("Cloth", 2, ArmorType.Cloth, new HeroAttribute(1, 1, 1), Slot.Body) };

            yield return new object[] { typeof(Swashbuckler), new Armor("Cloth", 1, ArmorType.Cloth, new HeroAttribute(1, 1, 1), Slot.Body) };
            yield return new object[] { typeof(Swashbuckler), new Armor("Mail", 2, ArmorType.Mail, new HeroAttribute(1, 1, 1), Slot.Body) };

            yield return new object[] { typeof(Barbarian), new Armor("Cloth", 1, ArmorType.Cloth, new HeroAttribute(1, 1, 1), Slot.Body) };
            yield return new object[] { typeof(Barbarian), new Armor("Mail", 2, ArmorType.Mail, new HeroAttribute(1, 1, 1), Slot.Body) };
        }

        [Theory]
        [MemberData(nameof(InvalidWeaponData))]
        public void Hero_Equips_Invalid_Weapon_Test(Type heroType, Weapon invalidWeapon)
        {
            //Arrange
            Hero hero = (Hero)Activator.CreateInstance(heroType, "name");

            //Assert
            Assert.Throws<InvalidWeaponException>(() => hero.EquipWeapon(invalidWeapon));
        }

        [Theory]
        [MemberData(nameof(InvalidArmorData))]
        public void Hero_Equips_Invalid_Armor_Test(Type heroType, Armor invalidArmor)
        {
            //Arrange
            Hero hero = (Hero)Activator.CreateInstance(heroType, "name");

            //Assert
            Assert.Throws<InvalidArmorException>(() => hero.EquipArmor(invalidArmor));
        }
    }
}

