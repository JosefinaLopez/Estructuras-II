namespace ConsoleApp2
{

    class Node
    {
        public string Origen;
        public string Destino;
        public double Costo;
        public Node Left;
        public Node Right;

        public Node(string origen, string destino, double costo)
        {
            Origen = origen;
            Destino = destino;
            Costo = costo;
            Left = null;
            Right = null;
        }
    }

    class ArbolBinario
    {
        public Node Raiz;

        public ArbolBinario()
        {
            Raiz = null;
        }
        public void Insertar(string origen, string destino, double costo)
        {
            Raiz = InsertarReg(Raiz, origen, destino, costo);
        }
        private Node InsertarReg(Node raiz, string origen, string destino, double costo)
        {
            if (raiz == null)
            {
                raiz = new Node(origen, destino, costo);
                return raiz;
            }

            if (string.Compare(origen, raiz.Origen) < 0)
            {
                raiz.Left = InsertarReg(raiz.Left, origen, destino, costo);
            }
            else if (string.Compare(origen, raiz.Origen) > 0)
            {
                raiz.Right = InsertarReg(raiz.Right, origen, destino, costo);
            }

            return raiz;
        }
        public void PrintInOrder(Node raiz)
        {
            if (raiz != null)
            {
                PrintInOrder(raiz.Left);
                Console.WriteLine($"Origen: {raiz.Origen}, Cost: {raiz.Costo}");
                PrintInOrder(raiz.Right);
            }
        }
        public int ContadorHojas(Node raiz, ref int cont)
        {
            if (raiz == null)
            {
                return 0;
            }
            else
            {
                if(raiz.Left == null && raiz.Right == null)
                {
                    Console.WriteLine("La Hoja Origen es: " + raiz.Origen);
                    cont++;
                }
                ContadorHojas(raiz.Left,ref cont);
                ContadorHojas(raiz.Right,ref cont);

                return cont;
            }
        }
        public void ImprimirArbol(Node nodo, string prefijo, bool esIzquierdo = false)
        {
            //!Identifica si el nodo no es nulo.
            if (nodo != null)
            {    

                //!Prefijo  verifica , si es izquierdo o Derecho imprime la figura, mas el nombre puesto en la clase.
                Console.WriteLine(prefijo + (esIzquierdo ? "├──" : "└──") + nodo.Origen);
                //!El metodo se llama a si mismo recursivamente, para poder recorrer todo el arbol y posteriormente imprimir
                ImprimirArbol(nodo.Left, prefijo + (esIzquierdo ? "│   " : "    "), true);
                ImprimirArbol(nodo.Right, prefijo + (esIzquierdo ? "│   " : "    "), false);
            }
        }
        public void PrintPreOrder(Node raiz)
        {
            if (raiz != null)
            {
                Console.WriteLine($"Origen: {raiz.Origen}, Cost: {raiz.Costo}");
                PrintPreOrder(raiz.Left);
                PrintPreOrder(raiz.Right);
            }
        }
        public void PrintPostOrder(Node raiz)
        {
            if (raiz != null)
            {

                PrintPostOrder(raiz.Left);
                PrintPostOrder(raiz.Right);
                Console.WriteLine($"Origen: {raiz.Origen}, Cost: {raiz.Costo}");
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {  
            int cont = 0;
            ArbolBinario arbol = new ArbolBinario();

            arbol.Insertar("Managua", "Mateare", 1500.25);
            arbol.Insertar("Leon", "Chinandega", 200.5);
            arbol.Insertar("Esteli", "Ocotal", 300);
            arbol.Insertar("Matagalpa", "Juigalpa", 400);
            arbol.Insertar("Wiwili", "Jinotega", 1563);

            Console.WriteLine("In-order :");
            arbol.PrintInOrder(arbol.Raiz);

            Console.WriteLine("Pre-order :");
            arbol.PrintPreOrder(arbol.Raiz);

            Console.WriteLine("Post-order :");
            arbol.PrintPostOrder(arbol.Raiz);

            int x = arbol.ContadorHojas(arbol.Raiz,ref cont);
            Console.WriteLine("Hojas totales del Arbol Binario "+ x);
            Console.WriteLine("-----------------------------------------------------");
            // Llamada para imprimir el árbol
            arbol.ImprimirArbol(arbol.Raiz, "");
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();

            /*
                Managua < Leon/  ?
                Esteli  < Matagalpa ? 


                Raiz = Managua 
                        I
                        L_ Leon 
                        I   L Esteli
                        I
                        L_ Matagalpa 
                                L Wiwili


            */


        }
    }
}
