using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class CC
    {
        private bool[] marked;
        private int[] id;
        private int count;
        private Queue<int> pre;
        private Queue<int> pos;
        private Stack<int> reversePost;


        public CC(Graph G)
        {
            marked = new bool[G.V];
            id = new int[G.V];
            count = 0;
            for (var i = 0; i < G.V; i++)
            {
                if (!marked[i])
                {
                    Dfs(G, i);
                    count++;
                }
            }
        }

        private void Dfs(Graph G, int v)
        {
            pre.Enqueue(v);
            marked[v] = true;
            id[v] = count;
            foreach(var w in G.Adj[v])
            {
                if (!marked[w])
                {
                    Dfs(G, w);
                }
            }
            pos.Enqueue(v);
            reversePost.Push(v);
        }
    }
}
