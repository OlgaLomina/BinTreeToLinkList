using System;
using System.Collections.Generic;
using System.Linq;

//4.4 Give n a binary tree, design an algorithm which creates a linked list of all the nodes at each depth
//(e.g. , if you have a tree with depth D, you'll have D linked lists).

namespace BinTreeToLinkList
{
    public class Node<T>
    {
        public Node<T> next;
        public T data;
        
        public Node()
        {
            next = null;
        }
        public Node(T value)
        {
            next = null;
            data = value;
        }
    }

 
    public class TreeNode
    {
        public TreeNode left, right;
        public int data;

        public TreeNode()
        {
            left = right = null;
        }
        public TreeNode(int value)
        {
            left = right = null;
            data = value;
        }
    }
   
    public class MyBST
    {
        public TreeNode root;

        public MyBST()
        {
            root = null;
        }

        List<Node<int>> list = new List<Node<int>>();

        public void BinTreeToLinkList(TreeNode root)
        {
            if (root == null) return;

            //<Node<int>> list = new List<Node<int>>();

            Queue<TreeNode> q = new Queue<TreeNode>();
            int levelNodes = 0;

            q.Enqueue(root);
            while (q.Count() > 0)
            {
                levelNodes = q.Count();
                Node<int> head = null;
                Node<int> curr = null;
                while (levelNodes > 0)
                {
                    TreeNode tnode = q.Dequeue();
                    Node<int> lnode = new Node<int>(tnode.data);
                    if (head == null)
                    {
                        head = lnode;
                        curr = lnode;
                    }
                    else
                    {
                        curr.next = lnode;
                        curr = curr.next;
                    }
                    if (tnode.left != null) q.Enqueue(tnode.left);
                    if (tnode.right != null) q.Enqueue(tnode.right);
                    levelNodes--;
                }
                list.Add(head);
            }
            PrintList(list);
        }

        public void PrintList(List<Node<int>> list)
        {
            if (list.Count() == 0)
            { Console.WriteLine("There is no elements"); }
            else
            {
                foreach (Node<int> node in list)
                {
                    PrintNode(node);
                }
            }
        }

        public void PrintNode(Node<int> head)
        {
            Node<int> cur = head;
            if (cur == null)
            { return; }
            else
            {
                while (cur.next != null)
                {
                    Console.WriteLine(cur.data);
                    cur = cur.next;
                }
                Console.WriteLine(cur.data);
                Console.WriteLine("-----------");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(7);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            root.left.left.left = new TreeNode(1);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(8);

            MyBST bt = new MyBST();
            bt.root = root;

            bt.BinTreeToLinkList(root);
        }
    }
}
