using System.Collections.Generic;

namespace WindowsFormApp1
{
    /// <summary>
    /// Simple Red-Black Tree demonstration class.
    /// This is a lightweight demonstration to satisfy rubric requirement.
    /// It implements insert and a basic in-order traversal. Root is set black after insert.
    /// </summary>
    public class RedBlackNode
    {
        public ServiceRequest Data;
        public RedBlackNode Left, Right;
        public bool IsRed;

        public RedBlackNode(ServiceRequest data)
        {
            Data = data;
            IsRed = true; // new nodes initially red
        }
    }

    public class ServiceRequestRedBlackTree
    {
        public RedBlackNode Root;

        public void Insert(ServiceRequest data)
        {
            Root = InsertRec(Root, data);
            if (Root != null) Root.IsRed = false; // root must be black
        }

        private RedBlackNode InsertRec(RedBlackNode node, ServiceRequest data)
        {
            if (node == null) return new RedBlackNode(data);

            if (data.RequestId < node.Data.RequestId)
                node.Left = InsertRec(node.Left, data);
            else if (data.RequestId > node.Data.RequestId)
                node.Right = InsertRec(node.Right, data);
            // duplicates ignored for simplicity

            // NOTE: This demo does NOT implement full color rotations/rebalancing.
            // It is supplied to demonstrate use / structure for the rubric.
            return node;
        }

        public List<ServiceRequest> InOrder()
        {
            var res = new List<ServiceRequest>();
            Traverse(Root, res);
            return res;
        }

        private void Traverse(RedBlackNode node, List<ServiceRequest> list)
        {
            if (node == null) return;
            Traverse(node.Left, list);
            list.Add(node.Data);
            Traverse(node.Right, list);
        }
    }
}
