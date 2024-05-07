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
            Reload();
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
            Console.WriteLine(@AmmooList.Count + "/" + MaxMagazineSize);
            
            var a = AmmooList.Count;
            
            foreach (Ammo ammo in AmmooList)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------");
                Console.WriteLine("Bullet Number " + a);
                Console.WriteLine("Serial Number : " + ammo.SerialNumber);
                Console.WriteLine("Caliber : " + Caliber);
                a--;
            }
            
        }
        
        public void AssignAmmoParameters()
        {
            Caliber = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Typ Ráže")
                .PageSize(3)
                .AddChoices(new[] { "9mm", "5.56mm", "12 gauge" }));
            Console.Clear();
            MaxMagazineSize = AnsiConsole.Prompt(new TextPrompt<int>("Zadej Velikost Zásobníku: ")
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
        }
        
        
        
        public void Reload()
        {
            List<Ammo> l = [];
            
            for(int i = 0; i < MaxMagazineSize; i++) l.Add(new Ammo());

            AmmooList = l;
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