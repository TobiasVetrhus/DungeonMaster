namespace DungeonMaster.HeroBase
{
    public class HeroAttribute
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        //Constructor for a HeroAttribute.
        public HeroAttribute(int strength = 0, int dexterity = 0, int intelligence = 0)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        /// <summary>
        /// Add two instances of HeroAttribute together and returns a new instance
        /// with the summed attribute value.
        /// </summary>
        /// <param name="attribute1"></param>
        /// <param name="attribute2"></param>
        /// <returns>A new HeroAttribute with summed attribute values.</returns>
        public static HeroAttribute Add(HeroAttribute attribute1, HeroAttribute attribute2)
        {
            int totalStrength = attribute1.Strength + attribute2.Strength;
            int totalDexterity = attribute1.Dexterity + attribute2.Dexterity;
            int totalIntelligence = attribute1.Intelligence + attribute2.Intelligence;

            return new HeroAttribute(totalStrength, totalDexterity, totalIntelligence);
        }
    }
}
