using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class BinarySearch<Key, Value> 
        where Key : IComparable<Key>
        where Value : class
    {
        private Key[] _keys;
        private Value[] _values;
        private int N = 0;

        public BinarySearch(int capacity)
        {
            _keys = new Key[capacity];
            _values = new Value[capacity];
        }

        public int Rank(Key key, int lo, int hi)
        {
            if (lo > hi) return lo;
            var mid = lo + ((hi - lo) / 2);
            if(mid < N && _keys[mid].CompareTo(key) < 0){
                return Rank(key, lo, mid - 1);
            }
            if (mid > N || _keys[mid].CompareTo(key) > 0)
            {
                return Rank(key, mid+1, hi);
            }
            return mid;
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        public void Put(Key key, Value value)
        {
            var j = Rank(key, 0, N - 1);
            if (j < N && _keys[j].Equals(key))
            {
                _values[j] = value;
            }
            else
            {
                for (var k = N; k > j; k--)
                {
                    _keys[k] = _keys[k - 1];
                    _values[k] = _values[k - 1];
                }
                _keys[j] = key;
                _values[j] = value;
                N++;
            }

        }

        public Value Get(Key key)
        {
            if (IsEmpty()) return null;
            var j = Rank(key, 0, N-1);
            if (j < N && _keys[j].Equals(key))
            {
                return _values[j];
            }
            return null;
        }
    }
}
