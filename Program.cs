using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForce
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program programa = new Program();

            programa.CheckExist();

            programa.CheckEmpty();

            StartBrute sb = new StartBrute();

            sb.BruteForce();

            Console.ReadLine();
        }
        public void CheckEmpty()
        {
            CheckFile check = new CheckFile();

            check.CheckFileEmpty("senhas.txt");

            check.CheckFileEmpty("users.txt");
        }
        public void CheckExist()
        {
            CheckFile check = new CheckFile();

            check.CheckExists("users.txt");

            check.CheckExists("senhas.txt");

            check.CheckExists("acessivel.txt");
        }
       
    }
}
