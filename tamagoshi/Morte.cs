namespace tamagoshi
{
    public class Morte
    {
        
        public static bool VerificarMorte(BichoVirtual bicho)
        {
            if (bicho.Fome >= 100 || bicho.Sono >= 100)
                return true;

            return false;
        }

        
    }
}
