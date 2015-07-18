using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class DephFirstSearch
    {
        private bool[] marked;
        private int count;

        public DephFirstSearch(Graph G, int s)
        {
            marked = new bool[G.V];
            count = 0;
            Dfs(G, s);
        }

        private void Dfs(Graph G, int s)
        {
            marked[s] = true;
            count++;
            foreach(var w in G.Adj[s]){
                if(!marked[w])
                    Dfs(G, s);
            }
        }
    }
}
