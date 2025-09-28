using System;

namespace AmobaProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Alapadatok
            int sorok = 10;
            int oszlopok = 10;
            string[,] tabla = new string[sorok, oszlopok];
            string jatekos1 = "X";
            string jatekos2 = "O";
            string[,] hasznaltmezok = new string[sorok, oszlopok];
            int lepesek = 100;
            bool jatekos1fordulo = true;
            string mostanijatekos = "1. Játékos";
            int currentPoint = 0;
            bool jatek = false;
            //Tábla feltöltése
            for (int i = 0; i < sorok; i++)
            {
                for (int j = 0; j < oszlopok; j++)
                {
                    tabla[i, j] = " ";
                    hasznaltmezok[i, j] = " ";
                }
            }

            //menü
            do
            {
                bool selected = false;
                do
                {
                    Menu(currentPoint);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter:
                            selected = true;
                            break;

                        case ConsoleKey.UpArrow:
                            if (currentPoint > 0) currentPoint--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentPoint < 2) currentPoint++;
                            break;

                        default:
                            Console.Beep();
                            break;
                    }
                } while (!selected);

                switch (currentPoint)
                {
                    case 0: // Játék kezdése
                        Console.Clear();
                        currentPoint = 2;
                        jatek = true;
                        break;

                    case 1: // Beállítások
                        Console.Clear();
                        break;

                    case 2: // Kilépés
                        Console.Clear();
                        Console.Write("Biztosan ki szeretnél lépni? (i/n): ");
                        char valasz = Console.ReadKey(true).KeyChar;
                        if (valasz != 'i' && valasz != 'I')
                            currentPoint = 0;
                        break;
                }
            } while (currentPoint != 2);

            // Játék futtatása
            if (jatek)
            {
                int sor = 0;
                int oszlop = 0;
                do
                {
                    Console.Clear();
                    Tabla(sorok, oszlopok, tabla);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Az {mostanijatekos} következik");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("Add meg a sor számát (1-10): ");
                    sor = SorEllenorzes() - 1;
                    Console.Write("Add meg az oszlop számát (1-10): ");
                    oszlop = Oszlopellenorzes() - 1;

                    // Ellenőrzés
                    while (hasznaltmezok[sor, oszlop] == jatekos1 || hasznaltmezok[sor, oszlop] == jatekos2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erre a mezőre már lépett valaki!");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("Add meg a sor számát (1-10): ");
                        sor = SorEllenorzes() - 1;
                        Console.Write("Add meg az oszlop számát (1-10): ");
                        oszlop = Oszlopellenorzes() - 1;
                    }
                    //Játékos lépése
                    if (jatekos1fordulo)
                    {
                        tabla[sor, oszlop] = jatekos1;
                        hasznaltmezok[sor, oszlop] = jatekos1;
                        jatekos1fordulo = false; ;
                    }
                    else
                    {
                        tabla[sor, oszlop] = jatekos2;
                        hasznaltmezok[sor, oszlop] = jatekos2;
                        jatekos1fordulo = true;

                    }
                    //Függőleges,víszintes ellenőrzés
                    for (int sorv = 0; sorv < sorok; sorv++)
                    {
                        for (int oszlopv = 0; oszlopv < oszlopok - 4; oszlopv++)
                        {
                            if (tabla[sorv, oszlopv] != " " && tabla[sorv, oszlopv] == tabla[sorv, oszlopv + 1] && tabla[sorv, oszlopv] == tabla[sorv, oszlopv + 2] && tabla[sorv, oszlopv] == tabla[sorv, oszlopv + 3] && tabla[sorv, oszlopv] == tabla[sorv, oszlopv + 4])
                            {
                                Console.Clear();
                                Tabla(sorok, oszlopok, tabla);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"{mostanijatekos} nyert!");
                                Console.ForegroundColor = ConsoleColor.White;
                                jatek = false;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Nyomd meg az entert a menübe való visszatéréshez!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                            }
                        }
                    }
                    for (int sorv = 0; sorv < sorok - 4; sorv++)
                    {
                        for (int oszlopv = 0; oszlopv < oszlopok; oszlopv++)
                        {
                            if (tabla[sorv, oszlopv] != " " && tabla[sorv, oszlopv] == tabla[sorv + 1, oszlopv] && tabla[sorv, oszlopv] == tabla[sorv + 2, oszlopv] && tabla[sorv, oszlopv] == tabla[sorv + 3, oszlopv] && tabla[sorv, oszlopv] == tabla[sorv + 4, oszlopv])
                            {
                                Console.Clear();
                                Tabla(sorok, oszlopok, tabla);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"{mostanijatekos} nyert!");
                                Console.ForegroundColor = ConsoleColor.White;
                                jatek = false;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Nyomd meg az entert a menübe való visszatéréshez!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                            }
                        }
                    }
                    //Átlós ellenőrzés

                    for (int sor1 = 0; sor1 < sorok-4; sor1++)
                    {
                        for (int oszlop1 = 0; oszlop1 < oszlopok - 4; oszlop1++)
                        {
                            if (tabla[sor1, oszlop1] == "X" && tabla[sor1 + 1, oszlop1 + 1] == "X" && tabla[sor1 + 2, oszlop1 + 2] == "X" && tabla[sor1 + 3, oszlop1 + 3] == "X" && tabla[sor1 + 4, oszlop1 + 4] == "X")
                            {
                                Console.Clear();
                                Tabla(sorok, oszlopok, tabla);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"{mostanijatekos} nyert!");
                                Console.ForegroundColor = ConsoleColor.White;
                                jatek = false;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Nyomd meg az entert a menübe való visszatéréshez!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                            }
                        }
                    }



                    //Lépésszám csökkentése
                    if (jatek)
                    {
                        Tabla(sorok, oszlopok, tabla);
                    }
                    if (mostanijatekos == "1. Játékos")
                    {
                        mostanijatekos = "2. Játékos";
                    }
                    else
                    {
                        mostanijatekos = "1. Játékos";
                    }
                    lepesek--;
                } while (jatek && lepesek > 0);
                currentPoint = 0;
                Menu(currentPoint);
            }
        }

        /// <summary>
        /// Sor szám ellenőrzése hogy nem betü-e és 1-10 közötti szám-e
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Oszlop szám ellenőrzése hogy nem betü-e és 1-10 közötti szám-e
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// A menü kirajzolása,lehetőségek kiirása
        /// </summary>
        /// <returns></returns>
        private static void Menu(int cPoint)
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

        private static void Tabla(int sorok, int oszlopok, string[,] tabla)
        {
            int size = 10;
            Console.Write("┌");
            for (int i = 0; i < size; i++)
            {
                Console.Write("───");
                if (i != size - 1) Console.Write("┬");
            }
            Console.Write("┐\n");

            for (int sor = 0; sor < size; sor++)
            {
                Console.Write("│");
                for (int oszlop = 0; oszlop < size; oszlop++)
                {
                    if (tabla[sor, oszlop] == "X")
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (tabla[sor, oszlop] == "O")
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($" {tabla[sor, oszlop]} ");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (oszlop != size - 1) Console.Write("│");
                }
                Console.Write("│\n");

                if (sor != size - 1)
                {
                    Console.Write("├");
                    for (int elvalaszto = 0; elvalaszto < size; elvalaszto++)
                    {
                        Console.Write("───");
                        if (elvalaszto != size - 1) Console.Write("┼");
                    }
                    Console.Write("┤\n");
                }
            }

            Console.Write("└");
            for (int i = 0; i < size; i++)
            {
                Console.Write("───");
                if (i != size - 1) Console.Write("┴");
            }
            Console.Write("┘\n");
        }
    }
}