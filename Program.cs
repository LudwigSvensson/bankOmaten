using Microsoft.Win32;
using System.Data;
using System.Reflection.Metadata;

namespace bankOmaten
{
    internal class Program
    {
        //Användarnas konton 
        private static decimal ludwigsKortKonto = 100.50m;
        private static decimal ludwigSparKonto = 1000.50m;
        private static decimal ludwigsMEGAsparKonto = 10000.50m;
        private static decimal anasKortKonto = 200.50m;
        private static decimal anasSparKonto = 2000.50m;
        private static decimal marcusKortKonto = 300.50m;
        //private static Dictionary<string, decimal> ludwigsKonton = new Dictionary<string, decimal>();


        static void Main(string[] args)
        {
            //ludwigsKonton["Kortkonto"] = 100.50m;
            //ludwigsKonton["Sparkonto"] = 1000.50m;
            //ludwigsKonton["MEGAsparkonto"] = 10000.50m;
            //decimal kortKonto = ludwigsKonton["Kortkonto"];
            //Console.WriteLine(kortKonto);
            //anasKonton["Kortkonto"] = 200.50m;
            //anasKonton["Sparkonto"] = 2000.50m;
            //string[] acc = new string[3];
            //acc[0] = "[Kortkonto]";
            //acc[1] = "[SparKonto]";
            //acc[2] = "[MEGASparkonto]";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
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
            Console.WriteLine("Ange rätt användarnamn och rätt lösenord för att logga in");
                        
        }//Metod som skriver ut välkomstmeddelande
        
        static Dictionary<string, int> userPW = new Dictionary<string, int>
        {
            { "ludwig", 123456 },
            { "anas", 654321 },
            { "marcus", 111222 }
        };//Parar ihop användareinlogg och lösenord på ett snyygt och smidigt sätt
        static int LoggaIn(ref int tries)
        {
            try
            {                
                Console.Write("Vänligen ange Användarnamn: ");
                var user = Console.ReadLine().ToLower();
                Console.Write("Vänligen ange din sexsiffriga pinkod: ");
                var pw = Convert.ToInt32(Console.ReadLine());
                if (userPW.ContainsKey(user) && userPW[user] == pw)
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
                    Thread.Sleep(2000);
                    Console.Clear();
                    return tries--;
                }              
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Du börjar med att skriva in ditt användarnamn, \n efter det din SEXsiffriga pinkod");
                Thread.Sleep(2000);
                Console.Clear();
                return tries--;
            }
        } //Metod som används för att logga in i 'banken' 
        static void Showtries(int tries)
        {                     
                Console.WriteLine($"Du har {tries} försök kvar");
                Thread.Sleep(1000);  
        }//Metod som visar skriver ut hur många försök man har kvar på att logga in
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
                        
                        if (user == "ludwig")
                        {
                            Console.Clear();
                            LudwigsKonton();
                        }
                        else if (user=="anas")
                        {
                            Console.Clear();
                            AnasKonton();
                        }
                        else if (user=="marcus")
                        {
                            Console.Clear();
                            MarcusKonton();    
                        }
                        break;

                    case 2:
                        Console.Clear();
                        if (user == "ludwig")
                        {
                            LudwigsTransfer();                   
                        }
                        else if (user == "anas")
                        {
                            AnasTransfer();
                        }
                        else if (user == "marcus")
                        {
                            Console.WriteLine("Du har bara ett konto...därav kan du inte göra överföringar");
                            MarcusKonton();                            
                        }
                        
                        break;

                    case 3:
                        Console.Clear();
                        withdrawStålar(user);
                        break;
                                              
                    case 4:                        
                        Console.Clear();
                        Console.WriteLine("Återvänder till Inloggning.......");
                        Thread.Sleep(1500);
                        Console.Clear();                        
                        return tries--;
                        
