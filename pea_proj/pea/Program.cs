using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using pea.algorithms;
using pea.other;

namespace pea
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanceTestsDeviation(6, 132);

            Console.Read();
        }
        
        public static void InstanceTestsDeviation(int cities, int trueSolution)
        {
            var graph = new Graph($"C:\\My Work\\Studies\\PWr\\PEA\\BF-DP\\Effective-Algorithms-Design\\pea_proj\\pea\\instances\\data{cities}.txt");

            IAlgorithmsInterface algorithm = new Bruteforce(graph) { Name = $"Brute force{cities}D" };
            ComputeAndSaveDeviation(algorithm, trueSolution, 10);
            
        }

        public static void Write(Graph graph)
        {
            for (int i = 0; i < graph.GraphSize; i++)
            {
                for (int j = 0; j < graph.GraphSize; j++)
                {
                    Console.Write(graph.GetWeight(i, j) + " ");
                }
                Console.Write(Environment.NewLine);
            }
        }

        public static void Write(IAlgorithmsInterface algorithm)
        {
            Console.WriteLine($"{algorithm.Result.Weight}");
            foreach (var item in algorithm.Result.Path)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

        private static void Write(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        private static long MeasureTime(IAlgorithmsInterface algorithm)
        {
            var sw = new Stopwatch();

            sw.Start();
            algorithm.Request();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static void ComputeAndSave(IAlgorithmsInterface algorithm)
        {
            using (StreamWriter writer = new StreamWriter(algorithm.Name + ".txt"))
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(algorithm.Name);
                    long time = MeasureTime(algorithm);
                    
                    Console.WriteLine("Time:");
                    Console.WriteLine(time);
                    
                    Console.WriteLine("Path:");
                    Write(algorithm.Result.Path);
                    
                    Console.WriteLine("Weight:");
                    Console.WriteLine(algorithm.Result.Weight);
                    
                    Console.WriteLine();
                }
                writer.Close();
            }
        }

        private static void ComputeAndSaveDeviation(IAlgorithmsInterface algorithm, int trueSolution, int iterations)
        {
                long timeSum = 0;
                var results = new List<int>();
                for (int i = 0; i < iterations; i++)
                {
                    Console.WriteLine(algorithm.Name);
                    long time = MeasureTime(algorithm);
                    
                    timeSum += time;
                    Console.WriteLine("Time");
                    Console.WriteLine(time);
                    
                    Console.WriteLine("Path:");
                    Write(algorithm.Result.Path);
                    
                    Console.WriteLine("Weight:");
                    Console.WriteLine(algorithm.Result.Weight);
                    results.Add(algorithm.Result.Weight);
                }
                
                Console.WriteLine("Deviation");
                
                float sum = 0;
                foreach (var result in results)
                {
                    sum += (result - trueSolution) * 100f / trueSolution;
                }
                
                sum /= results.Count;
                Console.WriteLine(sum + "%");
                Console.WriteLine("Average Time:");
                Console.WriteLine(timeSum / iterations);
                Console.WriteLine();
        }
    }
}