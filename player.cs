
    public class Player : Entity
    {
        public float Critchance { get; set; }
        public float Hitmulti { get; set; }

        public Player(string name, int health, int attack, int Maxhealth, int exp, int level, int critchance, float hitmulti) : base(name, health, attack, Maxhealth, exp, level)
        {
            Critchance = critchance;
            Hitmulti = hitmulti;
        }
    }
    
