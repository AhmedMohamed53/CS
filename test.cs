void PrintSlowly(string message, ConsoleColor kleur = ConsoleColor.Yellow, bool useWriteline = true, int delay = 35)
{
   Console.ForegroundColor
           = kleur;
   if (useWriteline)
   {
      foreach (char c in message)
      {
         Console.Write(c);
         Thread.Sleep(delay);
      }
      Console.WriteLine();
   }
   else
   {
      foreach (char c in message)
      {
         Console.Write(c);
         Thread.Sleep(delay);
      }
      ;
   }
}


int maxHealth = 100;


PrintSlowly("Plese enter your name:");
string userName = Console.ReadLine();
Player player = new Player(userName, 100, 10, 100, 0, 1, 30, 1.5f);



string[] enemies = { "Old Man", "Goblin", "Dwarf", "Jasper", "Shedion", "Von" };
string[] bEnemy = { "Old Man", "Goblin", "Dwarf" };
string[] tEnemy = { "Jasper", "Shedion", "Von" };

Random random = new Random();
Enemy enemy = new Enemy("Goblin", 40, 8, 40, 0, 1);


PrintSlowly("Welcome," + userName);

PrintSlowly("You found yourself laying down, Lost in a forest");
PrintSlowly("You are fulled with rage");
PrintSlowly("You are ready to fight");
PrintSlowly("A wild Goblin appeared");




while (player.Health > 0)
{
   Thread.Sleep(1000);
   Console.Clear();
   if (enemy.Health <= 0)
   {

      string randomEnemy = enemies[random.Next(0, enemies.Length)];
      int randomHealth = random.Next(30, 120);
      int randomDamage = random.Next(5, 20);

      Enemy enemy1;

      enemy1 = new Enemy(randomEnemy, randomHealth, randomDamage, 130, 0, 1);


      PrintSlowly($"A wild  {enemy1.Name} appears with {enemy1.Health} health, {enemy1.Attack} attack!", ConsoleColor.Red);
      enemy = enemy1;





   }
   PrintSlowly("\nChoose an action: A to attack, R to run, H to heal, N to do Nothing", ConsoleColor.Cyan, true, 20);
   string hit = Console.ReadLine().ToUpper();
   if (hit == "H")
   {

      player.Health = player.maxHealth;
      if (player.Health < player.maxHealth)
      {
         player.Health = maxHealth;
         PrintSlowly($"You have {player.maxHealth} Health, you can't go above that!", ConsoleColor.Red);
      }
      else
      {
         PrintSlowly("You have been healed, You have " + player.Health + " health left", ConsoleColor.White);
      }


   }

   if (hit == "A")
   {
      bool isCriticalHit = random.NextDouble() < (player.Critchance / 100f);
      if (isCriticalHit)
      {
         int criticalHitDamage = (int)(player.Attack * player.Hitmulti);
         PrintSlowly($"Critical hit! You attack the {enemy.Name} for {criticalHitDamage} damage.", ConsoleColor.Yellow);
         enemy.TakeDamage(criticalHitDamage);

         PrintSlowly($"{player.Name} attacks {enemy.Name} for {player.Attack} damage!", ConsoleColor.Green);
         PrintSlowly($"{enemy.Name} has {enemy.Health} HP left.", ConsoleColor.Green);

         player.TakeDamage(enemy.Attack);
         PrintSlowly($"{enemy.Name} attacks {player.Name} for {enemy.Attack} damage!", ConsoleColor.Red);
         PrintSlowly($"{player.Name} has {player.Health} HP left.", ConsoleColor.Red);

         if (enemy.Health < 0)
         {
            enemy.Health = 0;

         }
      }
      else
      {
         enemy.TakeDamage(player.Attack);
         PrintSlowly($"{player.Name} attacks {enemy.Name} for {player.Attack} damage!", ConsoleColor.Green);
         PrintSlowly($"{enemy.Name} has {enemy.Health} HP left.", ConsoleColor.Green);

         player.TakeDamage(enemy.Attack);
         PrintSlowly($"{enemy.Name} attacks {player.Name} for {enemy.Attack} damage!", ConsoleColor.Red);
         PrintSlowly($"{player.Name} has {player.Health} HP left.", ConsoleColor.Red);
      }
   }




   if (hit == "R")
   {
      PrintSlowly($"{player.Name} ran away from {enemy.Name}!");

      break;


   }

   if (hit == "N")
   {
      PrintSlowly($"{player.Name} did nothing.");
      player.TakeDamage(enemy.Attack);
      PrintSlowly($"{enemy.Name} attacks {player.Name} for {enemy.Attack} damage!", ConsoleColor.Red);
      PrintSlowly($"{player.Name} has {player.Health} HP left.", ConsoleColor.Red);
   }

   if (enemy.Health <= 0)
   {
      PrintSlowly($"You have defeated the {enemy.Name}!", ConsoleColor.Green);
      if (enemy.Name == "Von")
      {
         int expGained = random.Next(50, 100);
         player.Exp += expGained;
         PrintSlowly($"you have gained {expGained} experience!", ConsoleColor.Cyan);
      }
      if (enemy.Name == "Shedion")
      {
         int expGained = random.Next(30, 70);
         player.Exp += expGained;
         PrintSlowly($"you have gained {expGained} experience!", ConsoleColor.Cyan);
      }
      if (enemy.Name == "Jasper")
      {
         int expGained = random.Next(20, 50);
         player.Exp += expGained;
         PrintSlowly($"you have gained {expGained} experience!", ConsoleColor.Cyan);
      }
      if (enemy.Name == "Old Man")
      {
         int expGained = random.Next(10, 30);
         player.Exp += expGained;
         PrintSlowly($"you have gained {expGained} experience!", ConsoleColor.Cyan);
      }
      if (enemy.Name == "Dwarf")
      {
         int expGained = random.Next(5, 20);
         player.Exp += expGained;
         PrintSlowly($"you have gained {expGained} experience!", ConsoleColor.Cyan);
      }
      if (enemy.Name == "Goblin")
      {
         int expGained = random.Next(1, 10);
         player.Exp += expGained;
         PrintSlowly($"you have gained {expGained} experience!", ConsoleColor.Cyan);
      }
      int healthGain = random.Next(10, 30);
      player.Health += healthGain;
      PrintSlowly($"You have healed {healthGain} health by defeating the {enemy.Name}\n", ConsoleColor.Green);
      PrintSlowly($"You are level {player.Level} with {player.Exp}/100 experience", ConsoleColor.Cyan);

      if (player.Exp >= 100)
      {
         player.Level++;
         player.Exp = player.Exp - 100;
         player.maxHealth += 10;
         player.Attack += random.Next(1, 9);
         maxHealth += 10;
         PrintSlowly($"You have leveled up! You are now level {player.Level}. You have {player.Health} health, {player.Attack} attack and your max health has increased to {player.maxHealth} health.", ConsoleColor.Green);
      }

   }



   if (player.Health <= 0)
   {
      PrintSlowly($"{player.Name} died!");
      break;

   }
   if (player.Health > player.maxHealth)
   {
      player.Health = player.maxHealth;
   }


}
