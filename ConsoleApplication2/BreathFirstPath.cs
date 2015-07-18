using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class BreathFirstPath
    {
        private Graph G;
        private int s;
        private int[] edgeTo;
        private bool[] marked;

        public BreathFirstPath(Graph G, int s)
        {
            this.G = G;
            this.s = s;
            this.edgeTo = new int[G.V];
            this.marked = new bool[G.V];
            Bfs(G, s);
        }

        private void Bfs(Graph G, int s){
            var queue = new Queue<int>();
            queue.Enqueue(s);
            while(queue.Count!=0){
                var v = queue.Dequeue();
                if (!marked[v])
                {
		            marked[v] = true;
                    foreach(var w in G.Adj[v]){
                        edgeTo[w] = v;
                        queue.Enqueue(w);
                    }
                }
            }
        }
    }
}
