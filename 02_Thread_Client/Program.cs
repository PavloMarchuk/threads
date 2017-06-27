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
			TcpClient client = new TcpClient(("127.0.0.1"), port);
			NetworkStream stream = client.GetStream();
			Console.WriteLine("data: ");
			string message =Console.ReadLine();
			StreamWriter writer = new StreamWriter(stream);
			writer.Write(message);
			writer.Flush();


			try
			{
				//listerner = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
				//listerner.Start();
				while(true)
				{
					TcpClient client = listerner.AcceptTcpClient();
					NetworkStream stream = client.GetStream();
					StreamReader reader = new StreamReader(stream);
					string message = reader.ReadLine();
					Console.WriteLine("data: {}", message);
					StreamWriter writer = new StreamWriter(stream);
					writer.WriteLine(message.ToUpper() + "-server");

					writer.Close();
					reader.Close();
					stream.Close();
					client.Close();
				}
			}
			catch(Exception)
			{
				if(listerner != null)
				{
					listerner.Stop();
				}
			}




		}
	}
}
