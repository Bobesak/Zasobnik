using System;
using System.Threading;
using gun;
using Spectre.Console;

namespace GunHandling;

    public class Program
    {
        public int MagazineSize;
        public int PocetNaboju;
        
        static void Main(string[] args)
        {
            Gun weapon = new Gun();
            Program a = new Program();

            Console.WriteLine("Velikost Zasobniku? :");
            a.MagazineSize = int.Parse(Console.ReadLine());
            
            if (a.MagazineSize > 60 || a.MagazineSize < 1)
            {
                Console.WriteLine("Magazine Size Out of bounds, 1-60 max");
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                bool ValidMagazine = true;
            }
            


            Thread.Sleep(3000);

        }
    }

