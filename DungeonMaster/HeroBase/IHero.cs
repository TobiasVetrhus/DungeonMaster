using DungeonMaster.Enums;
using DungeonMaster.Equipment;

namespace DungeonMaster.HeroBase
{
    public interface IHero
    {
        string Name { get; }
        int Level { get; }
        HeroAttribute LevelAttributes { get; }
        Dictionary<Slot, Item?> Equipment { get; }
        List<WeaponType> ValidWeaponTypes { get; }
        List<ArmorType> ValidArmorTypes { get; }

        void LevelUp();
        void EquipWeapon(Weapon weapon);
        void EquipArmor(Armor armor);
        double CalculateDamage();
        HeroAttribute CalculateTotalAttributes();
        string Display();
        string ListEquippedItems();
    }
}
