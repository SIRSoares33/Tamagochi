using ProjetoTamagoshi.tamagoshi;
using System.Text;
using tamagoshiExceptions;
using telaExceptions;

namespace tamagoshi
{
    public class BichoVirtual
    {
        public string Name { get; private set; }
        public Cor cor { get; private set; }
        public int Fome { get; private set; }
        public int Felicidade { get; private set; }
        public int Sono { get; private set; }

        private Sentimento _sentimento;


        public BichoVirtual(string name, Cor cor)
        {
            Name = name;
            this.cor = cor;
            this.Felicidade = 0;
            this.Sono = 85;
            this.Fome = 85;
        }

        public void Brincar()
        {
            if (Felicidade >= 100) // Se a felicidade for maior que 100, ela volta a ser 100 novamente.
            {
                Felicidade = 100;
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
                if (Felicidade >= 100)
                {
                    Felicidade = 100;
                    Fome -= Fome;
                    Sono += 10;
                }
                else
                {
                    Felicidade += 5;
                    Fome -= Fome;
                    Sono += 10;
                }
                
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
            sb.AppendLine("Sentimento: " + this._sentimento);

            return sb.ToString();
        }
    }
}
