using MPDA_Proiect2.Models.Interfaces;

namespace MPDA_Proiect2.Models.Characters
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(
      string name,
      int health,
      int mana,
      int attack,
      int strength,
      int magic,
      int intuition,
      List<string> abilities,
      int level = 1)
        {
            Name = name;
            ImagePath = $"images/characters/{name.ToLower()}.png";
            Health = health;
            Mana = mana;
            AttackPower = attack;
            Strength = strength;
            Magic = magic;
            Intuition = intuition;
            Abilities = abilities;
            Level = level;

        }

    }
}
