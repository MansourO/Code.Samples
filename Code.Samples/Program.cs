// See https://aka.ms/new-console-template for more information
using Code.Samples;
using Code.Samples.DataStructures;
using Code.Samples.Helpers.Runners;

List<IRunner> runners = new List<IRunner>()
{
    new Graph<string>(),
    new BinaryTree()
};


foreach(var runner in runners)
{
    runner.Run();
    Console.WriteLine();
}
