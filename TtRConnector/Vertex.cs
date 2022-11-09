using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TtRConnector
{
    public class Vertex
    {

        public string name = "Brak nazwy";
        public int id;
        public List<int> connections = new();                     //Tworzona jest lista połączeń pomiędzy wierzchołkami
        public List<int> distances = new();                        //Tworzona jest lista długości odpowiadających połączeń
        public List<int> owner = new();

        public bool CheckConnection(int target)                         //Sprawdza czy połączenie z danym wierzchołkiem istnieje
        {
            return connections.IndexOf(target) != -1;               //Sprawdza czy połączenie z danym wierzchołkiem istnieje
        }

        public bool AddEdge(int target)
        {
            if (CheckConnection(target))                             //Jeżeli istnieje połączenie to nic nie rób
            {                                                       //Jeżeli jednak nie istnieje to utwórz nowe połączenie
                return false;
            }
            else
            {
                connections.Add(target);
                return true;
            }
        }

        public Vertex(string _name, int _id, List<int> connections)
        {
            name = _name;
            id = _id;
            foreach (int edge in connections) AddEdge(edge);          //Dodawanie dynamicznych połączeń do wierzchołka id
        }

        public Vertex()
        {

        }
    }
}
