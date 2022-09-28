using System.Net;
using System.Net.Sockets;
using System.Text;

const int port = 1303;

Console.WriteLine("Введите IP адрес сервера");
var address = Console.ReadLine() ?? throw new InvalidOperationException();
var ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Connect(ipPoint);
                
var data = new byte[256];
var builder = new StringBuilder();
var bytes = socket.Receive(data, data.Length, 0);
builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
Console.WriteLine("Сообщение сервера: " + builder);
 
socket.Shutdown(SocketShutdown.Both);
socket.Close();