                    default:
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val, försök igen");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }
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
        }//Metod för 'menyn' som visas när man loggat in i 'banken'
        
        static void LudwigsKonton()
       {                      
            Console.WriteLine($" [Kortkonto] {ludwigsKortKonto};- \n [Sparkonto] {ludwigSparKonto};- \n [MEGASparkonto] {ludwigsMEGAsparKonto};- ");
            Console.WriteLine("Vänligen trycker Enter för att gå tillbaka");
            Console.ReadLine();
            Console.Clear();
        }//Visar saldo för Ludwigs konton
        static void AnasKonton()
        {
            Console.Clear();
            Console.WriteLine($" [Kortkonto] {anasKortKonto};- \n [Sparkonto] {anasSparKonto};-");
            Console.WriteLine("Vänligen trycker Enter för att gå tillbaka");
            Console.ReadLine();
            Console.Clear();
        }//Visar saldo för Anas konton
        static void MarcusKonton()
        {
                      
            Console.WriteLine($"[Kortkonto] {marcusKortKonto};-");
            Console.WriteLine("Vänligen trycker Enter för att gå tillbaka");
            Console.ReadLine();
            Console.Clear();
        }//Visar saldo för Marcus konton
        static void LudwigsTransfer()
        {
            try
            {
                Console.WriteLine($"Välj konto du vill föra över ifrån \n [1][Kortkonto]{ludwigsKortKonto} \n [2][Sparkonto]{ludwigSparKonto} \n [3][MEGASparkonto]{ludwigsMEGAsparKonto}");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Välj konto du vill föra över till \n [1][Sparkonto]{ludwigSparKonto} \n [2][MEGASparkonto]{ludwigsMEGAsparKonto}");
                    int choice2 = Convert.ToInt32(Console.ReadLine());
                    if (choice2 == 1)
                    {
                        Console.Clear();
                        transferStålar(ref ludwigsKortKonto, ref ludwigSparKonto, "ludwig");
                    }
                    else if (choice2 == 2)
                    {
                        Console.Clear();
                        transferStålar(ref ludwigsKortKonto, ref ludwigsMEGAsparKonto, "ludwig");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val, försök igen");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }

                }
                else if (choice == 2)
                {
                    Console.Clear();
                    Console.WriteLine($"Välj konto du vill föra över till \n [1][Kortkonto]{ludwigsKortKonto} \n [2][MEGASparkonto]{ludwigsMEGAsparKonto}");
                    int choice2 = Convert.ToInt32(Console.ReadLine());
                    if (choice2 == 1)
                    {
                        Console.Clear();
                        transferStålar(ref ludwigSparKonto, ref ludwigsKortKonto, "anas");
                    }
                    else if (choice2 == 2)
                    {
                        Console.Clear();
                        transferStålar(ref ludwigSparKonto, ref ludwigsMEGAsparKonto, "anas");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val, försök igen");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                else if (choice == 3)
                {
                    Console.Clear();
                    Console.WriteLine($"Välj konto du vill föra över till \n [1][Kortkonto]{ludwigsKortKonto} \n [2][Sparkonto]{ludwigSparKonto}");
                    int choiceL2 = Convert.ToInt32(Console.ReadLine());
                    if (choiceL2 == 1)
                    {
                        Console.Clear();
                        transferStålar(ref ludwigsMEGAsparKonto, ref ludwigsKortKonto, "ludwig");
                    }
                    else if (choiceL2 == 2)
                    {
                        Console.Clear();
                        transferStålar(ref ludwigsMEGAsparKonto, ref ludwigSparKonto, "ludwig");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val, försök igen");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltigt val, försök igen");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Ogiltigt val, försök igen");
                Thread.Sleep(2000);
                Console.Clear();
            }           
        }//Metod för att föra över pengar emellan användare Ludwigs konton
        static void AnasTransfer()
        {
            try
            {                
                Console.WriteLine($"Välj konto du vill föra över ifrån \n [1][Kortkonto]{anasKortKonto};- \n [2][Sparkonto]{anasSparKonto};-");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Välj konto du vill föra över till \n [1][Kortkonto]{anasSparKonto};-");
                    int choice2 = Convert.ToInt32(Console.ReadLine());
                    if (choice2 == 1)
                    {
                        Console.Clear();
                        transferStålar(ref anasKortKonto, ref anasSparKonto,"anas");
                    }
                    else if (choice2 == 2)
                    {
                        Console.Clear();
                        transferStålar(ref anasSparKonto, ref anasKortKonto, "anas");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val, försök igen");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }

                }
                else if (choice == 2)
                {
                    Console.Clear();
                    Console.WriteLine($"Välj konto du vill föra över till \n [1][Kortkonto]{anasKortKonto}");
                    int choice2 = Convert.ToInt32(Console.ReadLine());
                    if (choice2 == 1)
                    {
                        transferStålar(ref anasSparKonto, ref anasKortKonto, "anas");
                    }
                    else
                    {
                        Console.WriteLine("Vänligen ange ett giltigt val \n Vänligen välj [1]");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltigt val, försök igen");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Ogiltigt val, försök igen");
                Thread.Sleep(2000);
                Console.Clear(); ;
            }

        }//Metod för att föra över pengar emellan användare Anas konton
        static void withdrawStålar(string user)
        {
            try
            {
                if (user == "ludwig")
                {
                    Console.Write("Vänligen ange din sexsiffriga pinkod för att fortsätta: ");
                    var pw = Convert.ToInt32(Console.ReadLine());
                    if (userPW[user] == pw)
                    {

                        Console.Clear();
                        Console.WriteLine($"Välj konto att ta ut pengar ifrån: \n [1][Kortkonto]{ludwigsKortKonto} \n [2][Sparkonto]{ludwigSparKonto} \n [3][MEGAsparkonto]{ludwigsMEGAsparKonto}");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.Clear();
                            Console.WriteLine($"[1][Kortkonto]{ludwigsKortKonto}");
                            Console.WriteLine("Hur mycket vill du ta ut? ");
                            decimal remove = Convert.ToDecimal(Console.ReadLine());
                            if (remove <= ludwigsKortKonto)
                            {
                                ludwigsKortKonto -= remove;
                                Console.WriteLine($"Uttaget är genomfört. Kvar på kontot: {ludwigsKortKonto}");
                                Thread.Sleep(2000);
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Du kan inte ta ut mer pengar än vad du har på ditt konto");
                            }
                        }
                        else if (choice == 2)
                        {
                            Console.Clear();
                            Console.WriteLine($"[2][Sparkonto]{ludwigSparKonto}");
                            Console.WriteLine("Hur mycket vill du ta ut? ");
                            decimal remove = Convert.ToDecimal(Console.ReadLine());
                            if (remove <= ludwigSparKonto)
                            {
                                ludwigSparKonto -= remove;
                                Console.WriteLine($"Uttaget är genomfört. Kvar på kontot: {ludwigSparKonto}");
                                Thread.Sleep(2000);
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Du kan inte ta ut mer pengar än vad du har på ditt konto");
                            }
                        }
                        else if (choice == 3)
                        {
                            Console.Clear();
                            Console.WriteLine($"[3][MEGASparkonto]{ludwigsMEGAsparKonto}");
                            Console.WriteLine("Hur mycket vill du ta ut? ");
                            decimal remove = Convert.ToDecimal(Console.ReadLine());
                            if (remove <= ludwigsMEGAsparKonto)
                            {
                                ludwigsMEGAsparKonto -= remove;
                                Console.WriteLine($"Uttaget är genomfört. Kvar på kontot: {ludwigsMEGAsparKonto}");
                                Thread.Sleep(2000);
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Du kan inte ta ut mer pengar än vad du har på ditt konto");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Du måste skriva in din SEXsiffriga pinkod...");
                            Thread.Sleep(2000);
                            Console.Clear();

                        }
                    }
                    else
                    {
                        Console.WriteLine("Du måste skriva in din SEXsiffriga pinkod...");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                else if (user == "anas")
                {
                    Console.Write("Vänligen ange din sexsiffriga pinkod för att fortsätta: ");
                    var pw = Convert.ToInt32(Console.ReadLine());
                    if (userPW[user] == pw)
                    {
                        Console.Clear();
                        Console.WriteLine($"Välj konto att ta ut pengar ifrån: \n [1][Kortkonto]{anasKortKonto} \n [2][Sparkonto]{anasSparKonto}");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.Clear();
                            Console.WriteLine($"[1][Kortkonto]{anasKortKonto}");
                            Console.WriteLine("Hur mycket vill du ta ut? ");
                            decimal remove = Convert.ToDecimal(Console.ReadLine());
                            if (remove <= anasKortKonto)
                            {
                                anasKortKonto -= remove;
                                Console.WriteLine($"Uttaget är genomfört. Kvar på kontot: {anasKortKonto}");
                                Thread.Sleep(2000);
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Du kan inte ta ut mer pengar än vad du har på ditt konto");
                            }

                        }
                        else if (choice == 2)
                        {
                            Console.Clear();
                            Console.WriteLine($"[2][Sparkonto]{anasSparKonto}");
                            Console.WriteLine("Hur mycket vill du ta ut? ");
                            decimal remove = Convert.ToDecimal(Console.ReadLine());
                            if (remove <= anasSparKonto)
                            {
                                anasSparKonto -= remove;
                                Console.WriteLine($"Uttaget är genomfört. Kvar på kontot: {anasSparKonto}");
                                Thread.Sleep(2000);
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Du kan inte ta ut mer pengar än vad du har på ditt konto");
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Du måste skriva in din SEXsiffriga pinkod...");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                else if (user == "marcus")
                {
                    Console.Write("Vänligen ange din sexsiffriga pinkod för att fortsätta: ");
                    var pw = Convert.ToInt32(Console.ReadLine());
                    if (userPW[user] == pw)
                    {
                        Console.Clear();
                        Console.WriteLine($"Välj konto att ta ut pengar ifrån: \n [1][Kortkonto]{marcusKortKonto}");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.Clear();
                            Console.WriteLine($"[1][Kortkonto]{marcusKortKonto}");
                            Console.WriteLine("Hur mycket vill du ta ut? ");
                            decimal remove = Convert.ToDecimal(Console.ReadLine());
                            if (remove <= marcusKortKonto)
                            {
                                marcusKortKonto -= remove;
                                Console.WriteLine($"Uttaget är genomfört. Kvar på kontot: {marcusKortKonto}");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Du kan inte ta ut mer pengar än vad du har på ditt konto");
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Du måste skriva in din SEXsiffriga pinkod...");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Du måste skriva in din SEXsiffriga pinkod...");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Du måste skriva in din SEXsiffriga pinkod... ");                
                Thread.Sleep(2000);
                Console.Clear();
            }
            
        }//Metod för att ta ut pengar ifrån användarnas konton
        static void transferStålar(ref decimal frånKonto, ref decimal tillKonto, string user)
        {            
            Console.WriteLine($"Hur mycket pengar vill du överföra från {frånKonto} till {tillKonto}?");
            decimal överföring = Convert.ToDecimal(Console.ReadLine());
            
            if (överföring > 0 && överföring <= frånKonto)
            {
                frånKonto -= överföring;
                tillKonto += överföring;
                Console.WriteLine("Överföringen lyckades! \n Nya saldon:");
                if (user == "ludwig")
                {
                    LudwigsKonton();
                }
                else if (user=="anas")
                {
                    AnasKonton();
                }
                else if (user=="marcus")
                {
                    MarcusKonton();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltigt val, försök igen");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Ogiltigt belopp eller otillräckligt saldo.");
            }
        } //Metod som genomför överföring av pengar emellan konton         
    }
}