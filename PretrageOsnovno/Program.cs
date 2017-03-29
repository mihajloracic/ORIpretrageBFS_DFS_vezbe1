using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PretrageOsnovno
{
    class Program
    {
        public static Node endNode = new Node("j");
        public static Graph instance = null;
        static void Main(string[] args)
        {
            //TODO 1: Ucitati datoteku Graph1.txt i proslediti klasi Graph
            string[] lines = File.ReadAllLines(@".\Graphs\Graph2.txt");
            instance = new Graph(lines);
            List<State> resenje = new List<State>();
            DepthFirstSearch dfs = new DepthFirstSearch();
            BreadthFirstSearch bfs = new BreadthFirstSearch();

            State startState = new State();
            Node startNode = instance.graph.Keys.First();
            startState.node = startNode;

            State sp = startState;
            State solution = dfs.search(sp);

            //ispisuje sadrzaj grafa u konzoli
            //i snima u datoteku
            instance.printGraph();

            if (solution != null)
            {
                resenje = solution.path();
            }
            List<string> putanja = new List<string>();
            //TODO 8: Snimiti resenje u tekstualnu datoteku
            foreach (State i in resenje)
            {
                putanja.Add(i.node.ToString());
            }
            File.WriteAllLines(@".\Graphs\outPutanja.txt", putanja);
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
