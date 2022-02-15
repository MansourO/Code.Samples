using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Samples
{
    public class BinaryTree
    {
        public TreeNode _root { get; set; }
        public TreeNode Search(int value)
        {
            return Search(_root, value);
        }

        public TreeNode Search(TreeNode node, int value)
        {
            if (node == null)
                return null;

            if (node.Value == value)
            {
                return node;
            }
            else
            {
                if (value < node.Value)
                {
                    return Search(node.Left, value);
                }
                else
                {
                    return Search(node.Right, value);
                }
            }
        }

        public void Insert(int value)
        {
            if (_root == null)
            {
                _root = new TreeNode(value);
            }
            else
            {
                InsertNewNode(_root, value);
            }
        }

        public void InsertNewNode(TreeNode node, int value)
        {
            if (node.Left == null || node.Right == null)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode(value);
                }
                else
                {
                    node.Right = new TreeNode(value);
                }
            }
            else
            {
                if (node.Left != null)
                {
                    InsertNewNode(node.Left, value);
                }
                else
                {
                    InsertNewNode(node.Right, value);
                }
            }
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(_root);
        }

        private void InOrderTraversal(TreeNode node)
        {
            if (node == null)
                return;

            InOrderTraversal(node.Left);
            Console.WriteLine(node.Value);
            InOrderTraversal(node.Right);
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(_root);
        }

        public void PreOrderTraversal(TreeNode node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.Value);
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);


        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(_root);
        }

        public void PostOrderTraversal(TreeNode node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.Value);
            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
        }

        public void PrintNode(TreeNode node)
        {
            if (node.IsFull())
            {
                Console.WriteLine($"L:{node.Left.Value} | V:{node.Value} | R:{node.Right.Value}");
            }
            else
            {
                if (node.Left != null)
                    Console.WriteLine($"L:{node.Left.Value}");
                if (node.Value > 0)
                    Console.WriteLine($"V:{node.Value}");
                if (node.Right != null)
                    Console.WriteLine("R:{node.Right.Value}");
            }
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
        }

        public bool IsFull()
        {
            return (this.Left != null && this.Right != null && Value > 0);
        }
    }
}
