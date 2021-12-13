using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopfieldaSiec
{
    public static class HopfieldaSiecAlgorytm
    {
        public static List<bool[,]> bazaObrazow = new List<bool[,]>();
        public static double[,] wagiObrazu;
        public static int n;

        public static void Inicjuj(int szerokosc, int wysokosc)
        {
            n = szerokosc * wysokosc;
            wagiObrazu = new double[n, n];
            Array.Clear(wagiObrazu, 0, wagiObrazu.Length);
        }

        public static void NauczObraz(bool[,] obraz)
        {
            var wektor = StworzWektor(obraz);

            for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                wagiObrazu[i, j] = i == j ? 0 : (double) (wagiObrazu[i, j] + (double) (wektor[i] * wektor[j]) / n);
        }

        public static int[] StworzWektor(bool[,] obraz)
        {
            var wektor = new int[obraz.GetLength(0) * obraz.GetLength(1)];
            for (var i = 0; i < obraz.GetLength(0); i++)
            for (var j = 0; j < obraz.GetLength(1); j++)
                wektor[i * obraz.GetLength(0) + j] = obraz[i, j] ? 1 : -1;
            return wektor;
        }

        public static bool RozpoznajObraz(ref bool[,] obraz)
        {
            var iteracje = 10;
            var wektor = StworzWektor(obraz);
            var suma_tymczasowa = new double[n];
            Array.Clear(suma_tymczasowa, 0, suma_tymczasowa.Length);
            for (var i = 0; i < iteracje; i++)
            {
                suma_tymczasowa = SumaTymczasowa(suma_tymczasowa, wektor);
                for (var j = 0; j < n; j++) wektor[j] = Sigma(suma_tymczasowa[j]);
            }

            for (var i = 0; i < obraz.GetLength(0); i++)
            for (var j = 0; j < obraz.GetLength(1); j++)
                obraz[i, j] = wektor[i * obraz.GetLength(0) + j] == 1;

            return true;
        }

        public static int Sigma(double wartosc)
        {
            return wartosc >= 0 ? 1 : -1;
        }

        public static double[] SumaTymczasowa(double[] suma_tymczasowa, int[] wektor)
        {
            for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                suma_tymczasowa[i] += wektor[j] * wagiObrazu[i, j];
            return suma_tymczasowa;
        }
    }
}