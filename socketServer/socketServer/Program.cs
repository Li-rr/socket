using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace socketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个新的socket,这里使用最常用的基于TCP的Stream Socket(流式套接字)
            var socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

            //将该socket绑定到主机上面的某个端口
            socket.Bind(new IPEndPoint(IPAddress.Any,4530));

            //启动监听，并且设置一个最大的队列长度
            socket.Listen(4);
            Console.WriteLine("Server is ready!");
            Console.Read();
        }
    }
}
