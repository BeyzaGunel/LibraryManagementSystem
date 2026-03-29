using System;
namespace KutuphaneSistemi
{
    public class Kitap
    {
        public required string Ad { get; set; }
        public required string Yazar { get; set; }
        public int SayfaSayisi { get; set;}

        public void BilgiYazdir()
        {
            Console.WriteLine($"- Kitap: {Ad} | Yazar. {Yazar} | Sayfa: {SayfaSayisi}");
        }
    }
}