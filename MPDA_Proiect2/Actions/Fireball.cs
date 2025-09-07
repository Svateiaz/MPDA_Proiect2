using MPDA_Proiect2.Models.Characters;
using MPDA_Proiect2.Models.Interfaces;

namespace MPDA_Proiect2.Actions
{
    public class Fireball : IActionStrategy
    {
        public int ManaCost { get; } = 10;
        private static readonly Random Randomizer = new();

        public void Execute(ICharacter actor, ICharacter target)
        {
            if (actor.Mana < ManaCost) return;
            actor.UseMana(ManaCost);

            int baseDamage = 30 + (actor is Character c ? c.Magic : 0);

            int variance = (int)(baseDamage * 0.15);
            int damage = baseDamage + Randomizer.Next(-variance, variance + 1);

            target.TakeDamage(damage);
        }
    }
}
