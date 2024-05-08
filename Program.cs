global using Spectre.Console;
using System;
using System.Threading;
using gun;

namespace GunHandling;

    public class Program
    {
        public static void Main(string[] args)
        {

            Gun weapon = new() { };
            var a = true;
            while (a == true)
            {
                Console.Clear();    
                weapon.DisplayAmmo();
                var action = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("Choose your action")
                    .PageSize(10)
                    .AddChoices("Fire", "Reload", "Change Magazine","Check Magazine" ,"[red]Exit[/]"));

                switch (action)
                {
                    case "Fire":
                        weapon.Fire();
                        Console.ReadKey();
                        break;

                    case "Change Magazine":
                        weapon.AssignAmmoParameters();
                        break;
                    
                    case "Reload": 
                        weapon.Reload();
                        break;
                    
                    case "Check Magazine":
                        weapon.CheckMagazine();
                        Console.ReadKey();
                        break;
                    
                    
                    case "[red]Exit[/]":
                        a = false;
                        break;
                }

            }
        }
    }

