using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            //STACK
            //Kutuya kitap yerleştirelim.
            Stack box = new Stack();
            //push ekleme işlemidir.
            box.Push("C# Öğreniyorum");
            box.Push("Python Öğreniyorum");
            box.Push("OOP Öğreniyorum");
            box.Push("Yapay Zekaya Giriş");
            //kutuya kitaplar eklendi.
            //Üst üste yığın olarak.
            Console.WriteLine(box.Pop());
            //pop kutuya  son eklenen elemanı kutudan
            //çıkarıp yazdırdı.
            //stack'den eleman çıktı.
            Console.WriteLine(box.Peek());
            //peek işlem sırasındaki elemanı gösterir,
            //stack'te hala mevcut kalır.

            //QUEUE
            //Bankada kuyruğa alıp,işleme sokalım.
            Queue bank = new Queue();
            //enqueue ekleme işlemidir.
            bank.Enqueue("Ali Yılmaz");
            bank.Enqueue("Mehmet Yılmaz");
            bank.Enqueue("Ahmet Yılmaz");
            bank.Enqueue("Hasan Yılmaz");
            bank.Enqueue("Hüseyin Yılmaz");
            bank.Enqueue("Aydın Yılmaz");
            //kuyruk oluştu.
            Console.WriteLine("İşleme alınan kişi:" + bank.Dequeue());
            ////dequeue çıkarma işlemidir.
            ///İlk kişiyi işleme alır.
            //İlk kişi ekranda görünür.
            //Yazdırılan kişi kuyruktan çıkar.
            Console.WriteLine("Sıradaki kişi:" + bank.Peek());
            //sıradaki kişiyi gösterir.
            //Ama kuyrukta hala mevcuttur.
            Console.ReadLine();
        }
    }
}
