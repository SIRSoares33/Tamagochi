using System.Text;
using tamagoshiExceptions;
using telaExceptions;

namespace tamagoshi
{
    public class BichoVirtual
    {
        public string? Name { get; private set; }
        public Cor cor { get; private set; }
        public int Fome { get; private set; }
        public int Felicidade { get; private set; }
        public int Sono { get; private set; }

        public BichoVirtual(string? name, Cor cor)
        {
            Name = name;
            this.cor = cor;
            this.Felicidade = 0;
            this.Sono = 0;
            this.Fome = 0;
        }

        public BichoVirtual(string? name, Cor cor, int fome, int felicidade, int sono) : this(name, cor)
        {
            if (fome > 100 || felicidade > 100 || sono > 100)
                throw new FeelingException("O tamagoshi não pode ter um sentimento maior que 100%");

            else
            {
                Fome = fome;
                Felicidade = felicidade;
                Sono = sono;
            }

        }

        public void Brincar()
        {
            if (Felicidade >= 100)
            {
                Sono += 25;
                Fome += 25;
            }
            else
            {
                Felicidade += 5;
                Sono += 10;
                Fome += 10;
            }
        }

        public void Dormir()
        {
            if (Sono == 0)
            {
                throw new FeelingException($"{Name} já está descansado.");
            }
            else
            {
                Sono -= Sono;
                Fome += 5;
            }    
        }
        public void Comer()
        {
            if (Fome == 0)
                throw new FeelingException($"{Name} não está com fome.");
            else
            {
                Fome -= Fome;
                Sono += 10;
                Felicidade += 5;
            }
        }
        
        public static string? Interacao(BichoVirtual bichoVirtual, char interaction)
        {
            if (bichoVirtual.Felicidade >= 100)
                bichoVirtual.Felicidade = 100;

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nome: " + Name);
            sb.AppendLine("Cor: " + this.cor);
            sb.AppendLine("Fome: " + Fome + "%");
            sb.AppendLine("Felicidade: " + Felicidade + "%");
            sb.AppendLine("Sono: " + Sono + "%");

            return sb.ToString();
        }
    }
}
