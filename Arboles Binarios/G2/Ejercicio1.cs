using System;

namespace Ejercicio1
{
    public class ContarNodos
    {
        class Nodo
        {
            public int dato;
            public Nodo izquierda;
            public Nodo derecha;
            public Nodo(int dato, Nodo izq, Nodo der)
            {
                this.dato = dato;
                izquierda = izq;
                derecha = der;
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
            q.izquierda = null;
            q.derecha = null;
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
                        if (d < t2.dato)
                            t1 = t2.izquierda;
                        else
                            t1 = t2.derecha;
                    }
                    Crearnodo(ref t, d);
                    if (d < t2.dato)
                        t2.izquierda = t;
                    else
                        t2.derecha = t;
                }
                Pedir("\nPresione 1 para seguir / Presione 0 para parar", ref resp);

            }
        }

        static Nodo IdentificarRaiz(Nodo r)
        {
            return r; //!Funcion que retorna la raiz
        }
        static int ContarSubArbolDerecho(Nodo d, Nodo raiz)
        {
            if (d == null)
            {
                return 0;
            }

            int contador = 0;

            if (d.dato > raiz.dato) //!Verifica si el nodo  es mayor que el nodo raiz --> derec
            {
                contador++; //!El contador aumenta en 1
                System.Console.WriteLine($"Nodo {d.dato} pertenece al sub arbol derecho");
            }

            contador += ContarSubArbolDerecho(d.derecha, raiz); //!Metodo recursivo
            contador += ContarSubArbolDerecho(d.izquierda, raiz);

            return contador;
        }

        static void ImprimirArbol(Nodo nodo, string prefijo, bool esIzquierdo = false)
        {
            if (nodo != null)
            {
                Console.WriteLine(prefijo + (esIzquierdo ? "├──" : "└──") + "Nombre: " + nodo.dato + " Numero: " + nodo.dato);
                ImprimirArbol(nodo.derecha, prefijo + (esIzquierdo ? "│   " : "    "), true);
                ImprimirArbol(nodo.izquierda, prefijo + (esIzquierdo ? "│   " : "    "), false);
            }
        }
        public static void Main(string[] args)
        {
            Nodo raiz = null;
            int op;
            do
            {
                System.Console.WriteLine("Sub Arbol Derecho");
                System.Console.WriteLine("1. Agregar Registro");
                System.Console.WriteLine("2. Contar Nodos de Sub Arbol Derecho");
                System.Console.WriteLine("3. Imprimir Arbol");
                System.Console.WriteLine("0. Salir");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Insertarnodo(ref raiz);
                        System.Console.WriteLine("Dato Agregado Exitosamente!");
                        break;

                    case 2:
                        Nodo x = IdentificarRaiz(raiz);
                        int result = ContarSubArbolDerecho(raiz, x);
                        System.Console.WriteLine($"La Cantidad de Nodos en el Sub Arbol es de {result}");
                        break;

                    case 3: ImprimirArbol(raiz, ""); break;
                    case 0: System.Console.WriteLine("Precione cualquier tecla para salir..."); break;
                    default: System.Console.WriteLine("Elija una opcion valida"); break;
                }
            } while (op != 0);
            Console.ReadKey();
        }
    }
}
