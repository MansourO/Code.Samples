using Code.Samples.Helpers.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Samples.DataStructures
{
    public class DSBinarySearchTree : IRunner
    {
        public TreeNode root;
        int COUNT = 5;
        public DSBinarySearchTree()
        {
            this.root = null;
        }

        public void insert(int value)
        {
            TreeNode newNode = new TreeNode(value);
            if(this.root == null)
            {
                this.root = newNode;
                return;
            }

            TreeNode currentNode = this.root;
            while(true)
            {
                if(currentNode.Value > value)
                {
                    if(currentNode.Left == null)
                    {
                        currentNode.Left = new TreeNode(value);
                        return;
                    }
                    currentNode = currentNode.Left;
                }
                else
                {
                    if(currentNode.Right == null)
                    {
                        currentNode.Right = new TreeNode(value);
                        return;
                    }
                    currentNode = currentNode.Right;

                }
            }
        }

        public TreeNode lookup(int value)
        {
            if(root == null)
            {
                return null;
            }

            TreeNode currentNode = this.root;
            while(currentNode != null)
            {
                if(value < currentNode.Value)
                {
                    currentNode = currentNode.Left;
                }
                else if(value > currentNode.Value)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    return currentNode;
                }
            }

            return null;
        }

        public void remove(int value)
        {
            if(root == null)
            {
                return;
            }

            TreeNode nodeToRemove = root;
            TreeNode parentNode = null;

            while(nodeToRemove.Value != value)
            {
                parentNode = nodeToRemove;
                if(value < nodeToRemove.Value)
                {
                    nodeToRemove = nodeToRemove.Left;
                }
                else if(value > nodeToRemove.Value)
                {
                    nodeToRemove = nodeToRemove.Right;
                }
            }

            TreeNode replacementNode = null;
            if(nodeToRemove.Right != null)
            {
                replacementNode = nodeToRemove.Right;
                if(replacementNode.Left == null)
                {
                    replacementNode.Left = nodeToRemove.Left;
                }
                else
                {
                    TreeNode replacementParentNode = nodeToRemove;
                    while(replacementNode.Left != null)
                    {
                        replacementParentNode = replacementNode;
                        replacementNode = replacementNode.Left;
                    }

                    replacementParentNode.Left = null;
                    replacementNode.Left = nodeToRemove.Left;
                    replacementNode.Right = nodeToRemove.Right;
                }
            }
            else if(nodeToRemove.Left != null)
            {
                replacementNode = nodeToRemove.Left;
            }

            if(parentNode == null)
            {
                root = replacementNode;
            }
            else if(parentNode.Left == nodeToRemove)
            {
                parentNode.Left = replacementNode;
            }
            else
            {
                parentNode.Right = replacementNode;
            }
        }

        public void printTree(TreeNode node)
        {
            print2DUtil(root, 0);
        }

        private void print2DUtil(TreeNode node, int space)
        {
            // Base case  
            if (root == null)
                return;

            // Increase distance between levels  
            space += COUNT;

            // Process right child first  
            print2DUtil(root.Right, space);

            // Print current node after space  
            // count  
            Console.Write("\n");
            for (int i = COUNT; i < space; i++)
            {
                Console.Write(" ");
            }
            Console.Write(root.Value + "\n");

            // Process left child  
            print2DUtil(root.Left, space);
        }

        public void Run()
        {
            this.insert(9);
            this.insert(4);
            this.insert(6);
            this.insert(20);
            this.insert(170);
            this.insert(15);
            this.insert(1);

            this.printTree(this.root);
        }
    }

    public class TreeNode
    {
        public TreeNode Left;
        public TreeNode Right;
        public int Value;

        public TreeNode(int value)
        {
            this.Value = value;
        }
    }
}
