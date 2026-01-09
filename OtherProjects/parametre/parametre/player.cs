using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parametre
{
    public class player
    {

        int maxhealth=100;
       public int health;
       public int mana;
       public int stamina;
       public int armor;
       public int gold = 100;

      public player()
        {
                Console.WriteLine("class hrac inc");
        }

       public player(int health, int mana,int stamina, int armor)
       {
           
           this.maxhealth = 100;
           this.health = health;
           this.stamina = stamina;
           this.mana = mana;
           this.armor = armor;


       }

                


    public void Refresh()
    {
        Console.WriteLine("Day: " + GameEnviroment.Day);
        Console.WriteLine();
        Console.WriteLine("health: " + health);
        Console.WriteLine("stamina: " + stamina);
        Console.WriteLine("mana: " + mana);
        Console.WriteLine("armor: " + armor);
        Console.WriteLine("gold: " + gold);
    }

    public void DealDamage(int damage)
        {
        health -= damage;
        }



        public void Sleep()
    {
        GameEnviroment.Day++;
        }



        public void Eat(int foodPoints)
        {
            health += foodPoints;

            if (health > maxhealth)
            {
                health = maxhealth;
            }

        }



    }
}

    


