using System;

namespace Ejercicio6
{
    class ContarHijosIzquierdos
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

        static void Pedir(string m, ref int x)
        {
            Console.WriteLine("{0}", m);
            x = int.Parse(Console.ReadLine());
        }

        static void Crearnodo(ref Nodo q, int d)
        {
            q = new Nodo(d, q, q);
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

        static int Contar(Nodo t, ref int cont)
        {
            if (t == null)
            {
                return 0;
            }
            else
            {
                if (t.Izquierda != null)
                {
                    Contar(t.Izquierda, ref cont);
                    cont++;
                }
            }
            Contar(t.Derecha, ref cont);
            return cont;
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
        static void Impinorden(Nodo t)
        {
            if (t != null)
            {
                Impinorden(t.Izquierda);
                Console.Write("  {0}  ", t.Dato);
                Impinorden(t.Derecha);
            }

        }

        static void Main(string[] args)
        {
            Nodo raiz = null;
            int cont = 0;
            int opcion;

            do
            {
                Console.WriteLine("Calificaciones Escolares");
                Console.WriteLine("1. Insertar");
                Console.WriteLine("2. Contar");
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
                        int result = Contar(raiz, ref cont);
                        System.Console.WriteLine("Conteo de Nodos Derechos");
                        System.Console.WriteLine("La cantidad de Nodos Derechos {0}", result);
                        break;

                    case 3:
                        System.Console.WriteLine("Imprimiendo Nodos Izquierdos");
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