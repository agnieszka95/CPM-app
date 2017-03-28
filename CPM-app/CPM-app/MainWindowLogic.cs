using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CPM_app
{
    partial class MainWindow : Window
    {
        /**
         * CreateConnection
         * Creates connection between two actions
         */
        private void CreateConnection()
        {
            object connection = new object();
            InitializeConnectionProperties(connection);
            PlaceConnectionOnPane(connection);
            AddConnectionToGraph(connection);
            connectionList.Add(connection);
            UpdateChart();
            UpdateGraph();
        }


        /**
         * EditConnection
         * Edits connection between two actions
         */
        private void EditConnection(object connection)
        {
            EditConnectionProperties(connection);
            UpdateGraph();
            UpdateChart();
        }

        /**
         * DeleteConnection
         * Deletes connection between two actions
         */
        private void DeleteConnection(object connection)
        {
            RemoveConnectionFromPane(connection);
            RemoveConnectionFromGraph(connection);
            connectionList.Remove(connection);
            UpdateGraph();
            UpdateChart();
        }

        /**
         * CreateAction
         * Creates loose action, not connected to the rest of the graph/diagram 
         */
        private void CreateAction()
        {
            object action = new object();
            InitializeActionProperties(action);
            PlaceActionOnPane(action);
            AddActionToGraph(action);
            actionList.Add(action);
            //TODO: Create action rectangle, add it to graph, display on Diagram pane
        }

        /**
         * EditAction
         * Edits action properties without affecting diagram/graph structure
         */
        private void EditAction(object action)
        {
            EditActionProperties(action);
            UpdateGraph();
            UpdateChart();

            //TODO: Edit action rectangle on double Click
        }

        /**
         * DeleteAction
         * Deletes action and it's connections
         */
        private void DeleteAction(object action)
        {
            RemoveActionFromPane(action);
            RemoveActionFromGraph(action);
            actionList.Remove(actionList);
            UpdateGraph();
            UpdateChart();
            //TODO: Delete action rectangle and remove it from graph on Click+Delete
        }
    }
}
