using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmőbaProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Alapadatok
            int sorok = 10;
            int oszlopok = 10;
            string[,] tabla = new string[sorok, oszlopok];
            string jatekos1 = "X";
            string jatekos2 = "O";
            string[,] hasznaltmezok = new string[sorok, oszlopok];
            int lepesek = 0;
            bool jatekos1fordulo = true;
            string mostanijatekos = "1. Játékos";
            int currentPoint = 0;
            bool jatek = false;
            for (int i = 0; i < sorok; i++)
            {
                for (int j = 0; j < oszlopok; j++)
                {
                    tabla[i, j] = ".";
                }
            }
            do
            {
                bool selected = false;
                do
                {
                    Menü(currentPoint);
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            selected = true;
                            break;

                        case ConsoleKey.UpArrow:
                            if (currentPoint > 0)
                                currentPoint--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentPoint < 2)
                                currentPoint++;
                            break;

                        default:
                            Console.Beep();
                            break;
                    }
                } while (!selected);
                switch (currentPoint)
                {
                    case 0:     //Játék kezdése
                        Console.Clear();
                        currentPoint = 2;
                        jatek = true;
                        break;
                    case 1: //beállítások menü
                        break;
                    case 2:     //kilepes
                        Console.Clear();
                        Console.Write("Biztosan ki szeretnél lépni?(i/n): ");
                        if (Console.ReadKey().Key != ConsoleKey.I)
                            currentPoint = 0;
                        break;
                }
            } while (currentPoint != 2);
            if(jatek)
            {
                int sor = 0;
                int oszlop = 0;
                do
                {
                    Console.Clear();
                    //Játék kezdése
                    Tábla(sorok, oszlopok, tabla);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Az {mostanijatekos} következik");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Add meg a sor számát(1-10): ");
                    sor = SorEllenorzes();
                    Console.Write("Add meg az oszlop számát(1-10): ");
                    oszlop = Oszlopellenorzes();
                    //elenőrzés hogy már lépett e oda
                    while (hasznaltmezok[sor - 1, oszlop - 1] == jatekos1 || (hasznaltmezok[sor - 1, oszlop - 1] == jatekos2))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erre a mezőre már lépett valaki!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Add meg a sor számát(1-10): ");
                        sor = SorEllenorzes();
                        Console.Write("Add meg az oszlop számát(1-10): ");
                        oszlop = Oszlopellenorzes();
                        while (!(sor > 0 && sor < 11 ))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nem adot meg 1-10-ig terjedő számot!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Add meg a sor számát(1-10): ");
                            sor = SorEllenorzes();

                        }
                        while (oszlop > 0 && oszlop < 11) 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nem adot meg 1-10-ig terjedő számot!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Add meg az oszlop számát(1-10): ");
                            oszlop = Oszlopellenorzes();
                        }
                    }
                    if (jatekos1fordulo)
                    {
                        tabla[sor - 1, oszlop - 1] = jatekos1;
                        hasznaltmezok[sor - 1, oszlop - 1] = jatekos1;
                        jatekos1fordulo = false;
                        mostanijatekos = "2. Játékos";
                    }
                    else
                    {
                        tabla[sor - 1, oszlop - 1] = jatekos2;
                        hasznaltmezok[sor - 1, oszlop - 1] = jatekos2;
                        jatekos1fordulo = true;
                        mostanijatekos = "1. Játékos";
                    }
                    Tábla(sorok, oszlopok, tabla);
                } while (jatek);
            }
        }

        private static int SorEllenorzes()
        {
            int sor;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out sor))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nem számot adott meg!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Add meg a sor számát (1-10): ");
                    continue;
                }

                if (sor < 1 || sor > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nem adott meg 1-10-ig terjedő számot!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Add meg a sor számát (1-10): ");
                    continue;
                }

                return sor;
            }
        }

        private static int Oszlopellenorzes()
        {
            int oszlop;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out oszlop))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nem számot adott meg!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Add meg az oszlop számát (1-10): ");
                    continue;
                }

                if (oszlop < 1 || oszlop > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nem adott meg 1-10-ig terjedő számot!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Add meg az oszlop számát (1-10): ");
                    continue;
                }

                return oszlop;
            }
        }


        private static void Menü(int cPoint)
        {
            Console.Clear();
            Console.Title = "Amőba";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*** AMŐBA ***");
            Console.ForegroundColor = ConsoleColor.White;
            if (cPoint == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Start");
            if (cPoint == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Beállítások");
            if (cPoint == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Kilépés");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Tábla(int sorok, int oszlopok, string[,] tabla)
        {
            //Amőba tábla kirajzolása
            for (int i = 0; i < sorok; i++)
            {
                for (int j = 0; j < oszlopok; j++)
                {
                    Console.Write(tabla[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}