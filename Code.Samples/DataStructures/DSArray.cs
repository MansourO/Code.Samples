using Code.Samples.Helpers.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Samples.DataStructures.Samples
{
    public class DSArray : IRunner
    {
        public int length;
        private Object[] data;

        public DSArray()
        {
            this.length = 0;
            this.data = new object[1];
        }

        //Get Item
        public Object get(int index)
        {
            return data[index];
        }

        //pushing item at last index
        public Object[] push(Object item)
        {
            if(this.data.Length == this.length)
            {
                Object[] temp = new object[this.length]; // creates a temp array
                Array.Copy(this.data, temp, length); //copies all data to temp array
                this.data = new object[length + 1]; //increases size of temp array
                Array.Copy(temp, this.data, length);
            }

            this.data[this.length] = item; //inserts item into last index
            this.length++;
            return this.data;
        }

        public Object pop()
        {
            Object popped = this.data[this.length - 1];
            this.data[this.length - 1] = null;
            this.length--;
            return popped;
        }

        public Object delete(int index)
        {
            Object itemToDelete = data[index];
            shiftItems(index);
            return itemToDelete;
        }

        private void shiftItems(int index)
        {
            for(int i = index; i < length-1; i++)
            {
                data[i] = data[i + 1];
            }

            data[length - 1] = null;
            length--;
        }

        public void Run()
        {
            Console.WriteLine("**DS Array Implementation**");

            this.push("Hello World");
            this.push("World");
            this.push("!");

            for(int i = 0; i < this.length; i++)
            {
                Console.WriteLine(this.get(i));
            }

            this.delete(1);

            for (int i = 0; i < this.length; i++)
            {
                Console.WriteLine(this.get(i));
            }


            Console.WriteLine("**************************************");


        }
    }
}

