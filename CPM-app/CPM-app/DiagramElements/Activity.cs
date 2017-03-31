using CPM_app.Graph.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM_app.DiagramElements
{
    //TODO: Inherit from chosen WPF class
    //TODO: Implement methods throwing NotImplementedException
    class Activity : IGraphNode
    {
        private static int topId=0;
        private readonly int id;
        private List<IGraphEdge> registeredEdges;
        private List<IGraphEdge> criticalPaths;
        private List<IGraphEdge> loosePaths;
        private string name;
        private double duration;
        private double criticalPathLength;
        public static readonly Activity Start=new Activity("START");
        public static readonly Activity End= new Activity("END");
        public Activity()
        { 
            id = topId++;
            registeredEdges = new List<IGraphEdge>();
            criticalPaths = new List<IGraphEdge>();
            loosePaths = new List<IGraphEdge>();
        }
        public Activity(string name,double duration):this()
        {
            this.SetName(name);
            this.SetDuration(duration);
        }
        private Activity(string name):this()
        {
            this.name = name;
            this.duration = 0.0;
        }
        public double Analyze()
        {
            if (this.Equals(Start))
                this.AsIGraphNode().Clear();
            else if (this.Equals(End))
            {
                criticalPathLength = 0.0;
                return criticalPathLength;
            }
            if (criticalPaths.Any())
                return criticalPathLength;
            criticalPathLength = -1.0;
            foreach (IGraphEdge edge in registeredEdges)
            {
                if (edge.GetStartNode().Equals(this))
                {
                    IGraphNode node = edge.GetEndNode();
                    double candidate = node.Analyze();
                    if (candidate > criticalPathLength)
                    {
                        criticalPathLength = candidate;
                        criticalPaths.Clear();
                        criticalPaths.Add(edge);
                    }
                    else if (candidate == criticalPathLength)
                    {
                        criticalPaths.Add(edge);
                    }
                    else if (candidate < 0.0)
                    {
                        node.MarkAsLoose();
                        loosePaths.Add(edge);
                    }

                }
            }
            if (this.Equals(Start))
                this.AsIGraphNode().MarkAsCritical();
            return criticalPathLength+duration;
        }
        public void Clear()
        {
            criticalPaths.Clear();
            loosePaths.Clear();
            AsIGraphNode().MarkAsNormal();
        }

        public void Destroy()
        {
            criticalPaths.Clear();
            loosePaths.Clear();

            foreach(IGraphEdge edge in registeredEdges)
            {
                edge.Destroy();
            }
            registeredEdges.Clear();
        }

        public double GetDuration()
        {
            return duration;
        }

        public int GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public IReadOnlyList<IGraphEdge> GetRegisteredConnections()
        {
            return registeredEdges.AsReadOnly();
        }

        public bool IsRegistered(IGraphEdge edge)
        {
            return registeredEdges.Contains(edge);
        }

        public void MarkAsCritical()
        {
            foreach (IGraphEdge edge in criticalPaths)
                edge.GetEndNode().MarkAsCritical();
            //TODO: Implement color change on marking as critical action
            throw new NotImplementedException();
            //end TODO
        }

        public void MarkAsLoose()
        {
            //TODO: Implement color change on marking as loose action
            throw new NotImplementedException();
            //end TODO
        }

        public void MarkAsNormal()
        {
            //TODO: Implement color change on marking as normal action
            throw new NotImplementedException();
            //end TODO
        }

        public void RegisterConnection(IGraphEdge edge)
        {
            registeredEdges.Add(edge);
        }

        public void SetDuration(double duration)
        {
            if (duration >= 0.0)
                this.duration = duration;
            else throw new Exception("Activity duration cannot be negative");
        }

        public void SetName(string name)
        {
            if (name != "START" && name != "END")
                this.name = name;
            else throw new Exception(string.Concat("Name ", name, " is restricted. Please choose another activity's name."));
        }

        public void UnregisterAll()
        {
            registeredEdges.Clear();
            criticalPaths.Clear();
            loosePaths.Clear();
        }

        public void UnregisterConnection(IGraphEdge edge)
        {
            while(registeredEdges.Remove(edge));
            while(criticalPaths.Remove(edge));
            while(loosePaths.Remove(edge));
        }
        public IGraphNode AsIGraphNode()
        {
            return this;
        }
    }
}
