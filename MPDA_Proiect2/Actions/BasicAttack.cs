using MPDA_Proiect2.Models.Characters;
using MPDA_Proiect2.Models.Interfaces;

namespace MPDA_Proiect2.Actions
{
    public class BasicAttack : IActionStrategy
    {
        private static readonly Random Randomizer = new();

        public void Execute(ICharacter actor, ICharacter target)
        {
            int baseDamage = actor.AttackPower + (actor is Character c ? c.Strength : 0);

            int variance = (int)(baseDamage * 0.1);
            int damage = baseDamage + Randomizer.Next(-variance, variance + 1);

            target.TakeDamage(damage);
        }
    }
}
