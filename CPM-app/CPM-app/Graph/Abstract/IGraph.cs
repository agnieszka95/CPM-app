using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CPM_app.Graph.Abstract
{
    public interface IGraph
    {
        /**
         * AddNode(IGraphNode node)
         * Add new node to the graph
         */
        void AddNode(IGraphNode node);
        /**
         * RemoveNode(IGraphNode node)
         * Remove node from the graph
         */
        void RemoveNode(IGraphNode node);
        /**
         * AddEdge(IGraphEdge edge)
         * Add new edge to the graph
         */
        void AddEdge(IGraphEdge edge);
        /**
         * RemoveEdge(IGraphEdge edge)
         * Remove edge from the graph
         */
        void RemoveEdge(IGraphEdge edge);
        void BindToLabel(Label criticalPath);

        /**
* Analyze()
* Run CPM analysis on the graph
*/
        void Analyze();
        /**
         * Clear()
         * Reset nodes to defaults
         */
        void Clear();
        /**
         * GetEdges()
         * Get all graph's edges
         */
        IReadOnlyList<IGraphEdge> GetEdges();
        /**
         * GetEdges()
         * Get all graph's nodes
         */
        IReadOnlyList<IGraphNode> GetNodes();
        IGraphNode ForId(int value);
    }
}
