class Sarkici
{
    public string Ad { get; set; }
    public string Tur { get; set; }
    public int CikisYili { get; set; }
    public double AlbumSatisi { get; set; }
}

class Program
{
    static void Main()
    {
        List<Sarkici> sarkicilar = new List<Sarkici>
        {
            new Sarkici { Ad = "Selena Gomez", Tur = "Pop", CikisYili = 2008, AlbumSatisi = 20 },
            new Sarkici { Ad = "Shakira", Tur = "Pop", CikisYili = 1990, AlbumSatisi = 75 },
            new Sarkici { Ad = "Madonna", Tur = "Pop", CikisYili = 1983, AlbumSatisi = 300 },
            new Sarkici { Ad = "Michael Jackson", Tur = "Pop", CikisYili = 1964, AlbumSatisi = 350 },
            new Sarkici { Ad = "Eminem", Tur = "Rap", CikisYili = 1996, AlbumSatisi = 220 },
            new Sarkici { Ad = "Britney Spears", Tur = "Pop", CikisYili = 1998, AlbumSatisi = 100 },
            new Sarkici { Ad = "Adele", Tur = "Pop", CikisYili = 2006, AlbumSatisi = 120 },
            new Sarkici { Ad = "Taylor Swift", Tur = "Pop", CikisYili = 2006, AlbumSatisi = 200 },
            new Sarkici { Ad = "Elvis Presley", Tur = "Rock", CikisYili = 1954, AlbumSatisi = 600 },
            new Sarkici { Ad = "The Weeknd", Tur = "R&B", CikisYili = 2010, AlbumSatisi = 75 },
            new Sarkici { Ad = "Snoop Dogg", Tur = "Rap", CikisYili = 1992, AlbumSatisi = 35 }
        };

        var sIleBaslayanlar = sarkicilar.Where(s => s.Ad.StartsWith("S"));
        Console.WriteLine("Adı 'S' ile başlayan şarkıcılar: " + string.Join(", ", sIleBaslayanlar.Select(s => s.Ad)));

        var onMilyonUstu = sarkicilar.Where(s => s.AlbumSatisi > 10);
        Console.WriteLine("Albüm satışları 10 milyon'un üzerinde olan şarkıcılar: " + string.Join(", ", onMilyonUstu.Select(s => s.Ad)));

        var eskiPopSarkicilari = sarkicilar
            .Where(s => s.CikisYili < 2000 && s.Tur == "Pop")
            .OrderBy(s => s.CikisYili)
            .ThenBy(s => s.Ad);
        Console.WriteLine("2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar: ");
        foreach (var grup in eskiPopSarkicilari.GroupBy(s => s.CikisYili))
        {
            Console.WriteLine($"{grup.Key} yılı:");
            foreach (var sarkici in grup)
                Console.WriteLine($"  {sarkici.Ad}");
        }

        var enCokSatan = sarkicilar.OrderByDescending(s => s.AlbumSatisi).First();
        Console.WriteLine($"En çok albüm satan şarkıcı: {enCokSatan.Ad}");

        var enYeni = sarkicilar.OrderByDescending(s => s.CikisYili).First();
        var enEski = sarkicilar.OrderBy(s => s.CikisYili).First();
        Console.WriteLine($"En yeni çıkış yapan şarkıcı: {enYeni.Ad}, {enYeni.CikisYili}");
        Console.WriteLine($"En eski çıkış yapan şarkıcı: {enEski.Ad}, {enEski.CikisYili}");
    }
}
