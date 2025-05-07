

   public class Entity
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int maxHealth { get; set; }
        public int Exp { get; set; }
        public int Level { get; set; }

        public Entity(string name, int health, int attack, int Maxhealth, int exp, int level)
        {
            Name = name;
            Health = health;
            Attack = attack;
            maxHealth = Maxhealth;
            Exp = exp;
            Level = level;
        }

        public void SetName(string name)
        {
            Name = name;
        }

public  void TakeDamage(int damage)  
        {
            Health -= damage;
        }

        public void SetAttack(int attackValue)
        {
            Attack = attackValue;
        }
    }

