using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class SeparateChainingHashST<Key, Value> where Key : IComparable<Key>
    {
        private int N;
        private int M;
        private SequentialSearchST<Key, Value>[] st;

        public SeparateChainingHashST()
            : this(997) { }

        public SeparateChainingHashST(int M)
        {
            this.M = M;
            st = new SequentialSearchST<Key, Value>[M];
            for (int i = 0; i < M; i++)
            {
                st[i] = new SequentialSearchST<Key, Value>();
            }
        }

        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }

        public Value Get(Key key)
        {
            return st[Hash(key)].Get(key);
        }

        public void Put(Key key, Value value)
        {
            st[Hash(key)].Put(key, value);
        }
    }
}
