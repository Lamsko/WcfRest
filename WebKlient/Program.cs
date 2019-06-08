using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebKlient
{
	class Program
	{
		static void Main(string[] args)
		{
			do
			{
				try
				{
					Console.WriteLine("Podaj format (xml lub json):");
					string format = Console.ReadLine();
					Console.WriteLine("Podaj metode (GET lub PUT lub ...):");
					string method = Console.ReadLine();
					Console.WriteLine("Podaj Uri:");
					string uri = Console.ReadLine();
					HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
					request.KeepAlive = false;
					request.Method = method.ToUpper();
					if (format == "xml")
						request.ContentType = "text/xml";
					else if (format == "json")
						request.ContentType = "application/json";
					else
					{
						Console.WriteLine("Podales zle dane");
						return;
					}
					switch (method.ToUpper())
					{
						case "GET":
							break;
						case "PUT":
							Console.WriteLine("Wklej zawartosc XML-a lub JSON-a (w jednej linii!");
							string dane = Console.ReadLine();
							byte[] bufor = Encoding.UTF8.GetBytes(dane);
							request.ContentLength = bufor.Length;
							Stream postData = request.GetRequestStream();
							postData.Write(bufor, 0, bufor.Length);
							postData.Close();
							break;
						default:
							break;
					}
					HttpWebResponse response = request.GetResponse() as HttpWebResponse;
					Encoding encoding = System.Text.Encoding.GetEncoding(1252);
					StreamReader responseStream = new StreamReader(response.GetResponseStream(), encoding);
					string responseString = responseStream.ReadToEnd();
					responseStream.Close();
					response.Close();
					Console.WriteLine(responseString);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message.ToString());
				}
				Console.WriteLine();
				Console.WriteLine("Chcesz kontynuowac?");
			} while (Console.ReadLine().ToUpper() == "Y");
		}
	}
}
