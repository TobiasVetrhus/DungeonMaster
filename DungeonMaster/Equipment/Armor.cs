using DungeonMaster.Enums;
using DungeonMaster.HeroBase;

namespace DungeonMaster.Equipment
{
    public class Armor : Item
    {
        public ArmorType ArmorType { get; }
        public HeroAttribute ArmorAttributes { get; }
        public Slot EquipmentSlot { get; }

        /// <summary>
        /// Method to create an Armor object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requiredLevel"></param>
        /// <param name="armorType"></param>
        /// <param name="armorAttribute"></param>
        /// <param name="equipmentSlot"></param>
        public Armor(string name, int requiredLevel, ArmorType armorType, HeroAttribute armorAttribute, Slot equipmentSlot)
            : base(name, requiredLevel, equipmentSlot)
        {
            ArmorType = armorType;
            ArmorAttributes = armorAttribute;
            EquipmentSlot = equipmentSlot;
        }
    }
}
