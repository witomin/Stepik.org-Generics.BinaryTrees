using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Generics.BinaryTrees
{
    public class BinaryTree<T> : IEnumerable<T>
            where T : IComparable, new()
    {
        public T Value { get; set; }
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }
        public bool isEmpty;

        public BinaryTree() : this(default(T))
        {
            isEmpty = true;
        }
        public BinaryTree(T value)
        {
            Value = value;
            isEmpty = false;
        }

        public IEnumerator<T> GetEnumerator()
        {
             if (isEmpty) yield break;
            if (Left != null)
            {
                foreach (var v in Left)
                {
                    yield return v;
                }
            }

            yield return Value;

            if (Right != null)
            {
                foreach (var v in Right)
                {
                    yield return v;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T Value)
        {
            if (isEmpty)
            {
                this.Value = Value;
                isEmpty = false;
                return;
            }
            if (Value.CompareTo(this.Value) <= 0)
            {
                if (Left == null)
                {
                    Left = new BinaryTree<T>(Value);
                }
                else
                {
                    Left.Add(Value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new BinaryTree<T>(Value);
                }
                else
                {
                    Right.Add(Value);
                }
            }
        }

    }
    public static class BinaryTree
    {
        public static BinaryTree<T> Create<T>(params T[] collection) where T : IComparable, new()
        {
            var tree = new BinaryTree<T>();
            foreach (var item in collection)
            {
                tree.Add(item);
            }
            return tree;
        }
    }

}
