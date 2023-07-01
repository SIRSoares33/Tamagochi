using System.Text;
using tamagoshi;

namespace tela
{
    public class Tela
    {
        public static string ExibirPossibilidadesDeInteracao()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Digite 'B' para brincar com seu companheiro. ");
            sb.AppendLine("Digite 'D' Para colocar seu companheiro para dormir.");
            sb.AppendLine("Digite 'F' para alimentar seu companheiro.");

            return sb.ToString();
        }
    }
}
