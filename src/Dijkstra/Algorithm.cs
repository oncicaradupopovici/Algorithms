using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Algorithm
    {
        public int? FindMinDistance(Graph graph, string source, string target)
        {
            Vertex sourceVertex;
            Vertex targetVertex;

            if (!graph.Vertices.TryGetValue(source, out sourceVertex))
                throw new KeyNotFoundException($"Vertex {source} not found.");

            if (!graph.Vertices.TryGetValue(target, out targetVertex))
                throw new KeyNotFoundException($"Vertex {target} not found.");

            if (source == target)
                return 0;

            var infinity = Int32.MaxValue;
            var minDistances = new Dictionary<string, int>();
            var prev = new Dictionary<string, string>();
            var unvisited = new List<Vertex>();
            

            foreach (var vertex in graph.Vertices)
            {
                minDistances[vertex.Key] = infinity;
                unvisited.Add(vertex.Value);
            }

            minDistances[source] = 0;

            while (unvisited.Any())
            {
                var minUnvisitedDistance = unvisited.Min(v => minDistances[v.Name]);
                var currentVertex = unvisited.First(v => minDistances[v.Name] == minUnvisitedDistance);
                unvisited.Remove(currentVertex);

                if (currentVertex.Name == target)
                    break;

                foreach(var edge in currentVertex.Neighbours)
                {
                    var distance = minDistances[currentVertex.Name] + edge.Distance;
                    if(distance < minDistances[edge.Target.Name])
                    {
                        minDistances[edge.Target.Name] = distance;
                        prev[edge.Target.Name] = currentVertex.Name;
                    }
                }
            }


            var result = minDistances[target] == infinity ? null : (int?)minDistances[target];
            return result;
        }




    }


    public class Vertex
    {
        public Vertex(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Edge> Neighbours { get; } = new List<Edge>();
    }

    public class Edge
    {
        public Edge(Vertex source, Vertex target, int distance)
        {
            this.Source = source;
            this.Target = target;
            this.Distance = distance;
        }

        public Vertex Source { get; private set; }
        public Vertex Target { get; private set; }
        public int Distance { get; private set; }
    }

    public class Graph
    {
        public Dictionary<string, Vertex> Vertices { get; } = new Dictionary<string, Vertex>();

        public void AddNeighbours(string source, string target, int distance)
        {
            Vertex sourceVertex;
            Vertex targetVertex;


            if (!Vertices.TryGetValue(source, out sourceVertex))
            {
                Vertices[source] = sourceVertex = new Vertex(source);
            }

            if(!Vertices.TryGetValue(target, out targetVertex))
            {
                Vertices[target] = targetVertex = new Vertex(target);
            }

            sourceVertex.Neighbours.Add(new Edge(sourceVertex, targetVertex, distance));
            targetVertex.Neighbours.Add(new Edge(targetVertex, sourceVertex, distance));
        }
    }



    
}
