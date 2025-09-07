using MPDA_Proiect2.Actions;
using MPDA_Proiect2.Models.Interfaces;
using MPDA_Proiect2.Factories;
using Xunit;
using System.Collections.Generic;

public class ActionTests
{
    [Fact]
    public void BasicAttack_ReducesTargetHealth_AndLogsAction()
    {
        // Arrange
        ICharacter attacker = CharacterFactory.CreatePlayer("Warrior", "Warrior");
        ICharacter target = CharacterFactory.CreateEnemy("Skeleton");
        List<string> battleLog = new List<string>();
        IActionStrategy attack = new BasicAttack();

        int initialTargetHealth = target.Health;

        // Act
        attacker.PerformAction(attack, target, battleLog);

        // Assert
        Assert.True(target.Health < initialTargetHealth); 
        Assert.Contains("Warrior", string.Join(" ", battleLog)); 
    }
}
