using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个socket
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //连接到指定服务器的指定端口
            socket.Connect("localhost", 4530);

            
            Console.WriteLine("connect to the server");
            Console.Read();
        }
    }
}
