using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TtRConnector
{
    public class Graph
    {
        public List<Vertex> Vertices = new();

        public Graph(System.IO.StreamReader file)
        {
            string line;
            List<int> destinations = new();
            List<int> distances = new();
            //_________ZAŁADOWANIE Z PLIKU___________

            while ((line = file.ReadLine()) != null)                           //Dopóki są zapełnione linie tekstu
            {
                destinations.Clear();
                distances.Clear();
                string[] lines = line.Split(',');                              //Tablica przechowuje pocięte spacjami linie tekstu
                string name = lines[0];                                        //Poszczególne elementy linii przechowują odpowiednie dane
                int cityId = Convert.ToInt32(lines[1]);
                for (int i = 2; i < lines.Length; i++)
                {
                    string[] connections = lines[i].Split('-');
                    destinations.Add(Convert.ToInt32(connections[0]));
                    distances.Add(Convert.ToInt32(connections[1]));

                }
                Vertices.Add(new Vertex(name, cityId, destinations));  //Tworzenie wierzchołka o podanych wcześniej parametrach
                foreach (int d in distances)
                {
                    Vertices.Last().distances.Add(d);
                    Vertices.Last().owner.Add(0);
                }
            }

        }

        //public Graph()
        //{
            
        //}

        public bool CheckEdge(int start, int end)                       //Sprawdza czy istnieje połączenie między wierzchołkami
        {
            if (start > end)                                                  //Jeżeli element końcowy jest większy to odwraca elementy
            {
                return CheckEdge(end, start);
            }
            return Vertices[start].CheckConnection(end);
        }

        public int Load(string city)
        {
            foreach (Vertex conn in Vertices)
            {
                if (city == conn.name) return conn.id;
            }

            return 1;
        }

        struct Data                     //Struktura wykorzystana do przechowywania informacji o wierzchołku
        {
            public int distance;
            public int previous;
            public bool visited;
        };

        Data[] table;

        static int SearchMinimum(ref Data[] tab)            //Funkcja znajduje minimalny dystans z tabeli wierzchołków
        {
            int min = -1;
            int mindist = int.MaxValue;
            for (int i = 0; i < tab.Length; i++)
            {
                if (!tab[i].visited && tab[i].distance < mindist)
                {
                    min = i;
                    mindist = tab[i].distance;
                }
            }
            return min;
        }

        static Data[] Dijkstra(int[,] matrix, int start)                   //Realizacja algorytmu Dijkstry
        {
            Data[] tab = new Data[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)                   //  Przygotowanie grafu do wyszukiwania
            {
                tab[i].distance = (i == start) ? 0 : int.MaxValue;
                tab[i].visited = false;
                tab[i].previous = -1;
            }
            int u = start;
            while (u != -1)
            {
                tab[u].visited = true;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[u, i] > 0 && tab[u].distance + matrix[u, i] < tab[i].distance)
                    {
                        tab[i].distance = tab[u].distance + matrix[u, i];
                        tab[i].previous = u;
                    }
                }
                u = SearchMinimum(ref tab);
            }
            return tab;
        }

        //_______________________________________________________________________
        //                                  TO DO
        //_______________________________________________________________________
        //
        //          Zmienić strukturę wyszukiwania (zastosować foreach)

        static Data[] Dijkstra(int[,] matrix, int start, int owner, List<Vertex> vertices)                   //Realizacja algorytmu Dijkstry
        {
            Data[] tab = new Data[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)                   //  Przygotowanie grafu do wyszukiwania
            {
                tab[i].distance = (i == start) ? 0 : int.MaxValue;
                tab[i].visited = false;
                tab[i].previous = -1;
            }


            Vertex v = vertices[start];
            //foreach(Vertex v in vertices)
            do
            {
                tab[v.id].visited = true;
                foreach (int neighbour in v.connections)
                {
                    if (v.owner[v.connections.IndexOf(neighbour)] == owner)
                    {
                        tab[v.id].distance = 0;
                        if (matrix[v.id, neighbour] > 0 && tab[v.id].distance + matrix[v.id, neighbour] < tab[neighbour].distance)
                        {
                            tab[neighbour].distance = tab[v.id].distance + matrix[v.id, neighbour];
                            tab[neighbour].previous = v.id;
                        }
                    }
                    //LAST CHANGE
                    else if (v.owner[v.connections.IndexOf(neighbour)] == 0)
                    {
                        if (matrix[v.id, neighbour] > 0 && tab[v.id].distance + matrix[v.id, neighbour] < tab[neighbour].distance)
                        {
                            tab[neighbour].distance = tab[v.id].distance + matrix[v.id, neighbour];
                            tab[neighbour].previous = v.id;
                        }
                    }
                }
                if (SearchMinimum(ref tab) == -1) break;
                v = vertices[SearchMinimum(ref tab)];
            } while (tab[v.id].previous != -1);
            return tab;
        }

        readonly List<string> cities = new();                             //Przechowuje nazwy poszczególnych miast na drodze do celu
        public List<string> Cities() => cities;
        public int len = 0;

        public bool IsConnected(int start, int meta, int owner)
        {
            var queue = new Queue<Vertex>();
            List<Vertex> visited = new();
            queue.Enqueue(Vertices[start]);
            while (queue.Count > 0)
            {              
                var vertex = queue.Dequeue();
                if (visited.Contains(vertex)) continue;
                visited.Add(vertex);
                foreach (int neighbour in vertex.connections)
                {
                    if (vertex.owner[vertex.connections.IndexOf(neighbour)] == owner)
                    {
                        queue.Enqueue(Vertices[neighbour]);
                        if (neighbour == meta) return true;
                    }
                }
            }
            return false;
        }

        void WypiszDane(int meta, Data[] d)             //Wypisuje dane z otrzymanej tablicy wynikowej
        {
            int u = meta;
            List<int> visited = new();
            len = d[u].distance;
            cities.Add(Vertices[u].name);
            while (d[u].previous != -1)
            {
                visited.Add(u);
                cities.Add(Vertices[d[u].previous].name);
                u = d[u].previous;
                if (visited.Contains(u)) break;
            }

        }

        public List<string> Droga(int start, int meta, int owner)              //Funkcja generuje trasę i liczy dystans
        {
            cities.Clear();
            int graphSize = Vertices.Count;                      //n - liczba elementów w bazie danych
            int[,] neighbours = new int[graphSize, graphSize];                 //Tablica sąsiedztwa
            for (int i = 0; i < graphSize; i++)                     //Zerowanie tablicy
            {
                for (int j = 0; j < graphSize; j++)
                {         
                    neighbours[i, j] = 0;
                }
            }
            for (int i = 0; i < graphSize; i++)                     //Wprowadzanie wartości z bazy danych to tablicy sąsiedztwa
            {
                for (int j = 0; j < graphSize; j++)
                {
                    if (j == i) neighbours[i, j] = 0;
                    else
                    {
                        if (!Vertices[i].connections.Contains(j)) neighbours[i, j] = 10000;
                        else
                            neighbours[i, j] = Vertices[i].distances[Vertices[i].connections.IndexOf(j)];
                    }
                }
            }
            if (owner == 0)
            {
                table = Dijkstra(neighbours, start);
            }
            else
            {
                table = Dijkstra(neighbours, start, owner, Vertices);
            }
            WypiszDane(meta, table);
            //cities.Reverse();
            return cities;
        }

        public List<string> Droga(int start, int meta, int owner, int x, int y)              //Funkcja generuje trasę i liczy dystans
        {
            cities.Clear();
            int graphSize = Vertices.Count;                      //n - liczba elementów w bazie danych
            int[,] neighbours = new int[graphSize, graphSize];                 //Tablica sąsiedztwa
            for (int i = 0; i < graphSize; i++)                     //Zerowanie tablicy
            {
                for (int j = 0; j < graphSize; j++)
                {
                    neighbours[i, j] = 0;
                }
            }
            for (int i = 0; i < graphSize; i++)                     //Wprowadzanie wartości z bazy danych to tablicy sąsiedztwa
            {
                for (int j = 0; j < graphSize; j++)
                {
                    if (j == i) neighbours[i, j] = 0;
                    else
                    {
                        if (!Vertices[i].connections.Contains(j)) neighbours[i, j] = 10000;
                        else
                            neighbours[i, j] = Vertices[i].distances[Vertices[i].connections.IndexOf(j)];
                    }
                }
            }
            neighbours[x, y] = 10000;
            neighbours[y, x] = 10000;
            if (owner == 0)
            {
                table = Dijkstra(neighbours, start);
            }
            else
            {
                table = Dijkstra(neighbours, start, owner, Vertices);
            }
            WypiszDane(meta, table);
            //cities.Reverse();
            return cities;
        }

    }
}
