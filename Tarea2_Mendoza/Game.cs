using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_Mendoza
{
    internal class Game
    {
        private Player player;
        private List<Entity> enemies;
        private int turnCounter;

        public Game(Player player, List<Entity> enemies)
        {
            this.player = player;
            this.enemies = enemies;
            turnCounter = 0;
        }

        public void StartGame()
        {
            Console.WriteLine("Comienza el juego");
            while (player.IsAlive() && enemies.Count > 0)
            {
                if (turnCounter % 2 == 0)
                {
                    PlayerTurn();
                }
                else
                {
                    EnemyTurn();
                }

                turnCounter++;
            }
        }

        private void PlayerTurn()
        {
            Console.WriteLine("Es tu turno. Selecciona un enemigo para atacar:");
            for (int i = 0; i < enemies.Count; i++)
            {
                Console.WriteLine($"Enemigo {i + 1} - Vida: {enemies[i].Health}");
            }

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > enemies.Count)
            {
                Console.WriteLine("Selecciona un enemigo válido.");
            }

            Entity enemy = enemies[choice - 1];
            enemy.TakeDamage(player.DealDamage());
            Console.WriteLine($"Atacaste al enemigo {choice} y causaste {player.DealDamage()} de daño.");

            if (!enemy.IsAlive())
            {
                Console.WriteLine($"El enemigo {choice} ha sido derrotado.");
                enemies.Remove(enemy);
            }

            if (enemies.Count == 0)
            {
                Console.WriteLine("¡Victoria!");
            }
        }

        private void EnemyTurn()
        {
            foreach (Entity enemy in enemies)
            {
                if (enemy.IsAlive())
                {
                    int damageDealt = enemy.DealDamage();
                    player.TakeDamage(damageDealt);
                    Console.WriteLine($"Un enemigo te atacó y causó {damageDealt} de daño.");

                    if (!player.IsAlive())
                    {
                        Console.WriteLine("Has sido derrotado.");
                        break;
                    }
                }
            }
        }
    }
}
