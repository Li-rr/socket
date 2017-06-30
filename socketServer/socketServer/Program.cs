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

            //开始接收客户端连接请求
            socket.BeginAccept(new AsyncCallback((ar) =>
            {
                //这就是客户端的实例
                var client = socket.EndAccept(ar);

                //给客户端发送一个欢迎消息
                client.Send(Encoding.Unicode.GetBytes("Hi,there,I accept you request you request at "+DateTime.Now.ToString()));

                //实现每隔两秒给客户端发一个消息
                //这里使用了一个定时器
                var timer = new System.Timers.Timer();
                timer.Interval = 2000D;
                timer.Enabled = true;
                timer.Elapsed += (o, a) =>
                {
                    //检测客户端socket的状态
                    if(client.Connected)
                    {
                        try
                        {
                            client.Send(Encoding.Unicode.GetBytes("Message from server at " + DateTime.Now.ToString()));
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        timer.Stop();
                        timer.Enabled = false;
                        Console.WriteLine("Client is disconnected, the timer is stop.");
                    }
                   // client.Send(Encoding.Unicode.GetBytes("Message from server at " + DateTime.Now.ToString()));
                 };
                timer.Start();
            }), null);
            Console.WriteLine("Server is ready!");
            Console.Read();
        }
    }
}
