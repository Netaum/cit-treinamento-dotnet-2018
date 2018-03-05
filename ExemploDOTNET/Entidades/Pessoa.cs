using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDOTNET.Entidades
{
    public class Pessoa
    {

        public String Nome { get; set; }

        public String Sobrenome { get; set; }


        public string MedaNomeComplete()
        {

            return Nome + " " + Sobrenome;
        }
    }
}
