using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _02_Thread_Client
{
	class Program
	{
		const int port = 8888;
		static void Main(string[] args)
		{
			Console.Write("Введите сообщение: ");
			string message = Console.ReadLine();

			TcpClient client = new TcpClient(("127.0.0.1"), port);
			NetworkStream stream = client.GetStream();
			
			BinaryWriter writer = new BinaryWriter(stream);
			writer.Write(message);
			writer.Flush();

			BinaryReader reader = new BinaryReader(stream);
			Console.WriteLine("server: "+ reader.ReadString());

			Console.ReadKey();
			writer.Close();
			reader.Close();
			stream.Close();
			client.Close();
		}
	}
}
