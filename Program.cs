using System;
using System.Threading;
using gun;
using Spectre.Console;

namespace GunHandling;

    public class Program
    {
        public int MagazineSize;
        public int PocetNaboju;
        public string Caliber;
        
        static void Main(string[] args)
        {
            Gun weapon = new Gun();
            Program a = new Program();

            Console.WriteLine("Velikost Zasobniku? :");
            a.MagazineSize = int.Parse(Console.ReadLine());
            
            if (a.MagazineSize > 60 || a.MagazineSize < 1) //zkontroluje platnost zasobniku
            {
                Console.WriteLine("Magazine Size Out of bounds, 1-60 max");
                throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine(@"Typy Ráží: 
            1. 9mm
            2. 5.56mm
            3. 12 gauge
            "); //vypíše možné ráže


            string Caliber = Console.ReadLine();
            if (Caliber == "9mm" || Caliber == "5.56mm" || Caliber == "12 gauge") //zkontroluje platnost ráže
            {
                Console.WriteLine("Acceptable ammo Type");
            }

            else
            {
                Console.WriteLine("Invalid ammo type");
                throw new ArgumentOutOfRangeException();
            }
            Console.ReadKey();


        }
    }

