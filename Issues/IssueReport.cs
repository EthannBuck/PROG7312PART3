using System;
using System.Collections;
using System.Collections.Generic;

namespace WindowsFormApp1
{
    // Model representing a single issue report
    public class IssueReport
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string MediaPath { get; set; }
        public DateTime SubmittedAt { get; set; }
    }

    // Custom singly-linked list for storing issues
    public class IssueLinkedList : IEnumerable<IssueReport>
    {
        private class Node
        {
            public IssueReport Data;
            public Node Next;
            public Node(IssueReport data) { Data = data; }
        }

        private Node _head;
        private Node _tail;
        public int Count { get; private set; }

        // Add issue at the end of the list
        public void AddLast(IssueReport item)
        {
            var n = new Node(item);
            if (_head == null) _head = _tail = n;
            else { _tail.Next = n; _tail = n; }
            Count++;
        }

        // Remove first issue from the list
        public IssueReport RemoveFirst()
        {
            if (_head == null) throw new InvalidOperationException("List empty");
            var d = _head.Data;
            _head = _head.Next;
            if (_head == null) _tail = null;
            Count--;
            return d;
        }

        public bool IsEmpty => _head == null;

        // Enumerator for foreach iteration
        public IEnumerator<IssueReport> GetEnumerator()
        {
            var cur = _head;
            while (cur != null)
            {
                yield return cur.Data;
                cur = cur.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    // FIFO Queue using linked nodes
    public class IssueQueue
    {
        private class Node
        {
            public IssueReport Data;
            public Node Next;
            public Node(IssueReport d) { Data = d; }
        }

        private Node _front, _back;
        public int Count { get; private set; }
        public bool IsEmpty => _front == null;

        // Add issue to back of queue
        public void Enqueue(IssueReport item)
        {
            var n = new Node(item);
            if (_back == null) _front = _back = n;
            else { _back.Next = n; _back = n; }
            Count++;
        }

        // Remove issue from front of queue
        public IssueReport Dequeue()
        {
            if (_front == null) throw new InvalidOperationException("Queue empty");
            var d = _front.Data;
            _front = _front.Next;
            if (_front == null) _back = null;
            Count--;
            return d;
        }

        // Peek at front issue without removing
        public IssueReport Peek()
        {
            if (_front == null) throw new InvalidOperationException("Queue empty");
            return _front.Data;
        }
    }

    // Binary Search Tree keyed by category, each node has linked list of issues
    public class CategoryIndexBST
    {
        private class Node
        {
            public string Key; // category in lowercase
            public IssueLinkedList Bucket;
            public Node Left, Right;
            public Node(string key) { Key = key; Bucket = new IssueLinkedList(); }
        }

        private Node _root;

        // Add issue to BST under its category
        public void Add(IssueReport issue)
        {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            var key = (issue.Category ?? string.Empty).Trim().ToLowerInvariant();
            _root = Insert(_root, key, issue);
        }

        private Node Insert(Node node, string key, IssueReport issue)
        {
            if (node == null)
            {
                var created = new Node(key);
                created.Bucket.AddLast(issue);
                return created;
            }

            int cmp = string.Compare(key, node.Key, StringComparison.Ordinal);
            if (cmp < 0) node.Left = Insert(node.Left, key, issue);
            else if (cmp > 0) node.Right = Insert(node.Right, key, issue);
            else node.Bucket.AddLast(issue);
            return node;
        }

        // Retrieve all issues in a given category
        public IssueLinkedList Get(string category)
        {
            var key = (category ?? string.Empty).Trim().ToLowerInvariant();
            var n = Find(_root, key);
            return n?.Bucket ?? new IssueLinkedList();
        }

        private Node Find(Node node, string key)
        {
            while (node != null)
            {
                int cmp = string.Compare(key, node.Key, StringComparison.Ordinal);
                if (cmp < 0) node = node.Left;
                else if (cmp > 0) node = node.Right;
                else return node;
            }
            return null;
        }

        // Enumerate categories in sorted order (for dropdowns)
        public IEnumerable<string> CategoriesInOrder()
        {
            foreach (var k in InOrder(_root)) yield return k;
        }

        private IEnumerable<string> InOrder(Node node)
        {
            if (node == null) yield break;
            foreach (var k in InOrder(node.Left)) yield return k;
            yield return node.Key;
            foreach (var k in InOrder(node.Right)) yield return k;
        }
    }

    // Static repository using linked list, queue, and BST for issues
    public static class IssueRepository
    {
        public static readonly IssueLinkedList AllIssues = new IssueLinkedList();
        public static readonly IssueQueue PendingQueue = new IssueQueue();
        public static readonly CategoryIndexBST ByCategory = new CategoryIndexBST();

        // Add issue to all internal data structures
        public static void Add(IssueReport issue)
        {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            if (issue.SubmittedAt == default) issue.SubmittedAt = DateTime.Now;

            AllIssues.AddLast(issue);
            PendingQueue.Enqueue(issue);
            ByCategory.Add(issue);
        }
    }
}
