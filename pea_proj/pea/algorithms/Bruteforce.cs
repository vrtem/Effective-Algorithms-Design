using System;
using System.Collections.Generic;
using System.Linq;

using pea.other;

namespace pea.algorithms
{
    class Bruteforce : IAlgorithmsInterface
    {
        private readonly Graph _graph;

        public Result Result { get; }

        public string Name { get; set; }

        public Bruteforce(Graph graph)
        {
            _graph = graph;
            Result = new Result
            {
                Weight = int.MaxValue
            };
        }

        public void Request()
        {
            HeapPermutation(_graph.Tops, _graph.GraphSize);
        }

        private static void Swap(IList<int> array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private void HeapPermutation(IList<int> array, int size)
        {
            if (size == 1)
            {
                var totalWeight = 0;

                //pobieramy całą wagę drogi
                for (var i = 0; i < array.Count - 1; i++)
                {
                    totalWeight += _graph.GetWeight(array[i], array[i + 1]);
                }
                //waga pomiedzy ostatnim a pierwszym
                totalWeight += _graph.GetWeight(array[array.Count - 1], array[0]);

                //droga
                var resultPath = array.ToList();
                resultPath.Add(array[0]);

                if (Result.Weight > totalWeight)
                {
                    Result.Weight = totalWeight;
                    Result.Path = resultPath;
                }

                return;
            }

            for (var i = 0; i < size; i++)
            {
                HeapPermutation(array, size-1);
                
                //jezeli rozmiar podzielny przez 2 z ostatkiem 1, robimy swap z 0 pozycji na size - 1
                //inaczej z i-tej pozycji na size-1
                Swap(array, size % 2 == 1 ? 0 : i, size - 1);
            }
        }
    }
}