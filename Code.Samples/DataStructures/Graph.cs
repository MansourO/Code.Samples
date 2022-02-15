using Code.Samples.Helpers.Runners;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Samples.DataStructures
{

    public class Node<T>
    {
        private T value;
        private NodeList<T> neighbors = null;

        public Node() { }
        public Node(T value) : this(value, null) { }
        public Node(T value,  NodeList<T> neighbors)
        {
            this.value = value;
            this.neighbors = neighbors;
        }

        public T Value { get; set; }
        protected NodeList<T> Neighbors { get; set; }
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }
        public NodeList(int initialSize)
        {
            for(int i = 0; i < initialSize; i++)
            {
                base.Items.Add(default(Node<T>));
            }
        }

        public Node<T> FindByValue(T value)
        {
            foreach(Node<T> node in Items)
            {
                if(node.Value != null && node.Value.Equals(value))
                {
                    return node;
                }
            }

            return null;
        }
    }

    public class GraphNode<T> : Node<T>
    {
        private List<int> costs;

        public GraphNode() : base() { }
        public GraphNode(T value) : base(value) { }
        public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }

        new public NodeList<T> Neighbors
        {
            get
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>();

                return base.Neighbors;
            }
        }

        public List<int> Costs
        {
            get
            {
                if (costs == null)
                    costs = new List<int>();

                return costs;
            }
        }
    }

    public class Graph<T> : IEnumerable<Node<T>>, IRunner
    {
        private NodeList<T> nodeSet;
        public NodeList<T> Nodes { get; }

        public Graph() : this(null) { }
        public Graph(NodeList<T> nodeSet)
        {
            if(nodeSet == null)
            {
                this.nodeSet = new NodeList<T>();
            }
            else
            {
                this.nodeSet = nodeSet;
            }
        }

        public void AddNode(GraphNode<T> node)
        {
            nodeSet.Add(node);
        }

        public void AddNode(T value)
        {
            nodeSet.Add(new GraphNode<T>(value));
        }

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);
        }

        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            AddDirectedEdge(from, to, cost);

            to.Neighbors.Add(to);
            to.Costs.Add(cost);
        }

        public bool Contains(T value)
        {
            return nodeSet.FindByValue(value) != null;
        }

        public bool Remove(T value)
        {
            GraphNode<T> nodeToRemove = (GraphNode<T>)nodeSet.FindByValue(value);
            if (nodeToRemove != null)
                return false;

            nodeSet.Remove(nodeToRemove);

            foreach(GraphNode<T> gnode in nodeSet)
            {
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if(index != -1)
                {
                    gnode.Neighbors.RemoveAt(index);
                    gnode.Costs.RemoveAt(index);
                }
            }

            return true;
        }

        public int Count
        {
            get { return nodeSet.Count; }
        }


        public IEnumerator<Node<T>> GetEnumerator()
        {
            return nodeSet.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Run()
        {
            Console.WriteLine("Graph Run");

            Graph<string> web = new Graph<string>();
            web.AddNode("Privacy.aspx");
            web.AddNode("People.aspx");
            web.AddNode("About.aspx");
            web.AddNode("Index.aspx");
            web.AddNode("Products.aspx");
            web.AddNode("Contact.aspx");

            var people = new GraphNode<string>("People.aspx");
            var privacy = new GraphNode<string>("Privacy.aspx");
            var index = new GraphNode<string>("Index.aspx");
            var about = new GraphNode<string>("About.aspx");
            var contact = new GraphNode<string>("Contact.aspx");
            var products = new GraphNode<string>("Products.aspx");

            web.AddDirectedEdge(people, privacy, 1);  // People -> Privacy
            web.AddDirectedEdge(privacy, index, 1);    // Privacy -> Index
            web.AddDirectedEdge(privacy, about, 1);    // Privacy -> About
            web.AddDirectedEdge(about, privacy, 1);    // About -> Privacy
            web.AddDirectedEdge(about, people, 1);    // About -> People
            web.AddDirectedEdge(about, contact, 1);   // About -> Contact
            web.AddDirectedEdge(index, about, 1);      // Index -> About
            web.AddDirectedEdge(index, contact, 1);   // Index -> Contacts
            web.AddDirectedEdge(index, products, 1);  // Index -> Products
            web.AddDirectedEdge(products, index, 1);  // Products -> Index
            web.AddDirectedEdge(products, people, 1);// Products -> People


            Console.WriteLine(web.Contains("Privacy.aspx"));
            Console.WriteLine(web.Contains("Products.aspx"));

          
        }
    }
}
