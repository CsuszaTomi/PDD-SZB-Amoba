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
            //Amőba tábla kirajzolása
            for (int i = 0; i < sorok; i++)
            {
                for (int j = 0; j < oszlopok; j++)
                {
                    tabla[i, j] = ".";
                    Console.Write(tabla[i, j] + " ");
                }
                Console.WriteLine();
            }
            //Játék kezdése
            Console.WriteLine($"{mostanijatekos} következik");
            Console.WriteLine("Add meg a sor számát");
            int sor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Add meg az oszlop számát");
            int oszlop = Convert.ToInt32(Console.ReadLine());
        }
    }
}