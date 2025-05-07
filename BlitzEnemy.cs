public class BlitzEnemy : Enemy
{
    public int doublea { get; set; }

    public BlitzEnemy(string name, int health, int attack, int Maxhealth, int exp, int level, int doubleAttack) 
        : base(name, health, attack, Maxhealth, exp, level)
    {
        doublea = doubleAttack;
    }
}
