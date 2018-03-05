using ExemploDOTNET.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDOTNET
{
    class Program
    {
        static void Main(string[] args)
        {
            Teste();
        }


        private static void Teste()
        {
            int x = 10;

           
            bool a = false;
            Boolean b = true;
            List<int> lista = new List<int> { 10, 32, 44 };

            //for (int i = 0; i < lista.Count; i++)
            //{
            //    Console.WriteLine(lista[i]);
            //}


            lista.ForEach(val =>
            {
                Console.WriteLine(val.ToString());
            });

            //foreach(int val in lista)
            //{
            //    Console.WriteLine(val);
            //}

            string texto = string.Empty;
            int valor = 18;


            if(valor < 18)
            {
                texto = "novo";
            }
            else
            {
                texto = "velho";
            }

            


            texto = (valor < 18) ? "novo" : (valor == 18) ? "ta quasee" : (valor == 65) ? "ta quase" : "velho";

            texto.ToString();

           string inputUsuario =  Console.ReadLine();


            Pessoa pess = new Pessoa
            {
                Nome = "Thiago",
                Sobrenome = "Martins"
            };


            pess.Nome = "Livia";
            pess.Sobrenome = "Fernandes";


            Console.WriteLine(pess.Nome);

            Console.WriteLine(pess.Sobrenome);

            Console.WriteLine(pess.MedaNomeComplete());

            Console.ReadLine();
        }
    }
}
