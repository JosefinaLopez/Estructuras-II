using System;

namespace Ejercicio2
{
    public class Inventario
    {
        class Nodo
        {
            public string Nombre {get;set;}
            public int Cantidad {get; set;}
            public double Precio {get; set;}
            public Nodo Izquierda {get; set;}
            public Nodo Derecha {get; set;}
            public Nodo(string nombre, int cantidad, double precio, Nodo izq, Nodo der)
            {
                Nombre = nombre;
                Cantidad = cantidad;
                Precio = precio;
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
        static void Crearnodo(ref Nodo q, string n, int cant, double precio)
        {
            q = new Nodo(n, cant,precio ,q, q);
            q.Izquierda = null;
            q.Derecha = null;
        }
        static void Insertarnodo(ref Nodo r)
        {
            Nodo t1 = null, t2 = null, t = null;
            int resp = 1;
            string n = "";
            int cant = 0;
            double precio = 0.0;

            while (resp == 1)
            {
                if (r == null)
                {
                    Pedir("Ingrese el Dato para el Nodo Raiz --- Nombre Producto", ref n);
                    Pedir("Ingrese el Dato para el Nodo Raiz --- Cantidad", ref cant);
                    Pedir("Ingrese el Dato para el Nodo Raiz --- Precio", ref precio);
                    Crearnodo(ref r, n, cant, precio);
                }
                else
                {
                    Pedir("Ingrese el Dato para el Nodo Hijo --- Nombre Producto", ref n);
                    Pedir("Ingrese el Dato para el Nodo Hijo --- Cantidad", ref cant);
                    Pedir("Ingrese el Dato para el Nodo Hijo --- Precio", ref precio);
                    t1 = t2 = r;

                    while (t1 != null)
                    {
                        t2 = t1;
                        if (string.Compare(n, t2.Nombre) < 0)
                            t1 = t2.Izquierda;
                        else
                            t1 = t2.Derecha;
                    }

                    //!ERROR SOLUCIONADO: Crear el nuevo nodo fuera del bucle
                    Crearnodo(ref t, n, cant, precio);

                    if (string.Compare(n, t2.Nombre) < 0)
                        t2.Izquierda = t;
                    else
                        t2.Derecha = t;
                }

                Pedir("\nPresione 1 para seguir / Presione 0 para parar", ref resp);
            }
        }

        static Nodo Buscar(Nodo t, string producto)
        {
            if (t == null)
            {
                return null;
            }
            else
            {
                if (t.Nombre == producto)
                {
                    System.Console.WriteLine("Producto Encontrado!");
                    System.Console.WriteLine("Producto: {0}", t.Nombre);
                    System.Console.WriteLine("Cantidad: {0}", t.Cantidad);
                    System.Console.WriteLine("Precio C${0}", t.Precio);
                    return t;
                }
                //!Funcion recursiva que retorna el nodo encontrado
                Nodo nodoEncontradoDerecha = Buscar(t.Derecha, producto);
                if (nodoEncontradoDerecha != null)
                    return nodoEncontradoDerecha;

                Nodo nodoEncontradoIzquierda = Buscar(t.Izquierda, producto);
                if (nodoEncontradoIzquierda != null)
                    return nodoEncontradoIzquierda;
            }
            return null;
        }

        static void ActualizarProducto(Nodo t, string producto)
        {
            int cantidad = 0;
            double precio = 0.0;

            Nodo nodoEncontrado = Buscar(t, producto);
            if (nodoEncontrado != null)
            {
                Pedir("De el Precio a Actualizar: ", ref precio);
                Pedir("De la cantidad a Actualizar: ", ref cantidad);
                nodoEncontrado.Precio = precio;
                nodoEncontrado.Cantidad = cantidad;

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
                Console.WriteLine(prefijo + (esIzquierdo ? "├──" : "└──") + "Producto: " + nodo.Nombre + " Cantidad: " + nodo.Cantidad + " Precio: "+ nodo.Precio);
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
                Console.WriteLine("Inventario");
                Console.WriteLine("1. Insertar registro en el Inventario");
                Console.WriteLine("2. Buscar Producto");
                Console.WriteLine("3. Actualizar por Producto");
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
                        Console.Write("Ingrese el nombre del producto a buscar: ");
                        string nombreBusqueda = Console.ReadLine();
                        Buscar(raiz, nombreBusqueda);
                        break;

                    case 3:
                        Pedir("Ingrese el nombre del producto a actualizar", ref p);
                        ActualizarProducto(raiz, p);
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