using System;

namespace GrafoConMatrizDeAdyacencia
{
    class GrafoDirigido3
    {
        public static int V; // Número de vértices
        public static bool[,] matrizAdyacencia; // Matriz de adyacencia

        public GrafoDirigido3(int v)
        {
            V = v;
            matrizAdyacencia = new bool[v, v];
        }

        // Método para agregar una arista dirigida al grafo
        public void AgregarArista(int origen, int destino)
        {
            matrizAdyacencia[origen, destino] = true;
        }

        public static void Ciclo()
        {
            for (int i = 0; i < V; i++)
            {   
                for (int j = 0; j < V; j++)
                {
                    if (matrizAdyacencia[i, j])
                    {
                        if(i.Equals(j))
                        {
                            System.Console.WriteLine($"El Ciclo Presente pertenece al Vertice -> {i}");
                        }
                    }
                }
            }
        }
        // Método para imprimir el grafo dirigido
        public static void ImprimirGrafo()
        {
            Console.WriteLine("Representación del Grafo Dirigido:");
            for (int i = 0; i < V; i++)
            {
                Console.Write("Vértice " + i + " -> ");
                for (int j = 0; j < V; j++)
                {
                    if (matrizAdyacencia[i, j])
                    {
                        Console.Write(j + " ");
                    }
                }
                Console.WriteLine();
            }
        }


        // Método para crear grafo
        public static void CrearGrafo()
        {
            Console.Write("Ingrese el número de vértices: ");
            int numVertices = int.Parse(Console.ReadLine());

            GrafoDirigido3 grafo = new GrafoDirigido3(numVertices);

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

                //!Metodo que evita que se rompa el programa xd
                if (origen >= numVertices || destino >= numVertices)
                {
                    System.Console.WriteLine("No puede Insertar un numero que exceda el rango de Vertices");
                }
                else
                {
                    grafo.AgregarArista(origen, destino);
                }
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
                Pedir("\nMenu\n 1- Crear Grafo\n 2- Imprimir Valor de Ciclo\n 3- ImprimirGrafo\n 0- Salir\n", ref op);
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

