using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankApp
{
    public class Control
    {
        // Kullanıcı adı ve şifreyi saklayacak listeler
        
        

        public static class UserStorage
        {
            public static List<string> UsernameList { get; set; } = new List<string>();
            public static List<string> PasswordList { get; set; } = new List<string>();
        }

        public bool RegisterArea(string userRegisterChoice)
        {
           

            if (userRegisterChoice == "1")
            {
                Console.WriteLine("\n************");
                Console.WriteLine("Kayıt İşlemi");
                Console.WriteLine("\n************");

                // Kullanıcı adı alma ve kontrol etme
                string registerUserName = null;
               
                int usernameAttempts = 0; // Kullanıcı adı için deneme sayısı
                while (usernameAttempts < 3)
                {
                    Console.Write("\nLütfen bir kullanıcı adı giriniz: ");
                    registerUserName = Console.ReadLine()?.ToLower();

                    if (string.IsNullOrWhiteSpace(registerUserName))
                    {
                        Console.WriteLine("\nKullanıcı adı boş olamaz. Lütfen tekrar deneyiniz.");
                    }
                    else if (UserStorage.UsernameList.Contains(registerUserName))
                    {
                        Console.WriteLine("\nBu kullanıcı adı kullanılmaktadır. Lütfen tekrar deneyiniz.");
                    }
                    else if (registerUserName.Length < 8)
                    {
                        Console.WriteLine("\nKullanıcı adı en az 8 haneli olmalıdır. Lütfen tekrar deneyiniz.");
                    }
                    else
                    {
                        break; // Geçerli bir kullanıcı adı girildiyse, döngüyü kır
                    }

                    usernameAttempts++;
                    if (usernameAttempts == 3)
                    {
                        Console.WriteLine("3 kez hatalı giriş yaptınız. Kayıt işlemi iptal ediliyor.");
                        Countdown(15);
                        usernameAttempts = 0;
                    }
                }

                // Şifre alma ve kontrol etme
                string registerPassword = null;
                int passwordAttempts = 0; // Şifre için deneme sayısı
                while (passwordAttempts < 3)
                {
                    Console.Write("\nLütfen bir şifre giriniz: ");
                    registerPassword = Console.ReadLine();

                    if (registerPassword.Length < 8)
                    {
                        Console.WriteLine("Şifre en az 8 karakter uzunluğunda olmalıdır. Lütfen tekrar deneyiniz.");
                    }
                    else
                    {
                        break; // Geçerli bir şifre girildiyse, döngüyü kır
                    }

                    passwordAttempts++;
                    if (passwordAttempts == 3)
                    {
                        Console.WriteLine("3 kez hatalı şifre girdiniz. Kayıt işlemi iptal ediliyor.");
                        Countdown(15);
                        passwordAttempts = 0; ;
                    }
                }

                // Kullanıcı adı ve şifreyi listeye ekleme
                UserStorage.UsernameList.Add(registerUserName);
                UserStorage.PasswordList.Add(registerPassword);
                Console.WriteLine("\n---------------");
                Console.WriteLine("Kayıt başarılı!");
                Console.WriteLine($"Kullanıcı adı : {registerUserName} \nŞifre : {registerPassword}");
                Console.WriteLine("\n---------------");

               
                return true;
            }

            

            Console.WriteLine("\nGeçersiz seçim. Lütfen tekrar deneyiniz.");
            return false;
        }
        private void Countdown(int seconds)
        {
            while(seconds > 0)
            {
                Console.WriteLine($"\nKalan süre : {seconds} saniye ");
                Thread.Sleep(1000);
                seconds--;
            }
            Console.WriteLine("\nDevam edebilirsiniz.");
        }
        public bool LoginArea(string userLoginChoice)
        {
            if (userLoginChoice == "2")
            {
                Console.WriteLine("\n************");
                Console.WriteLine("Giriş işlemi");
                Console.WriteLine("\n************");
            }
            string loginUsername= null;
            int usernameAttempt = 0; // Kullanıcı adı için deneme sayısı
            while (usernameAttempt < 3)
            {
                Console.Write("\nLütfen bir kullanıcı adı giriniz: ");
                loginUsername = Console.ReadLine()?.ToLower();
                


                if (string.IsNullOrWhiteSpace(loginUsername))
                {
                    Console.WriteLine("\nKullanıcı adı boş olamaz. Lütfen tekrar deneyiniz.");
                }

                else if (!UserStorage.UsernameList.Contains(loginUsername))
                {
                    Console.WriteLine("\nKullanıcı adı bulunamadı. Lütfen tekrar deneyiniz.");
                }
                else { break; }

                usernameAttempt++;
                if (usernameAttempt == 3)
                {
                    Console.WriteLine("3 kez hatalı giriş yaptınız. Giriş işlemi iptal ediliyor. Hata nedeni : Kullanıcı adı boş!");
                    Countdown(15);
                    return false;
                }
            }
            string loginPassword = null;
            int loginAttempt = 0;
            while (loginAttempt < 3)
            {
                Console.Write("\nLütfen bir şifre giriniz : ");
                loginPassword = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(loginPassword))
                {
                    Console.WriteLine("\nŞifre boş olamaz. Lütfen tekrar deneyiniz.");
                }

                else if(UserStorage.UsernameList.Contains(loginUsername) 
                    && UserStorage.PasswordList[UserStorage.UsernameList.IndexOf(loginUsername)] == loginPassword)
                {
                    return true;

                }
                else
                {
                    Console.WriteLine("\nŞifre yanlış. Lütfen tekrar deneyiniz.");
                }

                loginAttempt++;
                if (loginAttempt == 3)
                {
                    Console.WriteLine("3 kez hatalı giriş yaptınız. Giriş işlemi iptal ediliyor.");
                    Countdown(15);
                    loginAttempt = 0;
                }             
            }
           Console.WriteLine("\nGeçersiz seçim. Lütfen tekrar deneyiniz.");
            return false;
        }
        
    }
   }


