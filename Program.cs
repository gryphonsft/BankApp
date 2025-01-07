using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankApp
{
    public class Program
    {
        static decimal bakiye = 1000;
        static void Main(string[] args)
        {
            Control control = new Control();
           
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("******************");
                Console.WriteLine("*BANKA UYGULAMASI*");
                Console.WriteLine("******************");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n1: Kayıt Ol");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2: Giriş yap");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("3: Çıkış");
                Console.ResetColor();

                Console.Write("\nLütfen yapmak istediğiniz işlemi seçiniz (1, 2 veya 3): ");
                string userChoice = Console.ReadLine();

                if (userChoice == "1")
                {
                    bool isSuccess = control.RegisterArea(userChoice);
                    if (isSuccess)
                    {
                        Console.WriteLine("\nLütfen bekleyiniz...");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nKayıt başarılı!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        continue;
                     
                    }
                    // İsteğe bağlı: Başarısız olduğunda tekrar denemek için döngü devam eder
                }
                else if(userChoice == "2")
                {
                    bool isSuccess = control.LoginArea(userChoice);
                    if (isSuccess)
                    {
                        Console.WriteLine("\nLütfen bekleyiniz...");
                        Thread.Sleep(3000);
                        Console.WriteLine("\nGiriş başarılı!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        KullanıcıEkranı();
                        break;
                    }

                }
                else if (userChoice == "3")
                {
                    Console.WriteLine("İyi günler.");
                    Console.WriteLine("Çıkış yapılıyor...");
                    break; // Döngüyü kırarak programdan çık
                }
                else if(userChoice == "gecis")
                {
                    KullanıcıEkranı();
                    break;
                }
               
                else
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen 1 veya 2'yi seçiniz.");
                }

               
            }
            Console.Clear();

            Console.ReadLine();
        }
        static void KullanıcıEkranı()
        {
            int secim = 0;
            float bakiye = 10;
            do {
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("\n1:Para çek");
                Console.WriteLine("2:Para yatır");
                Console.WriteLine("3:Hesap bakiyesini görüntüle");
                Console.WriteLine("4:Çıkış");
                Console.Write("\nLütfen yapmak istediğiniz işlemi seçiniz (1, 2, 3 veya 4): ");
                secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                       ParaCek();
                        break;
                    case 2:
                        ParaYatir();
                        break;
                    case 3:
                        BakiyeGoruntule();
                        break;
                    case 4:
                        Console.WriteLine("İyi günler.");
                        Console.WriteLine("Çıkış yapılıyor...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            } while (true);
        }
        static void ParaCek()
        {
            Console.Clear();
            Console.Write("\nLütfen çekmek istediğiniz tutarı giriniz: ");
            
            decimal cekmetutar = Convert.ToDecimal(Console.ReadLine());
            if (cekmetutar > bakiye)
            {
                Console.WriteLine("\nBakiyeniz yetersizdir!");
            }
            else
            {
                Console.WriteLine( $"\n{cekmetutar} TL para çekildi!");
                bakiye -= cekmetutar;
            }

        }
        static void ParaYatir()
        {
            Console.Clear();
            Console.Write("\nLütfen yatırmak istediğiniz tutarı giriniz: ");
            decimal yatırmatutar = Convert.ToDecimal(Console.ReadLine());
            bakiye += yatırmatutar;
            Console.WriteLine($"\n{yatırmatutar} TL para yatırıldı!");

        }
        static void BakiyeGoruntule()
        {
            Console.WriteLine($"\nBakiye : {bakiye}");
        }

    }
}

