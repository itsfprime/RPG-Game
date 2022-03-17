using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; //Used for timing the text rate.
using static System.Console; //This avoids having to use Console.Whatever for everything. Console.WriteLine(); -> WriteLine(); Much easier
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace RPG_Game
{
    internal class Program
    {
        public class mobFight
        {
            public string lvl1UI = @"LVL 1 Monster                                                                                

                              @@@@@@#                                           
                          @@@@@@@@@@@@@@,                                       
                        @@@@@@@@@@@@@@@@@@                                      
                       (@@@@@@@@@@@@@@@@@@@                                     
                       @@@@@@@@@@@@@@@@@@@@                                     
                        @@@@@@@@@@@@@@@@@@,                                     
                         @@@@@@@@@@@@@@@@                                       
                            @@@@@@@@@@#                      ./@@@@@@@@@@@@*    
                                                (&@@@@@@@@@@@@@@@@@@@@@@@@@@    
                      @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@     
                   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/             
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(                           
             @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                     
          @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                     
       @@@@@@@@@@@@@    @@@@@@@@@@@@@@@@@@@                                     
       @@@@@@@@@@.      @@@@@@@@@@@@@@@@@@@                                     
        @@@@@@@@@@      @@@@@@@@@@@@@@@@@@@                                     
          @@@@@@@@@     @@@@@@@@@@@@@@@@@@@                                     
           @@@@@@@@@    @@@@@@@@@@@@@@@@@@@                                     
            @@@@@@@@@%  @@@@@@@@@@@@@@@@@@@                                     
             @@@@@@@@@@ @@@@@@@@@@@@@@@@@@@                                     
              #@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                     
                @@@@@@@@@@@@@@@@@@@@@@@@@@@                                     
                  .     @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@@   @@@@@@@@                                     
                        @@@@@@@.   @@@@@@@.                                                                                                                     
";

            public string lvl1Dead = @"";

            public double lvl1HP = 100;
            public double lvl1DMG = 12;
        }
        public class OdinsPlace
        {
            //ASCII ART OMG

            public string room = @"
      ────────────────────────────────────────────────
     /                                                \  
    /      -----------------------------------         \     
   /                                                    \    
  /     -----------------------------------------        \   
 /                                                        \  
|     -----------------------------------------------      \ 
|                                                           |
|                                                           |
|                      ┌────────┐                           |
|                      |        |                           |
|                      └────────┘                           |
|      ┌───┐                             ┌───┐              |
|      |   |            ┌──────┐         |   |              |
|      | ╬ |            |      |         | ╬ |              |
|      |   |            |      |         |   |              |
|      └───┘            |     .|         └───┘              |
|                       |      |                            |
|                       |      |                            |
└───────────────────────────────────────────────────────────┘";
        }
        public class Shop
        {
            public int weaponLevel = 1;
            public string contents =
                @"---Shop---
1.) Upgrade Sword ";

            //Input is for selection, price is self explanatory
            public string userInput;
            public int[] itemsPrice = { 100 };
            
        }
        public class Common
        {
            //Info about the user. Try not to use more than one input variable unless necessary.
            public string userName;
            public int userBal;
            public string userInput;
            public double health = 100;
            public double xp;

            //Weapon Stats:
            public int atkTime;
            public int damage;
            public int range;
            public int manaDmg;
            public int weaponLvl;

            //Has certain weapon bools
            public bool hasKE;
            public bool hasBow;
            public bool hasBA;
            public bool hasDag;

            //Weapon Name
            public string weaponName;

            //Weapon Stats. Stats[0] Is AtkTime, Stats[1] is Damage, Stats[2] is Range, and Stats[3] is Mana Damage;
            public double[] KESTATS = { 1.25, 1, 1, 1};
            public double[] BASTATS = { .5, 2, 1.25, .5};
            public double[] BOWSTATS = { .75, .5, 2, 1};
            public double[] DAGGERSTATS = { 2, .75, .5, 1};
        }

        static void Main(string[] args)
        {
            Random r = new Random();
            int useRand; //Integer to use for random.
            mobFight mobFight = new mobFight();
            OdinsPlace op = new OdinsPlace();
            Common common = new Common();
            Shop shop = new Shop();
            common.userBal = 1000;
            string d =  "Odin: Hey you! Yea, you. What's your name?";
            int x = 0;
            while(x < d.Length)
            {
                Write(d[x]);
                Thread.Sleep(25);
                x++;
            }
            if(x == d.Length)
            {
                WriteLine();
                x = 0;
            }
            ForegroundColor = ConsoleColor.Green; common.userName = ReadLine(); ForegroundColor = ConsoleColor.White;
            d = "Odin: Well hello, " + common.userName + ". My name is Odin, I assume you're new here, so I'll be giving you a quick tour. Don't go around telling everyone though, I'm not usually this nice.";
            while (x < d.Length)
            {
                Write(d[x]);
                Thread.Sleep(25);
                x++;
            }
            if (x == d.Length)
            {
                WriteLine();
                x = 0;
            }
            WriteLine("\nEnter to continue...");
            ReadLine();
            Clear();
            d = "Odin: Well, for starters, here in the Aether, you can't survive without a weapon, so I'll let you pick a weapon from my shop. It'll cost you though...";
            while (x < d.Length)
            {
                Write(d[x]);
                Thread.Sleep(25);
                x++;
            }
            if (x == d.Length)
            {
                WriteLine();
                x = 0;
            }
            ReadLine();
            d = "Odin: Here in the Aether, you must defeat monsters to survive. Monsters will allow you to earn XP to upgrade " +
                "your weapons and armor. XP has many uses, but unfortunately you cannot sell it. Speaking of which, " +
                "money is also important here in the Aether. You see, a huge monster raid came through 5 years ago (Year 1230) " +
                "so our economy isn't looking so great. Money can be difficult to get, but I suspect that you'll have no problem.";
            while (x < d.Length)
            {
                Write(d[x]);
                Thread.Sleep(25);
                x++;
            }
            if (x == d.Length)
            {
                WriteLine();
                x = 0;
            }
            d = "Anyways, money can be made via killing monsters, doing jobs, and for special events. It looks like you have about " 
                + common.userBal + " dollars. That's not bad. How'd you get that? Well, nevermind. The shop can be accessed at any time " +
                "by entering 's' at idle times. Try it out now!";
            while (x < d.Length)
            {
                Write(d[x]);
                Thread.Sleep(25);
                x++;
            }
            if (x == d.Length)
            {
                WriteLine();
                x = 0;
            }
            string startShop;
            startShop = ReadLine();
            if(startShop == "s")
            {
                WriteLine(shop.contents);

                WriteLine("\nPlease type the ID of the item you would like to buy. Enter an invalid input to leave");
                shop.userInput = ReadLine();

                if(shop.userInput == "1")
                {
                    WriteLine("Sorry, you can't buy that item right now!");
                    /*if(common.userBal < shop.itemsPrice[0])
                    {
                        Clear();
                        WriteLine("Whoops! You're too broke for that. Broke idiot");
                        Thread.Sleep(500);
                        Clear();
                    }
                    else
                    {
                        common.userBal -= shop.itemsPrice[0];
                    } */
                }
            }
            d = "Good job, you've seen the shop. You know what " + common.userName + ", you seem pretty nice, and you've got some kind of aura around you. I trust you'll become great. I'll give you a " +
                "sword for free, just follow me.";
            while (x < d.Length)
            {
                Write(d[x]);
                Thread.Sleep(25);
                x++;
            }
            if (x == d.Length)
            {
                WriteLine();
                x = 0;
            }
            WriteLine("\nEnter to continue...");
            ReadLine();
            Clear();
            int asdfghjkl = 0;
            while (asdfghjkl < 1)
            {
                WriteLine(op.room);
                d = "Odin: Please pick a weapon. Don't expect these handouts often";
                while (x < d.Length)
                {
                    Write(d[x]);
                    Thread.Sleep(25);
                    x++;
                }
                if (x == d.Length)
                {
                    WriteLine();
                    x = 0;
                }
                d = @"1.) Knight's Edge
2.) Battle Axe
3.) Tree Stump Bow
4.) Dagger";
                while (x < d.Length)
                {
                    Write(d[x]);
                    Thread.Sleep(25);
                    x++;
                }
                if (x == d.Length)
                {
                    WriteLine();
                    x = 0;
                }

                common.userInput = ReadLine();

                if (common.userInput == "1")
                {
                    common.hasKE = true;
                    asdfghjkl++;
                    common.atkTime = 75;
                    common.damage = 50;
                    common.range = 50;
                    common.manaDmg = 50;
                    common.weaponLvl = 1;


                    File.WriteAllText("weapons.txt", "Knight's Edge");
                    common.weaponName = "Knight's Edge";

                    d = "Congrats! You have just purchased the Knight's Edge!";
                    while (x < d.Length)
                    {
                        Write(d[x]);
                        Thread.Sleep(25);
                        x++;
                    }
                    if (x == d.Length)
                    {
                        WriteLine();
                        x = 0;
                    }
                }
                else if (common.userInput == "2")
                {
                    common.hasBA = true;
                    asdfghjkl++;
                    common.atkTime = 25;
                    common.damage = 100;
                    common.range = 75;
                    common.manaDmg = 25;
                    common.weaponLvl = 1;

                    File.WriteAllText("weapons.txt", "Battle Axe");
                    common.weaponName = "Battle Axe";

                    d = "Congrats! You have just purchased the Battle Axe!";
                    while (x < d.Length)
                    {
                        Write(d[x]);
                        Thread.Sleep(25);
                        x++;
                    }
                    if (x == d.Length)
                    {
                        WriteLine();
                        x = 0;
                    }
                }
                else if (common.userInput == "3")
                {
                    common.hasBow = true;
                    asdfghjkl++;
                    common.atkTime = 38;
                    common.damage = 25;
                    common.range = 100;
                    common.manaDmg = 50;
                    common.weaponLvl = 1;

                    File.WriteAllText("weapons.txt", "Tree Stump Bow");
                    common.weaponName = "Tree Stump Bow";

                    d = "Congrats! You have just purchased the Tree Stump Bow!";
                    while (x < d.Length)
                    {
                        Write(d[x]);
                        Thread.Sleep(25);
                        x++;
                    }
                    if (x == d.Length)
                    {
                        WriteLine();
                        x = 0;
                    }
                }
                else if (common.userInput == "4")
                {
                    common.hasDag = true;
                    asdfghjkl++;
                    common.atkTime = 100;
                    common.damage = 38;
                    common.range = 25;
                    common.manaDmg = 50;
                    common.weaponLvl = 1;

                    File.WriteAllText("weapons.txt", "Dagger");
                    common.weaponName = "Dagger";

                    d = "Congrats! You have just purchased the Dagger!";
                    while (x < d.Length)
                    {
                        Write(d[x]);
                        Thread.Sleep(25);
                        x++;
                    }
                    if (x == d.Length)
                    {
                        WriteLine();
                        x = 0;
                    }
                }
                else
                {
                    WriteLine("Hm, that selection didn't work, try again!");
                    ReadLine();
                    Clear();
                }
                asdfghjkl = 0;
                d = "Odin: Well, as with any other weapon, you'll need to do some training with it to be of any use. Try killing this monster here.";
                while (x < d.Length)
                {
                    Write(d[x]);
                    Thread.Sleep(25);
                    x++;
                }
                if (x == d.Length)
                {
                    WriteLine();
                    x = 0;
                }
                while(asdfghjkl < 1)
                {
                    WriteLine(mobFight.lvl1UI);
                    WriteLine("HP: " + mobFight.lvl1HP);
                    WriteLine("\nUse the enter key to use your base attack. The base attack with your " + common.weaponName + " is " + common.damage);
                    ReadLine();
                    useRand = r.Next(1, 10);
                    if(useRand == 5)
                    {
                        mobFight.lvl1HP -= common.damage * 1.5;
                        common.health -= mobFight.lvl1DMG;
                    }
                    else
                    {
                        mobFight.lvl1HP -= common.damage;
                        common.health -= mobFight.lvl1DMG;
                    }
                    Clear();
                    if (mobFight.lvl1HP <= 0)
                    {
                        asdfghjkl = 1;
                        common.health = 100;
                    }
                    else if (common.health <= 0)
                    {
                        WriteLine("You died! Enter 'y' to try again, or just press enter to end the fight...");
                        common.userInput = ReadLine();
                        if (common.userInput == null)
                        {
                            asdfghjkl = 1;
                            common.health = 100;
                        }
                        common.health = 100;
                    }
                }
                common.xp += 25;
                File.WriteAllText("xp.txt", common.xp.ToString());
                d = "Odin: That one wasn't bad now was it? That just so happened to be an easier monster though, they can get quite difficult.";
                while (x < d.Length)
                {
                    Write(d[x]);
                    Thread.Sleep(25);
                    x++;
                }
                if (x == d.Length)
                {
                    WriteLine();
                    x = 0;
                }
                ReadLine();
                d = "";
            }
        }
    }
}
