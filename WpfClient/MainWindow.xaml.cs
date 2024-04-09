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
using System.Xml.Linq;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Channel channel;
        private Greeter.GreeterClient client;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            channel = new Channel("localhost", 8099, ChannelCredentials.Insecure);
            client = new Greeter.GreeterClient(channel);
            var response = client.SayHello(new HelloRequest() { Name = "Hello Chen" });
            ListBoxMessage.Items.Add(response);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            channel?.ShutdownAsync().Wait();
            base.OnClosing(e);
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            string name = TxtBoxName.Text;
            var response = client.SayHello(new HelloRequest() { Name = name });
            ListBoxMessage.Items.Add(response);
        }
    }
}
