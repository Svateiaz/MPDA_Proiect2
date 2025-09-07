namespace MPDA_Proiect2.Models.Characters
{
    public class EnemyCharacter : Character
    {
        public EnemyCharacter(string name, int health, int mana, int attack)
        {
            Name = name;
            ImagePath = $"images/enemies/{name.ToLower()}.png";
            Health = health;
            Mana = mana;
            AttackPower = attack;
        }
    }
}
