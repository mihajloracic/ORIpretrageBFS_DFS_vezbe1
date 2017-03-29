using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PretrageOsnovno
{
    class Graph
    {
        public Dictionary<Node, List<Node>> graph;

        public Graph(string[] lines)
        {
            graph = new Dictionary<Node, List<Node>>();
            formGraph(lines);
        }

        //TODO 2 : Implementirati metodu
        private void formGraph(string[] lines)
        {
            foreach (string i in lines)
            {
                string[] words = i.Split(':');
                string node1;
                string node2;
                
                string[] nodes = words[1].Split(',');
                node1 = nodes[0];
                node2 = nodes[1];
                Node parentNode = new Node(node1);
                Node childNode = new Node(node2);
                List<Node> list = new List<Node>();
                if(!graph.ContainsKey(parentNode)){
                    graph.Add(parentNode, new List<Node>());
                }
                graph[parentNode].Add(childNode);
            }
        }

        //TODO 3: Implementirati metodu koja prolazi kroz graph, cita njegov sadrzaj i upisuje u datoteku
        public void printGraph()
        {
            List<string> grapPrint = new List<string>();
            foreach(KeyValuePair<Node,List<Node>> i in graph)
            {
                foreach(Node j in i.Value)
                {
                    grapPrint.Add(String.Format("veza {0}, {1}",i.Key,j));
                }
                Console.WriteLine();
            }
            File.WriteAllLines(@".\Graphs\out.txt",grapPrint);
        }



    }
}
