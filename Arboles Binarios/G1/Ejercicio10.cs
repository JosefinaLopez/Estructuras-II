using System;

namespace Ejercicio10
{
    public class Eliminarxd
    {
        class Nodo
        {
            public int Dato { get; set; }
            public Nodo Izquierda { get; set; }
            public Nodo Derecha { get; set; }
            public Nodo(int dato, Nodo izq, Nodo der)
            {
                Dato = dato;
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
        static void Crearnodo(ref Nodo q, int dat)
        {
            q = new Nodo(dat, q, q);
            q.Izquierda = null;
            q.Derecha = null;
        }

        static void Insertarnodo(ref Nodo r)
        {
            Nodo t1 = null, t2 = null, t = null;
            int resp = 1, d = 0;
            while (resp == 1)
            {
                if (r == null)
                {
                    Pedir("Ingrese el Dato para el Nodo RAÍZ", ref d);
                    Crearnodo(ref r, d);
                }
                else
                {
                    Pedir("\nIngrese el dato para el Nodo HIJO", ref d);
                    t1 = t2 = r;
                    while (t1 != null)
                    {
                        t2 = t1;
                        if (d < t2.Dato)
                            t1 = t2.Izquierda;
                        else
                            t1 = t2.Derecha;
                    }
                    Crearnodo(ref t, d);
                    if (d < t2.Dato)
                        t2.Izquierda = t;
                    else
                        t2.Derecha = t;
                }
                Pedir("\nPresione 1 para seguir / Presione 0 para parar", ref resp);

            }
        }

        static Nodo BuscarHojas(Nodo t, int dato)
        {
            if (t == null)
            {
                return null;
            }
            else
            {
                if (t.Dato.Equals(dato))
                {
                    System.Console.WriteLine("Dato Encontrado!");
                    if (t.Izquierda == null && t.Derecha != null || t.Izquierda != null && t.Derecha == null)
                    {
                        System.Console.WriteLine("El dato tiene un hijo");
                        return t;
                    }
                    return t;
                }
                else
                {
                    Nodo hojaEnIzquierda = BuscarHojas(t.Izquierda, dato);
                    Nodo hojaEnDerecha = BuscarHojas(t.Derecha, dato);

                    if (hojaEnIzquierda != null)
                    {
                        return hojaEnIzquierda;
                    }

                    if (hojaEnDerecha != null)
                    {
                        return hojaEnDerecha;
                    }

                    System.Console.WriteLine("Dato no Encontrado");
                    return null;
                }
            }
        }
        static Nodo EliminarHojas(Nodo t, int dato)
        {
            if (t == null)
            {
                return null;
            }
            else
            {
                if (BuscarHojas(t, dato) != null)
                {
                    if (t.Izquierda == null && t.Derecha != null || t.Izquierda != null && t.Derecha == null)
                    {
                        System.Console.WriteLine("El dato tiene un hijo");
                        System.Console.WriteLine("Eliminando dato padre");
                        return null;
                    }
                    else
                    {
                        t.Izquierda = EliminarHojas(t.Izquierda, dato);
                        t.Derecha = EliminarHojas(t.Derecha, dato);
                        return t;
                    }
                }
                return t;
            }
        }

        static void ImprimirArbol(Nodo nodo, string prefijo, bool esIzquierdo = false)
        {
            if (nodo != null)
            {
                Console.WriteLine(prefijo + (esIzquierdo ? "├──" : "└──") + "Nombre: " + nodo.Dato);
                ImprimirArbol(nodo.Derecha, prefijo + (esIzquierdo ? "│   " : "    "), true);
                ImprimirArbol(nodo.Izquierda, prefijo + (esIzquierdo ? "│   " : "    "), false);
            }
        }
        public static void Main(string[] args)
        {
            Nodo raiz = null;
            int xd = 0;
            int opcion;

            do
            {
                Console.WriteLine("XDDDD");
                Console.WriteLine("1. Insertar registro");
                Console.WriteLine("2. Buscar Registro");
                Console.WriteLine("3. Eliminar dato con un Hijo");
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
                        Pedir("De un dato para buscar y se verificara si tiene hijo", ref xd);
                        BuscarHojas(raiz, xd);
                        break;

                    case 3:
                        Pedir("Escriba el dato, y si tiene un solo hijo se eliminara", ref xd);
                        EliminarHojas(raiz, xd);
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