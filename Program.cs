using System;

namespace ArbolBinario
{
  
    public class NodoT
    {
        public NodoT NodoIzquierdo;
        public String Informacion;
        public NodoT NodoDerecho;
     
        public NodoT()
            {
            this.NodoIzquierdo = null;
            this.Informacion = "";
            this.NodoDerecho = null;
            }
        
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            NodoT p = null;
            int opcion = 0;
            do
            {
                opcion = Menu(); 
                switch (opcion)
                {
                    case 1:
                        p = new NodoT();
                        Carga(p);
                        Console.Clear();
                    break;
                    case 2:
                        Console.WriteLine("Recorrido en Preorden");
                        Preorden(p);
                        Console.WriteLine();
                        Console.WriteLine("Fin del Recorrido");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        Console.WriteLine("Recorrido en Postorden");
                        Postorden(p);
                        Console.WriteLine();
                        Console.WriteLine("Fin del Recorrido");
                        Console.ReadLine();
                        Console.Clear();

                        break;
                    case 4:
                        Console.WriteLine("Recorrido en Inorden");
                        inorden(p);
                        Console.WriteLine();
                        Console.WriteLine("Fin del Recorrido");
                        Console.ReadLine();
                        Console.Clear();

                        break;
                    case 5:
                        int contador = 0;  
                        Console.WriteLine("El nodo tiene " + contarNodos(p , contador) + " Nodos");
                        Console.ReadLine();
                        Console.Clear();
                       
                        break;

                    case 6:
                        int contador1 = 0;
                        Console.WriteLine("El nodo tiene " + contarHojas(p, contador1) + " Hojas");
                        Console.ReadLine();
                        Console.Clear();
                        break; 


                }
            } while (opcion != 7);
        }

        static void Finalizar()
        {
            Console.WriteLine("Fin del programa, presione una tecla para continuar");
            Console.ReadLine(); 
        }
        static int Menu()
        {
            int Resultado = 0;
            Console.WriteLine("Arbol Binario");
            Console.WriteLine("");
            Console.WriteLine("1.- Cargar los nodos del arbol");
            Console.WriteLine("2.- Preorden");
            Console.WriteLine("3.- Pos Orden");
            Console.WriteLine("4.- Inorden");
            Console.WriteLine("5.- Numero de nodos del arbol");
            Console.WriteLine("6.- Numero de hojas del arbol");
            Console.WriteLine("7.- Finalizar el programa");
            Console.WriteLine("");
            Console.Write("Opcion: ");
            Resultado = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            return Resultado; 
        }
        static void Carga (NodoT n)
        {
            String info;
            NodoT otro;
            char resp;
            Console.WriteLine("Informacion del nodo:    ");
            info = Console.ReadLine();
            n.Informacion = info;
            Console.WriteLine("Existen nodos por la izquierda  " + info + "[S/N] ?");
            resp = Convert.ToChar(Console.ReadLine()); 
            if(char.ToUpper(resp) == 'S' )
            {
                otro = new NodoT();
                n.NodoIzquierdo = otro;
                Carga(n.NodoIzquierdo); 
            }
            else
                n.NodoIzquierdo = null;
            Console.WriteLine("Existe nodo por la derecha  " + info + "[s/n] ?");
            resp = Convert.ToChar(Console.ReadLine());
            if (char.ToUpper(resp) == 'S')
            {
                otro = new NodoT();
                n.NodoDerecho = otro;
                Carga(n.NodoDerecho);
            }
            else
                n.NodoDerecho = null;
        }

        static void Preorden (NodoT P)
        {
            if(P != null)
            {
                Console.WriteLine(" " + P.Informacion);
                Preorden(P.NodoIzquierdo);
                Preorden(P.NodoDerecho); 
            }
        }
        static void Postorden (NodoT P)
        {
            if (P != null)
            {
                Postorden(P.NodoIzquierdo);
                Postorden(P.NodoDerecho);
                Console.WriteLine(" " + P.Informacion);
            }
        }
        static void inorden(NodoT P)
        {
            if (P != null)
            {
                inorden(P.NodoIzquierdo);
                Console.WriteLine(" " + P.Informacion);
                inorden(P.NodoDerecho);               
            }
        }

        static int contarNodos(NodoT p , int contador)
        {
            if (p != null )
            {
                contador++; 
                contador= + contarNodos(p.NodoIzquierdo , contador);
                contador= + contarNodos(p.NodoDerecho , contador); 
            } 
            return contador; 
        }
        static int contarHojas(NodoT p, int contador)
        {

            if (p != null )
            {
                if (p.NodoIzquierdo == null && p.NodoDerecho == null)
                {
                    contador++;
                }
                contador = + contarHojas(p.NodoIzquierdo, contador);
                contador = + contarHojas(p.NodoDerecho, contador); 
            }
            return contador;
        }
    }
}
