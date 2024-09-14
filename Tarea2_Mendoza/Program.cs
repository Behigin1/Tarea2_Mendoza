using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_Mendoza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = CreatePlayer();

            List<Entity> enemies = new List<Entity>
        {
            new MeleeEnemy(50, 10),
            new RangedEnemy(30, 15, 5)
        };

            Game game = new Game(player, enemies);
            game.StartGame();
        }

        public static Player CreatePlayer()
        {
            int health, damage;

            Console.WriteLine("Creador de personaje:");
            do
            {
                Console.WriteLine("Elige la vida de tu personaje (1-100):");
                health = int.Parse(Console.ReadLine());
            } while (health < 1 || health > 100);

            do
            {
                Console.WriteLine("Elige el daño de tu personaje (1-100):");
                damage = int.Parse(Console.ReadLine());
            } while (damage < 1 || damage > 100);

            return new Player(health, damage);
        }
    }

}
