using KutuphaneSistemi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace KutuphaneSistemi
{
    class Program
    {
        static List<Kitap> kitapListesi = new List<Kitap>();
        static void Main(string[] args)
        {
            VerileriYukle();
            Console.Title = "ProjeK - Kütüphane Sisemi";
            bool devamEdilsinMi = true;

            while (devamEdilsinMi)
            {
                Console.Clear();
                Console.WriteLine("Kütüphane Yönetim Sistemi");
                Console.WriteLine("1.Kitap Ekle");
                Console.WriteLine("2.Kitaplari Listele");
                Console.WriteLine("3.Çıkış");
                Console.WriteLine("\nSeçiminiz: ");

                string secim = Console.ReadLine() ?? "";

                switch (secim)

                {
                    case "1":
                        KitapEkle();
                        break;
                    case "2":
                        KitaplariListele();
                        break;
                    case "3":
                        Console.WriteLine("Veriler kaydediliyor ve çıkış yapılıyor...");
                        VerileriKaydet();
                        devamEdilsinMi = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim, devam etmek için bir tuşa basın.");
                        Console.ReadKey();
                        break;
                }

            }
        }
        static void KitapEkle()
        {
            Console.Write("Kitap Adı:");
            string adGiris = Console.ReadLine() ?? "İsimisiz";

            Console.Write("Yazarı.:");
            string yazarGiris = Console.ReadLine() ?? "Yazarsız";

            int sayfa;
            Console.Write("Sayfa Sayısı:");
            while (!int.TryParse(Console.ReadLine(), out sayfa) || sayfa <= 0)
            {
                Console.Write("Hata! Lütfen geçerli bir sayfa sayısı giriniz:");
            }
            Kitap yeniKitap = new Kitap
            {
                Ad = adGiris,
                Yazar = yazarGiris,
                SayfaSayisi = sayfa
            };

            kitapListesi.Add(yeniKitap);
            Console.WriteLine("\nKitap başarıyla eklendi. Menüye dönmek için bir tuşa basın.");
            Console.ReadKey();
        }
        static void KitaplariListele()
        {
            Console.WriteLine("\n--Kayıtlı kitaplar --");

            if (kitapListesi.Count == 0)
            {
                Console.WriteLine("Kütüphane şu an boş.");
            }
            else
            {
                foreach (var kitap in kitapListesi)
                {
                    kitap.BilgiYazdir();
                }
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın.");
            Console.ReadKey();
        }
        static void VerileriKaydet()
        {
            List<string> satirlar = new List<string>();
            foreach (var k in kitapListesi)
            {
                satirlar.Add($"{k.Ad};{k.Yazar};{k.SayfaSayisi}");
            }
            File.WriteAllLines("kitaplar.txt", satirlar);
        }

        static void VerileriYukle()
        {
            if (File.Exists("kitaplar.txt"))
            {
                string[] dosyaSatirlari = File.ReadAllLines("kitaplar.txt");
                foreach (var satir in dosyaSatirlari)
                {
                    string[] parcalar = satir.Split(',');
                    if (parcalar.Length == 3)
                    {
                        kitapListesi.Add(new Kitap
                        {
                            Ad = parcalar[0],
                            Yazar = parcalar[1],
                            SayfaSayisi = int.Parse(parcalar[2])
                        });
                     }
                }
            }
        }
    }
}
