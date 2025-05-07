public class Enemy : Entity
{


    public Enemy(string name, int health, int attack, int Maxhealth, int exp, int level) : base(name, health, attack, Maxhealth, exp, level)
    {
    }

    public virtual void PerformAttack(Entity target)
    {
        target.TakeDamage(Attack);
    }
}
