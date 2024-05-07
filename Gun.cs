namespace gun
{
    public class Gun
    {

        public void Ammo()
        {
            
        }

        public void Fire()
        {
            Console.WriteLine("Fire");
        }

        public void Reload()
        {
            Console.WriteLine("Reload");
        }


    public static string GenerateAmmoSerialNumber(int delka = 11)
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