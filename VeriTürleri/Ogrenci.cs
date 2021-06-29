using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriTürleri
{
    public struct Ogrenci
    {
        //struck yapıları değer tiplidir!

        public Ogrenci(int numara, string adi, string soyadi, bool cinsiyet=true)
        {
            Numara = numara;
            Adi = adi;
            Soyadi = soyadi;
            Cinsiyet = cinsiyet;
        }

        public int Numara { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public bool Cinsiyet { get; set; }

        public override string ToString()
        {
            return $"{Numara,-5} {Adi,-10} {Soyadi,-10}" + string.Format("{0,-8}", Cinsiyet == true ? "Erkek" : "Kadın");
        }
    }
    public class OgretimElemani
    {
        public int SicilNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public bool Cinsiyet { get; set; }
        public OgretimElemani()
        {

        }

        public OgretimElemani(int sicilNo, string adi, string soyadi, bool cinsiyet)
        {
            SicilNo = sicilNo;
            Adi = adi;
            Soyadi = soyadi;
            Cinsiyet = cinsiyet;
        }

        public override string ToString()
        {
            return $"{SicilNo,-5} {Adi,-10} {Soyadi,-10}" + 
                string.Format("{0,-8}", Cinsiyet == true ? "Erkek" : "Kadın");
        }
    }
}
