using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace KMCGAME

{

    enum Command

    {
        Attack, Deffence, Magic
    }

    class Player

    {
        public int Hp;

        public int Atk;

        public int Def;

        public bool isDef;

        public void Damage(int x)

        {
            int damage = x - Def;

            if (isDef)

            {
                damage = damage / 3;
            }

            if (damage > 0)

            {
                Hp -= damage;
                Console.WriteLine("To player" + damage + "damage!");
            }

            else

            {
                Console.WriteLine("No damage to player!");
            }
        }
        
        public Player(int h, int a, int d)

        {
            Hp = h;

            Atk = a;

            Def = d;

            isDef = false;
        }
    }


    class Enemy

    {
        public int Hp;

        public int Atk;

        public int Def;

        public bool isAtk;

        public string name;

        public void Damage(int x)

        {
            int damage = x - Def;

            if (damage > 0)

            {
                Hp -= damage;

                Console.WriteLine("To enemy" + damage + "damage!");

            }

            else

            {
                Console.WriteLine("No damage to" + name);
            }

        }
        
        
        public Enemy(int h, int a, int d, string s)

        {
            Hp = h;

            Atk = a;

            Def = d;

            name = s;

            isAtk = false;
            
        }
    }

  

    class Program

    {
        static void Main(string[] args)

        {
            Random r = new Random();

            Player player = new Player(100, 50, 10);

            List<Enemy> enemy = new List<Enemy>();

            for (int i = 0; i < 5; i++)

            {
                enemy.Add(new Enemy(30, 30, 5, "enemy" + i));
            }

            for (int i = 0; i < enemy.Count; ++i)

            {
                Console.WriteLine(enemy[i].name + "comes up! HP:" + enemy[i].Hp + "Atk:" + enemy[i].Atk + "Def:" + enemy[i].Def);
            }

            Console.WriteLine();

            while (true)

            { 

                Console.WriteLine("What will do you do? 1:Attack, 2:Defense, 3:Magic");

                int command = int.Parse(Console.ReadLine());

                switch (command)

                {
                    case 1:

                        Console.WriteLine("To who?");

                        for (int i = 0; i < enemy.Count; ++i)

                        {
                            Console.WriteLine(i + ":" + enemy[i].name);
                        }

                        int command2 = int.Parse(Console.ReadLine());

                        if (command2 >= 0 && command2 < enemy.Count)

                        {
                            enemy[command2].Damage(player.Atk);
                        }

                        break;

                    case 2:

                        Console.WriteLine("Player puts shield");

                        player.isDef = true;

                        break;

                    case 3:

                        for (int i = 0; i < enemy.Count; ++i)

                        {
                            enemy[i].Damage(player.Atk / 2);
                        }

                        break;

                }

                enemy.RemoveAll(e => e.Hp <= 0);

                if (enemy.Count == 0)

                {
                    Console.WriteLine("Beat the enemy!");

                    break;

                }

                for (int i = 0; i < enemy.Count; ++i)

                {
                    int num = r.Next(3);

                    if (num >= 0 && num <= 1)

                    {
                        Console.WriteLine(enemy[i].name + "attack!");

                        if (enemy[i].isAtk)

                        {
                            player.Damage(enemy[i].Atk * 2);

                            enemy[i].isAtk = false;

                        }

                        else

                        {
                            player.Damage(enemy[i].Atk);

                        }

                    }

                    else

                    {
                        Console.WriteLine(enemy[i].name + "is charging!");

                        enemy[i].isAtk = true;
                    }

                }

                player.isDef = false;

                if (player.Hp <= 0)

                {
                    Console.WriteLine("Player died!");

                    break;

                }

            }

        }
    }
}
