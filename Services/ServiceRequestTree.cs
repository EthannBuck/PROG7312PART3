using System;
using System.Collections.Generic;

namespace WindowsFormApp1
{
    // AVL Tree to store ServiceRequest objects sorted by RequestId
    public class ServiceRequestTree
    {
        // Node class representing each element in the tree
        private class Node
        {
            public ServiceRequest Data;
            public Node Left, Right;
            public int Height;

            public Node(ServiceRequest data)
            {
                Data = data;
                Height = 1;
            }
        }

        private Node root;

        // Get height of a node (0 if null)
        private int Height(Node n) => n == null ? 0 : n.Height;

        // Calculate balance factor (left subtree height - right subtree height)
        private int Balance(Node n) => Height(n.Left) - Height(n.Right);

        // Right rotation for balancing
        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

        // Left rotation for balancing
        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }

        // Recursive insertion with AVL balancing
        private Node Insert(Node node, ServiceRequest data)
        {
            if (node == null) return new Node(data);

            if (data.RequestId < node.Data.RequestId)
                node.Left = Insert(node.Left, data);
            else if (data.RequestId > node.Data.RequestId)
                node.Right = Insert(node.Right, data);
            else
                return node; // Duplicate RequestId not allowed

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

            int balance = Balance(node);

            if (balance > 1 && data.RequestId < node.Left.Data.RequestId)
                return RotateRight(node);

            if (balance < -1 && data.RequestId > node.Right.Data.RequestId)
                return RotateLeft(node);

            if (balance > 1 && data.RequestId > node.Left.Data.RequestId)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && data.RequestId < node.Right.Data.RequestId)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        // Public insert method
        public void Insert(ServiceRequest data)
        {
            root = Insert(root, data);
        }

        // Return all requests in ascending order (InOrder traversal)
        public IEnumerable<ServiceRequest> InOrder()
        {
            List<ServiceRequest> list = new List<ServiceRequest>();
            Traverse(root, list);
            return list;
        }

        // Helper for InOrder traversal
        private void Traverse(Node n, List<ServiceRequest> list)
        {
            if (n == null) return;
            Traverse(n.Left, list);
            list.Add(n.Data);
            Traverse(n.Right, list);
        }
    }
}
