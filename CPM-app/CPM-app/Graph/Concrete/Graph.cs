using CPM_app.DiagramElements;
using CPM_app.Graph.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CPM_app.Graph.Concrete
{
    public class Graph : IGraph
    {
        List<IGraphNode> nodes;
        List<IGraphEdge> edges;
        private static IGraph onlyInstance=new Graph();
        private double totalDuration;
        private Label pathLabel;

        private Graph()
        {
            nodes = new List<IGraphNode>();
            nodes.Add(Activity.Start);
            nodes.Add(Activity.End);
            edges = new List<IGraphEdge>();
            totalDuration = 0;
        }
        public double GetTotalDuration()
        {
            return totalDuration;
        }
        public void AddEdge(IGraphEdge edge)
        {
            edges.Add(edge);
            Analyze();
        }

        public void AddNode(IGraphNode node)
        {
            nodes.Add(node);
        }

        public void Analyze()
        {
            Clear();
            totalDuration=Activity.Start.AsIGraphNode().Analyze();
            UpdateLabel();
            //throw new NotImplementedException();
        }

        private void UpdateLabel()
        {
            if(pathLabel!=null)
            {
                pathLabel.Content = totalDuration.ToString();
            }
        }

        public IReadOnlyList<IGraphEdge> GetEdges()
        {
            return edges.AsReadOnly();
        }

        public IReadOnlyList<IGraphNode> GetNodes()
        {
            return nodes.AsReadOnly();
        }

        public void RemoveEdge(IGraphEdge edge)
        {
            while(edges.Remove(edge));
            edge.Destroy();
            Analyze();
        }

        public void RemoveNode(IGraphNode node)
        {
            if (node.Equals(Activity.Start) || node.Equals(Activity.End))
                return;
            foreach(IGraphEdge edge in node.GetRegisteredConnections())
            {
                RemoveEdge(edge);
            }
            while(nodes.Remove(node));
            node.Destroy();
            Analyze();
        }

        /**
         * GetInstance()
         * The only way to obtain Graph instance
         */
        public static IGraph GetInstance()
        {
            return onlyInstance;
        }

        public void Clear()
        {
            totalDuration = 0.0;
            foreach (IGraphNode node in nodes)
                node.Clear();
        }

        public IGraphNode ForId(int value)
        {
            return nodes.Find(x => x.GetId() == value);
        }

        public void BindToLabel(Label criticalPath)
        {
            this.pathLabel = criticalPath;
        }
    }
}
