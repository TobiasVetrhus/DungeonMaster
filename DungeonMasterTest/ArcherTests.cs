using DungeonMaster.HeroTypes;

namespace DungeonMaster.Tests
{
    public class ArcherTests
    {
        [Fact]
        public void Create_Archer_Test()
        {
            //Arrange
            string name = "Legolas";

            //Act
            Archer archer = new Archer(name);

            //Assert
            Assert.Equal(name, archer.Name);
            Assert.Equal(1, archer.Level);
            Assert.Equal(1, archer.LevelAttributes.Strength);
            Assert.Equal(7, archer.LevelAttributes.Dexterity);
            Assert.Equal(1, archer.LevelAttributes.Intelligence);
        }

        [Fact]
        public void Archer_LevelUp_Test()
        {
            //Arrange
            string name = "Legolas";

            //Act
            Archer archer = new Archer(name);
            archer.LevelUp();

            //Assert
            Assert.Equal(2, archer.Level);
            Assert.Equal(2, archer.LevelAttributes.Strength);
            Assert.Equal(12, archer.LevelAttributes.Dexterity);
            Assert.Equal(2, archer.LevelAttributes.Intelligence);
        }
    }
}
