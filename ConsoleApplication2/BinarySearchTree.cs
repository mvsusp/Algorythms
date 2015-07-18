using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class BinarySearchTree<Key, Value> where Key : class, IComparable<Key> where Value : class
    {
        private Node _root;

        public class Node
        {
            public Key Key;
            public Value Value;
            public Node Left, Right;
            public int N;
            public Node(Key key, Value value, int n)
            {
                Key = key; Value = value; N = n;
            }
        }

        public IEnumerable<Key> Keys()
        {
            return Keys(Min(), Max());
        }

        public IEnumerable<Key> Keys(Key lo, Key hi)
        {
            var keys = new List<Key>();
            Keys(_root, keys, lo, hi);
            return keys;
        }

        private void Keys(Node node, List<Key> keys, 
            Key hi, Key lo)
        {
            if (node == null)
            {
                return;
            }
            if (node.Key.CompareTo(lo) > 0)
            {
                Keys(node.Left, keys, hi, lo);
            }
            if (node.Key.CompareTo(lo) >= 0 && 
                node.Key.CompareTo(hi) >= 0)
            {
                keys.Add(node.Key);
            }
            if (node.Key.CompareTo(hi) > 0)
            {
                Keys(node.Right, keys, hi, lo);
            }
        }

        public Key Max()
        {
            return Max(_root).Key;
        }

        private Node Max(Node node)
        {
            if (node.Right == null) return node;
            return Max(node.Right);
        }

        public int Rank(Key key)
        {
            return Rank(_root, key);
        }

        private int Rank(Node node, Key key)
        {
            if (node == null) return 0;
            var cmp = node.Key.CompareTo(key);
            if (cmp == 0)
            {
                return Size(node.Left);
            }
            if (cmp > 0)
            {
                return Rank(node.Left, key);
            }
            return Size(node) + Rank(node.Right, key);
        }

        public Key Select(int k)
        {
            return Select(_root, k).Key;
        }

        private Node Select(Node node, int k)
        {
            if (node == null) return null;
            var t = Size(node.Left);
            if (t == k) return node;
            if (t < k) return Select(node.Right, k - 1 - t);
            return Select(node.Left, k);
        }

        public int Size()
        {
            return Size(_root);
        }

        public int Size(Node node)
        {
            if(node == null) return 0;
            return node.N;
        }

        public Value Get(Key key)
        {
            return Get(key, _root);
        }

        private Value Get(Key key, Node node)
        {
            if (node == null) return null;
            if (node.Key.Equals(key))
            {
                return node.Value;
            }
            if (node.Key.CompareTo(key) < 0)
            {
                return Get(key, node.Left);
            }
            return Get(key, node.Right);
        }

        public void Put(Key key, Value value)
        {
            _root = Put(key, value, _root);
        }

        private Node Put(Key key, Value value, Node node)
        {
            if (node == null)
            {
                node = new Node(key, value, 1);
            }
            var cmp = node.Key.CompareTo(key);
            
            if(cmp == 0)
            {
                node.Value = value;
            }
            else if (cmp > 0)
            {
                Put(key, value, node.Left);
            }
            else
            {
                Put(key, value, node.Right);
            }
            node.N = Size(node.Left) + 1 + Size(node.Right);
            return node;
        }

        public Key Min()
        {
            return Min(_root).Key;
        }

        private Node Min(Node node)
        {
            if (node.Left == null) return node;
            return Min(node.Left);
        }

        public Key Floor(Key key)
        {
            var floor = Floor(key, _root);
            if (floor == null) return null;
            return floor.Key;
        }

        private Node Floor(Key key, Node node)
        {
            if(node == null) return null;
            var cmp = key.CompareTo(node.Key);
            if(cmp == 0) return node;
            if(cmp < 0) return Floor(key, node.Left);
            Node t = Floor(key, node.Right);
            if(t != null)return t;
            return node;
        }

        public void DeleteMin()
        {
            _root = DeleteMin(_root);
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            node.Left = DeleteMin(node.Left);
            node.N = Size(node.Left) + 1 + Size(node.Right);
            return node;
        }

        public void Delete(Key key)
        {
            _root = Delete(key, _root);
        }

        private Node Delete(Key key, Node node)
        {
            if (node == null) return null;
            var cmp = key.CompareTo(node.Key);
            if (cmp < 0) node.Left = Delete(key, node.Left);
            if (cmp > 0) node.Right = Delete(key, node.Right);
            else
            {
                if (node.Right == null) return node.Left;
                if (node.Left == null) return node.Right;
                var t = node;
                node.Right = DeleteMin(node.Right);
                node.Left = t.Left;
            }
            node.N = Size(node.Left) + 1 + Size(node.Right);
            return node;
        }
    }
}
