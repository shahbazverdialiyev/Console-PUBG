using Generic_Collection_Data_Structure.Models;
using Generic_Collection_Data_Structure.Enums;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {

        Weapon weapon;
        Bullet bullet;
        List<Weapon> weapons = new List<Weapon>();
        List<Bullet> bullets;
        Console.WriteLine("1. Create Weapon \r\n2. Remove Weapon\r\n3. Get Weapon By Capacity \r\n4. Get Weapons \r\n5. Select Weapon\r\n6.Exit");
        Console.WriteLine("---------------------- ------------------- ------------------------- --------");
        Console.WriteLine();
        Console.Write(">>>  ");
        string command = Console.ReadLine();
        while (command != "6")
        {
            if (command == "1")
            {
                Console.WriteLine("-----------Create Weapon------------");
                weapons.Add(CreateWeapon());
                Console.WriteLine("----Created Weapon");
            }
            else if (command == "2")
            {
                Console.WriteLine("-----------Remove Weapon------------");
                RemoveWeapon(weapons);
                Console.WriteLine("Removed weapon");
            }
            else if (command == "3")
            {
                Console.WriteLine("-------Get Weapon By Capacity-------");
                GetWeaponByCapacity(weapons).ForEach(w => Console.WriteLine($"Id: {w.Id}    Name: {w.Name}     Bullets: {w.Bullets.Count}"));
            }
            else if (command == "4")
            {
                Console.WriteLine("------------Get Weapons-------------");
                weapons.ForEach(w => Console.WriteLine($"Id: {w.Id}    Name: {w.Name}     Bullets: {w.Bullets.Count}"));
            }
            else if (command == "5")
            {
                Console.WriteLine("-----------Select Weapon------------");
                weapon = GetWeapon(weapons);
                Console.WriteLine();
                Console.WriteLine($"<--- {weapon.Id} {weapon.Name} --->");
                Console.WriteLine();
                Console.WriteLine("1. Fire \r\n2. PullTrigger\r\n3. Fill\r\n4.Back");
                Console.WriteLine("--- ---- --- --- ---");
                Console.Write(">>>  ");
                command = Console.ReadLine();
                while (command != "4")
                {
                    switch (command)
                    {
                        case "1":
                            Console.Write("Atesh novu sechin  (");
                            foreach (FireType type in Enum.GetValues(typeof(FireType)))
                            {
                                Console.Write(" " + type);
                            }
                            Console.Write(" ) : ");
                            FireType FireType;
                            while (!(FireType.TryParse(Console.ReadLine(), out FireType)))
                            {
                                Console.WriteLine("Yuxaridakilardan birini sechin!");
                                Console.Write("Atesh novu sechin: ");
                            }
                            weapon.Fire(FireType);
                            break;
                        case "2":
                            weapon.PullTrigger();
                            break;
                        case "3":
                            weapon.Fill();
                            break;
                        default:
                            Console.WriteLine("Yuxardaki komandalardan birini yazin");
                            break;
                    }
                    Console.Write(">>>  ");
                    command = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Yuxaridaki kommandalardan birini yazin");
            }
            Console.Write(">>>  ");
            command = Console.ReadLine();
        }


    }
    private static Weapon CreateWeapon()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Mermi novu sechin  (");
        foreach (BulletType type in Enum.GetValues(typeof(BulletType)))
        {
            Console.Write(" " + type);
        }
        Console.Write(" ) : ");
        BulletType BulletType;
        while (!(BulletType.TryParse(Console.ReadLine(), out BulletType)))
        {
            Console.WriteLine("Yuxaridakilardan birini sechin!");
            Console.Write("Mermi novu sechin: ");
        }
        Console.Write("Mermi Tutumu: ");
        int BulletCapacity;
        while (!(Int32.TryParse(Console.ReadLine(), out BulletCapacity)))
        {
            Console.WriteLine("Eded yazin!");
            Console.Write("Mermi Tutumu: ");
        }
        return new Weapon(name, BulletType, BulletCapacity);
    }
    
    private static void RemoveWeapon(List<Weapon> weapons)
    {
        int id;
        while (true)
        {
            Console.Write("Id: ");
            if (!(Int32.TryParse(Console.ReadLine(), out id)))
            {
                Console.WriteLine("Eded yazin!");
                continue;
            }
            Weapon weapon = weapons.Find(w => w.Id == id);
            if (weapon == null)
            {
                Console.WriteLine("Silah tapilmadi");
                continue;
            }
            weapons.Remove(weapon);
            break;
        }
    }
    private static List<Weapon> GetWeaponByCapacity(List<Weapon> weapons)
    {
        int capacity;
        List<Weapon> findWeapons;
        while (true)
        {
            Console.Write("Capacity: ");
            if (!(Int32.TryParse(Console.ReadLine(), out capacity)))
            {
                Console.WriteLine("Eded yazin!");
                continue;
            }
            findWeapons = weapons.FindAll(w => w.Id > capacity);
            if (findWeapons == null)
            {
                Console.WriteLine("Silah tapilmadi");
                continue;
            }
            return findWeapons;
        }
    }
    private static Weapon GetWeapon(List<Weapon> weapons)
    {
        int id;
        while (true)
        {
            Console.Write("Id: ");
            if (!(Int32.TryParse(Console.ReadLine(), out id)))
            {
                Console.WriteLine("Eded yazin!");
                continue;
            }
            Weapon? weapon = weapons.Find(w => w.Id == id);
            if (weapon == null)
            {
                Console.WriteLine("Silah tapilmadi");
                continue;
            }
            return weapon;
        }
    }
}