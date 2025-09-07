using MPDA_Proiect2.Models.Interfaces;
using MPDA_Proiect2.Factories;
using Xunit;

public class CharacterTests
{
    [Fact]
    public void Player_TakesDamage_DecreasesHealth()
    {
        // Arrange
        ICharacter warrior = CharacterFactory.CreatePlayer("Warrior", "Warrior");
        int damage = 30;

        // Act
        warrior.TakeDamage(damage);

        // Assert
        Assert.Equal(120, warrior.Health); 
    }

    [Fact]
    public void Player_Heals_IncreasesHealth()
    {
        // Arrange
        ICharacter healer = CharacterFactory.CreatePlayer("Healer", "Healer");
        healer.TakeDamage(50);

        // Act
        healer.Heal(30);

        // Assert
        Assert.Equal(100, healer.Health); 
    }
}
