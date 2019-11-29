using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lucas
{
    public class Manejo_de_patentes
    {
        public void Crear_pila(ref Stack<string> pila)
        {
            if (pila != null)
            {
                Console.Clear();
                Console.WriteLine("la pila ya esta creada, desea borrar la pila actual y crear una pila nueva? y/n");
                string borrar = Console.ReadLine();
                bool continuar = true;

                while (continuar)
                {
                    switch (borrar)
                    {
                        case "y":
                            Borrar_Pila(ref pila);
                            continuar = false;
                            break;
                        case "n":
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("debe ingresar y o n!");
                            Console.ReadKey();
                            break;
                    }
                    borrar = Console.ReadLine();
                }

            }
            Console.Clear();
            Console.WriteLine("Creaste la Pila de Patentes!");
            pila = new Stack<string>();


        }

        public void Borrar_Pila(ref Stack<string> pila)
        {
            Console.Clear();
            if (pila == null)
            {
                Console.WriteLine("no hay ninguna Pila que borrar!");
            }
            else
            {
                Console.WriteLine("Borraste la Pila de Patentes!");
                pila = null;
            }

        }

        public void Agregar_Patente(ref Stack<string> pila, string formato)
        {
            Console.Clear();
            if (!Validar_Existencia_Pila(pila))
            {
                return;
            }
            Console.WriteLine("Ingrese Patente en el Formato correcto");
            if (formato == Constantes.Formato_Patente_Anterior2016)
            {
                Console.WriteLine("Formato Actual: ABC123");
            }
            else
            {
                Console.WriteLine("Formato Actual: AB123CD");
            }


            string patente = Console.ReadLine();
            if (Validar_Existencia_de_Patente(pila, patente))
            {
                Console.WriteLine("La patente ya Existe!");
            }
            else
            {
                if (Regex.IsMatch(patente, formato))
                {


                    pila.Push(patente);
                    Console.WriteLine("Ingreso Patente Correctamente!");

                }
                else
                {
                    Console.WriteLine("Por favor ingrese un formato de patente valido");

                }
            }
        }

        public void Listar_Patentes(Stack<string> pila)
        {
            Console.Clear();
            if (!Validar_Existencia_Pila(pila))
            {
                return;
            }
            if (pila.Count == 0)
            {
                Console.WriteLine("no hay patentes que listar!");
            }
            else
            {
                Console.WriteLine("Listado de patentes");
                foreach (var item in pila)
                {
                    Console.WriteLine(item);

                }
            }
        }

        public bool Validar_Existencia_Pila(Stack<string> pila)
        {
            if (pila == null)
            {
                Console.Clear();
                Console.WriteLine("no se ha creado Pila de Patentes");

                return false;
            }
            return true;
        }

        public bool Validar_Existencia_de_Patente(Stack<string> pila, string patente)
        {
          return  pila.Contains(patente);
        }

        public void Borrar_Patente(ref Stack<string> pila)
        {
            Console.Clear();
            if (!Validar_Existencia_Pila(pila))
            {
                return;
            }
            Console.WriteLine("ingresa la patente que deseas borrar");
            string patente = Console.ReadLine();
            if (pila.Contains(patente))
            {
                Stack<string> pila_secundaria = new Stack<string>();
                foreach (var item in pila)
                {
                    if (item != patente)
                    {
                        pila_secundaria.Push(item);
                    }

                }
                pila = pila_secundaria;
                Console.WriteLine("se borro la patente exitosamente");
            }
            else
            {
                Console.WriteLine("la patente ingresada no existe");
            }

        }

        public void Listar_Primer_Patente(Stack<string> pila)
        {
            Console.Clear();
            if (!Validar_Existencia_Pila(pila))
            {
                return;
            }
            if (pila.Count == 0)
            {
                Console.WriteLine("no hay patentes que listar!");
            }

            int i = 0;
            foreach (var item in pila)
            {
                if (i == pila.Count - 1)
                {
                    Console.WriteLine("El primer elemento de la pila es: " + item);

                    return;

                }
                i++;
            }
        }

        public void Listar_Ultima_Patente(Stack<string> pila)
        {
            Console.Clear();
            if (!Validar_Existencia_Pila(pila))
            {
                return;
            }
            if (pila.Count == 0)
            {
                Console.WriteLine("no hay patentes que listar!");
            }
            else
            {
                Console.WriteLine("El ultimo elemento de la pila es: " + pila.Peek());
            }
        }

        public void Contar_Patentes(Stack<string> pila)
        {
            Console.Clear();
            if (!Validar_Existencia_Pila(pila))
            {
                return;
            }
            Console.WriteLine("la cantidad de patentes es: " + pila.Count);

        }

        public void Modificar_Formato_Patentes(ref string formato)
        {
            Console.Clear();
            Console.WriteLine("desea cambiar el formato de su patente?");
            Console.WriteLine("si/no");
            string cambio_formato = Console.ReadLine();
            if (cambio_formato == "si")
            {
                formato = (formato == Constantes.Formato_Patente_Anterior2016) ? Constantes.Formato_Patente_Actual : Constantes.Formato_Patente_Anterior2016;
                Console.WriteLine("Se ha cambiado el formato ");
            }
            else
            {
                Console.WriteLine("No se ha cambiado el formato ");
            }

        }

        public void Ordenar_Alfabeticamente(Stack<string> pila)
        {
            if (!Validar_Existencia_Pila(pila))
            {
                return;
            }
            string[] array = pila.ToArray();
            Array.Sort(array);
            Array.Reverse(array);
            Listar_Patentes(new Stack<string>(array));
        }

    }
}
