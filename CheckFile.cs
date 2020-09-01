using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BruteForce
{
    public class CheckFile
    {
        public void CheckExists(string arquivo)
        {
            if (!File.Exists(arquivo))
            {
                File.Create(arquivo);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nArquivo: {arquivo} criado com sucesso.");
            }
        }
        public void CheckFileEmpty(string arquivo)
        {
            var quantidade = File.ReadAllLines(arquivo).Length;
            if (quantidade < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Arquivo: {arquivo} está vazio, adicione alguma conta/senha para funcionar normalmente.");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
