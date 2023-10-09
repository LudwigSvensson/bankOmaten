using System.Reflection.Metadata;

namespace bankOmaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tries = 5;
            
            
            Thread.Sleep(1000);
            while (tries != 0)
            {
                Welcome();
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
            Console.WriteLine("Skriv in användarnamn och lösenord för att logga in.");
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
                    Console.Clear();
                    Console.WriteLine("Inloggning lyckades!");
                    Thread.Sleep(1000);
                    Console.WriteLine("..........\n........... \n............");
                    Thread.Sleep(1500);
                    Console.Clear();
                    tries = 6;
                    while (tries ==6)
                    {                                               
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
            Console.WriteLine("[1]. Se dina konton och dess saldon\n[2]. Överföring mellan konton\n[3]. Ta ut pengar\n[4]. Logga ut");
            try
            {
                int uInput = Convert.ToInt32(Console.ReadLine());
            
                switch (uInput)
                {
                    case 1:
                        Console.WriteLine("[1]. Se dina konton och dess saldon");
                        break;

                    case 2:
                        Console.WriteLine("[2]. Överföring mellan konton");
                        break;

                    case 3:
                        Console.WriteLine("[3]. Ta ut pengar");
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
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val, försök igen");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Du måste ange en av siffrorna: 1, 2, 3 eller 4.");
                Thread.Sleep(1500);
                Console.Clear();
            }
            catch (OverflowException)
            {
                Console.Clear();
                Console.WriteLine("Du måste ange en av siffrorna: 1, 2, 3 eller 4.");
                Thread.Sleep(1500);
                Console.Clear();
            }  
            catch(Exception)
            {
                Console.Clear();
                Console.WriteLine("Vänligen välj ett utav alternativen. 1, 2, 3 eller 4.");
                Thread.Sleep(1500);
                Console.Clear();
            }

            return tries;
        }
    }
}