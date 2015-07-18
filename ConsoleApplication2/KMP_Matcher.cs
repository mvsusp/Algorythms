using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class KMP_Matcher
    {
        void match(String T, String P)
        {
            var pi = ComputePrefixFunction(P);
            var q = 0;
            for (int i = 0; i < T.Length; i++)
            {
                while (q > 0 && T[i] != P[q+1])
                    q = pi[q];
                if (T[i]==P[q+1])
                {
                    q++;
                }
                if (q == P.Length)
                {
                    Console.WriteLine(q);
                    q = pi[q];
                }
            }
        }

        int[] ComputePrefixFunction(String P)
        {
            var pi = new int[P.Length];
            pi[0] = 0;

            var k = 0;
            for (int q = 1; q < P.Length; q++)
            {
                while (k > 0 && P[q] != P[k+1])
                    k = pi[k];
                if (P[q] == P[k+1])
                {
                    k++;
                }
                pi[q] = k;
            }
            return pi;
        }
    }
}
