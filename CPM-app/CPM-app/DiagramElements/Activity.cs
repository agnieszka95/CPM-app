using CPM_app.Graph.Abstract;
using CPM_app.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace CPM_app.DiagramElements
{
    //TODO: Inherit from chosen WPF class
    //TODO: Implement methods throwing NotImplementedException
    public class Activity : IGraphNode
    {
        private static int topId=0;
        private readonly int id;
        private List<IGraphEdge> registeredEdges;
        private List<IGraphEdge> criticalPaths;
        private List<IGraphEdge> loosePaths;
        private int criticalPathLength;
        private string actionName;
        private int duration;
        protected Label label { get; set; }
        public static readonly Activity Start=new Activity("START");
        public static readonly Activity End= new Activity("END");
        public Activity()
        { 
            id = topId++;
            registeredEdges = new List<IGraphEdge>();
            criticalPaths = new List<IGraphEdge>();
            loosePaths = new List<IGraphEdge>();
        }
        public Activity(string name,int duration):this()
        {
            this.SetName(name);
            this.SetDuration(duration);
        }
        private Activity(string name):this()
        {
            this.actionName=name;
            this.duration = 0;
        }
        public int Analyze()
        {
            this.AsIGraphNode().Clear();
            if(this.Equals(End))
            {
                criticalPathLength = 0;
                return criticalPathLength;
            }
            if (criticalPaths.Any())
                return criticalPathLength;
            criticalPathLength = -1;
            foreach (IGraphEdge edge in registeredEdges)
            {
                if (edge.GetStartNode().Equals(this))
                {
                    IGraphNode node = edge.GetEndNode();
                    int candidate = node.Analyze();
                    node.MarkAsNormal();
                    if (candidate < 0)
                    {
                        node.MarkAsLoose();
                        loosePaths.Add(edge);
                    }
                    else if (candidate > criticalPathLength)
                    {
                        criticalPathLength = candidate;
                        criticalPaths.Clear();
                        criticalPaths.Add(edge);
                    }
                    else if (candidate == criticalPathLength)
                    {
                        criticalPaths.Add(edge);
                    }

                }
            }
            if (criticalPathLength < 0)
                return criticalPathLength;
            if (this.Equals(Start)&&this.criticalPathLength>=0)
                this.AsIGraphNode().MarkAsCritical();
            return criticalPathLength+ (int)duration;
        }

        public int GetCriticalPath()
        {
            return criticalPathLength;
        }

        public void Clear()
        {
            criticalPaths.Clear();
            loosePaths.Clear();
            AsIGraphNode().MarkAsDetached();
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

        public int GetDuration()
        {
            return (int)duration;
        }

        public int GetId()
        {
            return id;
        }

        public string GetName()
        {
            return actionName;
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
            if(label!=null)
            label.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xCC, 0xCC));
            //end TODO
        }

        public void MarkAsLoose()
        {
            //TODO: Implement color change on marking as loose action
            if (label != null)
                label.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xCC, 0xFF, 0xCC));
            //end TODO
        }

        public void MarkAsNormal()
        {
            //TODO: Implement color change on marking as normal action
            if (label != null)
                label.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xCC, 0xCC, 0xFF));
            //end TODO
        }

        public void MarkAsDetached()
        {
            if (label != null)
                label.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xCC, 0xCC, 0xCC));

        }

        public void RegisterConnection(IGraphEdge edge)
        {
            registeredEdges.Add(edge);
        }

        public void SetDuration(int duration)
        {
            if (duration >= 0)
                this.duration=duration;
            else throw new Exception("Activity duration cannot be negative");
        }

        public void SetName(string name)
        {
            if (name != "START" && name != "END")
                this.actionName = name;
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
        public Label GetLabel()
        {
            return label;
        }
        public void SetLabel(Label label)
        {
            this.label = label;

        }
    }
}
