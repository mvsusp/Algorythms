using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class TrieST<Value> where Value : class
    {
        private static int R = 256;
        private Node root;

        class Node
        {
            public Value val;
            public Node[] next = new Node[R];
        }

        public Value Get(String key)
        {
            var x = Get(root, key, 0);
            if (x == null) return null;
            return x.val;
        }

        private Node Get(Node x, String key, int d)
        {
            if (x==null)
            {
                return null;
            }
            if (key.Length==d)
            {
                return x;
            }
            var c = key[d];
            return Get(x.next[c], key, d++);
        }

        public void Put(String key, Value val)
        {
            root = Put(root, key, val, 0);
        }

        private Node Put(Node x, String key, Value val, int d){
            if (x == null) x = new Node();
            if (d == key.Length)
            {
                x.val = val;
                return x;
            }
            char c = key[d];
            x.next[c] = Put(x.next[c], key, val, d++);
            return x;
        }

        public IEnumerable<String> Keys()
        {
            return KeysWithPrefix("");
        }

        public IEnumerable<String> KeysWithPrefix(String pre)
        {
            var q = new Queue<String>();
            Collect(Get(root, pre, 0), pre, q);
            return q;
        }

        private void Collect(Node x, String pre, Queue<String> q)
        {
            if (x == null) return;
            if (x.val != null) q.Enqueue(pre);
            for(var c = 0; c < R; c++)
            {
                Collect(x.next[c], pre + c, q);
            }
        }
    }
}
