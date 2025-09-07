using MPDA_Proiect2.Models.Characters;
using MPDA_Proiect2.Models.Interfaces;

namespace MPDA_Proiect2.Factories
{
    public static class CharacterFactory
    {
        public static ICharacter CreatePlayer(string classType, string name)
        {
            return classType switch
            {
                "Warrior" => new PlayerCharacter(name, 150, 50, 20, 20, 5, 10, new List<string> { "Attack" }),
                "Mage" => new PlayerCharacter(name, 100, 100, 10, 5, 25, 15, new List<string> { "Attack", "Fireball" }),
                "Healer" => new PlayerCharacter(name, 120, 60, 15, 10, 15, 20, new List<string> {"Heal" }),
                _ => throw new ArgumentException("Invalid player class")
            };
        }

        public static ICharacter CreateEnemy(string name)
        {
            return name switch
            {
                "Goblin" => new EnemyCharacter("Goblin", 80, 0, 15),
                "Wolf" => new EnemyCharacter("Wolf", 70, 0, 20),

                "Skeleton" => new EnemyCharacter("Skeleton", 100, 0, 25),
                "Orc" => new EnemyCharacter("Orc", 150, 0, 40),

                _ => throw new ArgumentException("Invalid enemy name")
            };
        }

        public static List<ICharacter> GetEnemiesForArea(string area)
        {
            return area switch
            {
                "Forest" => new List<ICharacter> { CreateEnemy("Goblin"), CreateEnemy("Wolf") },
                "Cave" => new List<ICharacter> { CreateEnemy("Skeleton"), CreateEnemy("Orc") },
                _ => throw new ArgumentException("Invalid area")
            };
        }
    }
}
