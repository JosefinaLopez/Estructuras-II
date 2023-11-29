using System;

namespace Grafos4
{
    class GrafoDirigido
    {
        public static int V; // Número de vértices
        public static List<int>[] listaAdyacencia; // Lista de adyacencia

        public GrafoDirigido(int v)
        {
            V = v;
            listaAdyacencia = new List<int>[v];
            for (int i = 0; i < v; i++)
            {
                listaAdyacencia[i] = new List<int>();
            }
        }

        // Método para agregar una arista dirigida al grafo
        public void AgregarArista(int origen, int destino)
        {
            listaAdyacencia[origen].Add(destino);
        }

        // Método para imprimir el grafo dirigido
        public static void ImprimirGrafo()
        {
            Console.WriteLine("Representación del Grafo Dirigido:");
            for (int i = 0; i < V; i++)
            {
                Console.Write("Vértice " + i + " -> ");
                foreach (var nodo in listaAdyacencia[i])
                {
                    Console.Write(nodo + " ");
                }
                Console.WriteLine();
            }
        }
        //! Lista donde se guardaran los ciclos
        public static List<int> loops = new List<int>();
        public static void Ciclo()
        {
            //bool band = false;
            for (int i = 0; i < V; i++)
            {
                foreach (var nodo in listaAdyacencia[i])
                {
                    if(i.Equals(nodo))
                    {   
                        System.Console.WriteLine($"Vertice con ciclo {nodo}");
                        loops.Add(nodo);
                        //band = true;
                    }
                }
            }
        }
        //!Imprime la lista con los vertices de ciclos encontrados
        static void Imploops()
        {
            foreach (var loop in loops)
            {
                System.Console.WriteLine($"Valor de Ciclo Almacenado : {loop}");
            }
        }

        // Método para crear grafo
        public static void CrearGrafo()
        {
            Console.Write("Ingrese el número de vértices: ");
            int numVertices = int.Parse(Console.ReadLine());

            GrafoDirigido grafo = new GrafoDirigido(numVertices);

            while (true)
            {
                Console.WriteLine("Ingrese una arista (origen destino) o escriba 'fin' para terminar:");
                string input = Console.ReadLine();

                if (input.ToLower() == "fin")
                {
                    break;
                }

                string[] partes = input.Split(' ');
                if (partes.Length != 2)
                {
                    Console.WriteLine("Entrada no válida. Debe ingresar dos números separados por espacio.");
                    continue;
                }

                int origen = int.Parse(partes[0]);
                int destino = int.Parse(partes[1]);

                grafo.AgregarArista(origen, destino);
            }

        }

        public static void Pedir(string m, ref int x)
        {
            System.Console.WriteLine(m);
            x = int.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            
            int op = 0;
            do
            {
                Pedir("\nMenu\n 1- Crear Grafo\n 2- Buscar Ciclos en el grafo\n 3- Imprimir Grafo\n 4- Imprimir Ciclos Guardados\n  0- Salir\n", ref op);
                switch (op)
                {
                    case 1:
                        CrearGrafo();
                        break;
                    case 2:
                        Ciclo();
                        break;
                    case 3:
                        ImprimirGrafo();  
                        break;  
                    case 4:
                        Imploops();
                        break;
                    case 0:
                        System.Console.WriteLine("Saliendo del Programa");
                        break;
                    default:
                        System.Console.WriteLine("Debes seleccionar una opción válida.");
                        break;
                }
            } while (op != 0);
        }

    }
}