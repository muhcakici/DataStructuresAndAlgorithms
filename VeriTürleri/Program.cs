using System;
using System.Collections;
using System.Collections.Generic;

namespace VeriTürleri
{
    class Program
    {

        static void Main(string[] args)
        {
            
            
            Console.ReadKey();
        }
        public static void BubbleSort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[j+1])>0)
                    {
                        //Swap(array, j, j + 1);
                    }
                }
            }
            //private static void Swap<T>(T[] array, int first, int second)
            //{
            //    T temp = array[first];
            //    array[first] = array[second];
            //    array[second] = temp;
            //}

        }

        public static int[] SelectionSort(int[] Array)
        {
            //main
            var arr = new int[] { 15, 10, 25, 35, 70, 80 };
            foreach (var item in arr)
            {
                Console.WriteLine($"{item,5}");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-',50));
            SelectionSort(arr);
            foreach (var item in arr)
            {
                Console.WriteLine($"{item,5}");
            }
            //tanımlama
            int minIndex;
            int len = Array.Length - 1;
            for (int i = 0; i < len; i++)
            {
                minIndex = i;
                int minValue = Array[minIndex];
                for (int j = 0; j < len; j++)
                {
                    if (minValue > Array[j + 1])
                    {
                        minValue = Array[j + 1];
                        minIndex = j + 1;
                    }
                }

                if (i != minIndex)
                {
                    int temp = Array[i];
                    Array[i] = Array[minIndex];
                    Array[minIndex] = temp;
                }
            }
            return Array;
        }

        private static void HashSetUygulaması()
        {
            //HashSet
            //Tanımlama
            var sesliHarf = new HashSet<char>()
            {
                'e','ı','i','o','ö','u','ü','b'
        };
            //ekleme
            sesliHarf.Add('a');
            Console.WriteLine();
            foreach (var k in sesliHarf)
            {
                Console.Write($"{k,5}");
            }
            Console.WriteLine();
            Console.WriteLine("Eleman sayısı:{0}", sesliHarf.Count);
            //çıkarma
            sesliHarf.Remove('b');
            Console.WriteLine();
            foreach (var k in sesliHarf)
            {
                Console.Write($"{k,5}");
            }
            Console.WriteLine();
            Console.WriteLine("Eleman sayısı:{0}", sesliHarf.Count);

            var alfabe = new List<char>();
            for (int i = 97; i < 123; i++)
            {
                alfabe.Add((char)i);
            }
            alfabe.ForEach(a => Console.WriteLine(a));
        }

        private static void SortedSetKümeUygulaması()
        {
            var A = new SortedSet<int>() { 1, 2, 3, 4 };
            var B = new SortedSet<int>() { 1, 2, 5, 6 };

            // union(birleşme)

            A.UnionWith(B);

            //AUnionWithB (kesişim)
            A.IntersectWith(B);

            //sadece A da olan elemanlar
            A.ExceptWith(B);

            //kesişim dışında olanlar
            A.SymmetricExceptWith(B);
        }

        private static void SortedSetUygulaması2()
        {
            //SortedSet
            var sayilar = new List<int>();
            var r = new Random();

            Console.WriteLine();
            for (int i = 0; i < 1000; i++)
            {
                sayilar.Add(r.Next(5, 25));
                Console.Write($"{sayilar[i],-5}");
            }
            Console.WriteLine();

            //listedeki benzersiz elemanları bulma

            var benzersizSayiListesi = new SortedSet<int>(sayilar);

            Console.WriteLine("\nBenzersiz Sayıların Listesi\n");
            foreach (var s in benzersizSayiListesi)
            {
                Console.WriteLine($"{s,-3}");
            }
            Console.WriteLine("\nBenzersiz {0} sayı var", benzersizSayiListesi.Count);
        }

        private static void SortedSetUygulaması()
        {
            //sortedSet

            var list = new SortedSet<string>();

            //ekleme
            if (list.Add("Mehmet"))
            {
                Console.WriteLine("Mehmet Eklendi");
            }
            else
            {
                Console.WriteLine("Ekleme Başarısız");
            }


            Console.WriteLine("{0}", list.Add("Ahmet") == true ?
                "Ahmet Eklendi" : "Ekleme Başarısız");
            list.Add("Şule");
            list.Add("Neslihan");
            list.Add("Fahrettin");
            list.Add("Fatih");

            //silme
            list.Remove("Şule");
            list.RemoveWhere(deger => deger.Contains("A"));

            Console.WriteLine("\nİsimler Listesi");
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Eleman sayisi     :{0,3}", list.Count);
        }

        private static void SortedDictionaryOrnegi()
        {
            //sortedDictionary

            var kitapIndeks = new SortedDictionary<string, List<int>>()
            {
                {"HTML",new List<int>(){8,10,12} },
                {"CSS",new List<int>(){70,80,90} },
                {"JQuery",new List<int>(){3,5,15} },
                {"SQL",new List<int>(){70,80} },

            };

            kitapIndeks.Add("FTP", new List<int>() { 3, 5, 7 });
            kitapIndeks.Add("ASP.NET", new List<int>() { 50, 60 });

            foreach (var kavram in kitapIndeks)
            {
                Console.WriteLine(kavram.Key);
                kavram.Value.ForEach(s => Console.WriteLine($"\t{s,-5} pp"));
            }
        }

        private static void DictionaryUygulama2()
        {
            //dictionary
            var personelListesi = new Dictionary<int, Personel>()
            {
                {110,new Personel("Mehmet","Sonsoz",7500) },
                {120,new Personel("Ahmet","Can",9000) },
            };
            personelListesi.Add(100, new Personel("Zeynep", "Aslan", 5000));
            foreach (var p in personelListesi)
            {
                Console.WriteLine(p);
            }
        }

        private static void DictionaryTemeller()
        {
            //Dictionary Temeller

            var telefonKodlari = new Dictionary<int, string>()
            {
                {322,"Konya"},
                {344,"Kahramanmaraş" },
                {466,"Art" },
                {422,"Malatya" }
            };
            //ekleme
            telefonKodlari.Add(312, "Ankara");
            telefonKodlari.Add(212, "İstanbul");
            telefonKodlari.Add(216, "İstanbul");

            //erişme
            telefonKodlari[466] = "Artvin";

            //containKey

            if (!telefonKodlari.ContainsKey(352))
            {
                Console.WriteLine("\aKayseri'nın kod bilgisi tanımlı değil!");
                telefonKodlari.Add(352, "Kayseri");
                Console.WriteLine("Yeni kod eklendi");
            }

            //containsValue
            if (!telefonKodlari.ContainsValue("Malatya"))
            {
                Console.WriteLine("\aMalatyanın kod bilgisi tanımlı değil");
                telefonKodlari.Add(422, "Malatya");
                Console.WriteLine("Yeni Kod Eklendi");
            }

            telefonKodlari.Remove(322);
            foreach (var s in telefonKodlari)
            {
                Console.WriteLine(s);
            }
        }

        private static void LinkedListTemelleri()
        {
            //LinkedList Temelleri
            //tanımlama
            var sehirler = new LinkedList<string>();
            sehirler.AddFirst("Ordu"); // ilk düğüm
            sehirler.AddFirst("Trabzon"); //ilk duğüm oldu.
            sehirler.AddLast("İstanbul");
            sehirler.AddBefore(sehirler.First.Next.Next, "Giresun");
            sehirler.AddAfter(sehirler.Find("Ordu"), "Samsun");
            sehirler.AddAfter(sehirler.Last.Previous, "Sinop");
            sehirler.AddAfter(sehirler.Find("Sinop"), "Zonguldak");
            foreach (var s in sehirler)
            {
                Console.WriteLine(s);
            }
        }

        private static void QueueKuyrukUygulaması()
        {
            var sesliHarfler = new List<char>()
            {
                'a','e','ı','i','o','ö','u','ü'
            };
            ConsoleKeyInfo secim;
            var kuyruk = new Queue<char>();
            foreach (var k in sesliHarfler)
            {
                Console.WriteLine();
                Console.Write($"{k,-5} ifadesi kuyruğa eklensin mi? [e/h] ");
                secim = Console.ReadKey();
                Console.WriteLine();
                if (secim.Key == ConsoleKey.E)
                {
                    kuyruk.Enqueue(k);
                    Console.WriteLine($"\n{k,-5} kuyruğa eklendi.");
                    Console.WriteLine($"Kuyruktaki eleman sayısı: {kuyruk.Count}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Kuyruktan elemanların kaldırılması için Esc tuşuna basın.");
            secim = Console.ReadKey();
            if (secim.Key == ConsoleKey.Escape)
            {
                Console.WriteLine();
                while (kuyruk.Count > 0)
                {
                    Console.WriteLine($"{kuyruk.Peek(),5} kuyruktan çıkartılıyor.");
                    Console.WriteLine($"{kuyruk.Dequeue(),5} kuyruktan çıkarıldı.");
                    Console.WriteLine($"Kuyruktaki eleman sayısı: {kuyruk.Count}");

                }
                Console.WriteLine("\nKuyruktan çıkarma işlemi tamamlandı.");
            }
            Console.WriteLine("Program Bitti.");
        }

        private static void QueueKuyrukTemelleri()
        {
            //Queue
            //Tanımlama
            var karakterKuyrugu = new Queue<char>();
            //ekleme
            karakterKuyrugu.Enqueue('a');
            karakterKuyrugu.Enqueue('e');
            Console.WriteLine($"Eleman Sayısı : {karakterKuyrugu.Count}");
            //çıkarma
            Console.WriteLine($"Kuyruğun başındaki eleman:{karakterKuyrugu.Peek()}");
            Console.WriteLine($"{karakterKuyrugu.Dequeue()} kuyruktan çıkarıldı.");
            Console.WriteLine($"Eleman Sayısı : {karakterKuyrugu.Count}");
            Console.WriteLine($"Kuyruğun başındaki eleman:{karakterKuyrugu.Peek()}");
        }

        private static void StackOrnegiBasamakAyrıstırma()
        {
            Console.WriteLine("Bir sayı giriniz:");
            int sayi = Convert.ToInt32(Console.ReadLine());

            var sayiYigini = new Stack<int>();
            while (sayi > 0)
            {
                int k = sayi % 10;
                sayiYigini.Push(k);
                sayi = sayi / 10;

            }
            int i = 0;
            int n = sayiYigini.Count - 1;
            foreach (var s in sayiYigini)
            {
                Console.WriteLine($"\t{s,7} x" +
                    $" {Math.Pow(10, n - i),7}\t=" +
                    $"{s * Math.Pow(10, n - i),7}");
                i++;
            }
        }

        private static void StackYiginOrnegiAsci()
        {
            //Asci kod örneği STACK

            var karakterYigini = new Stack<char>();
            for (int i = 65; i <= 90; i++)
            {
                karakterYigini.Push((char)i);
                Console.WriteLine($"{karakterYigini.Peek()} yığına eklendi. ");
                Console.WriteLine($"Yığındaki eleman sayısı: {karakterYigini.Count}");
            }
            Console.WriteLine("Yığından çıkarma işlemi için bir tuşa basın.");
            Console.ReadKey();

            while (karakterYigini.Count > 0)
            {
                Console.WriteLine($"{karakterYigini.Pop()} yığından çıkarıldı.");
                Console.WriteLine($"Yığındaki eleman sayısı: {karakterYigini.Count}");

            }
        }

        private static void YiginOrnegi()
        {
            //Stack tanımlama
            var karakterYigini = new Stack<char>();

            //Ekleme
            karakterYigini.Push('A');
            Console.WriteLine(karakterYigini.Peek());
            karakterYigini.Push('B');
            Console.WriteLine(karakterYigini.Peek());
            karakterYigini.Push('C');
            Console.WriteLine(karakterYigini.Peek());

            //Çıkarma
            Console.WriteLine(karakterYigini.Pop() + " yığından çıkarıldı.");
            Console.WriteLine(karakterYigini.Pop() + " yığından çıkarıldı.");
            Console.WriteLine(karakterYigini.Pop() + " yığından çıkarıldı.");
        }

        private static void ListOrnegi()
        {
            var sayilar = new List<int>() { 46, 33, 25, 98, 75, 15 };
            sayilar.Sort(); //siralama
            sayilar.ForEach(s => Console.WriteLine(s));

            var sehirler = new List<Sehir>()
            {
                new Sehir(6,"Ankara"),
                new Sehir(34,"İstanbul"),
                new Sehir(38,"Kayseri"),
                new Sehir(55,"Samsun"),
                new Sehir(10,"Balıkesir"),
                new Sehir(1,"Adana"),
            };
            sehirler.Add(new Sehir(46, "Kahramanmaraş"));
            sehirler.Sort();
            sehirler.ForEach(s => Console.WriteLine(s));
        }

        private static void SortedListUygulamasıKitapIcindekiler()
        {
            var kitapIcerigi = new SortedList();
            kitapIcerigi.Add(1, "Önsöz");
            kitapIcerigi.Add(50, "Değişkenler");
            kitapIcerigi.Add(40, "Döngüler");
            kitapIcerigi.Add(60, "Operatörler");
            kitapIcerigi.Add(45, "İlişkisel Operatörler");

            Console.WriteLine("İçindekiler");
            Console.WriteLine(new string('-', 25));

            foreach (DictionaryEntry item in kitapIcerigi)
            {
                Console.WriteLine($"{item.Value,-30}  {item.Key,-5}");
            }
        }

        private static void SortedListYapısı()
        {
            //SortedList Yapısı


            //tanımlama
            var list = new SortedList()
            {
                {1,"Bir"},
                {2,"İki"},
                {3,"Üç"},
                {8,"Sekiz"},
                {5,"Beş"},
                {6,"Altı"},
            };
            //ekleme
            list.Add(4, "Dört");
            list.Add(7, "Yedi");
            //Dolasma
            foreach (DictionaryEntry item in list)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.WriteLine("Listedeki eleman sayısı:{0}", list.Count);
            Console.WriteLine("Listenin kapasitesi:{0}", list.Capacity);
            list.TrimToSize();//kapasiteyi set eder.
            Console.WriteLine("Listenin kapasitesi:{0}", list.Capacity);

            //elemana erişme keyle
            Console.WriteLine(list[6]);
            //elemana erişme indexle
            Console.WriteLine(list.GetByIndex(0));
            //get key
            Console.WriteLine(list.GetKey(0));
            //liste sonundaki elemanın degeri
            Console.WriteLine(list.GetByIndex(list.Count - 1));
            //liste sonundaki elemanın keyi
            Console.WriteLine(list.GetKey(list.Count - 1));

            var anahtarlar = list.Keys;
            //anahtarları alma
            Console.WriteLine("\nAnahtarlar");
            foreach (var item in anahtarlar)
            {
                Console.WriteLine(item);
            }
            //değerleri alma
            var degerler = list.Values;
            Console.WriteLine("\nDeğerler");
            foreach (var item in degerler)
            {
                Console.WriteLine(item);
            }

            //keye bağlı güncelleme
            Console.WriteLine("\nGüncelleme");
            if (list.ContainsKey(1))
            {
                list[1] = "One";
            }
            foreach (DictionaryEntry item in list)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            //keye baglı silme
            Console.WriteLine("\nSilme");
            list.Remove(6);

            foreach (DictionaryEntry item in list)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }

        private static void HashtableUygulamasıAnlamlıURLeldeEtme()
        {
            //Hashtable Uygulaması Anlamlı URL elde etme
            Console.WriteLine("Başlık Giriniz:");
            string baslik = Console.ReadLine();
            baslik = baslik.ToLower();
            var karakterSeti = new Hashtable()
            {
                {'ç','c' },
                {'ı','i' },
                {'ö','o' },
                {'ü','u' },
                {'ğ','g' },
                {' ','-' },
                {'\'','-' },
                {'.','-' },

            };
            foreach (DictionaryEntry item in karakterSeti)
            {
                baslik = baslik.Replace((char)item.Key, (char)item.Value);
            }
            Console.WriteLine(baslik);
        }

        private static void HashtableYapisi()
        {
            //HashtableYapısı

            //tanımlama
            var sehirler = new Hashtable();

            //ekleme
            sehirler.Add(6, "Ankara");
            sehirler.Add(34, "İstanbul");
            sehirler.Add(46, "Kahramanmaraş");
            sehirler.Add(55, "Samsun");

            //dolasma
            foreach (DictionaryEntry item in sehirler)
            {
                Console.WriteLine($"{item.Key,-5}-" +
                    $"{item.Value,-5}");
            }
            //anahtarları alma
            Console.WriteLine("\nAnahtarlar (Keys)");
            var anahtarlar = sehirler.Keys;
            foreach (var item in anahtarlar)
            {
                Console.WriteLine(item);
            }
            //degerleri alma
            Console.WriteLine("\nDeğerler (Values)");
            var degerler = sehirler.Values;
            foreach (var item in degerler)
            {
                Console.WriteLine(item);
            }
            //elemana erişme
            Console.WriteLine("\nElemanaErişme");
            Console.WriteLine(sehirler[46]);

            //eleman silme
            Console.WriteLine("\nElemanSilme");
            sehirler.Remove(46);

            //dolaşma
            foreach (DictionaryEntry item in sehirler)
            {
                Console.WriteLine($"{item.Key,-5}-" +
                    $"{item.Value,-5}");
            }
        }

        private static void DizilerveArrayClassMetotları()
        {
            int[] sayilar = new int[] { 5, 3, 8, 10, 2, 18, 46, 23, 55, 6, 34, 50 };
            var numbers = Array.CreateInstance(typeof(int), sayilar.Length);
            var arr = new ArrayList(sayilar);

            sayilar.CopyTo(numbers, 0); //kopyalama

            Array.Sort(sayilar); //sıralama
            Array.Sort(numbers); //sıralama
            Array.Clear(sayilar, 2, 3); //silme
            arr.Sort(); //sıralama
            Console.WriteLine(Array.IndexOf(sayilar, 46));//index arama


            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"sayılar[{i}]=" +
                    $"{sayilar[i],-3} " +
                    $"numbers[{i}]=" +
                    $"{numbers.GetValue(i),-3} " +
                    $"arr[{i}]=" +
                    $"{arr[i],3}");
            }
        }

        private static void ClassYapilari()
        {
            ////I.Tanımlama
            //OgretimElemani ogrGor = new OgretimElemani()
            //{
            //    SicilNo = 201,Adi="Arzu",Soyadi="Ak",Cinsiyet=false
            //};

            ////II.Tanımlama
            //OgretimElemani ogrGor2 = new OgretimElemani();
            //ogrGor2.SicilNo = 101;
            //ogrGor2.Adi = "Ahmet";
            //ogrGor2.Soyadi = "Yıldız";
            //ogrGor2.Cinsiyet = true;

            ////III.Tanımlama
            //OgretimElemani ogrGor3 = new OgretimElemani(215,"Cansu","Ay",false);

            //List Tanımlama
            var liste1 = new List<OgretimElemani>()
            {
                new OgretimElemani(100,"Ahmet","Ak",true),
                new OgretimElemani(102,"Arzu","Ay",false),
                new OgretimElemani(105,"Aylin","Tok",false),
                new OgretimElemani(106,"Feray","Çak",false),
                new OgretimElemani(110,"Ali","Gök",true),
            };
            //Yazdırma
            liste1.ForEach(o => Console.WriteLine(o));
            Console.WriteLine();

            //Classların Referans Tipli olması
            var liste2 = liste1;

            liste2.ForEach(o => Console.WriteLine(o));
            liste2.Add(new OgretimElemani(101, "Öner", "Han", true));
            liste1.RemoveAt(0);
            Console.WriteLine();
            liste1.ForEach(o => Console.WriteLine(o));
            Console.WriteLine();
            liste2.ForEach(o => Console.WriteLine(o));
        }

        private static void StruckKullanımı()
        {
            ////struct kullanma =>değer tiplidir.
            //Ogrenci ogr = new Ogrenci();
            //ogr.Numara = 10;
            //ogr.Adi = "Ahmet";
            //ogr.Soyadi = "Yılmaz";
            //ogr.Cinsiyet = true;

            ////alternatif kullanma
            //var ogr2 = new Ogrenci()
            //{
            //    Numara = 20,
            //    Adi = "Fatma",
            //    Soyadi = "Efe",
            //    Cinsiyet = false
            //};

            ////constructorlu alternatif
            //var ogr3 = new Ogrenci(30, "Mehmet", "Arslan", true);
            //var ogr4 = new Ogrenci(34, "Ahmet", "Kul");

            //list tasarımı
            var ogrenciListesi = new List<Ogrenci>()
            {
                new Ogrenci(10, "Ahmet", "Yılmaz", true),
                new Ogrenci(20, "Fatma", "Efe", false),
                new Ogrenci(30, "Mehmet", "Arslan", true),
                new Ogrenci(34, "Ahmet", "Kul")
            };
            ogrenciListesi.ForEach(o => Console.WriteLine(o));
        }

        private static void VeriBoyutlari()
        {
            //8-bit int
            Console.WriteLine(nameof(SByte));
            Console.WriteLine($"Alt Limit       :{SByte.MinValue,20}");
            Console.WriteLine($"Üst Limit       :{SByte.MaxValue,20}");
            Console.WriteLine($"Boyutu          :{sizeof(SByte),20}");
            Console.ReadKey();

            //Unsigned 8-bit int
            Console.WriteLine(nameof(Byte));
            Console.WriteLine($"Alt Limit       :{Byte.MinValue,20}");
            Console.WriteLine($"Üst Limit       :{Byte.MaxValue,20}");
            Console.WriteLine($"Boyutu          :{sizeof(Byte),20}");
            Console.ReadKey();

            //16-bit int
            Console.WriteLine(nameof(Int16));
            Console.WriteLine($"Alt Limit       :{Int16.MinValue,20}");
            Console.WriteLine($"Üst Limit       :{Int16.MaxValue,20}");
            Console.WriteLine($"Boyutu          :{sizeof(Int16),20}");
            Console.ReadKey();

            //Unsigned 16-bit int
            Console.WriteLine(nameof(UInt16));
            Console.WriteLine($"Alt Limit       :{UInt16.MinValue,20}");
            Console.WriteLine($"Üst Limit       :{UInt16.MaxValue,20}");
            Console.WriteLine($"Boyutu          :{sizeof(UInt16),20}");
            Console.ReadKey();

            //32-bit int
            Console.WriteLine(nameof(Int32));
            Console.WriteLine($"Alt Limit       :{Int32.MinValue,20}");
            Console.WriteLine($"Üst Limit       :{Int32.MaxValue,20}");
            Console.WriteLine($"Boyutu          :{sizeof(Int32),20}");
            Console.ReadKey();

            //Double
            Console.WriteLine(nameof(Double));
            Console.WriteLine($"Alt Limit       :{Double.MinValue,20}");
            Console.WriteLine($"Üst Limit       :{Double.MaxValue,20}");
            Console.WriteLine($"Boyutu          :{sizeof(Double),20}");
            Console.ReadKey();
        }
    }
    
}
