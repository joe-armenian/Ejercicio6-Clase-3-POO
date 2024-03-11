using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6
{
    public class PolizaAutomovil:Poliza
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public PolizaAutomovil(string estado,double tasa,double prima,Cliente unCliente,string marca,string modelo) 
        :base(estado,tasa,prima,unCliente)
        {
            Marca = marca; Modelo = modelo; 
            
        }

        public override double CalcularValorPoliza()
        {
            return base.CalcularValorPoliza();  
        }


    }
}
