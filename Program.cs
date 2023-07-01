using tela;
using tamagoshi;
using tamagoshiExceptions;
using telaExceptions;

namespace ProjetoTamagoshi;
class Program
{
    static void Main(string[] args)
    {
        BichoVirtual bichoVirtual;

        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Vamos criar seu tamagoshi!");
                Console.WriteLine();

                Console.Write("Nome do seu tamagoshi: ");
                string? name = Console.ReadLine();

                Console.Write($"Cor de {name}: ");
                Cor cor = Enum.Parse<Cor>(Console.ReadLine());


                bichoVirtual = new BichoVirtual(name, cor, 85, 0, 85);


                Console.WriteLine("Perfeito! Você criou seu tamagoshi.");

                Console.ReadKey();

                break;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Puxa! parece que você digitou a cor errada. Vamos tentar novamente.");
                Console.ReadKey();
            }
        }


        while (true)
        {
            try
            {
                Console.Clear();

                if (Morte.VerificarMorte(bichoVirtual))
                {
                    Console.WriteLine($"{bichoVirtual.Name} morreu. Ou você não alimentou, ou não o colocou para dormir.");
                    break;
                }
                   

                Console.WriteLine($"Informações sobre {bichoVirtual.Name}:");
                Console.WriteLine();
                Console.WriteLine(bichoVirtual.ToString());

                Console.WriteLine();

                Console.WriteLine($"O que deseja fazer com {bichoVirtual.Name}? ");

                Console.WriteLine(Tela.ExibirPossibilidadesDeInteracao());

                Console.Write("O que você deseja fazer? ");
                char interaction = char.Parse(Console.ReadLine().ToLower());

                Console.Clear();

                Console.WriteLine(BichoVirtual.Interacao(bichoVirtual, interaction));

                Console.ReadKey();
            }

            catch (FeelingException error)
            {
                Console.WriteLine(error.Message);
                Console.ReadKey();
            }
            catch (InteractionException)
            {
            }
            catch (FormatException)
            {
            }
        }
    }
}
