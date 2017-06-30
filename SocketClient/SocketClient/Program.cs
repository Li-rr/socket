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

            //实现消息接收的方法

            var buffer = new byte[1024]; //设置一个缓冲区，保存数据
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback((ar) =>
            {
                var length = socket.EndReceive(ar);
                var message = Encoding.Unicode.GetString(buffer, 0, length);
                Console.WriteLine(message);
            }), null);

            Console.WriteLine("connect to the server");
            Console.Read();
        }
    }
}
