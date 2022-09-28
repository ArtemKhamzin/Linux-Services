using System.Net;
using System.Net.Sockets;
using System.Text;

const int port = 1303;

var ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
var listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
listenSocket.Bind(ipPoint);
listenSocket.Listen();
Console.WriteLine("Сервер запущен");
 
while (true)
{
    var socket = listenSocket.Accept();
    var data = Encoding.Unicode.GetBytes(DateTime.Now.ToString("dd.MM.yy HH:mm"));
    socket.Send(data);
    Console.WriteLine("Ответ отправлен");
                    
    socket.Shutdown(SocketShutdown.Both);
    socket.Close();
}