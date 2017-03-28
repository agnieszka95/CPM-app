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

        /**
         * NewAction_Click
         * NewAction button clicked event
         */
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

        /**
         * NewConnection_Click
         * NewConnection button clicked event
         */
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

        private List<object> actionList;
        private List<object> connectionList;
    }
}
