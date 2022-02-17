using Code.Samples.Helpers.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Samples.DataStructures
{
    public class DSGraph : IRunner
    {
        private Dictionary<int, List<int>> adjacentList;
        private int numberOfNodes;

        public DSGraph()
        {
            adjacentList = new Dictionary<int, List<int>>();
            numberOfNodes = 0;
        }

        public void addVertex(int value)
        {
            adjacentList.Add(value, new List<int>());
            numberOfNodes++;
        }

        public void addEdge(int value1, int value2)
        {
            adjacentList[value1].Add(value2);
            adjacentList[value2].Add(value1);
        }

        public void showConnections()
        {
            foreach(var item in adjacentList)
            {
                List<int> nodeConnections = adjacentList[item.Key];
                StringBuilder connections = new StringBuilder();
                foreach(int edge in nodeConnections)
                {
                    connections.Append(edge).Append(" ");
                }

                Console.WriteLine($"{item.Key} ---> {connections}");
            }
        }

        public void Run()
        {
            this.addVertex(0);
            this.addVertex(1);
            this.addVertex(2);
            this.addVertex(3);
            this.addVertex(4);
            this.addVertex(5);
            this.addVertex(6);
            this.addEdge(3, 1);
            this.addEdge(3, 4);
            this.addEdge(4, 2);
            this.addEdge(4, 5);
            this.addEdge(1, 2);
            this.addEdge(1, 0);
            this.addEdge(0, 2);
            this.addEdge(6, 5);
            this.showConnections();
        }
    }
}
