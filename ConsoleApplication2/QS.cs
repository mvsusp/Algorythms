using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class QS<Item> where Item : IComparable<Item>
    {
        public void Sort(Item[] items)
        {
            Randomize(items);
            Sort(items, 0, items.Length-1);
        }

        private void Randomize(Item[] items)
        {
            throw new NotImplementedException();
        }

        private void Sort(Item[] items, int lo, int hi)
        {
            if (lo >= hi) return;
            var j = Partition(items, lo, hi);
            Sort(items, lo, j - 1);
            Sort(items, j + 1, hi);
        }

        private int Partition(Item[] items, int lo, int hi)
        {
            int i = lo, j = hi + 1;
            Item v = items[lo];
            while (true)
            {
                if (v.CompareTo(items[++i]) > 0) if(i==hi) break;
                if (v.CompareTo(items[--j]) < 0) if(lo==j) break;
                if (i >= j) break;
                Exch(items, i, j);
            }
            Exch(items, j, lo);
            return lo;
        }

        private void Exch(Item[] items, int a, int b)
        {

        }
    }
}
