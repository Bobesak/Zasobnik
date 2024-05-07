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

            a.MagazineSize = AnsiConsole.Prompt(new TextPrompt<int>("Zadej Velikost Zásobníku: ")
                .InvalidChoiceMessage("Invalid Magazine Size")
                .PromptStyle("grey")
                .ValidationErrorMessage("Invalid Magazine Size")
                .Validate(magazine =>
                        {
                            if (magazine < 0 || magazine > 60)
                            {
                                return ValidationResult.Error("Invalid Magazine Size");
                            }
                            return ValidationResult.Success();
                        }));                

            Console.Clear();
            a.Caliber = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Typ Ráže")
                .PageSize(3)
                .AddChoices(new[] { "9mm", "5.56mm", "12 gauge" }));
            
            Console.ReadKey();


        }
    }

