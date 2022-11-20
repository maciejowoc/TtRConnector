using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TtRConnector
{
    delegate void OppoMove(int x, int y, int owner);
    internal class Opponent : Game
    {
        readonly int id;
        public int opponentScore;
        public int start;
        public int end;
        public int opponentCarts;
        int tempScore;
        int idx;
        int nextidx;
        bool endgame = false;

        //readonly List<Vertex> vertList;
        readonly Graph oppoMap;

        

        public Opponent(int _id, ref Graph _graph)
        {
            opponentScore = 0;
            id = _id;
            //vertList = _vertices;
            oppoMap = _graph;
            opponentCarts = 45;
            DrawTicket();
        }

        public Opponent()
        {
            
        }

        public void DrawTicket()
        {
            Random rnd = new();
            bool condition = false;               //Warunek sprawdzający czy wylosowane miasto jako meta nie koliduje z warunkami wyszukiwania
            start = rnd.Next(oppoMap.Vertices.Count);
            while (condition != true)
            {
                end = rnd.Next(oppoMap.Vertices.Count);
                if (!oppoMap.Vertices[start].CheckConnection(end) && start != end)
                {
                    condition = true;
                    oppoMap.Droga(start, end, 0);
                    tempScore = oppoMap.len;
                }
            }
            CheckRealisation(start, end, id);
        }

        List<string> cities = new();

        public (int,int,int,int,bool) MakeMove()
        {
            oppoMap.Droga(start, end, id);
            if (oppoMap.len > 2000) DrawTicket();
            cities = oppoMap.Cities();
            for (int i = 0; i < cities.Count - 1; i++)
            {
                idx = oppoMap.Vertices.IndexOf(oppoMap.Vertices.Where(v => v.name == cities[i]).FirstOrDefault());
                nextidx = oppoMap.Vertices.IndexOf(oppoMap.Vertices.Where(v => v.name == cities[i + 1]).FirstOrDefault());
                int cost = oppoMap.Vertices[idx].distances[oppoMap.Vertices[idx].connections.IndexOf(nextidx)];
                if (oppoMap.Vertices[idx].owner[oppoMap.Vertices[idx].connections.IndexOf(nextidx)] == id) continue;
                if (opponentCarts >= cost)
                {
                    oppoMap.Vertices[idx].owner[map.Vertices[idx].connections.IndexOf(nextidx)] = id;
                    oppoMap.Vertices[nextidx].owner[map.Vertices[nextidx].connections.IndexOf(idx)] = id;
                    opponentCarts -= cost;
                    switch (cost)
                    {
                        case 1:
                            opponentScore++;
                            break;
                        case 2:
                            opponentScore += 2;
                            break;
                        case 3:
                            opponentScore += 4;
                            break;
                        case 4:
                            opponentScore += 7;
                            break;
                        case 5:
                            opponentScore += 10;
                            break;
                        case 6:
                            opponentScore += 15;
                            break;

                    }
                    if (oppoMap.Vertices[idx].owner[oppoMap.Vertices[idx].connections.IndexOf(nextidx)] == 1)
                        oppoMap.Droga(start, end, 2, idx, nextidx);
                    else
                    {
                        oppoMap.Vertices[idx].owner[map.Vertices[idx].connections.IndexOf(nextidx)] = 2;
                        oppoMap.Vertices[nextidx].owner[map.Vertices[nextidx].connections.IndexOf(idx)] = 2;
                    }
                    CheckRealisation(start, end, id);
                    if (opponentCarts < 6)
                    {
                        endgame = true;
                        oppoMap.Clear();
                    }
                    DisableButton(idx, nextidx,2);
                    break;
                }
            }
            return (opponentScore, opponentCarts, idx, nextidx, endgame);
        }


        void CheckRealisation(int start, int meta, int owner)
        {
            oppoMap.Droga(meta, start, owner);
            if (oppoMap.IsConnected(start, meta, owner))
            {
                opponentScore += tempScore;
                DrawTicket();
            }
        }

    }
}
