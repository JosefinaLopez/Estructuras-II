using System;

namespace Ejercicio4
{
    public class Notas
    {
        class Nodo
        {
            public string Nombre { get; set; }
            public double Calificacion { get; set; }
            public Nodo Izquierda { get; set; }
            public Nodo Derecha { get; set; }
            public Nodo(string nombre, double calificacion, Nodo izq, Nodo der)
            {
                Nombre = nombre;
                Calificacion = calificacion;
                Izquierda = izq;
                Derecha = der;
            }
        }
        //TODO: Metodos de Arbol de Inventario
        static void Pedir(string m, ref string x)
        {
            Console.WriteLine("{0}", m);
            x = Console.ReadLine();
        }

        static void Pedir(string m, ref int x)
        {
            Console.WriteLine("{0}", m);
            x = int.Parse(Console.ReadLine());
        }

        static void Pedir(string m, ref double x)
        {
            Console.WriteLine("{0}", m);
            x = double.Parse(Console.ReadLine());
        }
        static void Crearnodo(ref Nodo q, string alumn,  double nota)
        {
            q = new Nodo(alumn, nota, q, q);
            q.Izquierda = null;
            q.Derecha = null;
        }
        static void Insertarnodo(ref Nodo r)
        {
            Nodo t1 = null, t2 = null, t = null;
            int resp = 1;
            string alumn = "";
            double calificacion = 0.0;
            while (resp == 1)
            {
                if (r == null)
                {
                    Pedir("Ingrese el Dato para el Nodo Raiz --- Nombre de Alumno", ref alumn);
                    Pedir("Ingrese el Dato para el Nodo Raiz --- Calificacion", ref calificacion);
                    Crearnodo(ref r, alumn, calificacion);
                }
                else
                {
                    Pedir("Ingrese el Dato para el Nodo Hijo --- Nombre de Alumno", ref alumn);
                    Pedir("Ingrese el Dato para el Nodo Hijo --- Calificacion", ref calificacion);
                    t1 = t2 = r;
                    while (t1 != null)
                    {
                        t2 = t1;
                        //!La comparacion se hace con la calificacion
                        if (t2.Calificacion < calificacion)
                            t1 = t2.Izquierda;
                        else
                            t1 = t2.Derecha;
                    }

                    Crearnodo(ref t, alumn, calificacion); // Crear un nuevo nodo
                    if (t2.Calificacion < calificacion)
                        t2.Izquierda = t; // Enlazar el nuevo nodo a la izquierda
                    else
                        t2.Derecha = t; // Enlazar el nuevo nodo a la derecha
                }
                Pedir("\nPresione 1 para seguir / Presione 0 para parar", ref resp);
            }
        }

        static void ImprimirArbol(Nodo nodo, string prefijo, bool esIzquierdo = false)
        {
            if (nodo != null)
            {
                Console.WriteLine(prefijo + (esIzquierdo ? "├──" : "└──") + "Nombre: " + nodo.Nombre + " Numero: " + nodo.Calificacion);
                ImprimirArbol(nodo.Derecha, prefijo + (esIzquierdo ? "│   " : "    "), true);
                ImprimirArbol(nodo.Izquierda, prefijo + (esIzquierdo ? "│   " : "    "), false);
            }
        }
        
        //!Metodo para imprimir los aprobados, es recursivo.
        static void ImprimirAprobados(Nodo t, string prefijo, bool IsIzquier = false)
        {
            if(t != null)
            {
                ImprimirAprobados(t.Izquierda, prefijo + (IsIzquier ? "│   " : "    "), false);
                if(t.Calificacion >= 60)
                {
                    Console.WriteLine(prefijo + (IsIzquier ? "├──" : "└──") + "Alumno: " + t.Nombre + " Calificacion: " + t.Calificacion);
                }
                ImprimirAprobados(t.Derecha, prefijo + (IsIzquier ? "│   " : "    "), true);
            }
        }
        static void Main(string[] args)
        {
            Nodo raiz = null;
            int opcion;

            do
            {
                Console.WriteLine("Calificaciones Escolares");
                Console.WriteLine("1. Insertar registro de Alumno");
                Console.WriteLine("2. Imprimir Aprobados");
                Console.WriteLine("3. Imprimir");
                Console.WriteLine("0. Salir");
                Console.Write("Ingrese su opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Insertarnodo(ref raiz);
                        Console.WriteLine("Registro insertado con éxito.");
                        break;

                    case 2:
                        System.Console.WriteLine("Imprimiendo lista de Aprobados");
                        ImprimirAprobados(raiz,"");
                        break;
                    case 3:
                        System.Console.WriteLine("Imprimiendo lista de Aprobados");
                        ImprimirArbol(raiz, "");
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

                Console.WriteLine();
            } while (opcion != 0);
        }

    }
}