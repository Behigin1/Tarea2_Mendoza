using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_Mendoza
{
    internal class RangedEnemy : Entity
    {
        public int Ammo { get; private set; }

        public RangedEnemy(int health, int damage, int ammo) : base(health, damage)
        {
            Ammo = ammo;
        }

        public bool CanShoot()
        {
            return Ammo > 0;
        }

        public void Shoot()
        {
            if (CanShoot())
            {
                Ammo--;
            }
            else
            {
                Console.WriteLine("No tienes balas.");
            }
        }

        public override int DealDamage()
        {
            if (CanShoot())
            {
                return base.DealDamage();
            }
            else
            {
                return 0;
            }
        }
    }

}
