using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrearArbol
{
    class Program
    {
        class Nodo
        {
            public string nombre;
            public string numero;
            public Nodo izquierda;
            public Nodo derecha;
            public Nodo(string nombre,string numero, Nodo izq, Nodo der)
            {
                this.nombre = nombre;
                this.numero = numero;
                izquierda = izq;
                derecha = der;
            }
        }

        static void Pedir(string m, ref string x)
        {
            Console.WriteLine("{0}", m);
            x = (Console.ReadLine());
        }

        static void Pedir(string m, ref int x)
        {
            Console.WriteLine("{0}", m);
            x = int.Parse(Console.ReadLine());
        }


        static void Crearnodo(ref Nodo q, string n, string num)
        {
            q = new Nodo(n,num, q, q);
            q.izquierda = null;
            q.derecha = null;
        }

        static void Insertarnodo(ref Nodo r)
        {
            Nodo t1 = null, t2 = null, t = null;
            int resp = 1;
            string n = "" ;
            string num = "";
            while (resp == 1)
            {
                if (r == null)
                {
                    Pedir("Ingrese el Dato para el Nodo RAÍZ --- Nombre", ref n);
                    Pedir("Ingrese el Dato para el Nodo RAÍZ --- Telefono", ref num);
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
                        if (string.Compare(n,t.nombre) < 0)
                            t1 = t2.izquierda;
                        else
                            t1 = t2.derecha;
                    }

                    Crearnodo(ref t, n,num);
                    if (string.Compare(num, t.numero) < 0)
                        t2.izquierda = t;
                    else
                        t2.derecha = t;
                }
                Pedir("\nPresione 1 para seguir / Presione 0 para parar", ref resp);

            }
        }

        static void Eliminar(Nodo t ) { }
        static void Buscar(Nodo t, string Nombre) { }


        static void Impinorden(Nodo t)
        {
            if (t != null)
            {
                Impinorden(t.izquierda);
                Console.WriteLine("{0} ", t.nombre);
                Console.Write("  {0}  ", t.numero);
                Impinorden(t.derecha);
            }

        }

        static void Main(string[] args)
        {
            Nodo raiz = null;
            Insertarnodo(ref raiz);
            Impinorden(raiz);
            Console.ReadKey();
        }

    }
}
