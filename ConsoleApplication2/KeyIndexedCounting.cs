using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class KeyIndexedCounting
    {
        public class Item
        {
            public int Key;
            public String Name;
        }

        public static void sort(String[] a, int W)
        {
            int N = a.Length;
            int R = 256;
            String[] aux = new String[N];

            for (int d = W - 1; d >= 0; d--)
            {
                int[] count = new int[R + 1];
                for (int i = 0; i < N; i++)
                {
                    count[a[i][d] + 1]++;
                }
                for (int i = 0; i < R; i++)
                {
                    count[i + 1] += count[i];
                }
                for (int i = 0; i < a.Length; i++)
                    aux[count[a[i][d]]++] = a[i];
                for (int i = 0; i < a.Length; i++)
                    a[i] = aux[i];
            }
        }

        public List<Item> Sort(List<Item> items, int R)
        {
            int N = items.Count;
            var count = new int[R + 1];
            foreach(var item in items)
            {
                count[item.Key + 1]++;
            }
            for (int i = 0; i < R; i++)
            {
                count[i + 1] += count[i];
            }
            List<Item> aux = new List<Item>();
            for (int i = 0; i < items.Count; i++)
            {
                aux[count[items[i].Key]++] = items[i];
            }
            return aux;
        }
    }
}
