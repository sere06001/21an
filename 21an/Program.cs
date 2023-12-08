using System;
namespace Tjugoettan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till 21:an!");
            Meny();
        }
        static void Meny()
        {
            Console.WriteLine("Välj ett alternativ");
            Console.WriteLine("1. Spela 21:an");
            Console.WriteLine("2. Visa senaste vinnaren");
            Console.WriteLine("3. Spelets regler");
            Console.WriteLine("4. Avsluta programmet");
            bool svar = int.TryParse(Console.ReadLine(), out var n);
            while (svar == false || n > 4 || n < 1)
            {
                Console.Write("Ogiltig input, försök igen: ");
                svar = int.TryParse(Console.ReadLine(), out n);
            }
            SwitchMeny(n);
        }
        static void SwitchMeny(int n)
        {
            switch (n)
            {
                case 1:
                    Random random = new Random();
                    List<int> SpelarePoäng = new List<int>();
                    SpelarePoäng.Add(random.Next(11));
                    List<int> DatorPoäng = new List<int>();
                    DatorPoäng.Add(random.Next(11));
                    int SpelareSumma = SpelarePoäng[0];
                    int DatorSumma = DatorPoäng[0];
                    int DatorExtraDrag = 0;

                    Console.WriteLine("Nu kommer två kort dras per spelare");
                    Console.WriteLine($"Dina poäng: {SpelarePoäng[0]}");
                    Console.WriteLine($"Datorns poäng: {DatorPoäng[0]}");
                    Console.Write("Vill du ha ett till kort? (j/n): ");
                    string svar = Console.ReadLine();
                    int i = 0;
                    int count = 0;
                    while (svar == "j" || svar == "J")
                    {
                        SpelarePoäng.Add(random.Next(11));
                        DatorPoäng.Add(random.Next(11));
                        SpelareSumma += SpelarePoäng[i];
                        DatorSumma += DatorPoäng[i];
                        DatorExtraDrag += random.Next(1, 11);

                    }
                    break;
                case 2:
                    break;
                case 3:
                    Console.WriteLine("Ditt mål är att tvinga datorn att få mer än 21 poäng.");
                    Console.WriteLine("Du får poäng genom att dra kort, varje kort har 1 - 10 poäng.");
                    Console.WriteLine("Om du får mer än 21 poäng har du förlorat.");
                    Console.WriteLine("Både du och datorn får två kort i början.Därefter får du ");
                    Console.WriteLine("dra fler kort tills du är nöjd eller får över 21.");
                    Console.WriteLine("När du är färdig drar datorn kort till den har");
                    Console.WriteLine("mer poäng än dig eller över 21 poäng.");
                    Console.WriteLine();
                    Meny();
                    break;

            }
        }
    }
}