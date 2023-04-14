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
            List<Indirizzo> TuttiGliIndirizzi = getTextToAddress("C:\\Users\\sundi\\source\\repos\\csharp-lista-indirizzi\\addresses.csv");
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
                    this.Name = name;
                    this.Surname = surname;
                    this.Street = street;
                    this.City = city;
                    this.Province = province;
                    this.ZIP = zip;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            public void StampaVideo()
            {
                Console.WriteLine($"{Name} - {Surname} - {Street} - {City} - {Province} - {ZIP}");
            }
        }

        public static List<Indirizzo> getTextToAddress(string path)
        {

            List<Indirizzo> AllAddress= new List<Indirizzo>();
            string[] textLines;            
            textLines= File.ReadAllLines(path);

            foreach(string line in textLines)
            {
                string[] element = line.Split(",");
                if (element.Length == 6)
                {
                    if (element[0] != "" && element[1] != "" && element[2] != "" && element[3] != "" && element[4] != "" && element[5] != "")
                    {
                        Indirizzo newIndirizzo = new Indirizzo(element[0], element[1], element[2], element[3], element[4], element[5]);
                        AllAddress.Add(newIndirizzo);
                    }                
                    
                }                
            }
            return AllAddress;
        }
    }
}