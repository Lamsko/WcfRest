using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebSerwis2
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class RestService1 : IRestSerwis1
	{
		private static int maxId = 3;
		private static List<Ksiazka> ksiazki = new List<Ksiazka>()
		{
			new Ksiazka {Autor = "Tolkien", Tytul = "Hobbit", Id = 1, Cena = 30},
			new Ksiazka {Autor = "Tolkien", Tytul = "Silmarillion", Id = 2, Cena = 80},
			new Ksiazka {Autor = "Sanderson", Tytul = "Droga Królów", Id = 3, Cena = 50}
		};



		public List<Ksiazka> getAll()
		{
			return ksiazki;
		}

		public Ksiazka getById(string Id)
		{
			int intId = int.Parse(Id);
			return ksiazki.Find(b => b.Id == intId);
		}

		public string priceUpdate(string id, double price)
		{
			int intId = int.Parse(id);
			int idx = ksiazki.FindIndex(b => b.Id == intId);
			if (idx == -1)
				return "Nie mozna zaktualizowac ceny ksiazki o id=" + id;
			ksiazki[intId].Cena = price;
			return "Zaktualizowano cene ksiazki o id= " + id;
		}

		public List<Ksiazka> getJsonAll()
		{
			return ksiazki;
		}

		public Ksiazka getJsonById(string Id)
		{
			int intId = int.Parse(Id);
			return ksiazki.Find(b => b.Id == intId);
		}


		public string add(string tytul, string autor, string cena, string id)
		{
			maxId++;
			int intId = int.Parse(id);
			double dCena = double.Parse(cena);
			Ksiazka ksiazka = new Ksiazka { Tytul = tytul, Autor = autor, Cena = dCena, Id = intId };
			ksiazki.Add(ksiazka);
			return "Dodana nowa ksiazke";
		}

		public string delete(string Id)
		{
			int intId = int.Parse(Id);
			int idx = ksiazki.FindIndex(b => b.Id == intId);
			if (idx == -1)
				return "Nie mozna usunac ksiazki o id=" + Id;
			ksiazki.RemoveAt(idx);
			return "Usunieto ksiazke o indexie= " + Id;
		}

		public List<Ksiazka> getByTitle(string title)
		{
			List<Ksiazka> wynik = new List<Ksiazka>();
			foreach (Ksiazka ksiazka in ksiazki)
			{
				if (ksiazka.Tytul == title)
				{
					wynik.Add(ksiazka);
				}
			}
			return wynik;
		}

		public List<Ksiazka> getByAuthor(string author)
		{
			List<Ksiazka> wynik = new List<Ksiazka>();
			foreach (Ksiazka ksiazka in ksiazki)
			{
				if (ksiazka.Autor == author)
				{
					wynik.Add(ksiazka);
				}
			}
			return wynik;
		}

		public string jsonPriceUpdate(string id, double price)
		{
			int intId = int.Parse(id);
			int idx = ksiazki.FindIndex(b => b.Id == intId);
			if (idx == -1)
				return "Nie mozna zaktualizowac ceny ksiazki o id=" + id;
			ksiazki[intId].Cena = price;
			return "Zaktualizowano cene ksiazki o id= " + id;
		}

		public string jsonAdd(string tytul, string autor, string cena, string id)
		{
			maxId++;
			int intId = int.Parse(id);
			double dCena = double.Parse(cena);
			Ksiazka ksiazka = new Ksiazka { Tytul = tytul, Autor = autor, Cena = dCena, Id = intId };
			ksiazki.Add(ksiazka);
			return "Dodana nowa ksiazke";
		}

		public List<Ksiazka> jsonGetByTitle(string title)
		{
			List<Ksiazka> wynik = new List<Ksiazka>();
			foreach (Ksiazka ksiazka in ksiazki)
			{
				if (ksiazka.Tytul == title)
				{
					wynik.Add(ksiazka);
				}
			}
			return wynik;
		}

		public List<Ksiazka> jsonGetByAuthor(string author)
		{
			List<Ksiazka> wynik = new List<Ksiazka>();
			foreach (Ksiazka ksiazka in ksiazki)
			{
				if (ksiazka.Autor == author)
				{
					wynik.Add(ksiazka);
				}
			}
			return wynik;
		}

		public string jsonDelete(string Id)
		{
			int intId = int.Parse(Id);
			int idx = ksiazki.FindIndex(b => b.Id == intId);
			if (idx == -1)
				return "Nie mozna usunac ksiazki o id=" + Id;
			ksiazki.RemoveAt(idx);
			return "Usunieto ksiazke o indexie= " + Id;
		}
	}
}
