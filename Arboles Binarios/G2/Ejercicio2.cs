using System;

namespace Ejercicio2
{
    public class ContarNodosIzq
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
            // System.Console.WriteLine($"La Raiz es {r.dato}");
            return r; //!Retorna el valor de la raiz
        }
        static int ContarSubArbolDerecho(Nodo i, Nodo raiz)
        {
            //System.Console.WriteLine(raiz.dato);
            if (i == null)
            {
                return 0;
            }

            int contador = 0;

            if (i.dato < raiz.dato) //!Valida si el dato es menor que la raiz -- izq
            {
                contador++;
                System.Console.WriteLine($"Nodo {i.dato} pertenece al sub arbol izquierdo");
            }

            contador += ContarSubArbolDerecho(i.derecha, raiz); //!Funcion Recursiva xd
            contador += ContarSubArbolDerecho(i.izquierda, raiz);

            return contador;
        }
        static int Par(Nodo i, Nodo raiz)
        {
            //System.Console.WriteLine(raiz.dato);
            if (i == null)
            {
                return 0;
            }

            int contador = 0;

            if (i.dato < raiz.dato) //!Igualmente verifica si el dato es menor que la raiz
            {
                if (i.dato % 2 == 0) //!Luego verifica si es par
                {
                    contador++;
                    System.Console.WriteLine($"El Nodo {i.dato} Es par");
                }
            }

            contador += Par(i.derecha, raiz); //!Funcion recursiva x2 xd
            contador += Par(i.izquierda, raiz);

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
                System.Console.WriteLine("Sub Arbol Izquierdo");
                System.Console.WriteLine("1. Agregar Registro");
                System.Console.WriteLine("2. Contar Nodos de Sub Arbol Izquierdo");
                System.Console.WriteLine("3. Contar Cuantos Nodos Pares Tiene el Sub Arbol Izquierdo");
                System.Console.WriteLine("4. Imprimir Arbol");
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
                        System.Console.WriteLine($"La Cantidad de Nodos En El Sub Arbol Es De: {result}");
                        break;

                    case 3:
                        Nodo re = IdentificarRaiz(raiz);
                        int resultado = Par(raiz, re);
                        System.Console.WriteLine($"La Cantidad de Nodos Pares Encontrados En El Sub Arbol Es De: {resultado}");
                        break;

                    case 4: ImprimirArbol(raiz, ""); break;
                    case 0: System.Console.WriteLine("Precione cualquier tecla para salir..."); break;
                    default: System.Console.WriteLine("Elija una opcion valida"); break;
                }
            } while (op != 0);
            Console.ReadKey();
        }
    }
}
