using System;

namespace Ejercicio12
{
    class Menor
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

                    // Crea el nuevo nodo y asignarlo a 't'
                    Crearnodo(ref t, d);

                    // Asigna el nuevo nodo a la estructura del árbol
                    if (d < t2.Dato)
                        t2.Izquierda = t;
                    else
                        t2.Derecha = t;
                }
                Pedir("\nPresione 1 para seguir / Presione 0 para parar", ref resp);
            }
        }


        static Nodo Buscar(Nodo t,int dato)
        {
            if (t == null)
            {
                return null;
            }
            else
            {
                if (t.Dato == dato)
                {   
                    System.Console.WriteLine("Dato Encontrado! {0}", t.Dato);
                    Buscar(t.Derecha,  dato);
                    
                }
            }
            Buscar(t.Izquierda,dato);
            return t;
        }

        static Nodo Eliminar(Nodo t, int dato)
        {
            if(t == null)
            {
                return null;
            }
            else
            {
                if (Buscar(t,  dato) != null)
                {   
                    System.Console.WriteLine("Eliminando Dato");
                    return  null;
                }
                Eliminar(t.Izquierda , dato);
                Eliminar(t.Derecha, dato);
            }
            return t;
        }
        static int ImprimirMenor(Nodo nodo, ref int menor)
        {
            if(nodo == null)
            {
                return 0;
            }
            else
            {
                if(nodo.Dato < menor)
                {
                    menor = nodo.Dato;
                }
                ImprimirMenor(nodo.Izquierda, ref menor);
                ImprimirMenor(nodo.Derecha,ref menor);
            }
            return menor;
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
            int cont = 0, busq = 0, dato =0;
            int opcion;
            int menor = 9999;


            do
            {
                Console.WriteLine("Arbol Binario");
                Console.WriteLine("1. Insertar");
                Console.WriteLine("2. Buscar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Imprimir Menor");
                Console.WriteLine("5. Imprimir Arbol");
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
                        System.Console.WriteLine("Busqueda");
                        Pedir("De el numero a buscar", ref busq);
                        Buscar(raiz, busq);
                        break;


                    case 3:
                        System.Console.WriteLine("Eliminar Datos");
                        Pedir("De el dato a eliminar", ref dato);
                        Eliminar(raiz,dato);
                        break;
                
                    case 4:
                        System.Console.WriteLine("Imprimiendo Menores");
                        int xd = ImprimirMenor(raiz,ref menor);
                        System.Console.WriteLine("El Nodo con menor valor en el arbol binario es {0} ", xd);
                        break;


                    case 5:
                        System.Console.WriteLine("Imprimiendo Arbol");
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