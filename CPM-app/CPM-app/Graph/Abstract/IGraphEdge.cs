using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM_app.Graph.Abstract
{
    public interface IGraphEdge
    {
        /**
         * GetStartNode()
         * Retrieves edge's start point
         */
        IGraphNode GetStartNode();
        /**
         * GetEndNode()
         * Retrieves edge's start point
         */
        IGraphNode GetEndNode();
        /**
         * Destroy()
         * Unregisters edge from both nodes' registered lists
         */
        void Destroy();
    }
}
