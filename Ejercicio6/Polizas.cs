using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6
{
    public class Poliza
    {
        public string Estado { get; set; }
        public double Tasa { get; set; }  //0.1% auto,0.3% barco.  
        public double Prima {  get; set; }
        public Cliente clienteAsociado { get; set; }    

        public Poliza(string estado,double tasa,double prima,Cliente unCliente)
        {
            Estado = estado; Tasa = tasa; Prima = prima; clienteAsociado= unCliente;    
        }

        public virtual double CalcularValorPoliza()
        {
            return Tasa * Prima;
        }

        public void MostrarEstadoPoliza()
        {
            Console.WriteLine($"Estado de la poliza:{Estado}");
        }

    }
}
