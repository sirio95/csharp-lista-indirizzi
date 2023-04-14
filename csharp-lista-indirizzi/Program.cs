using System;
using System.IO;
using System.Xml.Linq;
using static csharp_lista_indirizzi.Program;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Indirizzo> TuttiGliIndirizzi = getText("C:\\Users\\sundi\\source\\repos\\csharp-lista-indirizzi\\addresses.csv");
            foreach (Indirizzo idn in TuttiGliIndirizzi)
            {
                idn.StampaVideo();
            }
            
        }

        public class Indirizzo
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Province { get; set; }
            public string ZIP { get; set; }

            public Indirizzo(string name, string surname, string street, string city, string province, string zip)
            {
                try
                {
                    Name = name;
                    Surname = surname;
                    Street = street;
                    City = city;
                    Province = province;
                    ZIP = zip;
                }
                catch (Exception e)
                { 
                    if(name == null)
                    {
                        Console.WriteLine("Il nome non può essere nullo");
                    }
                    else if(surname == null)
                    {
                        Console.WriteLine("Il cognome non può essere nullo");
                    }
                    else if(street == null)
                    {
                        Console.WriteLine("La strada non può essere nulla");
                    }
                    else if(city == null)
                    {
                        Console.WriteLine("La città non può essere nulla");
                    }
                    else if(province == null)
                    {
                        Console.WriteLine("La provincia non può essere nulla");
                    }
                    else
                    {
                        Console.WriteLine("Il codice postale non può essere nullo");
                    }
                }
            }

            public void StampaVideo()
            {
                Console.WriteLine($"{Name} - {Surname} - {Street} - {City} - {Province} - {ZIP}");
            }
        }

        public static List<Indirizzo> getText(string path)
        {

            List<Indirizzo> AllAddress= new List<Indirizzo>();
            string[] textLines;            
            textLines= File.ReadAllLines(path);

            foreach(string line in textLines)
            {
                int separatore = line.IndexOf(',');
                string nome = line.Substring(0, separatore);
                string cognome =line.Substring(separatore+1);
                string strada = line.Substring(separatore + 2);
                string città = line.Substring(separatore + 3);
                string provincia= line.Substring(separatore + 4);
                string zip = line.Substring (separatore + 5);


                Indirizzo newIndirizzo = new Indirizzo(nome, cognome, strada, città, provincia, zip);
                AllAddress.Add(newIndirizzo);
            }
            return AllAddress;
        }
    }
}