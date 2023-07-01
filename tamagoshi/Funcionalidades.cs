using telaExceptions;

namespace tamagoshi
{
    public class Funcionalidades
    {
        public static string? Interacao(BichoVirtual bichoVirtual, char interaction) // esse método estático recebe um char e um tamagochi para realizar
        // a interação CLIENT -> SERVER / SERVER -> CLIENT.
        {
            switch (interaction)
            {
                case 'b':
                    bichoVirtual.Brincar();
                    return $"Você brincou com {bichoVirtual.Name}. Ele recebeu mais 5 de felicidade.";

                case 'd':
                    bichoVirtual.Dormir();
                    return $"{bichoVirtual.Name} Adormeceu. Energia recuperada em 100%";


                case 'f':
                    bichoVirtual.Comer();
                    return $"{bichoVirtual.Name} comeu toda a refeição. Isso saciou 100% de sua fome";

                default:
                    throw new InteractionException(null);
            }
        }
        public static bool VerificarMorte(BichoVirtual bicho)
        {
            if (bicho.Fome >= 100 || bicho.Sono >= 100)
                return true;

            return false;
        }
    }
}
