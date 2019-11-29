using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lucas
{
    class Program
    {
        static void Main(string[] args)
        {            
            bool comienzo = true;           
            Stack<string> patentes = null;
            Manejo_de_patentes manejo = new Manejo_de_patentes();
            string formato_patente = Constantes.Formato_Patente_Anterior2016;

            while (comienzo)
            {
                Console.WriteLine("Bienvenido");
                Console.WriteLine("1.Crear Pila Contenedora de Patentes");
                Console.WriteLine("2.Borrar Pila Contenedora de Patentes");
                Console.WriteLine("3.Agregar Patente");
                Console.WriteLine("4.Borrar Patente");
                Console.WriteLine("5.Listar Todas Las Patentes");
                Console.WriteLine("6.Listar Primera Patente");
                Console.WriteLine("7.Listar Ultima Patente");
                Console.WriteLine("8.Contador de de Patentes");
                Console.WriteLine("9.Salir");
                Console.WriteLine("10.Modificar Formato de Patente");
                Console.WriteLine("11.Listado Alfabetico");
                Console.WriteLine("Ingrese Opcion: ");
                string ingreso = Console.ReadLine();

                switch (ingreso)
                {
                    case "1":

                        manejo.Crear_pila(ref patentes);                        

                        break;

                    case "2":

                        manejo.Borrar_Pila(ref patentes);

                        break;

                    case "3":                      
                        manejo.Agregar_Patente(ref patentes, formato_patente);
                        break;

                    case "4":
                        manejo.Borrar_Patente(ref patentes);
                        break;

                    case "5":
                        manejo.Listar_Patentes(patentes);
                        break;

                    case "6":
                        manejo.Listar_Primer_Patente(patentes);
                        break;

                    case "7":
                        manejo.Listar_Ultima_Patente(patentes);
                        break;

                    case "8":
                        manejo.Contar_Patentes(patentes);
                        break;

                    case "9":
                        Console.WriteLine("Adios!");
                        comienzo = false;
                        break;

                    case "10":
                        manejo.Modificar_Formato_Patentes(ref formato_patente);
                        break;

                    case "11":
                        manejo.Ordenar_Alfabeticamente(patentes);
                        break;



                    default:
                        Console.WriteLine("elija uhn numero entre el 1 y el 11");
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
