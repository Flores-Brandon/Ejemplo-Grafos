using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_Grafos
{
    class Grafo
    {
        private int V; // Número de nodos (vértices)
        private List<int>[] listaAdyacencia; // Lista de adyacencia para representar el grafo

        public Grafo(int v)
        {
            V = v;
            listaAdyacencia = new List<int>[v];
            for (int i = 0; i < v; ++i)
            {
                listaAdyacencia[i] = new List<int>();
            }
        }

        // Método para agregar una arista al grafo
        public void AgregarArista(int v, int w)
        {
            listaAdyacencia[v].Add(w);
            listaAdyacencia[w].Add(v); // En un grafo no dirigido, la arista es bidireccional
        }

        // Función recursiva para realizar un recorrido en profundidad (DFS)
        private void DFSUtil(int v, bool[] visitado)
        {
            visitado[v] = true;
            Console.Write(v + " ");

            foreach (int i in listaAdyacencia[v])
            {
                if (!visitado[i])
                {
                    DFSUtil(i, visitado);
                }
            }
        }

        // Función para realizar un recorrido en profundidad (DFS) desde un nodo de inicio dado
        public void DFS(int inicio)
        {
            bool[] visitado = new bool[V];

            Console.WriteLine("Recorrido en profundidad (DFS) desde el nodo " + inicio + ":");
            DFSUtil(inicio, visitado);
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroNodos = 5;
            Grafo grafo = new Grafo(numeroNodos);

            grafo.AgregarArista(0, 1);
            grafo.AgregarArista(0, 2);
            grafo.AgregarArista(1, 3);
            grafo.AgregarArista(2, 4);

            int nodoInicio = 0;
            grafo.DFS(nodoInicio);
        }
    }
}
