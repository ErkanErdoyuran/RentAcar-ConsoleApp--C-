using System;

namespace OtoGaleriUygulamasi_G019
{
    class Program
    {
        static Galeri OtoGaleri = new Galeri();
        //Bu classta mümkün olduğunca Araba nesnesini kullanmayalım.
        static void Main(string[] args)
        {
            Uygulama();
        }
        static void Uygulama()
        {
            //SahteVeriGir();
            Menu();
            while (true)
            {
                string secim = SecimAl();
                switch (secim)
                {
                    case "1":
                    case "K":
                        ArabaKirala();
                        break;
                    case "2":
                    case "T":
                        TeslimAl();
                        break;
                    case "3":
                    case "R":
                        KiradakiAraclar();
                        break;
                    case "4":
                    case "M":
                        MusaitAraclar();
                        break;
                    case "5":
                    case "A":
                        TumAraclar();
                        break;
                    case "6":
                    case "I":
                        KiralamaIptal();
                        break;
                    case "7":
                    case "Y":
                        ArabaEkle();
                        break;
                    case "8":
                    case "S":
                        ArabaSil();
                        break;
                    case "9":
                    case "G":
                        BilgileriGoster();
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static string PlakaAl()
        {
            while (true)
            {
                Console.Write("Plaka: ");
                string plaka = Console.ReadLine().ToUpper();
            }
        }
        static bool PlakaUygunMu(string plaka)
        {
            string plakaDevami = plaka.Substring(2);
            if (plaka.Length >= 7 && plaka.Length <= 9)
            {
                if (PlakaIlBilgisiUygunMu(plaka))
                {
                    if (PlakaHarfBilgisiUygunMu(plakaDevami))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static bool PlakaIlBilgisiUygunMu(string plaka)
        {
            string ilBilgisi = plaka.Substring(0, 2);
            int sayi = 0;
            if (int.TryParse(ilBilgisi, out sayi))
            {
                if (sayi > 0 && sayi < 82)
                {
                    return true;
                }
            }
            return false;
        }
        static bool PlakaHarfBilgisiUygunMu(string plakaDevami)
        {
            int sayi = 0;
            int harfsayac = 0;
            int rakamsayac = 0;
            for (int i = 0; i < plakaDevami.Length; i++)
            {
                char karakter = plakaDevami[i];
                if (!int.TryParse(karakter.ToString(), out sayi))
                {
                    harfsayac++;
                }
                else
                {
                    break;
                }
            }
            if (harfsayac >= 1 && harfsayac <= 3)
            {
                string rakamlar = plakaDevami.Substring(harfsayac);
                for (int i = 0; i < rakamlar.Length; i++)
                {
                    char rakam = rakamlar[i];
                    if (!int.TryParse(rakam.ToString(), out sayi))
                    {
                        return false;
                    }
                    rakamsayac++;
                }
                if (harfsayac == 2 && rakamsayac == 5)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        static void ArabaEkle()
        {
            bool kontrol = true;
            Console.WriteLine("-Yeni Araç Ekle-");
            while (kontrol)
            {
                Console.Write("Plaka: ");
                string plaka = Console.ReadLine().ToUpper();
                if (PlakaUygunMu(plaka))
                {
                    if (OtoGaleri.PlakaVarMi(plaka))
                    {
                        Console.WriteLine("Aynı plakada araç mevcut. Girdiğiniz plakayı kontrol edin.");
                    }
                    else
                    {
                        Console.Write("Marka: ");
                        string marka = Console.ReadLine();
                        Console.Write("Kiralama Bedeli: ");
                        float kiralamaBedeli = float.Parse(Console.ReadLine());
                        Console.WriteLine("Araç Tipleri:");
                        Console.WriteLine("- " + ARAC_TIPI.SUV + " için 1");
                        Console.WriteLine("- " + ARAC_TIPI.Hatchback + " için 2");
                        Console.WriteLine("- " + ARAC_TIPI.Sedan + " için 3");
                        bool kontrol1 = true;
                        ARAC_TIPI aracTipi = ARAC_TIPI.Empty;
                        while (kontrol1)
                        {
                            string secim = Console.ReadLine();
                            switch (secim)
                            {
                                case "1":
                                    kontrol1 = false;
                                    aracTipi = ARAC_TIPI.SUV;
                                    break;
                                case "2":
                                    kontrol1 = false;
                                    aracTipi = ARAC_TIPI.Hatchback;
                                    break;
                                case "3":
                                    kontrol1 = false;
                                    aracTipi = ARAC_TIPI.Sedan;
                                    break;
                                default:
                                    Console.WriteLine("Hatalı giriş yapıldı, tekrar deneyin.");
                                    break;
                            }
                        }
                        OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, aracTipi);
                        Console.WriteLine("Araç başarılı bir şekilde eklendi");
                        Console.WriteLine();
                        kontrol = false;
                    }
                }
                else
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                }
            }
        }
        static string SecimAl()
        {
            while (true)
            {
                string secimler = "123456789KTRMAIYSGX";
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine().ToUpper();
                foreach (char item in secimler)
                {
                    if (item.ToString() == secim)
                    {
                        return secim;
                    }
                }
                Console.WriteLine();
            }
        }
        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon");
            Console.WriteLine("1 - Araba Kirala(K)");
            Console.WriteLine("2 - Araba Teslim Al(T)");
            Console.WriteLine("3 - Kiradaki arabaları listele(R)");
            Console.WriteLine("4 - Müsait arabaları listele(M)");
            Console.WriteLine("5 - Tüm arabaları listele(A)");
            Console.WriteLine("6 - Kiralama İptali(I)");
            Console.WriteLine("7 - Yeni araba Ekle(Y)");
            Console.WriteLine("8 - Araba sil(S)");
            Console.WriteLine("9 - Bilgileri göster(G)");
            Console.WriteLine("10 - Çıkış(X)");
            Console.WriteLine();
        }
        static void SahteVeriGir()
        {
            OtoGaleri.ArabaEkle("12aaa22", "BMW", 120, ARAC_TIPI.Sedan);
            OtoGaleri.ArabaEkle("15aaa22", "Opel", 80, ARAC_TIPI.SUV);
            OtoGaleri.ArabaEkle("75aaa22", "FIAT", 60, ARAC_TIPI.Sedan);
            OtoGaleri.ArabaEkle("26aaa22", "VW", 40, ARAC_TIPI.Hatchback);
        }
        static void TumAraclar()
        {
            if (OtoGaleri.Arabalar.Count == 0)
            {
                Console.WriteLine("Listelenecek araba yok.");
            }
            else
            {
                Console.WriteLine("-Tüm Araçlar-");
                Console.Write("Plaka".PadRight(15, ' ') + "Marka".PadRight(15, ' ') + "K. Bedeli".PadRight(15, ' ') + "Araç Tipi".PadRight(15, ' ') + "K. Sayisi".PadRight(15, ' ') + "Durum".PadRight(15, ' '));
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------------------------------");
                foreach (Araba item in OtoGaleri.Arabalar)
                {
                    Console.WriteLine(item.Plaka.PadRight(15, ' ') + item.Marka.PadRight(15, ' ') + item.KiralamaBedeli.ToString().PadRight(15, ' ') + item.AracTipi.ToString().PadRight(15, ' ') + item.KiralanmaSayisi.ToString().PadRight(15, ' ') + item.Durum.ToString());
                }
            }
            Console.WriteLine();
        }
        static void MusaitAraclar()
        {
            if (OtoGaleri.BekleyenAracSayisi == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine("-Müsait Araçlar-");
                Console.WriteLine("Plaka".PadRight(15, ' ') + "Marka".PadRight(15, ' ') + "K. Bedeli".PadRight(15, ' ') + "Araç Tipi".PadRight(15, ' ') + "K. Sayisi".PadRight(15, ' ') + "Durum".PadRight(15, ' '));
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                foreach (Araba item in OtoGaleri.Arabalar)
                {
                    if (item.Durum == DURUM.Galeride)
                    {
                        Console.WriteLine(item.Plaka.PadRight(15, ' ') + item.Marka.PadRight(15, ' ') + item.KiralamaBedeli.ToString().PadRight(15, ' ') + item.AracTipi.ToString().PadRight(15, ' ') + item.KiralanmaSayisi.ToString().PadRight(15, ' ') + item.Durum);
                    }
                }
            }
            Console.WriteLine();
        }
        static void KiradakiAraclar()
        {
            int a = OtoGaleri.KiradakiAracSayisi;
            if (a == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine("-Kiradaki Araçlar-");
                Console.WriteLine("Plaka".PadRight(15, ' ') + "Marka".PadRight(15, ' ') + "K. Bedeli".PadRight(15, ' ') + "Araç Tipi".PadRight(15, ' ') + "K. Sayisi".PadRight(15, ' ') + "Durum".PadRight(15, ' '));
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                foreach (Araba item in OtoGaleri.Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        Console.WriteLine(item.Plaka.PadRight(15, ' ') + item.Marka.PadRight(15, ' ') + item.KiralamaBedeli.ToString().PadRight(15, ' ') + item.AracTipi.ToString().PadRight(15, ' ') + item.KiralanmaSayisi.ToString().PadRight(15, ' ') + item.Durum);
                    }
                }
            }
            Console.WriteLine();
        }
        static void ArabaKirala()
        {
            Console.WriteLine("-Araç Kirala-");
            bool kontrol = true;
            while (kontrol)
            {
                if (OtoGaleri.Arabalar.Count > 0)
                {
                    Console.Write("Kiralanacak aracın plakası: ");
                    string plaka = Console.ReadLine();
                    if (PlakaUygunMu(plaka))
                    {
                        if (OtoGaleri.PlakaVarMi(plaka))
                        {
                            if (OtoGaleri.ArabaKiralanabilirMi(plaka))
                            {
                                Console.Write("Kiralama süresi: ");
                                int kiralamaSuresi = 0;
                                if (!int.TryParse(Console.ReadLine(), out kiralamaSuresi))
                                {
                                    Console.WriteLine("Hatalı giriş yapıldı, tekrar deneyin.");
                                }
                                else
                                {
                                    OtoGaleri.ArabaKirala(plaka, kiralamaSuresi);
                                    Console.WriteLine(plaka + " plakalı araç " + kiralamaSuresi + " saatliğine kiralandı.");
                                    Console.WriteLine();
                                    kontrol = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Araç zaten kirada");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Galeriye ait böyle bir araç yok.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                    }
                }
                else
                {
                    kontrol = false;
                    Console.WriteLine("Galeride araç yok.");
                    Console.WriteLine();
                }
            }
        }
        static void TeslimAl()
        {
            Console.WriteLine("-Araç Teslim-");
            bool kontrol = true;
            while (kontrol)
            {
                if (OtoGaleri.KiradakiAracSayisi > 0)
                {
                    Console.Write("Teslim edilecek aracın plakası: ");
                    string plaka = Console.ReadLine();
                    if (PlakaUygunMu(plaka))
                    {
                        if (OtoGaleri.PlakaVarMi(plaka))
                        {
                            if (OtoGaleri.ArabaKiradaMi(plaka))
                            {
                                OtoGaleri.TeslimAl(plaka);
                                Console.WriteLine("Araç galeride beklemeye alındı.");
                                Console.WriteLine();
                                kontrol = false;
                            }
                            else
                            {
                                Console.WriteLine("Araç zaten galeride.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Galeriye ait böyle bir araç yok");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                    }
                }
                else
                {
                    Console.WriteLine("Kirada araç yok.");
                    Console.WriteLine();
                    kontrol = false;
                }
            }
        }
        static void KiralamaIptal()
        {
            Console.WriteLine("-Kiralama iptali-");
            bool kontrol = true;
            while (kontrol)
            {
                if (OtoGaleri.KiradakiAracSayisi > 0)
                {
                    Console.Write("Kiralaması iptal edilecek aracın plakası: ");
                    string plaka = Console.ReadLine();
                    if (PlakaUygunMu(plaka))
                    {
                        if (OtoGaleri.PlakaVarMi(plaka))
                        {
                            if (OtoGaleri.ArabaKiradaMi(plaka))
                            {
                                OtoGaleri.KiralamaIptal(plaka);
                                Console.WriteLine("İptal gerçekleştirildi.");
                                Console.WriteLine();
                                kontrol = false;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı giriş yapıldı. Araç zaten galeride.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Galeriye ait böyle bir araç yok");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                    }
                }
                else
                {
                    Console.WriteLine("Kirada araç yok.");
                    Console.WriteLine();
                    kontrol = false;
                }
            }
        }
        static void ArabaSil()
        {
            Console.WriteLine("-Araba Sil-");
            bool kontrol = true;
            while (kontrol)
            {
                if (OtoGaleri.Arabalar.Count > 0)
                {
                    Console.Write("Silinmek istenen araç plakasını girin: ");
                    string plaka = Console.ReadLine();
                    if (PlakaUygunMu(plaka))
                    {
                        if (OtoGaleri.PlakaVarMi(plaka))
                        {
                            if (!OtoGaleri.ArabaKiradaMi(plaka))
                            {
                                OtoGaleri.AracSil(plaka);
                                Console.WriteLine("Araç silindi.");
                                Console.WriteLine();
                                kontrol = false;
                            }
                            else
                            {
                                Console.WriteLine("Araç kirada olduğu için silme işlemi gerçekleştirilemedi.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Silinecek araç bulunamadı.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                    }
                }
                else
                {
                    kontrol = false;
                    Console.WriteLine("Galeride silinecek araç yok.");
                    Console.WriteLine();
                }
            }
        }
        static void BilgileriGoster()
        {
            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine("Toplam Araç Sayısı: " + OtoGaleri.ToplamAracSayisi);
            Console.WriteLine("Kiradaki Araç Sayısı: " + OtoGaleri.KiradakiAracSayisi);
            Console.WriteLine("Bekleyen Araç Sayısı: " + OtoGaleri.BekleyenAracSayisi);
            Console.WriteLine("Toplam araç kiralama süresi: " + OtoGaleri.ToplamAracKiralanmaSuresi);
            Console.WriteLine("Toplam araç kiralama adeti: " + OtoGaleri.ToplamAracKiralanmaAdedi);
            Console.WriteLine("Ciro: " + OtoGaleri.Ciro);
            Console.WriteLine();
        }
    }
}
