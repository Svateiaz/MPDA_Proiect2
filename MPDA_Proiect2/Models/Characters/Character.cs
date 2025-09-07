using MPDA_Proiect2.Models.Interfaces;

namespace MPDA_Proiect2.Models.Characters
{
    public abstract class Character : ICharacter
    {
        public string Name { get; protected set; }
        public string ImagePath { get; protected set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Level { get; protected set; } = 1;
        public int Strength { get; protected set; }
        public int Magic { get; protected set; }
        public int Intuition { get; protected set; }
        public int AttackPower { get; protected set; }
        public List<string> Abilities { get; set; }

        public void TakeDamage(int amount) => Health -= amount;
        public void Heal(int amount) => Health += amount;
        public void UseMana(int amount) => Mana -= amount;

        public void PerformAction(IActionStrategy action, ICharacter target, List<string> battleLog)
        {
            int beforeHp = target.Health;

            action.Execute(this, target);
            int damageDealt = beforeHp - target.Health;

            string actionName = action.GetType().Name switch
            {
                "BasicAttack" => "Attack",
                "Fireball" => "Fireball",
                "HealSpell" => "Heal",
                _ => "Unknown"
            };

            if (actionName == "Heal")
                battleLog.Add($"{Name} used {actionName} on {target.Name}, restoring {Math.Abs(damageDealt)} HP.");
            else
                battleLog.Add($"{Name} used {actionName} on {target.Name}, dealing {damageDealt} damage.");
        }
    }
}
