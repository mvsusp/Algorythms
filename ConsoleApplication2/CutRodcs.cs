using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class CutRodcs
    {
        int Memoized_CutRod(int[] p, int n)
        {
            var r = new int[n];
            for (int i = 0; i < n; i++)
            {
                r[i] = int.MinValue;
            }
            return Memoized_CutRod(p, n, r);
        }

        private int Memoized_CutRod(int[] p, int n, int[] r)
        {
            if (r[n]>=0)
            {
                return r[n];
            }

            var max = p[n];
            for (int i = 0; i < n; i++)
            {
                max = Math.Max(max, p[i] + Memoized_CutRod(p, n - i, r));
            }
            r[n] = max;
            return max;
        }

        private int RecursiveMatrixChain(int[] p, int i, int j)
        {
            var m = new int[i, j];
            for (int x = 0; x < i; x++)
            {
                for (int y = 0; y < j; y++)
                {
                    m[x, y] = int.MaxValue;
                }
            }
            return RecursiveMatrixChain(p, i, j, m);
        }
        

        private int RecursiveMatrixChain(int[] p, int i, int j, int[,] m)
        {
            if (i==j)
            {
                return 0;
            }

            if (m[i,j]!=int.MaxValue)
            {
                return m[i, j];
            }

            var max = int.MaxValue;
            for (int k = i; k < j; k++)
            {
                var q = RecursiveMatrixChain(p, i, k, m)
                    + RecursiveMatrixChain(p, k + 1, j, m)
                    + p[i - 1] * p[k] * p[j];
                if (q < max)
                {
                    max = q;
                }
            }
            m[i, j] = max;
            return m[i, j];
        }
    }
}
