public class TankEnemy : Enemy
{
    public int armorValue { get; set; }

    public TankEnemy(string name, int health, int attack, int Maxhealth, int exp, int level, int armor) 
        : base(name, health, attack, Maxhealth, exp, level)
{
armorValue = armor;
    
}

}
