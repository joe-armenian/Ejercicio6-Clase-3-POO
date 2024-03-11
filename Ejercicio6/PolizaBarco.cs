using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6
{
    public class PolizaBarco:Poliza
    {
        public string AlgoEspecifico { get; set; }

        public PolizaBarco(string estado,double tasa,double prima,Cliente unCliente,string algoEspecifico)
        :base(estado,tasa,prima,unCliente)
        {
            AlgoEspecifico = algoEspecifico;
        }
        public override double CalcularValorPoliza()
        {
            return base.CalcularValorPoliza();
        }


    }
}
