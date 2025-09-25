using System;
using System.Collections.Generic;
using System.Linq;
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
            for (int i = 0; i < sorok; i++)
            {
                for (int j = 0; j < oszlopok; j++)
                {
                    tabla[i, j] = ".";
                }
            }
            Tábla(sorok, oszlopok, tabla);
            do
            {
                //Játék kezdése
                Console.WriteLine($"{mostanijatekos} következik");
                Console.WriteLine("Add meg a sor számát(1-10)");
                int sor = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Add meg az oszlop számát(1-10)");
                int oszlop = Convert.ToInt32(Console.ReadLine());
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
            } while (true);
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