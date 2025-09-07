namespace MPDA_Proiect2.Models.Interfaces
{
    public interface ICharacter
    {
        string Name { get; }
        string ImagePath { get; }
        int Health { get; set; }
        int Mana { get; set; }
        int AttackPower { get; }
        int Level { get; }
        int Strength { get; }
        int Magic { get; }
        int Intuition { get; }
        List<string> Abilities { get; }

        void TakeDamage(int amount);
        void Heal(int amount);
        void UseMana(int amount);
        void PerformAction(IActionStrategy action, ICharacter target, List<string> battleLog);
    }
}
