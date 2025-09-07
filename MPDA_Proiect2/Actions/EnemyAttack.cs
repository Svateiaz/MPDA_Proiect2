using MPDA_Proiect2.Models.Interfaces;

namespace MPDA_Proiect2.Actions
{
    public class EnemyAttack : IActionStrategy
    {
        private static readonly Random Randomizer = new();

        public void Execute(ICharacter actor, ICharacter target)
        {
            int baseDamage = actor.AttackPower;

            int variance = (int)(baseDamage * 0.2);
            int damage = baseDamage + Randomizer.Next(-variance, variance + 1);

            target.TakeDamage(damage);
        }
    }
}
