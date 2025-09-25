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
            int sorok = 10;
            int oszlopok = 10;
            string[,] tabla = new string[sorok, oszlopok];
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
        }
    }
}
