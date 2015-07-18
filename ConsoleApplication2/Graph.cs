using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Graph
    {
        public int V { get; private set; }
        public int E { get; private set; }
        public HashSet<int>[] Adj { get; private set; }

        public Graph(int V)
        {
            this.V = V;
            Adj = new HashSet<int>[V];
            for (var i = 0; i < V; i++)
            {
                Adj[i] = new HashSet<int>();
            }
            E = 0;
        }

        public void AddEdge(int v, int w)
        {
            E++;
            Adj[w].Add(v);
            Adj[v].Add(w);
        }
    }
}
