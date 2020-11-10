using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class Mensaje
    {

        public Mensaje(string men, Persona per)
        {
            this.TextoMensaje = men;
            this.persona = per;
        }
        public string TextoMensaje { get; set; }
        public Persona persona { get; set; }
    }
}
