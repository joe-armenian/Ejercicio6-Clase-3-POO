using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio6
{
     public class Program
    {
        static void Main(string[] args)
        {
            List <Cliente> clientes = new List <Cliente> ();
            List <Poliza> polizas=new List <Poliza> (); 
            List <PolizaAutomovil> polizasAuto=new List <PolizaAutomovil> ();
            List <PolizaBarco> polizasBarco=new List<PolizaBarco> ();

            int cantidadCliente;
            string linea;

            do
            {
                Console.Write("Ingrese la cantidad de clientes por favor:");
                linea=Console.ReadLine();

                if (!NumerosEnteros(linea))
                {
                    Console.Write($"El caracter ingresado:{linea}, no es valido. Por favor ingrese un numero correcto.");
                    Console.Write("\n");
                    continue;
                }
                break;
            } while (true);
            cantidadCliente = Convert.ToInt32(linea);
            string nombreCliente, apellidoCliente, dniCliente;


            for (int i = 0;i<cantidadCliente;i++)
            {
                do
                {
                    Console.Write($"Ingrese el nombre del cliente {i + 1}:");
                    nombreCliente = Console.ReadLine();
                    Console.Write($"Ingrese el apellido del cliente {i + 1}:");
                    apellidoCliente = Console.ReadLine();
                    Console.Write($"Ingrese el DNI del cliente {i + 1}:");
                    dniCliente = Console.ReadLine();

                    if (!Letras(nombreCliente)||(!Letras(apellidoCliente)) || (!NumerosEnteros(dniCliente)))
                    {
                        Console.Write($"Error en el ingreso de datos para el cliente {i + 1}. Por favor, intente nuevamente.\n");
                        continue;
                    }

                    clientes.Add(new Cliente(nombreCliente,apellidoCliente,Convert.ToInt32(dniCliente)));
                   
                    
                    break;
                } while (true);

            }

            string estadoPoliza, tasaPoliza, primaPoliza;

            for (int i = 0; i < cantidadCliente; i++)
            {
                do
                {
                    Console.Write($"Ingrese el estado de poliza del cliente {clientes[i].Nombre}:");
                    estadoPoliza = Console.ReadLine();

                    Console.Write($"Ingrese la tasa de poliza del cliente {clientes[i].Nombre}:");
                    tasaPoliza = Console.ReadLine();

                    Console.Write($"Ingrese la prima de poliza del cliente {clientes[i].Nombre}:");
                    primaPoliza = Console.ReadLine();

                    if (!Letras(estadoPoliza) || (!NumerosDouble(tasaPoliza)) || (!NumerosDouble(primaPoliza)))
                    {
                        Console.Write($"Error en el ingreso de datos para el cliente {clientes[i].Nombre}. Por favor, intente nuevamente.\n");
                        continue;
                    }

                    polizas.Add(new Poliza(estadoPoliza,Convert.ToDouble(tasaPoliza),Convert.ToDouble(primaPoliza),clientes[i]));

                    break;
                } while (true);
            
            }
            Console.WriteLine("Detalles de las polizas:");

            for (int i = 0; i < cantidadCliente; i++)
            {
                Console.Write($"Estado:{polizas[i].Estado}\nTasa:{polizas[i].Tasa}\nPrima:{polizas[i].Prima}\n");
                Console.Write($"Pertenece al cliente {clientes[i].Nombre}\n");
            }

            string variantePoliza;

            for (int i = 0; i < cantidadCliente; i++)
            
            {
                do
                {
                    Console.Write($"Si el cliente:{clientes[i].Nombre},esta asociado con una poliza de automovil ingresar 1, si esta asociado con una poliza de barcos ingresar 2, sino esta asociado con ninguna marcar 3.");
                    variantePoliza = Console.ReadLine();
                    if (!TiposPoliza(variantePoliza))
                    {
                        Console.Write("Por favor ingrese una opcion comprendida entre 1 y 3.");
                        continue;
                    }

                    if (variantePoliza =="1")
                    {
                        do
                        {
                            Console.Write($"Ingrese la marca de automovil para el cliente{clientes[i].Nombre}:");
                            string marcaAutomovil=Console.ReadLine();
                            Console.Write($"Ingrese el modelo para el cliente{clientes[i].Nombre}:");
                            string modeloAutomovil = Console.ReadLine();

                            if (!Letras(marcaAutomovil) || (!Letras(modeloAutomovil)))
                            {
                                Console.WriteLine($"Ingrese datos correctos de automovil para el cliente{clientes[i].Nombre}:");
                                continue;
                            }

                            polizasAuto.Add(new PolizaAutomovil(polizas[i].Estado,0.1,polizas[i].Prima,clientes[i],marcaAutomovil,modeloAutomovil));
                            break;
                        } while (true);
                    }
                    else if (variantePoliza =="2")
                    {
                        do
                        {

                            Console.Write($"Ingrese algo especifico para detallar el barco del cliente{clientes[i].Nombre}:");
                            string detalleBarco = Console.ReadLine();

                            if (!ValidarDireccion(detalleBarco))
                            {
                                Console.Write($"Por favor,ingrese un detalle correcto para el barco del cliente{clientes[i].Nombre}:");
                            }

                            polizasBarco.Add(new PolizaBarco(polizas[i].Estado,0.3,polizas[i].Prima,clientes[i],detalleBarco));

                            break;
                        } while (true);
                    }
                    else if (variantePoliza=="3")
                    {
                        Console.Write("");
                    }

                    break;
                } while (true);
               
            }

            Console.WriteLine("VALORES DE POLIZA PARA AUTOMOVILES:");
            foreach (PolizaAutomovil unaPoliza in polizasAuto)
            {
                
                Console.WriteLine($"Estado:{unaPoliza.Estado} y la nueva Taza:{unaPoliza.Tasa},multiplicando por la prima:{unaPoliza.CalcularValorPoliza()}");
            }
            Console.WriteLine("VALORES DE POLIZA PARA BARCOS:");

            foreach (PolizaBarco unaPoliza in polizasBarco)
            {
                Console.WriteLine($"{unaPoliza.Estado} y la nueva Taza:{unaPoliza.Tasa},multiplicando por la prima:{unaPoliza.CalcularValorPoliza()}");
            
            }

            


                //foreach (Cliente unCliente in clientes)
                //{
                //    Console.WriteLine($"Nombre:{unCliente.Nombre}\nApellido:{unCliente.Apellido}\nDNI:{unCliente.Dni}");
                //}




                Console.ReadLine();




        }

        public static bool ValidarDireccion(string entrada)
        {
            return Regex.IsMatch(entrada, @"^[\w¡ ]+$");
        }
        public static bool TiposPoliza(string linea)
        {
            return Regex.IsMatch(linea, @"^[1-3]+$");
        }
        public static bool NumerosEnteros(string linea)
        {
            return Regex.IsMatch(linea, @"^[0-9]+$");
        }
        public static bool Letras(string linea)
        {
            return Regex.IsMatch(linea, @"^[a-zA-Z]+$");
        }
        public static bool NumerosDouble(string linea)
        {
            return Regex.IsMatch(linea, @"^[0,0-9,9]+$");
        }



    }
}
