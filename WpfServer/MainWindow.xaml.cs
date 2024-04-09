using greeter.hello;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Server server;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            server = new Server()
            {
                Services = { Greeter.BindService(new RpcService()) },
                Ports = { new ServerPort("localhost", 8099, ServerCredentials.Insecure) }
            };
            server.Start();

            TxtBlockServer.Text = "Server: localhost:8099";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            server?.ShutdownAsync().Wait();
            base.OnClosing(e);
        }
    }
}
