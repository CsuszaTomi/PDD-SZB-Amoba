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
            string[,] tabla = new string[10, 10];
            //Amőba tábla kirajzolása
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tabla[i, j] = ".";
                    Console.Write(tabla[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
