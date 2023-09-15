using DungeonMaster.HeroTypes;

namespace DungeonMaster.Tests
{
    public class SwashbucklerTests
    {
        [Fact]
        public void Create_Swashbuckler_Test()
        {
            //Arrange
            string name = "Noah";

            //Act
            Swashbuckler swashbuckler = new(name);

            //Assert
            Assert.Equal(name, swashbuckler.Name);
            Assert.Equal(1, swashbuckler.Level);
            Assert.Equal(2, swashbuckler.LevelAttributes.Strength);
            Assert.Equal(6, swashbuckler.LevelAttributes.Dexterity);
            Assert.Equal(1, swashbuckler.LevelAttributes.Intelligence);
        }
        [Fact]
        public void Swashbuckler_LevelUp_Test()
        {
            //Arrange
            string name = "Noah";

            //Act
            Swashbuckler swashbuckler = new(name);
            swashbuckler.LevelUp();

            //Assert
            Assert.Equal(2, swashbuckler.Level);
            Assert.Equal(3, swashbuckler.LevelAttributes.Strength);
            Assert.Equal(10, swashbuckler.LevelAttributes.Dexterity);
            Assert.Equal(2, swashbuckler.LevelAttributes.Intelligence);
        }
    }
}
