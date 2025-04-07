using System;
using System.Collections.Generic;
using System.Globalization;

class Produkt
{
    public string Nazwa { get; set; }
    public int Ilosc { get; set; }
    public double CenaJednostkowa { get; set; }

    public Produkt(string nazwa, int ilosc, double cenaJednostkowa)
    {
        Nazwa = nazwa;
        Ilosc = ilosc;
        CenaJednostkowa = cenaJednostkowa;
    }

    public override string ToString()
    {
        return $"Nazwa: {Nazwa}, Ilość: {Ilosc}, Cena jednostkowa: {CenaJednostkowa}";
    }
}

class Program
{
    static List<Produkt> magazyn = new List<Produkt>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Dodaj produkt");
            Console.WriteLine("2. Usuń produkt");
            Console.WriteLine("3. Wyświetl listę produktów");
            Console.WriteLine("4. Aktualizuj produkt");
            Console.WriteLine("5. Oblicz wartość magazynu");
            Console.WriteLine("6. Wyjście");

            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    DodajProdukt();
                    break;
                case "2":
                    UsunProdukt();
                    break;
                case "3":
                    WyswietlListeProduktow();
                    break;
                case "4":
                    AktualizujProdukt();
                    break;
                case "5":
                    ObliczWartoscMagazynu();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja, spróbuj ponownie.");
                    break;
            }
        }
    }

    static void DodajProdukt()
    {
        Console.Write("Podaj nazwę produktu: ");
        string nazwa = Console.ReadLine();
        Console.Write("Podaj ilość: ");
        int ilosc = Convert.ToInt32(Console.ReadLine());
        Console.Write("Podaj cenę jednostkową: ");
        double cenaJednostkowa = Convert.ToDouble(Console.ReadLine(), CultureInfo.GetCultureInfo("pl-PL"));

        magazyn.Add(new Produkt(nazwa, ilosc, cenaJednostkowa));
        Console.WriteLine("Produkt dodany pomyślnie.");
    }

    static void UsunProdukt()
    {
        Console.Write("Podaj nazwę produktu do usunięcia: ");
        string nazwa = Console.ReadLine();

        Produkt produktDoUsuniecia = magazyn.Find(p => p.Nazwa == nazwa);
        if (produktDoUsuniecia != null)
        {
            magazyn.Remove(produktDoUsuniecia);
            Console.WriteLine("Produkt usunięty pomyślnie.");
        }
        else
        {
            Console.WriteLine("Produkt nie znaleziony.");
        }
    }

    static void WyswietlListeProduktow()
    {
        Console.WriteLine("Lista produktów:");
        foreach (var produkt in magazyn)
        {
            Console.WriteLine(produkt);
        }
    }

    static void AktualizujProdukt()
    {
        Console.Write("Podaj nazwę produktu do aktualizacji: ");
        string nazwa = Console.ReadLine();

        Produkt produktDoAktualizacji = magazyn.Find(p => p.Nazwa == nazwa);
        if (produktDoAktualizacji != null)
        {
            Console.Write("Podaj nową ilość (lub naciśnij Enter, aby pominąć): ");
            string nowaIlosc = Console.ReadLine();
            if (!string.IsNullOrEmpty(nowaIlosc))
            {
                produktDoAktualizacji.Ilosc = Convert.ToInt32(nowaIlosc);
            }

            Console.Write("Podaj nową cenę jednostkową (lub naciśnij Enter, aby pominąć): ");
            string nowaCena = Console.ReadLine();
            if (!string.IsNullOrEmpty(nowaCena))
            {
                produktDoAktualizacji.CenaJednostkowa = Convert.ToDouble(nowaCena, CultureInfo.GetCultureInfo("pl-PL"));
            }

            Console.WriteLine("Produkt zaktualizowany pomyślnie.");
        }
        else
        {
            Console.WriteLine("Produkt nie znaleziony.");
        }
    }

    static void ObliczWartoscMagazynu()
    {
        double wartoscMagazynu = 0;
        foreach (var produkt in magazyn)
        {
            wartoscMagazynu += produkt.Ilosc * produkt.CenaJednostkowa;
        }
        Console.WriteLine($"Całkowita wartość magazynu: {wartoscMagazynu}");
    }
}
