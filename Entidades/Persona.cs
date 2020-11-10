using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        public Persona()
        {

        }
        public Persona(string Apellido, string Nombre, int PersonId, double dni)
        {
            this.PersonId = PersonId;
            this.DNI = dni;
            this.Apellido = Apellido;
            this.Nombre = Nombre;
        }

        public int PersonId { get; set; }
        public double DNI { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }


        public override string ToString()
        {
            return this.Apellido + " " + this.Nombre;
        }

        public static Persona RetornarPersonaPorId(List<Persona> personas, double id)
        {
            foreach (Persona item in personas)
            {
                if (item.PersonId == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
