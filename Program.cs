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

        while (true) // Bloco 1 -> Onde é criado o tamagochi
        {
            try
            {
                Console.WriteLine();
                Console.Clear();
                Console.WriteLine("Vamos criar seu tamagoshi!");
                Console.WriteLine();

                Console.Write("Nome do seu tamagoshi: ");
                string? name = Console.ReadLine(); 

                Console.Write($"Cor de {name}: ");
                Cor cor = Enum.Parse<Cor>(Console.ReadLine());


                bichoVirtual = new BichoVirtual(name, cor); // Instancia um bicho virtual com 85 de fome, 0 de felicidade e 85 de sono

                Console.WriteLine("Perfeito! Você criou seu tamagoshi.");

                Console.ReadKey();

                break;
            }
            catch (ArgumentException) // Caso o user digite a cor errada no input "cor" o programa pega essa exceção
            {
                Console.WriteLine("Puxa! parece que você digitou a cor errada. Vamos tentar novamente.");
                Console.ReadKey();
            }
        }


        while (true) // Bloco 2 -> Onde o jogo começa
        {
            try
            {
                Console.Clear();

                if (Funcionalidades.VerificarMorte(bichoVirtual)) // Este método avalia se o tamagochi morreu, considerando a fome e o sono enm 100%.
                {
                    Console.WriteLine($"{bichoVirtual.Name} morreu. Ou você não alimentou, ou não o colocou para dormir.");
                    break; // se a expressão for verdadeira isto fecha o programa.
                }

                

                Console.WriteLine($"Informações sobre {bichoVirtual.Name}:");  
                Console.WriteLine();
                Console.WriteLine(bichoVirtual.ToString()); // Isto é o status do tamagochi. Aparece a % de fome, felicidade e sono aqui.

                Console.WriteLine();

                Console.WriteLine($"O que deseja fazer com {bichoVirtual.Name}? ");

                Console.WriteLine(Tela.ExibirPossibilidadesDeInteracao()); // Este método informa ao jogador o que digitar para interagir com o tamagochi

                Console.Write("O que você deseja fazer? ");
                char interaction = char.Parse(Console.ReadLine().ToLower());

                Console.Clear();

                Console.WriteLine(Funcionalidades.Interacao(bichoVirtual, interaction)); // este método recebe um char que significa a interação com o tamagochi.
                // ele tem o objetivo de verificar qual interação foi escolhida, e executa-la.

                Console.ReadKey();
            }

            catch (FeelingException error) // Feeling Exception é o tratamento de erro caso o tamagochi já esteja satifeito da fome ou sono 
            // (fome = 0, sono = 0)
            {
                Console.WriteLine(error.Message);
                Console.ReadKey();
            }
            catch (InteractionException) // É O tratamento de erro caso o user não digite o char que é possível digitar (b, d, f)
            {
            }
            catch (FormatException) // é o tratamento de erro caso o user não digite um char
            {
            }
        }
    }
}
