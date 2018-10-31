using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab6
{
    public class Dijkstra
    {
        // FIELDS
        Graph graph;
        System.Collections.Generic.SortedDictionary<int, int> openSet;
        System.Collections.Generic.SortedDictionary<int, int> closedSet;
        System.Collections.Generic.List<int> path;
        // CONSTRUCTORS
        public Dijkstra(Graph graph)
        {
            this.graph = graph;
            this.openSet = new System.Collections.Generic.SortedDictionary<int, int>();
            this.closedSet = new System.Collections.Generic.SortedDictionary<int, int>();
            this.path = new System.Collections.Generic.List<int>();
        }
        // ROPERTIES
        public System.Collections.Generic.IEnumerable<int> Path => path;
        // INDIXERS
        public int this[int edgeIndex]
        {
            get
            {
                if (closedSet.ContainsKey(edgeIndex))
                {
                    return closedSet[edgeIndex];
                }
                else throw new System.ArgumentException("The shortest path has not been found");
            }
        }
        // METHODS
        public void Run(int from)
        {
            Reset();
            openSet.Add(from, 0);// start position

            while (openSet.Count != 0)
            {
                // get closest edge
                int closestEdge = openSet.Values.Min();
                System.Collections.Generic.KeyValuePair<int, int> currentEdge = openSet.FirstOrDefault(v => v.Value == closestEdge);
                // finding shorter path
                CheckNeighbours(
                    neighbourWeight: graph.GetWeightToHeighbour(currentEdge.Key),
                    currentWeight: currentEdge.Value,
                    fromEdge: 0,
                    toEdge: graph.Size);
                // remove processed edge
                openSet.Remove(currentEdge.Key);
                closedSet.Add(currentEdge.Key, currentEdge.Value);
                path.Add(currentEdge.Key);
            }
        }
        public void RunAsync(int from, int threadAmount)
        {
            Reset();

            openSet.Add(from, 0);// start position

            while (openSet.Count != 0)
            {
                // get closest edge
                int closestEdge = openSet.Values.Min();
                System.Collections.Generic.KeyValuePair<int, int> currentEdge = openSet.FirstOrDefault(v => v.Value == closestEdge);
                int[] neigbourWeight = graph.GetWeightToHeighbour(currentEdge.Key);


                System.Threading.Thread[] threads = new System.Threading.Thread[threadAmount];
                int rowAmountForEachThread = graph.Size / threadAmount;
                int lastFrom = graph.Size - rowAmountForEachThread - 1;
                int lastTo = graph.Size;

                threads[threads.Length - 1] = new System.Threading.Thread(() =>
                {
                    CheckNeighbours(
                       neighbourWeight: neigbourWeight,
                       currentWeight: currentEdge.Value,
                       fromEdge: lastFrom,
                       toEdge: lastTo);
                });
                for (int t = 0; t < threads.Length - 1; ++t)
                {
                    // the lamba catch all variables by reference, need local copy
                    int localFromRow = t * rowAmountForEachThread;
                    int localToRow = t * rowAmountForEachThread + rowAmountForEachThread;
                    threads[t] = new System.Threading.Thread(() =>
                    {
                        CheckNeighbours(
                           neighbourWeight: neigbourWeight,
                           currentWeight: currentEdge.Value,
                           fromEdge: localFromRow,
                           toEdge: localToRow);
                    });

                    threads[t].Start();
                }
                threads[threads.Length - 1].Start();
                for (int t = 0; t < threads.Length; ++t)
                {
                    threads[t].Join();
                }
                // remove processed edge
                openSet.Remove(currentEdge.Key);
                closedSet.Add(currentEdge.Key, currentEdge.Value);
                path.Add(currentEdge.Key);
            }
        }

        private void CheckNeighbours(int[] neighbourWeight, int currentWeight, int fromEdge, int toEdge)
        {
            for (int edgeIndex = fromEdge; edgeIndex < toEdge; ++edgeIndex)
            {
                // for each edge, if there vertex, edge is not processed, the shorter way has been found
                if (CanBeBetter(edgeIndex, neighbourWeight) && WeightIsShorter(edgeIndex, currentWeight, neighbourWeight))
                {
                    openSet[edgeIndex] = currentWeight + neighbourWeight[edgeIndex];
                }
            }
        }
        private void Reset()
        {
            openSet.Clear();
            closedSet.Clear();
            path.Clear();
        }
        private bool CanBeBetter(int edgeIndex, int[] weights)
        {
            return weights[edgeIndex] != 0 && !closedSet.ContainsKey(edgeIndex);
        }
        private bool WeightIsShorter(int edgeIndex, int currentWeight, int[] weights)
        {
            return !openSet.ContainsKey(edgeIndex) || openSet[edgeIndex] > weights[edgeIndex] + currentWeight;
        }


    }
    class Program
    {
        public static void Main(string[] args)
        {
            int size, numOfTh;
            Console.WriteLine("Enter size of graph");
            size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of threads");
            numOfTh = Convert.ToInt32(Console.ReadLine());
            Graph test = new Graph(size);
            test.Generate();
            Dijkstra dis = new Dijkstra(test);
            Stopwatch st = new Stopwatch();
            st.Start();
            dis.Run(1);
            st.Stop();
            Console.WriteLine($"Time for single thread is: {st.Elapsed}");
            foreach (int item in dis.Path)
            {
                Console.Write(item);
            }

            st.Reset();
            st.Start();
            dis.RunAsync(1, numOfTh);
            st.Stop();
            Console.WriteLine($"Time for {numOfTh} threads is: {st.Elapsed}");
            foreach (int item in dis.Path)
            {
                Console.Write(item);
            }
            Console.ReadLine();
        }
    }
}
