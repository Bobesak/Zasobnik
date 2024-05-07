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
            
            if (a.MagazineSize > 60 || a.MagazineSize < 1) //zkontroluje platnost zasobniku
            {
                Console.WriteLine("Magazine Size Out of bounds, 1-60 max");
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                bool ValidMagazine = true;
            }
            Console.WriteLine(@"Typy Ráží:
            1. 9mm
            2. 5.56mm
            3. 12 gauge
            ");
            string Caliber = Console.ReadLine();
            if (Caliber == "9mm" || Caliber == "5.56mm" || Caliber == "12 gauge")
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

/*
// Ask for the user's favorite fruit
var fruit = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What's your [green]favorite fruit[/]?")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        .AddChoices(new[] {
            "Apple", "Apricot", "Avocado", 
            "Banana", "Blackcurrant", "Blueberry",
            "Cherry", "Cloudberry", "Cocunut",
        }));

// Echo the fruit back to the terminal
AnsiConsole.WriteLine($"I agree. {fruit} is tasty!");
*/