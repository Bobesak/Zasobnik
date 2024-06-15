using GunHandling;
namespace gun
{
    public class Gun
    {
        public class Ammo
        {
            public string SerialNumber { get; }
            public Ammo()
            {
                this.SerialNumber = GenerateAmmoSerialNumber();
            }
        }
        // vlastnosti
        public string SerialNumber { get; }
        public int MaxMagazineSize { get; private set; }
        public String Caliber { get; private set; }
        private Program a = new Program();
        public List<Ammo> AmmooList = new();
        // konstruktor
        public Gun()
        {
            this.SerialNumber = GenerateAmmoSerialNumber();
            AssignAmmoParameters();
            ReloadAll();
        }
        // metody
        public void Fire()
        {
            if (AmmooList.Count == 0) // pokud je zasobnik prazdny, nefunguje
            {
                Console.WriteLine("No Ammo");
                return;
            }
            AmmooList.RemoveAt(0); // odstrani jeden naboj
            
            
            
            var font = FigletFont.Load("starwars.flf");

            AnsiConsole.Write(
                new FigletText(font, "BANG!")
                    .Centered()
                    .Color(Color.Red));
            
    
            AnsiConsole.Write(new Text(@"
     _.-^^---....,,--       
 _--                  --_  
<                        >)
|                         | 
 \._                   _./  
    ```--. . , ; .--'''       
          | |   |             
       .-=||  | |=-.   
       `-=#$%&%$#=-'   
          | ;  :|     
 _____.,-#%&$@%#&#~,._____").Centered());
            
            Thread.Sleep(500);
        }
        public void DisplayAmmo()
        {
            AnsiConsole.Write(new BarChart()
                .Width(60)
                .Label("[green bold underline]Magazine[/]")
                .CenterLabel()
                .AddItem(@"Ammo : " + Caliber , AmmooList.Count, Color.Yellow)
                .AddItem(@"Max Ammo", MaxMagazineSize, Color.Red));
            AnsiConsole.WriteLine("------------------------------------------------------------------------------------------");
        }
        public void CheckMagazine()
        {
            var table = new Table();
            table.AddColumn("Bullet Number");
            table.AddColumn("Serial Number");
            table.AddColumn("Caliber");

            foreach (var ammo in AmmooList) table.AddRow((AmmooList.IndexOf(ammo) + 1) + ".", ammo.SerialNumber, Caliber);
            table.Border(TableBorder.Rounded);
//            table.Columns[0].Width(10);
            table.Columns[0].Centered();
            table.Columns[2].Centered();
            table.ShowRowSeparators = true;
            
            AnsiConsole.Write(table);

        }
        public void AssignAmmoParameters()
        {
            Caliber = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Ammo Type")
                .PageSize(3)
                .AddChoices(new[] { "9mm", "5.56mm", "12 gauge" }));
            Console.Clear();
            MaxMagazineSize = AnsiConsole.Prompt(new TextPrompt<int>("Enter Magazine Size: ")
                .InvalidChoiceMessage("Invalid Magazine Size")
                .PromptStyle("grey")
                .ValidationErrorMessage("Invalid Magazine Size")
                .Validate(magazine =>
                {
                    if (magazine <= 0 || magazine > 60)
                    {
                        return ValidationResult.Error("Invalid Magazine Size");
                    }
                    return ValidationResult.Success();
                }));
            ReloadAll();
            Console.Clear();
        }
        public void ReloadAll()
        {
            List<Ammo> l = [];
            for(int i = 0; i < MaxMagazineSize; i++) l.Add(new Ammo());
            AmmooList = l;
        }
        public void Reload()
        {
             
            
            var AmmoToReload = AnsiConsole.Prompt(new TextPrompt<int>("Amount of ammo to reload: ")
                .InvalidChoiceMessage("Doesnt fit in the magazine")
                .PromptStyle("grey")
                .ValidationErrorMessage("Doesnt fit in the magazine")
                .Validate(AmmoToReload =>
                {
                    if (AmmoToReload + AmmooList.Count > MaxMagazineSize)
                    {
                        return ValidationResult.Error("Doesnt fit in the magazine");
                    } 
                    return ValidationResult.Success();
                }));
            Console.Clear();
            
            for(int i = 0; i < AmmoToReload; i++) AmmooList.Add(new Ammo());
        }
        private static string GenerateAmmoSerialNumber(int delka = 11)
        {
            char[] chars = "ABCDEFGHIJKLMNOPRSTUVWXYZ123456789".ToCharArray();
            char[] word = new char[delka];

            for (int i = 0; i < delka; i++)
            {
                word[i] = chars[new Random().Next(chars.Length)];
            }
            return new string( word );
        }
    }
}