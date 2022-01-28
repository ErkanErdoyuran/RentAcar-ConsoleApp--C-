using System;
using System.Collections.Generic;
using System.Text;

namespace OtoGaleriUygulamasi_G019
{
    class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();

        public int ToplamAracSayisi
        {
            get
            {
                return Arabalar.Count;
            }
        }
        public int KiradakiAracSayisi
        {
            get
            {
                int adet = 0;

                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        adet++;
                    }
                }
                return adet;
            }
        }

        public int BekleyenAracSayisi
        {
            get
            {
                return ToplamAracSayisi - KiradakiAracSayisi;
            }
        }
        public int ToplamAracKiralanmaSuresi
        {
            get
            {
                int kiralanmaSuresi = 0;
                foreach (Araba item in Arabalar)
                {
                    kiralanmaSuresi += item.KiralanmaSuresi;
                }
                return kiralanmaSuresi;
            }
        }
        public int ToplamAracKiralanmaAdedi
        {
            get
            {
                int kiralanmaAdeti = 0;
                foreach (Araba item in Arabalar)
                {
                    kiralanmaAdeti += item.KiralanmaSayisi;
                }
                return kiralanmaAdeti;
            }
        }

        public float Ciro
        {
            get
            {
                float toplam = 0;
                foreach (Araba item in Arabalar)
                {
                    toplam += item.arabaCiro;
                }
                return toplam;
            }
        }


        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, ARAC_TIPI aracTipi)
        {
            Arabalar.Add(new Araba(plaka, marka, kiralamaBedeli, aracTipi));
        }

        public void ArabaKirala(string plaka, int sure)
        {
            //listede bu plakarı aracı arayacak
            Araba araba = ArabaGetir(plaka);

            if (araba != null)
            {
                araba.KiralanmaSureleri.Add(sure);
                araba.Durum = DURUM.Kirada;
            }
        }
        public bool ArabaKiralanabilirMi(string plaka)
        {
            Araba a = null;
            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    a = item;
                }
            }
            if(a.Durum==DURUM.Galeride)
            {
                return true;
            }
            return false;
        }
        public bool PlakaVarMi(string plaka)
        {
            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
        public bool ArabaKiradaMi(string plaka)
        {
            Araba araba = ArabaGetir(plaka);
            if (araba.Durum == DURUM.Kirada)
            {
                return true;
            }
            return false;
        }
        public Araba ArabaGetir(string plaka)
        {
            Araba a = null;
            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    a = item;
                }
            }
            return a;
        }
        public void TeslimAl(string plaka)
        {
            Araba araba = ArabaGetir(plaka);
            araba.Durum = DURUM.Galeride;
        }
        public void KiralamaIptal(string plaka)
        {
            Araba araba = ArabaGetir(plaka);

            if (araba != null)
            {
                araba.KiralanmaSureleri.RemoveAt(araba.KiralanmaSureleri.Count - 1);
                araba.Durum = DURUM.Galeride;
            }
        }
        public void AracSil(string plaka)
        {
            Araba araba = ArabaGetir(plaka);
            Arabalar.Remove(araba);
        }
    }
}
