using MPDA_Proiect2.Actions;
using MPDA_Proiect2.Factories;
using MPDA_Proiect2.Models.Interfaces;

namespace MPDA_Proiect2.Services
{
    public class GameEngine
    {
        public List<ICharacter> Players { get; set; } = new();
        public List<ICharacter> Enemies { get; set; } = new();
        public List<string> BattleLog { get; set; } = new();

        public void Initialize()
        {
            Players.Clear();
            Enemies.Clear();
            BattleLog.Clear();

            Players.Add(CharacterFactory.CreatePlayer("Warrior", "Warrior"));
            Players.Add(CharacterFactory.CreatePlayer("Mage", "Mage"));
            Players.Add(CharacterFactory.CreatePlayer("Healer", "Healer"));


            Enemies.Add(CharacterFactory.CreateEnemy("Goblin"));
            Enemies.Add(CharacterFactory.CreateEnemy("Wolf"));
        }

        public void PlayerAction(int playerIndex, string actionType, int targetIndex)
        {
            if (playerIndex >= Players.Count) return;

            var player = Players[playerIndex];
            ICharacter target = actionType == "Heal"
                ? Players[targetIndex]
                : (targetIndex < Enemies.Count ? Enemies[targetIndex] : null);

            if (target == null) return;

            IActionStrategy action = actionType switch
            {
                "Attack" => new BasicAttack(),
                "Fireball" => new Fireball(),
                "Heal" => new HealSpell(),
                _ => new BasicAttack()
            };

            player.PerformAction(action, target, BattleLog);
            BattleLog.Add($"{player.Name} used {actionType} on {target.Name}.");

            var rng = new Random();

            foreach (var enemy in Enemies.Where(e => e.Health > 0))
            {
                var alivePlayers = Players.Where(p => p.Health > 0).ToList();
                if (!alivePlayers.Any()) break;

                var enemyTarget = alivePlayers[rng.Next(alivePlayers.Count)];

                var enemyAction = new EnemyAttack(); 
                enemy.PerformAction(enemyAction, enemyTarget, BattleLog);
            }
        }

        public bool IsBattleOver() =>
            Players.All(p => p.Health <= 0) || Enemies.All(e => e.Health <= 0);
    }

}
