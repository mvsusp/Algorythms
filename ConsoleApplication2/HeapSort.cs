using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Heap<T> where T : IComparable
    {
        public void Sort(T[] a){
            var N = a.Length;
            for (int i = N/2; i >= 1; i--)
            {
                Sink(a, i, N);
            }
            while (N>1)
            {
                Exch(a, 1, N--);
                Sink(a, 1, N);
            }
        }

        private void Sink(T[] a, int node, int root)
        {
            while (node < 2 * a.Length)
            {
                var j = 2 * node;
                if(j<a.Length && Less(a[j],a[j+1])){j++;}

                if (!Less(a[node], a[j])) break;

                Exch(a, node, j);
                node = j;    
            }
        }

        private void Exch(T[] a, int x, int y)
        {

        }

        private bool Less(T x, T y)
        {
            return x.CompareTo(y) < 0;
        }
    }
}
