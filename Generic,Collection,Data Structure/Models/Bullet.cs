using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic_Collection_Data_Structure.Enums;

namespace Generic_Collection_Data_Structure.Models
{
    internal class Bullet
    {
        private static int id = 0;
        public int Id { get; }
        public BulletType Type { get; }
        public Bullet(BulletType type)
        {
            Id = ++id;
            Type = type;
        }
    }
}
