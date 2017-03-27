using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPM_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            actionList = new List<object>();
            connectionList = new List<object>();
        }


        private void NewAction_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("TODO: Nowa czynność");
            //throw new NotImplementedException();
            //Button button = new Button();
            //button.Click += Edit;
            //button.Content = "Dynamiczny przycisk";
            //listView.Items.Add(button);
            CreateAction();

        }
        private void NewConnection_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("TODO: Nowe połączenie");
            //throw new NotImplementedException();
            //Button button = new Button();
            //button.Click += Edit;
            //button.Content = "Dynamiczny przycisk";
            //listView.Items.Add(button);
            CreateConnection();
        }

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


        private void EditConnection(object connection)
        {
            EditConnectionProperties(connection);
            UpdateGraph();
            UpdateChart();
        }

        private void DeleteConnection(object connection)
        {
            RemoveConnectionFromPane(connection);
            RemoveConnectionFromGraph(connection);
            connectionList.Remove(connection);
            UpdateGraph();
            UpdateChart();
        }


        private void CreateAction()
        {
            object action = new object();
            InitializeActionProperties(action);
            PlaceActionOnPane(action);
            AddActionToGraph(action);
            actionList.Add(action);
            //TODO: Create action rectangle, add it to graph, display on Diagram pane
        }

        private void EditAction(object action)
        {
            EditActionProperties(action);
            UpdateGraph();
            UpdateChart();

            //TODO: Edit action rectangle on double Click
        }

        private void DeleteAction(object action)
        {
            RemoveActionFromPane(action);
            RemoveActionFromGraph(action);
            actionList.Remove(actionList);
            UpdateGraph();
            UpdateChart();
            //TODO: Delete action rectangle and remove it from graph on Click+Delete
        }
        private void AddActionToGraph(object action)
        {
            throw new NotImplementedException();
        }

        private void PlaceActionOnPane(object action)
        {
            throw new NotImplementedException();
        }

        private void InitializeActionProperties(object action)
        {
            throw new NotImplementedException();
        }


        private void UpdateChart()
        {
            throw new NotImplementedException();
        }

        private void UpdateGraph()
        {
            throw new NotImplementedException();
        }

        private void RemoveActionFromGraph(object action)
        {
            throw new NotImplementedException();
        }

        private void RemoveActionFromPane(object action)
        {
            throw new NotImplementedException();
        }


        private void EditActionProperties(object action)
        {
            throw new NotImplementedException();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("MAMY DYNAMICZNY KONTENT");
            throw new NotImplementedException();
        }

        private void AddConnectionToGraph(object connection)
        {
            throw new NotImplementedException();
        }

        private void PlaceConnectionOnPane(object connection)
        {
            throw new NotImplementedException();
        }

        private void InitializeConnectionProperties(object connection)
        {
            throw new NotImplementedException();
        }

        private void EditConnectionProperties(object connection)
        {
            throw new NotImplementedException();
        }

        private void RemoveConnectionFromGraph(object connection)
        {
            throw new NotImplementedException();
        }

        private void RemoveConnectionFromPane(object connection)
        {
            throw new NotImplementedException();
        }
        private List<object> actionList;
        private List<object> connectionList;
    }
}
