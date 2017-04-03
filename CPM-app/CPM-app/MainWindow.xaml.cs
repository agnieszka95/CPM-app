using CPM_app.DiagramElements;
using CPM_app.Graph.Abstract;
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
using CPM_app.Graph.Concrete;
using System.Collections.ObjectModel;

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
            graph = Graph.Concrete.Graph.GetInstance();
            graph.BindToLabel(criticalPath);
            actions.Items.Add(LabelFor(Activity.Start));
            actions.Items.Add(LabelFor(Activity.End));
        }
        private IGraph graph;
        private Label LabelFor(Activity act)
        {
            var label =new Label();
            string separator = " | ";
            label.Content = new StringBuilder().Append("ID: ").Append(act.GetId()).Append(separator).Append(act.GetName()).Append(separator).Append(act.GetDuration()).ToString();
            act.SetLabel(label);
            act.MarkAsDetached();
            return label;
        }

        private void NewAction(object sender, RoutedEventArgs e)
        {

            Activity act = new Activity();
            act.SetDuration((int)duration.Value);
            act.SetName(actionName.Text);
            graph.AddNode(act);
            actions.Items.Add(LabelFor(act));
            Redraw();
        }

        private void Redraw()
        {
            chartCanvas.Children.Clear();
            foreach(IGraphNode node in graph.GetNodes())
            {
                Line line = new Line();
                line.Stroke = node.GetLabel().Background;
                int length = 0;
                line.StrokeThickness = 10;
                //line.Width = 10;
                int offset =30+ 10*(Activity.Start.GetCriticalPath() - node.GetCriticalPath());
                if (node == Activity.Start)
                {
                    length += 6;
                    line.Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0xff, 0x00, 0x00));
                    offset += 3;
                }
                else if ( node == Activity.End)
                {
                    length += 6;
                    offset += 3;
                    line.Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0xff));
                }
                else
                {
                    length += 10 * node.GetDuration();
                }
                line.X1 = offset-length;
                line.X2 = offset;
                //line.Width += length;
                line.Y1 = 30 + node.GetId() * 15;
                line.Y2 = 30 + node.GetId() * 15;
                Console.Write(node.GetId());
                Console.Write(" | ");
                Console.Write(line.X1);
                Console.Write(" | ");
                Console.Write(line.X2);
                Console.Write(" | ");
                Console.WriteLine(node.GetCriticalPath());
                chartCanvas.Children.Add(line);
            }
        }

        private void NewConnection(object sender, RoutedEventArgs e)
        {
            IGraphNode start = graph.ForId((int)startNode.Value);
            IGraphNode end = graph.ForId((int)endNode.Value);
            if(start!=null && end != null)
            {
                try
                {
                    Connection connection = new Connection(start, end);
                    graph.AddEdge(connection);
                    connections.Items.Add(LabelFor(connection));
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Redraw();
        }

        private object LabelFor(Connection connection)
        {
            var label = new Label();
            string separator = " | ";
            label.Content = new StringBuilder().Append("FROM: ").Append(connection.GetStartNode().GetId()).Append("TO: ").Append(separator).Append(connection.GetEndNode().GetId()).ToString();
            return label;
        }
    }
}
