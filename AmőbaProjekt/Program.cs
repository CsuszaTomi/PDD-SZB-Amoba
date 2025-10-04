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
            int lepesek = sorok*oszlopok;
            bool jatekos1fordulo = true;
            string mostanijatekos = "1. Játékos";
            int currentPoint = 0;
            bool jatek = false;
            int beallitasvalaszto = 0;
            int szinvalaszto = 0;
            int jatekopcio = 0;
            int size = 10;
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
                        jatek = true;
                        Jatek(sorok, oszlopok, tabla, jatekos1, jatekos2, hasznaltmezok, ref lepesek, ref jatekos1fordulo, ref mostanijatekos, ref currentPoint, ref jatek, size);
                        break;

                    case 1: // Beállítások
                        beallitasvalaszto = Beallitasok(ref sorok, ref oszlopok, ref jatekos1, ref jatekos2, ref szinvalaszto, ref jatekopcio, ref size);
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
        }

        private static int Beallitasok(ref int sorok, ref int oszlopok, ref string jatekos1, ref string jatekos2, ref int szinvalaszto, ref int jatekopcio, ref int size)
        {
            int beallitasvalaszto;
            Console.Clear();
            beallitasvalaszto = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*** BEÁLLÍTÁSOK ***");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Háttérszín állítása");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("2. Játékmenet beállítások");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enterrel vissza a menübe");
            Console.ForegroundColor = ConsoleColor.White;
            while (beallitasvalaszto < 1)
            {
                Console.Write("Add meg a menüpont számát: ");
                if (!int.TryParse(Console.ReadLine(), out beallitasvalaszto))
                {
                    break;
                }
            }
            if (beallitasvalaszto == 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*** HÁTTÉRSZÍN ÁLLÍTÓ ***");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. Fekete");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("2. Kék");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("3. Zöld");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("4. Cián");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("5. Piros");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Add meg a háttérszín számát: ");
                while (!int.TryParse(Console.ReadLine(), out szinvalaszto))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nem jó számot adott meg!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Add meg a háttérszín számát: ");
                }
                switch (szinvalaszto)
                {
                    case 1:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        break;
                    case 2:
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Clear();
                        break;
                    case 3:
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Clear();
                        break;
                    case 4:
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Clear();
                        break;
                    case 5:
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Clear();
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        break;
                }
            }
            if (beallitasvalaszto == 2)
            {
                jatekopcio = 0;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*** JÁTÉK BEÁLLÍTÁSOK ***");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Játéktér méretének módosítása");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("2. Játékosok jelöléseinek módosítása");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enterrel vissza a menübe");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Add meg az opció számát: ");
                if (!int.TryParse(Console.ReadLine(), out jatekopcio))
                {

                }
                if (jatekopcio == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("*** TÁBLA MÉRET ÁLLÍTÓ ***");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"A tábla mérete jelenleg {size}x{size}, maximum 50x50-es táblát lehet beállítani.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Add meg a tábla méretét(5-50): ");
                    Console.ForegroundColor = ConsoleColor.White;
                    while (!int.TryParse(Console.ReadLine(), out size) || size < 5 || size > 50)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nem jó számot adott meg!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Add meg a tábla méretét(5-50): ");
                    }
                    sorok = size;
                    oszlopok = size;
                }
                if (jatekopcio == 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("*** JÁTÉKOS KARAKTER VÁLASZTÓ ***");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"A játékosok jelölései jelenleg {jatekos1} és {jatekos2}.");
                    string jatekos1v;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Add meg az 1. játékos jelölését (alapértelmezett: X): ");
                    Console.ForegroundColor = ConsoleColor.White;
                    jatekos1v = Console.ReadLine();
                    while (jatekos1v == jatekos2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ezt a karaktert az 2. játékos már használja! Adja meg újra!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Add meg az 1. játékos jelölését (alapértelmezett: X): ");
                        Console.ForegroundColor = ConsoleColor.White;
                        jatekos1v = Console.ReadLine();
                    }
                    while (jatekos1v != "" || jatekos1v != " ")
                    {
                        if (jatekos1v.Length > 1 || jatekos1v.Length < 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nem jól adta meg a jelölést! Adja meg újra!");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Add meg az 1. játékos jelölését (alapértelmezett: X): ");
                            Console.ForegroundColor = ConsoleColor.White;
                            jatekos1v = Console.ReadLine();
                            while (jatekos1v == jatekos2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ezt a karaktert az 1. játékos már használja!");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Add meg az 1. játékos jelölését (alapértelmezett: O): ");
                                Console.ForegroundColor = ConsoleColor.White;
                                jatekos1v = Console.ReadLine();
                            }
                        }
                        else
                        {
                            jatekos1 = jatekos1v;
                            break;
                        }
                    }
                    string jatekos2v;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Add meg az 2. játékos jelölését (alapértelmezett: O): ");
                    Console.ForegroundColor = ConsoleColor.White;
                    jatekos2v = Console.ReadLine();
                    while (jatekos2v == jatekos1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ezt a karaktert az 1. játékos már használja!");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Add meg az 2. játékos jelölését (alapértelmezett: O): ");
                        Console.ForegroundColor = ConsoleColor.White;
                        jatekos2v = Console.ReadLine();
                    }
                    while (jatekos2v != "" || jatekos2v != " ")
                    {
                        if (jatekos2v.Length > 1 || jatekos2v.Length < 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nem jól adta meg a jelölést! Adja meg újra!");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Add meg az 2. játékos jelölését (alapértelmezett: O): ");
                            Console.ForegroundColor = ConsoleColor.White;
                            jatekos2v = Console.ReadLine();
                            while (jatekos2v == jatekos1v)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ezt a karaktert az 1. játékos már használja!");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("Add meg az 2. játékos jelölését (alapértelmezett: O): ");
                                Console.ForegroundColor = ConsoleColor.White;
                                jatekos2v = Console.ReadLine();
                            }
                        }
                        else
                        {
                            jatekos2 = jatekos2v;
                            break;
                        }
                    }
                }
            }

            return beallitasvalaszto;
        }

        /// <summary>
        /// Maga a játék indítása,lépéskérés,ellenőrzések
        /// </summary>
        /// <returns></returns>
        private static void Jatek(int sorok, int oszlopok, string[,] tabla, string jatekos1, string jatekos2, string[,] hasznaltmezok, ref int lepesek, ref bool jatekos1fordulo, ref string mostanijatekos, ref int currentPoint, ref bool jatek, int size)
        {
            if (jatek)
            {
                tabla = new string[sorok, oszlopok];
                hasznaltmezok = new string[sorok, oszlopok];
                for (int i = 0; i < sorok; i++)
                {
                    for (int j = 0; j < oszlopok; j++)
                    {
                        tabla[i, j] = " ";
                        hasznaltmezok[i, j] = " ";
                    }
                }
                lepesek = sorok * oszlopok;
                jatekos1fordulo = true;
                mostanijatekos = "1. Játékos";
                int sor = 0;
                int oszlop = 0;
                int elejikiiras = 0;
                do
                {
                    Console.Clear();
                    Tabla(sorok, oszlopok, tabla, size, jatekos1, jatekos2);
                    if (elejikiiras == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Kilépéshez írd be hogy esc/kilepes/vissza.");
                        elejikiiras++;
                    }
                    if (lepesek == 0)
                    {
                        Console.Clear();
                        Tabla(sorok, oszlopok, tabla, size, jatekos1, jatekos2);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("A játéknak vége mivel elfogyott a hely. Így az állás döntetlen lett!");
                        jatek = false;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Nyomd meg az entert a menübe való visszatéréshez!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Az {mostanijatekos} következik");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write($"Add meg a sor számát (1-{size}): ");
                    sor = SorEllenorzes(size) - 1;
                    if (sor == 998)
                    {
                        Console.WriteLine("Break");
                        break;
                    }
                    Console.Write($"Add meg az oszlop számát (1-{size}): ");
                    oszlop = Oszlopellenorzes(size) - 1;
                    if (oszlop == 998)
                    {
                        Console.WriteLine("Break");
                        break;
                    }
                    // Ellenőrzés
                    while (hasznaltmezok[sor, oszlop] == jatekos1 || hasznaltmezok[sor, oszlop] == jatekos2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erre a mezőre már lépett valaki!");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write($"Add meg a sor számát (1-{size}): ");
                        sor = SorEllenorzes(size) - 1;
                        if (sor == 998)
                        {
                            Console.WriteLine("Break");
                            break;
                        }
                        Console.Write($"Add meg az oszlop számát (1-{size}): ");
                        oszlop = Oszlopellenorzes(size) - 1;
                        if (oszlop == 998)
                        {
                            Console.WriteLine("Break");
                            break;
                        }
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
                                Tabla(sorok, oszlopok, tabla, size, jatekos1, jatekos2);
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
                                Tabla(sorok, oszlopok, tabla, size, jatekos1, jatekos2);
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
                            if (tabla[sor1, oszlop1] != " " && tabla[sor1, oszlop1] == tabla[sor1 + 1, oszlop1 + 1] && tabla[sor1, oszlop1] == tabla[sor1 + 2, oszlop1 + 2] && tabla[sor1, oszlop1] == tabla[sor1 + 3, oszlop1 + 3] && tabla[sor1, oszlop1] == tabla[sor1 + 4, oszlop1 + 4])
                            {
                                Console.Clear();
                                Tabla(sorok, oszlopok, tabla,size, jatekos1, jatekos2);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"{mostanijatekos} nyert!");
                                Console.ForegroundColor = ConsoleColor.White;
                                jatek = false;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Nyomd meg az entert a menübe való visszatéréshez!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                            }
                            else if (tabla[sor1 + 4, oszlop1] != " " && tabla[sor1 + 4, oszlop1] == tabla[sor1 + 3, oszlop1 + 1] && tabla[sor1 + 4, oszlop1] == tabla[sor1 + 2, oszlop1 + 2] && tabla[sor1 + 4, oszlop1] == tabla[sor1 + 1, oszlop1 + 3] && tabla[sor1 + 4, oszlop1] == tabla[sor1, oszlop1 + 4])
                            {
                                Console.Clear();
                                Tabla(sorok, oszlopok, tabla, size, jatekos1, jatekos2);
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
                    if (mostanijatekos == "1. Játékos")
                    {
                        mostanijatekos = "2. Játékos";
                    }
                    else
                    {
                        mostanijatekos = "1. Játékos";
                    }
                    lepesek--;
                } while (jatek);
            }
        }

        /// <summary>
        /// Sor szám ellenőrzése hogy nem betü-e és 1-10 közötti szám-e
        /// </summary>
        /// <returns></returns>
        private static int SorEllenorzes(int size)
        {
            string sorinput = Console.ReadLine();
            int sor;
            bool kilep = false;
            if (sorinput == "esc" || sorinput == "kilepes" || sorinput == "vissza")
            {
                kilep = true;
                return 999;
            }
            while (!int.TryParse(sorinput, out sor) && kilep == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nem számot adott meg!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Add meg az sor számát (1-{size}): ");
                sorinput = Console.ReadLine();
            }
            while (sor < 1 || sor > size && kilep == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Nem adott meg 1-{size}-ig terjedő számot!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Add meg az sor számát (1-{size}): ");
                sorinput = Console.ReadLine();
                while (!int.TryParse(sorinput, out sor) && kilep == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nem számot adott meg!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Add meg az sor számát (1-{size}): ");
                    sorinput = Console.ReadLine();
                }
            }
            if (kilep == false)
            {
                return sor;
            }
            else
            {
                return sor;
            }
        }

        /// <summary>
        /// Oszlop szám ellenőrzése hogy nem betü-e és 1-10 közötti szám-e
        /// </summary>
        /// <returns></returns>
        private static int Oszlopellenorzes(int size)
        {
            string oszlopinput = Console.ReadLine();
            bool kilep = false;
            int oszlop;
            if (oszlopinput == "esc" || oszlopinput == "kilepes" || oszlopinput == "vissza")
            {
                    kilep = true;
                    return 999;
            }
            while (!int.TryParse(oszlopinput, out oszlop) && kilep == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nem számot adott meg!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Add meg az oszlop számát (1-{size}): ");
                oszlopinput = Console.ReadLine();
            }
            while (oszlop < 1 || oszlop > size && kilep == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Nem adott meg 1-{size}-ig terjedő számot!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Add meg az oszlop számát (1-{size}): ");
                oszlopinput = Console.ReadLine();
                while (!int.TryParse(oszlopinput, out oszlop) && kilep == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nem számot adott meg!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Add meg az oszlop számát (1-{size}): ");
                    oszlopinput = Console.ReadLine();
                }
            }
            if (kilep == false)
            {
                    return oszlop;
            }
            else
            {
                return oszlop;
            }
        }

        /// <summary>
        /// A menü kirajzolása, lehetőségek kiirása
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

        private static void Tabla(int sorok, int oszlopok, string[,] tabla, int size, string jatekos1, string jatekos2)
        {
            // Oszlop szamok kiirasa
            Console.Write("   ");
            for (int i = 0; i < size; i++)
            {
                Console.Write($" {i + 1,2} ");
            }
            Console.WriteLine();

            // Felso keret
            Console.Write("  ┌");
            for (int i = 0; i < size; i++)
            {
                Console.Write("───");
                if (i != size - 1) Console.Write("┬");
            }
            Console.Write("┐\n");

            for (int sor = 0; sor < size; sor++)
            {
                Console.Write($"{sor + 1,2}│"); //sor számok kiirasa
                for (int oszlop = 0; oszlop < size; oszlop++)
                {
                    if (tabla[sor, oszlop] == jatekos1)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (tabla[sor, oszlop] == jatekos2)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.Write($" {tabla[sor, oszlop]} ");
                    Console.ForegroundColor = ConsoleColor.White;

                    if (oszlop != size - 1) Console.Write("│");
                }
                Console.Write("│\n");

                if (sor != size - 1)
                {
                    Console.Write("  ├");
                    for (int elvalaszto = 0; elvalaszto < size; elvalaszto++)
                    {
                        Console.Write("───");
                        if (elvalaszto != size - 1) Console.Write("┼");
                    }
                    Console.Write("┤\n");
                }
            }

            // Also keret
            Console.Write("  └");
            for (int i = 0; i < size; i++)
            {
                Console.Write("───");
                if (i != size - 1) Console.Write("┴");
            }
            Console.Write("┘\n");
        }
    }
}