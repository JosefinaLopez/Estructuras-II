using System;

namespace Ejercicio3
{
    public class Diccionario
    {
        class Nodo
        {
            public string Palabra { get; set; }
            public string Definicion { get; set; }
            public Nodo Izquierda { get; set; }
            public Nodo Derecha { get; set; }
            public Nodo(string palabra, string definicion,  Nodo izq, Nodo der)
            {
                Palabra = palabra;
                Definicion = definicion;
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
        static void Crearnodo(ref Nodo q, string pal, string defi)
        {
            q = new Nodo(pal, defi, q, q);
            q.Izquierda = null;
            q.Derecha = null;
        }

        static void Insertarnodo(ref Nodo r)
        {
            Nodo t1 = null, t2 = null, t = null;
            int resp = 1;
            string p = "", def = "";
            while (resp == 1)
            {
                if (r == null)
                {
                    Pedir("Ingrese el Dato para el Nodo Raiz --- Palabra", ref p);
                    Pedir("Ingrese el Dato para el Nodo Raiz --- Definicion", ref def);
                    Crearnodo(ref r, p, def);
                }
                else
                {
                    Pedir("Ingrese el Dato para el Nuevo Nodo --- Palabra", ref p);
                    Pedir("Ingrese el Dato para el Nuevo Nodo --- Definicion", ref def);
                    t1 = t2 = r;
                    while (t1 != null)
                    {
                        t2 = t1;
                        if (string.Compare(p, t2.Palabra) < 0)
                            t1 = t2.Izquierda;
                        else
                            t1 = t2.Derecha;
                    }

                    // Crear el nuevo nodo y asignarlo a 't'
                    Crearnodo(ref t, p, def);

                    // Asignar el nuevo nodo a la estructura del árbol
                    if (string.Compare(p, t2.Palabra) < 0)
                        t2.Izquierda = t;
                    else
                        t2.Derecha = t;
                }

                Pedir("\nPresione 1 para seguir / Presione 0 para parar", ref resp);
            }
        }

        static Nodo Buscar(Nodo t, string palabra)
        {
            if(t == null)
            {
                return null;
            }
            else
            {
                if(t.Palabra.Equals(palabra))
                {
                    System.Console.WriteLine("Registro Encontrado!");
                    System.Console.WriteLine("Definicion: {0} ", t.Definicion);
                    return t;
                }
                //!Funcion recursiva que retorna el nodo encontrado
                Nodo nodoEncontradoDerecha = Buscar(t.Derecha, palabra);
                if (nodoEncontradoDerecha != null)
                    return nodoEncontradoDerecha;

                Nodo nodoEncontradoIzquierda = Buscar(t.Izquierda, palabra);
                if (nodoEncontradoIzquierda != null)
                    return nodoEncontradoIzquierda;
            }
            return t;
        }
        static void Actualizar(Nodo t, string palabra)
        {   
            string def = "";
            Nodo nodoEncontrado = Buscar(t, palabra);

            if (Buscar(t,palabra) != null)
            {
                Pedir("Escriba la Definicion a Actualizar",ref def);
                nodoEncontrado.Definicion = def;
                System.Console.WriteLine("Datos Actualizados Satisfactoriamente");
            }
            else
            {
                System.Console.WriteLine("No se puede actualizar un registro inexistente");
            }
        }
        static void ImprimirArbol(Nodo nodo, string prefijo, bool esIzquierdo = false)
        {
            if (nodo != null)
            {
                Console.WriteLine(prefijo + (esIzquierdo ? "├──" : "└──") + "Palabra: " + nodo.Palabra + " Definicion: " + nodo.Definicion);
                ImprimirArbol(nodo.Derecha, prefijo + (esIzquierdo ? "│   " : "    "), true);
                ImprimirArbol(nodo.Izquierda, prefijo + (esIzquierdo ? "│   " : "    "), false);
            }
        }
        public static void Main(string[] args)
        {
            Nodo raiz = null;
            string p = "";
            int opcion;


            do
            {
                Console.WriteLine("Diccionario");
                Console.WriteLine("1. Insertar registro en el Diccionario");
                Console.WriteLine("2. Buscar por Palabra");
                Console.WriteLine("3. Actualizar por Palabra");
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
                        Console.Write("Ingrese la palabra a buscar: ");
                        string nombreBusqueda = Console.ReadLine();
                        Buscar(raiz, nombreBusqueda);
                        break;

                    case 3:
                        Pedir("Ingrese el nombre del producto a actualizar", ref p);
                        Actualizar(raiz, p);
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