using System;
using System.Collections.Generic;
using System.Text;

namespace OtoGaleriUygulamasi_G019
{
    class Araba
    {
        public string Plaka;
        public string Marka;
        public float KiralamaBedeli;
        public int KiralanmaSayisi
        {
            get
            {
                return this.KiralanmaSureleri.Count;
            }
        }
        public int KiralanmaSuresi
        {
            get
            {
                int toplam = 0;
                foreach (int item in this.KiralanmaSureleri)
                {
                    toplam += item;
                }
                return toplam;
            }
        }
        public List<int> KiralanmaSureleri = new List<int>();
        public ARAC_TIPI AracTipi;
        public DURUM Durum; 
        public float arabaCiro
        {
            get
            {
                float kazanc = 0;
                for (int i = 0; i < KiralanmaSureleri.Count; i++)
                {
                    kazanc += KiralanmaSureleri[i] * KiralamaBedeli;
                }
                return kazanc;
            }
        }
        public Araba(string plaka, string marka, float kiralamaBedeli, ARAC_TIPI aracTipi)
        {
            this.Plaka = plaka.ToUpper();
            this.Marka = marka.ToUpper();
            this.KiralamaBedeli = kiralamaBedeli;
            this.AracTipi = aracTipi;
            this.Durum = DURUM.Galeride;
        }
    }
    public enum ARAC_TIPI
    {
        Empty,
        SUV,
        Hatchback,
        Sedan
    }
    public enum DURUM
    {
        Empty,
        Kirada,
        Galeride
    }
}
