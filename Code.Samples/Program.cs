﻿// See https://aka.ms/new-console-template for more information
using Code.Samples;
using Code.Samples.DataStructures;
using Code.Samples.DataStructures.Samples;
using Code.Samples.Helpers.Runners;

List<IRunner> runners = new List<IRunner>()
{
    //new DSArray(),
    //new DSHashTable(2),
    //new DSSinglyLinkedList(10),
    new DSDoublyLinkedList(11)
};


foreach(var runner in runners)
{
    runner.Run();
    Console.WriteLine();
}
