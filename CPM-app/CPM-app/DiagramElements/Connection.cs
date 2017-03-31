using CPM_app.Graph.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM_app.DiagramElements
{
    //TODO: Inherit from chosen WPF class
    class Connection : IGraphEdge
    {
        private readonly IGraphNode startNode;
        private readonly IGraphNode endNode;
        public Connection(IGraphNode start,IGraphNode end)
        {
            if (start.Equals(Activity.End))
                throw new Exception("Forbidden: END node cannot be connection's start node.");
            if (end.Equals(Activity.Start))
                throw new Exception("Forbidden: START node cannot be connection's end node.");
            startNode = start;
            endNode = end;
        }
        public void Destroy()
        {
            startNode.UnregisterConnection(this);
            endNode.UnregisterConnection(this);
        }

        public IGraphNode GetEndNode()
        {
            return endNode;
        }

        public IGraphNode GetStartNode()
        {
            return startNode;
        }
    }
}
