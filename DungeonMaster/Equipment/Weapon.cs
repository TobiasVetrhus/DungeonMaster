using DungeonMaster.Enums;

namespace DungeonMaster.Equipment
{
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; }
        public int WeaponDamage { get; }

        /// <summary>
        /// Method for creating a Weapon object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requiredLevel"></param>
        /// <param name="weaponType"></param>
        /// <param name="weaponDamage"></param>
        public Weapon(string name, int requiredLevel, WeaponType weaponType, int weaponDamage)
            : base(name, requiredLevel, Slot.Weapon)
        {
            WeaponType = weaponType;
            WeaponDamage = weaponDamage;
        }
    }
}
