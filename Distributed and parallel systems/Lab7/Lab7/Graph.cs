using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class Graph
    {
        // FIELDS
        int[][] graph;
        int size;
        // INCDEXERS
        public int this[int i, int j]
        {
            get
            {
                return graph[i][j];
            }
            set
            {
                graph[i][j] = value;
            }
        }
        // PROPERTIES
        public int Size
        {
            get
            {
                return size;
            }
        }
        // CONSTRUCTORS
        public Graph(int size)
        {
            this.size = size;
            this.graph = new int[size][];
            for (int i = 0; i < size; ++i)
            {
                graph[i] = new int[size];
            }
        }
        public Graph Generate(float noPathRate = 0.35F)
        {
            System.Random rand = new System.Random();
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (rand.NextDouble() < noPathRate || i == j) graph[i][j] = int.MaxValue;
                    else graph[i][j] = rand.Next(100);
                }
            }
            return this;
        }
    }
}
