using System;
using System.IO;
using System.Linq;

namespace pea.other
{
    public class Graph
    {
        private readonly int[,] graph;

        public int GraphSize { get; }
        public int[] Tops { get; }

        public Graph(int graphSize)
        {
            Tops = Enumerable.Range(0, graphSize).ToArray();
            graph = new int[graphSize - 1, graphSize - 1];
        }

        public Graph(string fileName)
        {
            try
            {  
                using (StreamReader sr = new StreamReader(fileName))
                {
                    var text = sr.ReadLine();

                    GraphSize = int.Parse(text);
                    Tops = Enumerable.Range(0, GraphSize).ToArray();
                    graph = new int[GraphSize, GraphSize];

                    for (var i = 0; i < GraphSize; i++)
                    {
                        text = sr.ReadLine();
                        var numbersAsText = text.Split(new string[]{"", " ", "\t"}, StringSplitOptions.RemoveEmptyEntries);

                        for (var j = 0; j < GraphSize; j++)
                        {
                            graph[i, j] = int.Parse(numbersAsText[j]);         
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Your file is unreadable:");
                Console.WriteLine(e.Message);
            }
        }

        public int GetWeight(int x, int y)
        {
            return graph[x, y];
        }

    }
}