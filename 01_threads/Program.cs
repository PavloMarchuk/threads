using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _01_threads
{
	class Program
	{
		const int port = 8888;
		static TcpListener listerner;
		static void Main(string[] args)
		{			
			try
			{
				listerner = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
				listerner.Start();
				while(true)
				{
					TcpClient client = listerner.AcceptTcpClient();
					NetworkStream stream = client.GetStream();
					BinaryReader reader = new BinaryReader(stream);
					string message = reader.ReadString();
					Console.WriteLine("data: " + message);
					BinaryWriter writer = new BinaryWriter(stream);
					writer.Write(message.ToUpper() + "-server");

					writer.Close();
					reader.Close();
					stream.Close();
					client.Close();
				}
			}
			catch(Exception)
			{
				if(listerner!=null)
				{
					listerner.Stop();
				}				
			}
			

			
			
		}
	}
}
