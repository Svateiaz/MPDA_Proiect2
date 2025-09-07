using MPDA_Proiect2.Models.Interfaces;

namespace MPDA_Proiect2.Actions
{
    public class HealSpell : IActionStrategy
    {
        public int ManaCost { get; } = 8;
        public int HealAmount { get; } = 25;

        public void Execute(ICharacter actor, ICharacter target)
        {
            if (actor.Mana < ManaCost) return;
            actor.UseMana(ManaCost);
            target.Heal(HealAmount);
        }
    }
}
