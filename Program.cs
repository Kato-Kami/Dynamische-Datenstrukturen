using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Koffer_Dynamische_Datenstrukturen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Luggage
    {
        public double Weight { get; private set; }
        public string Description { get; private set; }

        public Luggage(double weight, string description)
        {
            Weight = weight;
            Description = description;
        }
    }

    public class Suitcase
    {
        private double maxWeight;
        private List<Luggage> luggageItems;

        public Suitcase(double maxWeight)
        {
            this.maxWeight = maxWeight;
            luggageItems = new List<Luggage>();
        }

        public bool GepäckHinzufügen(Luggage luggage)
        {
            if (this.Weight + luggage.Weight <= maxWeight)
            {
                luggageItems.Add(luggage);
                return true;
            }
            return false;
        }

        public Luggage GepäckEntfernen(string description)
        {
            for (int i = 0; i < luggageItems.Count; i++)
            {
                if (luggageItems[i].Description == description)
                {
                    Luggage removedItem = luggageItems[i];
                    luggageItems.RemoveAt(i);
                    return removedItem;
                }
            }
            return null;
        }

        public double Weight
        {
            get
            {
                return luggageItems.Sum(item => item.Weight);
            }
        }

        public void GetAllLuggage()
        {
            foreach (var item in luggageItems)
            {
                Console.WriteLine(item.Description);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Suitcase suitcase = new Suitcase(20);  // Der Koffer kann maximal 20 kg aufnehmen

            Luggage item1 = new Luggage(5, "Shirts");
            Luggage item2 = new Luggage(8, "Schuhe");
            Luggage item3 = new Luggage(23, "Bücher");
            Luggage item4 = new Luggage(10, "Laptop");

            // Einfügen der Gegenstände mit detaillierter Ausgabe
            Console.WriteLine($"Füge {item1.Description} hinzu: {suitcase.GepäckHinzufügen(item1)}");  // True
            Console.WriteLine($"Füge {item2.Description} hinzu: {suitcase.GepäckHinzufügen(item2)}");  // True
            Console.WriteLine($"Füge {item3.Description} hinzu: {suitcase.GepäckHinzufügen(item3)}");  // False, da Gesamtgewicht 20 kg überschreiten würde
            Console.WriteLine($"Füge {item4.Description} hinzu: {suitcase.GepäckHinzufügen(item4)}");  // False, da Gesamtgewicht 20 kg überschreiten würde

            // Aktuelles Gesamtgewicht des Koffers
            Console.WriteLine("Derzeitiges Gesamtgewicht: " + suitcase.Weight);  // 13

            // Entfernen eines Gegenstands
            Luggage removedItem = suitcase.GepäckEntfernen("Shoes");
            Console.WriteLine("Entfernter Gegenstand: " + (removedItem != null ? removedItem.Description : "None"));  // Shoes

            // Aktuelles Gesamtgewicht des Koffers nach dem Entfernen
            Console.WriteLine("Derzeitiges Gesamtgewicht: " + suitcase.Weight);  // 5

            // Alle Gegenstände im Koffer ausgeben
            Console.WriteLine("Derzeit befinden sich im Koffer:");
            suitcase.GetAllLuggage();  // Shirts
        }
    }





    //class Luggage
    //{
    //    public double Weight { get; set; }
    //    public string Description { get; set; }

    //    public Luggage(double maxweight, string description)
    //    {
    //        maxweight = this.Weight;
    //        description = this.Description;
    //    }
    //}

    //class Suitcase
    //{
    //    double maxweight;
    //    private List<Luggage> luggagecontents;

    //    public Suitcase(double maxweight)
    //    {
    //        this.maxweight = maxweight;
    //        luggagecontents = new List<Luggage>();
    //    }

    //    public bool InsertLuggage(Luggage luggage)
    //    {
    //        if (this.Weight + luggage.Weight <= maxweight)
    //        {
    //            luggagecontents.Add(luggage);
    //            return true;
    //        }
    //        return false;
    //    }

    //    public Luggage RemoveLuggage(string description)
    //    {
    //        for (int i = 0; i < luggagecontents.Count; i++)
    //        {
    //            if (luggagecontents[i].Description == description)
    //            {
    //                Luggage removedItem = luggagecontents[i];
    //                luggagecontents.RemoveAt(i);
    //                return removedItem;
    //            }
    //        }
    //        return null;
    //    }

    //    public double Weight
    //    {
    //        get
    //        {
    //            return luggagecontents.Sum(item => item.Weight);
    //        }
    //    }

    //    public void GetAllLuggage()
    //    {
    //        foreach (var item in luggagecontents)
    //        {
    //            Console.WriteLine(item.Description);
    //        }
    //    }
    //}





    //internal class Programm
    //    {
    //        static void Main(string[] args)
    //        {
    //            Suitcase suitcase = new Suitcase(5);  // Der Koffer kann maximal 20 kg aufnehmen

    //            Luggage item1 = new Luggage(5, "Shirts");
    //            Luggage item2 = new Luggage(8, "Shoes");
    //            Luggage item3 = new Luggage(7, "Books");
    //            Luggage item4 = new Luggage(10, "Laptop");

    //            // Einfügen der Gegenstände
    //            Console.WriteLine(suitcase.InsertLuggage(item1));  // True
    //            Console.WriteLine(suitcase.InsertLuggage(item2));  // True
    //            Console.WriteLine(suitcase.InsertLuggage(item3));  // False, da Gesamtgewicht 20 kg überschreiten würde
    //            Console.WriteLine(suitcase.InsertLuggage(item4));  // False, da Gesamtgewicht 20 kg überschreiten würde

    //            // Aktuelles Gesamtgewicht des Koffers
    //            Console.WriteLine("Current total weight: " + suitcase.Weight);  // 13

    //            // Entfernen eines Gegenstands
    //            Luggage removedItem = suitcase.RemoveLuggage("Shoes");
    //            Console.WriteLine("Removed item: " + (removedItem != null ? removedItem.Description : "None"));  // Shoes

    //            // Aktuelles Gesamtgewicht des Koffers nach dem Entfernen
    //            Console.WriteLine("Current total weight: " + suitcase.Weight);  // 5

    //            // Alle Gegenstände im Koffer ausgeben
    //            suitcase.GetAllLuggage();  // Shirts
    //         }
    //}
}






















