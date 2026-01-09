using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace parametre
{
   public class Program
    {
       static void Main(string[] args)
        {
            GameEnviroment.Day = 1;
            player Player= new player(100,80,50,20);
            XmlManager.LoadXMLWeapons();

           do
           {

               Console.Clear();
               Player.Refresh();
               Console.WriteLine();
               Console.Write("Zadajte prika>");
               string prikaz = Console.ReadLine();
               prikaz = prikaz.ToLower();

               switch (prikaz)
               {
                   case"suicade":
                       Player.DealDamage(50);
                       break;
                   case "eat":
                       Player.Eat(20);
                       break;
                   case "help":
                       Console.Clear();
                       Console.WriteLine("sleep,eat,close,suicade");
                       Thread.Sleep(3000);
                       break;
                   case "sleep":
                       Player.Sleep();
                       break;
                   case "close":
                       Console.ForegroundColor = ConsoleColor.Red;
                       Console.WriteLine("exit");
                       System.Threading.Thread.Sleep(1500);
                       Environment.Exit(0);
                       break;
               default:
                       Console.WriteLine("Invalid operation, try again(or writes help)");
                       break;
               }
               
           }while (true);
               Player.Refresh();
               
      Console.ReadLine();
        }

   }
}
   