using DungeonMaster.HeroTypes;

namespace DungeonMaster.Tests
{
    public class BarbarianTests
    {
        [Fact]
        public void Create_Barbarian_Test()
        {
            //Arrange
            string name = "Tommy";

            //Act
            Barbarian barbarian = new Barbarian(name);

            //Assert
            Assert.Equal(name, barbarian.Name);
            Assert.Equal(1, barbarian.Level);
            Assert.Equal(5, barbarian.LevelAttributes.Strength);
            Assert.Equal(2, barbarian.LevelAttributes.Dexterity);
            Assert.Equal(1, barbarian.LevelAttributes.Intelligence);
        }
        [Fact]
        public void Barbarian_LevelUp_Test()
        {
            //Arrange
            string name = "Tommy";

            //Act
            Barbarian barbarian = new Barbarian(name);
            barbarian.LevelUp();

            //Assert
            Assert.Equal(2, barbarian.Level);
            Assert.Equal(8, barbarian.LevelAttributes.Strength);
            Assert.Equal(4, barbarian.LevelAttributes.Dexterity);
            Assert.Equal(2, barbarian.LevelAttributes.Intelligence);
        }
    }
}
