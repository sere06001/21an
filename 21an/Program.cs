using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
namespace Tjugoettan
{
    class Program
    {
        public class Lista
        {
            private static List<string> SenasteVinnare = new List<string>();

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
                Console.Write("Svar: ");
                bool svar = int.TryParse(Console.ReadLine(), out var n);
                while (svar == false || n > 4 || n < 1)
                {
                    Console.Write("Ogiltig input, försök igen: ");
                    svar = int.TryParse(Console.ReadLine(), out n);
                }
                Console.WriteLine();
                SwitchMeny(n);
            }
            static void SwitchMeny(int n)
            {
                switch (n)
                {
                    case 1:
                        Random random = new Random();
                        List<int> SpelarePoäng = new List<int>();
                        SpelarePoäng.Add(random.Next(1, 21));
                        List<int> DatorPoäng = new List<int>();
                        DatorPoäng.Add(random.Next(1, 21));
                        int SpelareSumma = SpelarePoäng[0];
                        int DatorSumma = DatorPoäng[0];
                        int DatorExtraDrag = 0;

                        Console.WriteLine("Nu kommer två kort dras per spelare");
                        Console.WriteLine($"Dina poäng: {SpelarePoäng[0]}");
                        Console.WriteLine($"Datorns poäng: {DatorPoäng[0]}");
                        Console.Write("Vill du dra ett till kort? (j/n): ");
                        string svar = Console.ReadLine();
                        int i = 1;
                        int count = 0;
                        while (svar == "j" || svar == "J")
                        {
                            SpelarePoäng.Add(random.Next(1, 11));
                            DatorPoäng.Add(random.Next(1, 11));
                            SpelareSumma += SpelarePoäng[i];
                            if (DatorSumma != 21 || DatorSumma! > 21) { DatorSumma += DatorPoäng[i]; }
                            DatorExtraDrag += random.Next(1, 11);
                            if (DatorSumma > 21 && SpelareSumma > 21) { Över21Båda(SpelareSumma, DatorSumma); svar = ""; count = 1; }
                            else if (DatorSumma > 21)
                            {
                                Console.WriteLine();
                                Över21Dator(SpelareSumma, DatorSumma);
                                Console.Write("Skriv in ditt namn: ");
                                SenasteVinnare.Add(Console.ReadLine());
                                Console.WriteLine();
                                svar = "";
                                count = 1;
                            }
                            else if (SpelareSumma > 21) { Över21Spelare(SpelareSumma, DatorSumma); svar = ""; count = 1; }
                            else if (SpelareSumma == 21 && DatorSumma == 21) { Båda21(SpelareSumma, DatorSumma); svar = ""; count = 1; }
                            else if (SpelareSumma == 21)
                            {
                                SpelareVann(SpelareSumma, DatorSumma);
                                Console.Write("Skriv in ditt namn: ");
                                SenasteVinnare.Add(Console.ReadLine());
                                count = 1;
                            }
                            else if (DatorSumma == 21)
                            {
                                DatornVann(SpelareSumma, DatorSumma);
                                count = 1;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Dina poäng: {SpelareSumma}");
                                Console.WriteLine($"Datorns poäng: {DatorSumma}");
                                Console.Write("Vill du dra ett till kort? (j/n): ");
                                svar = Console.ReadLine();
                            }
                            i++;
                        }
                        if (count != 1)
                        {
                            int j = 0;
                            while (DatorSumma < 21)
                            {
                                DatorSumma += random.Next(1, 6);
                                j++;
                            }
                            if (DatorSumma > 21)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Datorn drog {j} extra kort");
                                Över21Dator(SpelareSumma, DatorSumma);
                                Console.Write("Skriv in ditt namn: ");
                                SenasteVinnare.Add(Console.ReadLine());
                            }
                            else if (DatorSumma > SpelareSumma) { DatornVann(SpelareSumma, DatorSumma); }
                            else
                            {
                                SpelareVann(SpelareSumma, DatorSumma);
                                Console.Write("Skriv in ditt namn: ");
                                SenasteVinnare.Add(Console.ReadLine());
                            }
                        }
                        Console.WriteLine();
                        Meny();

                        break;
                    case 2:
                        SenasteVinnare.Reverse();
                        for (int plats = 0; plats < SenasteVinnare.Count; plats++)
                        {
                            Console.WriteLine($"{plats+1}. {SenasteVinnare[plats]}");
                        }
                        SenasteVinnare.Reverse();
                        Console.WriteLine();
                        Meny();
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
                    case 4:
                        break;
                }
            }
            static void Över21Båda(int Spelare, int Dator)
            {
                Console.WriteLine();
                Console.WriteLine($"Dina totala poäng: {Spelare}");
                Console.WriteLine($"Datorns totala poäng: {Dator}");
                Console.WriteLine("Ingen vann! Båda fick över 21 poäng");
            }
            static void Över21Dator(int Spelare, int Dator)
            {
                Console.WriteLine($"Dina totala poäng: {Spelare}");
                Console.WriteLine($"Datorns totala poäng: {Dator}");
                Console.WriteLine("Du vann! Datorn fick över 21 poäng");
            }
            static void Över21Spelare(int Spelare, int Dator)
            {
                Console.WriteLine();
                Console.WriteLine($"Dina totala poäng: {Spelare}");
                Console.WriteLine($"Datorns totala poäng: {Dator}");
                Console.WriteLine("Datorn vann! Du fick över 21 poäng");
            }
            static void DatornVann(int Spelare, int Dator)
            {
                Console.WriteLine();
                Console.WriteLine($"Dina totala poäng: {Spelare}");
                Console.WriteLine($"Datorns totala poäng: {Dator}");
                Console.WriteLine("Datorn vann! Datorn fick 21 poäng");
            }
            static void SpelareVann(int Spelare, int Dator)
            {
                Console.WriteLine();
                Console.WriteLine($"Dina totala poäng: {Spelare}");
                Console.WriteLine($"Datorns totala poäng: {Dator}");
                Console.WriteLine("Du vann! Du fick 21 poäng");
            }
            static void Båda21(int Spelare, int Dator)
            {
                Console.WriteLine();
                Console.WriteLine($"Dina totala poäng: {Spelare}");
                Console.WriteLine($"Datorns totala poäng: {Dator}");
                Console.WriteLine("Ingen vann! Båda fick 21 poäng");
            }
        }
    }
}