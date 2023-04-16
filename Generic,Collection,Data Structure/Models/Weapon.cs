using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic_Collection_Data_Structure.Enums;
using Generic_Collection_Data_Structure.Exceptions;
namespace Generic_Collection_Data_Structure.Models
{
    internal class Weapon
    {
        private static int id = 0;
        public int Id { get; }
        public string Name { get; }
        public BulletType BulletType { get; }
        public int BulletCapacity { get; }
        public Stack<Bullet> Bullets = new Stack<Bullet>();
        public Weapon(string name, BulletType bulletType, int bulletCapacity)
        {
            Id = ++id;
            Name = name;
            BulletType = bulletType;
            BulletCapacity = bulletCapacity;
        }
        public void Fill()
        {
            if (BulletCapacity == Bullets.Count)
            {
                throw new CapacityException();
            }
            for (int i = Bullets.Count; i < BulletCapacity; i++)
            {
                Bullet bullet = new Bullet(BulletType);
                Bullets.Push(bullet);
            }
        }
        private Bullet? FireBullet;
        public Bullet PullTrigger()
        {
            Bullets.TryPeek(out FireBullet);
            return FireBullet;
        }
        public (int count, Bullet bullet) Fire(FireType fireType)
        {
            Bullet? bullet = FireBullet;
            if (bullet == null)
            {
                throw new BulletEmptyException();
            }
            switch (fireType)
            {
                case FireType.tekli:
                    if (Bullets.TryPop(out bullet))
                    {
                        return (Bullets.Count, bullet);
                    }
                    throw new BulletEmptyException();
                case FireType.ikili:
                    if (Bullets.TryPop(out bullet))
                    {
                        Bullets.TryPop(out bullet);
                        return (Bullets.Count, bullet);
                    }
                    throw new BulletEmptyException();
                case FireType.hamsi:
                    if (!(Bullets.TryPop(out bullet)))
                    {
                        throw new BulletEmptyException();
                    }
                    while (Bullets.TryPop(out bullet)) { }
                    return (Bullets.Count, bullet);
                default:
                    throw new FireTypeException();
            }
        }

    }
}
