using System;

namespace Ejercicio1
{
    class Agenda
    {
        class Nodo
        {
            public string Nombre { get; set; }
            public string Numero { get; set; }
            public Nodo Izquierda { get; set; }
            public Nodo Derecha { get; set; }
            public Nodo(string nombre, string numero, Nodo izq, Nodo der)
            {
                Nombre = nombre;
                Numero = numero;
                Izquierda = izq;
                Derecha = der;
            }
        }

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

        static void Crearnodo(ref Nodo q, string n, string num)
        {
            q = new Nodo(n, num, q, q);
            q.Izquierda = null;
            q.Derecha = null;
        }

        static void Insertarnodo(ref Nodo r)
        {
            Nodo t1 = null, t2 = null, t = null;
            int resp = 1;
            string n = "";
            string num = "";
            while (resp == 1)
            {
                if (r == null)
                {
                    Pedir("Ingrese el Dato para el Nodo Raiz --- Nombre", ref n);
                    Pedir("Ingrese el Dato para el Nodo Raiz --- Telefono", ref num);
                    Crearnodo(ref r, n, num);
                }
                else
                {
                    Pedir("Ingrese el Dato para el Nodo Hijo -- Nombre", ref n);
                    Pedir("Ingrese el Dato para el Nodo Hijo --- Telefono", ref num);
                    t1 = t2 = r;
                    while (t1 != null)
                    {
                        t2 = t1;
                        if (string.Compare(n, t2.Nombre) < 0)
                            t1 = t2.Izquierda;
                        else
                            t1 = t2.Derecha;
                    }

                    Crearnodo(ref t, n, num);
                    if (string.Compare(n, t2.Nombre) < 0)
                        t2.Izquierda = t;
                    else
                        t2.Derecha = t;
                }
                Pedir("\nPresione 1 para seguir / Presione 0 para parar", ref resp);
            }
        }

        static Nodo EliminarHojas(Nodo t)
        {
            if (t == null)
            {
                return null;
            }
            //!Verifica que sea una hoja
            else if (t.Derecha == null && t.Izquierda == null)
            {   
                //!El nodo se elimina, y vuelve a la rama padre
                Console.WriteLine("Eliminando Hoja");
                return null;
            }
            else
            {   
                //!Recorre el arbol recursivamente
                t.Izquierda = EliminarHojas(t.Izquierda);
                t.Derecha = EliminarHojas(t.Derecha);
                return t; 
            }
        }


        static string Buscar(Nodo t, string Nombre)
        {
            if (t == null)
            {
                return "Registro Eliminado";
            }
            else
            {   
                //!Verifica que exista
                if (t.Nombre == Nombre)
                {
                    Console.WriteLine("Contacto Encontrado!");
                    Console.WriteLine("{0}", t.Nombre);
                    Console.WriteLine("{0}", t.Numero);
                }
            }
            //!Recorre el arbol recursivamente
            Buscar(t.Derecha, Nombre);
            Buscar(t.Izquierda, Nombre);

            return "";
        }

        static void Impinorden(Nodo t)
        {
            if (t != null)
            {
                Impinorden(t.Izquierda);
                Console.WriteLine("{0} ", t.Nombre);
                Console.Write("  {0}  ", t.Numero);
                Impinorden(t.Derecha);
            }
        }

        static void ImprimirArbol(Nodo nodo, string prefijo, bool esIzquierdo = false)
        {
            if (nodo != null)
            {
                Console.WriteLine(prefijo + (esIzquierdo ? "├──" : "└──") + "Nombre: " + nodo.Nombre + " Numero: " + nodo.Numero);
                ImprimirArbol(nodo.Derecha, prefijo + (esIzquierdo ? "│   " : "    "), true);
                ImprimirArbol(nodo.Izquierda, prefijo + (esIzquierdo ? "│   " : "    "), false);
            }
        }

        static void Main(string[] args)
        {
            Nodo raiz = null;
            int opcion;

            do
            {
                Console.WriteLine("Agenda Telefónica");
                Console.WriteLine("1. Insertar registro en agenda");
                Console.WriteLine("2. Buscar Registro");
                Console.WriteLine("3. Eliminar Hojas");
                Console.WriteLine("4. Imprimir");
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
                        Console.Write("Ingrese el nombre a buscar: ");
                        string nombreBusqueda = Console.ReadLine();
                        string numeroEncontrado = Buscar(raiz, nombreBusqueda);
                        break;

                    case 3:
                        EliminarHojas(raiz);
                        break;

                    case 4:
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
