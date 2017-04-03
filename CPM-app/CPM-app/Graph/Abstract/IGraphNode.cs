using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CPM_app.Graph.Abstract
{
    public interface IGraphNode
    {
        /**
         * MarkAsCritical();
         * Change node pane's color if it's on critical path
         */
        void MarkAsCritical();
        /**
         * MarkAsNormal();
         * Change node pane's color if it's neither on critical path nor loose graph edge
         */
        void MarkAsNormal();
        /**
         * MarkAsLoose();
         * Change node pane's color if neither this node nor it's children are connected to Stop node
         */
        void MarkAsLoose();
        /**
         * MarkAsDetached();
         * Node color for new connections
         */
        void MarkAsDetached();
        /**
         * RegisterConnection(IGraphEdge edge)
         * Add given edge to internal IGraphEdge list
         */
        void RegisterConnection(IGraphEdge edge);
        /**
         * RegisterConnection(IGraphEdge edge)
         * Remove given edge from internal IGraphEdge list
         */
        void UnregisterConnection(IGraphEdge edge);
        /**
         * IsRegistered(IGraphEdge edge)
         * Checks if given edge is registered in the node
         */
        bool IsRegistered(IGraphEdge edge);
        /**
         * GetRegisteredConnections(IGraphEdge edge)
         * Returns immutable list of connections registered to node
         */
        IReadOnlyList<IGraphEdge> GetRegisteredConnections();
        /**
         * UnregisterAll()
         * Remove all edges from internal IGraphEdge list
         */
        void UnregisterAll();
        /**
         * Analyze()
         * Analyzes Node and it's children to find critical sub-path(s) and loose ends, returns maximum total duration
         */
        int Analyze();
        /**
         * GetLabel()
         * Retrieve label associated with given node
         */
        Label GetLabel();
        int GetCriticalPath();

        /**
        * Clear()
        * Removes all data from previous analysis
        */
        void Clear();
        /**
         * Destroy()
         * Removes all edges from registered list, plus disconnects these edges from their endpoints
         */
        void Destroy();
        /**
         * GetId()
         * Get node's Id
         */
        int GetId();
        /**
         * GetDuration()
         * Get node's duration
         */
        int GetDuration();
        /**
         * GetName()
         * Get node's name
         */
        string GetName();
        /**
         * SetName(string name)
         * Set node's name
         */
        void SetName(string name);
        /**
         * SetDuration(double duration)
         * Set node's name
         */
        void SetDuration(int duration);
    }
}
