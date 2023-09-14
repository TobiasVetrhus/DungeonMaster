using DungeonMaster.CustomExceptions;
using DungeonMaster.Enums;
using DungeonMaster.Equipment;
using DungeonMaster.HeroTypes;
using System.Text;

namespace DungeonMaster.HeroBase
{
    public abstract class Hero : IHero
    {
        //Properties to store Hero information. 
        public string Name { get; }
        public int Level { get; set; }
        public HeroAttribute LevelAttributes { get; set; }
        public Dictionary<Slot, Item?> Equipment { get; }
        public List<WeaponType> ValidWeaponTypes { get; }
        public List<ArmorType> ValidArmorTypes { get; }

        /// <summary>
        /// Constructor to initialize hero properties.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="validWeaponTypes"></param>
        /// <param name="validArmorTypes"></param>
        protected Hero(string name, List<WeaponType> validWeaponTypes, List<ArmorType> validArmorTypes)
        {
            Name = name;
            Level = 1;
            LevelAttributes = new HeroAttribute();
            Equipment = new Dictionary<Slot, Item?>
            {
                { Slot.Weapon, null },
                { Slot.Head, null },
                { Slot.Body, null },
                { Slot.Legs, null }
            };
            ValidWeaponTypes = validWeaponTypes;
            ValidArmorTypes = validArmorTypes;
        }

        //Abstract methods to be implemented by subclasses.
        public abstract void LevelUp();
        public abstract double GetDamagingAttributeMultiplier();
        public abstract string Display();

        /// <summary>
        /// Method to equip Weapon.
        /// </summary>
        /// <param name="weapon"></param>
        /// <exception cref="InvalidWeaponException">
        /// Throws an exception if the weapon is invalid.
        /// </exception>
        public void EquipWeapon(Weapon weapon)
        {
            if (ValidWeaponTypes.Contains(weapon.WeaponType) && Level >= weapon.RequiredLevel)
            {
                Equipment[Slot.Weapon] = weapon;
            }
            else
            {
                throw new InvalidWeaponException("The type cannot be used by this class or the weapon requires a higher level.\n");
            }
        }
        /// <summary>
        /// Method to equip Armor.
        /// </summary>
        /// <param name="armor"></param>
        /// <exception cref="InvalidArmorException">
        /// Throws an exception if the armor is invalid.
        /// </exception>
        public void EquipArmor(Armor armor)
        {
            if (ValidArmorTypes.Contains(armor.ArmorType) && Level >= armor.RequiredLevel)
            {
                Equipment[armor.EquipmentSlot] = armor;
            }
            else
            {
                throw new InvalidArmorException("The type cannot be used by this class or the armor requires a higher level.\n");
            }
        }

        /// <summary>
        /// Method to calculate the hero's total attributes.
        /// </summary>
        /// <returns>Total Attributes of the Hero.</returns>
        public HeroAttribute CalculateTotalAttributes()
        {
            HeroAttribute totalAttributes = LevelAttributes;

            //Loops through the Hero's equipment.
            foreach (KeyValuePair<Slot, Item?> equipmentItem in Equipment)
            {
                if (equipmentItem.Key != Slot.Weapon && equipmentItem.Value is Armor armor)
                {
                    totalAttributes = HeroAttribute.Add(totalAttributes, armor.ArmorAttributes); //Add armor attributes to the total attributes.
                }
            }
            return totalAttributes;
        }

        /// <summary>
        /// Calculates the hero's total damage, taking into account their base damage
        /// and any attribute modifiers based on their hero class.
        /// </summary>
        /// <returns>The calculated damage value.</returns>
        public double CalculateDamage()
        {
            double baseDamage = 1.0;

            //If Weapon is equipped update the baseDamage with the weapon's damage value.
            if (Equipment[Slot.Weapon] is Weapon equippedWeapon)
            {
                baseDamage = equippedWeapon.WeaponDamage;
            }

            double damagingAttributeMultiplier = 0.0;

            // Determine the hero class and add the corresponding attribute modifier.
            switch (this)
            {
                case Barbarian barbarian:
                    damagingAttributeMultiplier += barbarian.CalculateTotalAttributes().Strength;
                    break;
                case Wizard wizard:
                    damagingAttributeMultiplier += wizard.CalculateTotalAttributes().Intelligence;
                    break;
                case Archer archer:
                    damagingAttributeMultiplier += archer.CalculateTotalAttributes().Dexterity;
                    break;
                case Swashbuckler swashbuckler:
                    damagingAttributeMultiplier += swashbuckler.CalculateTotalAttributes().Dexterity;
                    break;
            }

            // Calculate the final damage by applying the base damage and attribute multiplier
            double damage = baseDamage * (1 + (damagingAttributeMultiplier / 100));

            return damage;
        }


        /// <summary>
        /// A method to be used by the Display to list a Hero's equipment.
        /// </summary>
        /// <returns>Returns the built string.</returns>
        public string ListEquippedItems()
        {
            StringBuilder stringBuilder = new StringBuilder();

            bool hasEquippedArmor = false;
            bool hasEquippedWeapon = false;

            //Loops through Equipment dictionary to list Armor and Weapon.
            foreach (KeyValuePair<Slot, Item?> equipmentItem in Equipment)
            {
                if (equipmentItem.Value is Armor equippedArmor)
                {
                    if (!hasEquippedArmor)
                    {
                        stringBuilder.AppendLine("Equipped Armor:");
                        hasEquippedArmor = true;
                    }

                    stringBuilder.AppendLine($" {equipmentItem.Key}: {equippedArmor.Name}");

                    stringBuilder.AppendLine($"     Armor Attributes:");
                    stringBuilder.AppendLine($"         Strength: {equippedArmor.ArmorAttributes.Strength}");
                    stringBuilder.AppendLine($"         Dexterity: {equippedArmor.ArmorAttributes.Dexterity}");
                    stringBuilder.AppendLine($"         Intelligence: {equippedArmor.ArmorAttributes.Intelligence}");
                }
                else if (equipmentItem.Value is Weapon equippedWeapon)
                {
                    if (!hasEquippedWeapon)
                    {
                        stringBuilder.AppendLine("Equipped Weapons:");
                        hasEquippedWeapon = true;
                    }

                    stringBuilder.AppendLine($" {equipmentItem.Key}: {equippedWeapon.Name}");
                    stringBuilder.AppendLine($"     Damage: {equippedWeapon.WeaponDamage}");
                }
            }

            if (!hasEquippedArmor)
            {
                stringBuilder.AppendLine("No Armor Equipped");
            }
            if (!hasEquippedWeapon)
            {
                stringBuilder.AppendLine("No Weapons Equipped");
            }

            return stringBuilder.ToString();
        }
    }
}
