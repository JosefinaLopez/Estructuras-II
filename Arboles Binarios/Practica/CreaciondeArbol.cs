using System;

namespace ConsoleApp
{
    //?Clase Nodo
    public class Nodo
    {
        public string Nombre { get; set; }
        public Nodo Izquierda { get; set; }
        public Nodo Derecha { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //!Nivel 1
            Nodo Raiz = new Nodo();
            Raiz.Nombre = "5";

            //!Nivel 2
            Nodo Nodo2 = new Nodo();
            Nodo2.Nombre = "2";
            Raiz.Derecha = Nodo2;

            Nodo Nodo6 = new Nodo();
            Nodo6.Nombre = "6";
            Raiz.Izquierda = Nodo6;

            //!Nivel 3 - Primera Rama
            Nodo Nodo1 = new Nodo();
            Nodo1.Nombre = "1";
            Nodo2.Izquierda = Nodo1;

            Nodo Nodo4 = new Nodo();
            Nodo4.Nombre = "4";
            Nodo2.Derecha = Nodo4;

            Nodo Nodo3 = new Nodo();
            Nodo3.Nombre = "3";
            Nodo4.Izquierda = Nodo3;

            //!Nivel 3 - Segunda Rama
            Nodo Nodo8 = new Nodo();
            Nodo8.Nombre = "8";
            Nodo6.Derecha = Nodo8;

            Nodo Nodo7 = new Nodo();
            Nodo7.Nombre = "7";
            Nodo8.Derecha = Nodo7;

            Nodo Nodo9 = new Nodo();
            Nodo9.Nombre = "9";
            Nodo8.Izquierda = Nodo9;

            // Llamada para imprimir el árbol
            ImprimirArbol(Raiz, "");

        }
        //!El valor booleano identifica si el nodo es hijo izquiero de su padre.
        public static void ImprimirArbol(Nodo nodo, string prefijo, bool esIzquierdo = false)
        { 
            //!Identifica si el nodo no es nulo.
            if (nodo != null)
            {   
                //!Prefijo  verifica , si es izquierdo o Derecho imprime la figura, mas el nombre puesto en la clase.
                Console.WriteLine(prefijo + (esIzquierdo ? "├──" : "└──") + nodo.Nombre);
                //!El metodo se llama a si mismo recursivamente, para poder recorrer todo el arbol y posteriormente imprimir
                ImprimirArbol(nodo.Izquierda, prefijo + (esIzquierdo ? "│   " : "    "), true);
                ImprimirArbol(nodo.Derecha, prefijo + (esIzquierdo ? "│   " : "    "), false);
            }
        }
    }
}
