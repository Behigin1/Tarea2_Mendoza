using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_Mendoza
{
    public abstract class Entity
    {
        public int Health { get; private set; }
        public int Damage { get; private set; }

        public Entity(int health, int damage)
        {
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public virtual int DealDamage()
        {
            return Damage;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}

