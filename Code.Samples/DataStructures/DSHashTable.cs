using Code.Samples.Helpers.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Samples.DataStructures.Samples
{
    public class DSHashTable : IRunner
    {
        private int length;
        private Nodes[] data;

        public DSHashTable(int size)
        {
            this.length = size;
            this.data = new Nodes[size];
        }

        private int hash(string key)
        {
            int hash = 0;
            for(int i = 0; i < key.Length; i++)
            {
                hash = (hash + (int)key[i] * i) % this.length;
            }

            return hash;
        }

        public void set(string key, int value)
        {
            int index = hash(key);
            if(this.data[index] == null)
            {
                this.data[index] = new Nodes();
            }
            this.data[index].Add(new Node(key, value));
        }

        public int get(string key)
        {
            int index = hash(key);
            if(this.data[index] == null)
            {
                return 0;
            }
            foreach(var node in this.data[index])
            {
                if(node.Key.Equals(key))
                {
                    return node.Value;
                }
            }
            return 0;
        }

        public List<string> keys()
        {
            List<string> result = new List<string>();
            for(int i = 0; i < this.data.Length; i++)
            {
                if(this.data[i] != null)
                {
                    for(int j = 0; j < length; j++)
                    {
                        result.Add(this.data[i][j].Key);
                    }
                }
            }
            return result;
        }

        public void Run()
        {
            Console.WriteLine("**DS Array Implementation**");

            this.set("grapes", 1000);
            this.set("grapes", 51);
            this.set("apples", 54);

            Console.WriteLine(this.get("apples"));

            foreach (var k in this.keys())
            {
                Console.WriteLine(k);
            }

            Console.WriteLine("**************************************");
        }
    }

    public class Nodes : List<Node> { }
    public class Node
    {
        public string Key { get; set; }
        public int Value { get; set; }
        public Node(string key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
