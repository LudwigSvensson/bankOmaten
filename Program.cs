using System.Reflection.Metadata;

namespace bankOmaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tries = 5;
            bool go = true;
            Welcome();
            Thread.Sleep(1000);
            while (tries != 0)
            {                
                Showtries(tries);
                LoggaIn(ref tries);                               
          }
            Console.Clear();
            Console.WriteLine("Du har förbrukat dina fem försök för att logga in, now fuck off");
        }
        static void Welcome()
        {
            string[] welcome = new string[] { "Välkommen till den fantastiska banken!", "Välkommen till bankernas bank!", "Hej och välkommen till den bästa banken!" };
            Random randy = new Random();
            int randyString = randy.Next(welcome.Length);
            string randyWelcome = welcome[randyString];
            Console.WriteLine(randyWelcome);
        }

        static int LoggaIn(ref int tries)
        {
            try
            {
                string[] users = new string[3] { "ludwig", "anas", "marcus" };
                Console.Write("Vänligen ange Användarnamn: ");
                var user = Console.ReadLine().ToLower();
                Console.Write("Vänligen ange din sexsiffriga pinkod: ");
                var pw = Convert.ToInt32(Console.ReadLine());
                if (pw == 123456 && (users.Contains(user)))
                {
                    tries = 6;
                    while (tries ==6)
                    {
                        Console.Clear();
                        Console.WriteLine("Inloggning lyckades!");
                        Thread.Sleep(1000);
                        Console.WriteLine("..........\n........... \n............");
                        Thread.Sleep(1500);
                        Console.Clear();
                        Bankmeny(ref tries, user);
                    }  
                    
                    return tries;  
                }

                else 
                {
                    Console.Clear();
                    Console.WriteLine("FEL! \nVänligen ange rätt användarnamn och lösenord");
                    return tries--;
                }              
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Du börjar med att skriva in ditt användarnamn, \n efter det din SEXsiffriga pinkod");
                return tries--;
            }
        }       
        static void Showtries(int tries)
        {                     
                Console.WriteLine($"Du har {tries} försök kvar");
                Thread.Sleep(1000);  
        }
        static int Bankmeny(ref int tries,string user)
        {
            Console.WriteLine($"Välkommen {user}");
            Console.WriteLine("[1]. Se dina konton och dess saldon\n[2]. Se dina konton och dess saldon\n[3]. Se dina konton och dess saldon\n[4]. Logga ut");
            int uInput = Convert.ToInt32(Console.ReadLine());

            switch (uInput)
            {
                case 1:
                    Console.WriteLine("[1]. Se dina konton och dess saldon");
                    break;
                case 2:
                    Console.WriteLine("[2]. Se dina konton och dess saldon");
                    break;
                case 3:
                    Console.WriteLine("[3]. Se dina konton och dess saldon");
                    break;
                case 4:
                    Console.WriteLine("[4]. Logga ut");                    
                    Console.Clear();
                    Console.WriteLine("Återvänder till Inloggning.......");
                    Thread.Sleep(1500);
                    Console.Clear();
                    return tries--;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen");
                    break;
            }
            return tries;
        }
    }
}