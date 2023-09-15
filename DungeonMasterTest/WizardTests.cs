using DungeonMaster.HeroTypes;

namespace DungeonMasterTest
{

    public class WizardTests
    {

        [Fact]
        public void Create_Wizard_Test()
        {
            //Arrange
            string name = "Gandalf";

            //Act
            Wizard wizard = new(name);

            //Assert
            Assert.Equal(name, wizard.Name);
            Assert.Equal(1, wizard.Level);
            Assert.Equal(1, wizard.LevelAttributes.Strength);
            Assert.Equal(1, wizard.LevelAttributes.Dexterity);
            Assert.Equal(8, wizard.LevelAttributes.Intelligence);
        }

        [Fact]
        public void Wizard_LevelUp_Test()
        {
            //Arrange
            string name = "Gandalf";

            //Act
            Wizard wizard = new(name);
            wizard.LevelUp();

            //Assert
            Assert.Equal(2, wizard.Level);
            Assert.Equal(2, wizard.LevelAttributes.Strength);
            Assert.Equal(2, wizard.LevelAttributes.Dexterity);
            Assert.Equal(13, wizard.LevelAttributes.Intelligence);
        }
    }
}

