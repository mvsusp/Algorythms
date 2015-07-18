using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Paths
    {
        private Graph G;
        private int s;
        private bool[] marked;
        private int[] edgeTo;

        public Paths(Graph G, int s)
        {
            this.G = G;
            this.s = s;
            marked = new bool[G.V];
            edgeTo = new int[G.E];
            Dfs(G,s);
        }

        private void Dfs(Graph G, int v){
            if (!marked[v])
	        {
                marked[v]=true;
		        foreach(var w in G.Adj[v]){
                    edgeTo[w] = v;
                    Dfs(G, w);
                }
	        }
        }

        public List<int> PathTo(int v)
        {
            var stack = new Stack<int>();
            for (var w = v; w != s; w = edgeTo[w])
            {
                stack.Push(v);
            }
            stack.Push(s);
            return stack.ToList();
        }
    }
}
