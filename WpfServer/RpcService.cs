using greeter.hello;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfServer
{
    class RpcService: Greeter.GreeterBase
    {
        public override Task<HelloResponse> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloResponse() { Message = "server response: " + request.Name });
        }
    }
}
