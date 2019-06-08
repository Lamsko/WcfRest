using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebSerwis2
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IRestSerwis1
	{

		[OperationContract]
		[WebGet(UriTemplate = "/Books")]
		List<Ksiazka> getAll();

		[OperationContract]
		[WebGet(UriTemplate = "/Books/{id}", ResponseFormat = WebMessageFormat.Xml)]
		Ksiazka getById(string Id);

		[OperationContract]
		[WebInvoke(UriTemplate = "/Books/priceUpdate/{id}", Method = "PUT", RequestFormat = WebMessageFormat.Xml)]
		string priceUpdate(String id, double price);

		[OperationContract]
		[WebInvoke(UriTemplate = "/Books/add/{id}", Method = "PUT", ResponseFormat = WebMessageFormat.Xml)]
		string add(String tytul, String autor, string cena, string id);

		[OperationContract]
		[WebInvoke(UriTemplate = "/Books/title/{title}", ResponseFormat = WebMessageFormat.Xml)]
		List<Ksiazka> getByTitle(string title);

		[OperationContract]
		[WebInvoke(UriTemplate = "/Books/author/{author}", ResponseFormat = WebMessageFormat.Xml)]
		List<Ksiazka> getByAuthor(string author);

		[OperationContract]
		[WebInvoke(UriTemplate = "/Books/delete/{id}", Method = "PUT", RequestFormat = WebMessageFormat.Xml)]
		string delete(string Id);

		[OperationContract]
		[WebGet(UriTemplate = "/json/Books", ResponseFormat = WebMessageFormat.Json)]
		List<Ksiazka> getJsonAll();

		[OperationContract]
		[WebGet(UriTemplate = "/json/Books/{id}", ResponseFormat = WebMessageFormat.Json)]
		Ksiazka getJsonById(string Id);

		[OperationContract]
		[WebInvoke(UriTemplate = "/json/Books/priceUpdate/{id}", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
		string jsonPriceUpdate(String id, double price);

		[OperationContract]
		[WebInvoke(UriTemplate = "/json/Books/add/{id}", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
		string jsonAdd(String tytul, String autor, string cena, string id);

		[OperationContract]
		[WebInvoke(UriTemplate = "/json/Books/title/{title}", ResponseFormat = WebMessageFormat.Json)]
		List<Ksiazka> jsonGetByTitle(string title);

		[OperationContract]
		[WebInvoke(UriTemplate = "/json/Books/author/{author}", ResponseFormat = WebMessageFormat.Json)]
		List<Ksiazka> jsonGetByAuthor(string author);

		[OperationContract]
		[WebInvoke(UriTemplate = "/json/Books/delete/{id}", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
		string jsonDelete(string Id);

		// TODO: Add your service operations here
	}


	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	[DataContract]
	public class Ksiazka
	{
		string autor = "";
		string tytul = "";
		int id = 0;
		double cena = 0.0;

		[DataMember]
		public string Autor
		{
			get { return autor; }
			set { autor = value; }
		}

		[DataMember]
		public string Tytul
		{
			get { return tytul; }
			set { tytul = value; }
		}

		[DataMember]
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		[DataMember]
		public double Cena
		{
			get { return cena; }
			set { cena = value; }
		}
	}
}
