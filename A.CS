using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

using System.IO;

using Microsoft.ReportingServices.RdlObjectModel;
namespace RDL
{
	class Program
	{
		static readonly HttpClient client = new HttpClient();
		static async Task Main()
		{
			/*Buffer();*/
			MemoryStream ms = new MemoryStream();
			Stream response = await client.GetStreamAsync("https://raw.githubusercontent.com/SQL-Server-projects/Reporting-Services-examples/master/ServerReports/Data%20Sources.rdl");
			await response.CopyToAsync(ms);
			ms.Position = 0;
			Report.Load(ms);
			StreamReader reader = new StreamReader(ms);
			// Read the content.
			string responseFromServer = reader.ReadToEnd();
			// Display the content.
			Console.WriteLine(responseFromServer);
			/*HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			MemoryStream ms = new MemoryStream();
			ms.Position = 0;
			using (Stream dataStream = response.GetResponseStream()) {
				dataStream.Seek(0, SeekOrigin.Begin);
				dataStream.CopyTo(ms);
				StreamReader reader = new StreamReader(ms);
				// Read the content.
				string responseFromServer = reader.ReadToEnd();
				// Display the content.
				Console.WriteLine(responseFromServer);
			}*/
			/*dataStream.Position = 0;*/
			/*using (MemoryStream ms = new MemoryStream())
			{
				dataStream.CopyTo(ms);
				StreamReader reader = new StreamReader(ms);
				// Read the content.
				string responseFromServer = reader.ReadToEnd();
				// Display the content.
				Console.WriteLine(responseFromServer);
				// Report.Load(ms);
			}*/
			/*StreamReader reader = new StreamReader(dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd();
			// Display the content.
			Console.WriteLine(responseFromServer);
			// Cleanup the streams and the response.
			reader.Close();*/
		}
		static void Buffer()
		{
			WebRequest request = WebRequest.Create("https://raw.githubusercontent.com/SQL-Server-projects/Reporting-Services-examples/master/ServerReports/Data%20Sources.rdl");
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream dataStream = response.GetResponseStream();
			MemoryStream ms = new MemoryStream();
			dataStream.CopyTo(ms);
			ms.Position = 0;
			StreamReader reader = new StreamReader(dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd();
			// Display the content.
			Console.WriteLine(responseFromServer);
		}
	}
}
