using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public int Dni { get; set; }

        public Cliente (string nombre,string apellido,int dni)
        {
            Nombre = nombre; Apellido=apellido; Dni = dni;
        }




    }
}
