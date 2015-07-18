using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class FiniteAutomationMatcher
    {
        bool Match(String T, int[][] trasition, int m)
        {
            var q = 0;
            for (int i = 0; i < T.Length; i++)
            {
                q = trasition[q][T[i]];
                if (q == m)
                    return true;
            }
            return false;
        }
    }
}
