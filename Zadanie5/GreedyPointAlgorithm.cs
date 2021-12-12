using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyPoint_Nazwisko_Imie
{
    public static class GreedyPointAlgorithm
    {
        public static List<bool[,]> bazaObrazow = new List<bool[,]>();

        public static void DodajObrazDoBazy(bool[,] obraz)
        {
            bazaObrazow.Add(obraz);
        }

        public static double MiaraNiepodobienstwa(bool[,] BA, bool[,] BB)
        {
            var miara = 0.0;

            for (var pay = 0; pay < BA.GetLength(0); pay++)
            for (var pax = 0; pax < BA.GetLength(1); pax++)
            {
                if (!BA[pay, pax])
                    continue;

                var odl_min = double.PositiveInfinity;
                for (var pby = 0; pby < BB.GetLength(0); pby++)
                for (var pbx = 0; pbx < BB.GetLength(1); pbx++)
                {
                    if (!BB[pby, pbx])
                        continue;

                    var odl_akt = MiaraEuklidesowa(pay, pax, pby, pbx);
                    odl_min = odl_min > odl_akt ? odl_akt : odl_min;
                }

                miara += odl_min;
            }

            return miara;
        }

        public static int RozpoznajObraz(bool[,] obraz)
        {
            var odl_min = double.NegativeInfinity;
            var wynik = -1;
            var iteracja = 1;
            foreach (var obraz_baza in bazaObrazow)
            {
                var odleglosc = -MiaraNiepodobienstwa(obraz_baza, obraz) - MiaraNiepodobienstwa(obraz, obraz_baza);
                if (odleglosc > odl_min)
                {
                    odl_min = odleglosc;
                    wynik = iteracja;
                }

                iteracja++;
            }

            return wynik;
        }

        public static double MiaraEuklidesowa(int pay, int pax, int pby, int pbx)
        {
            var odleglosc = Math.Pow(pay - pby, 2) + Math.Pow(pax - pbx, 2);
            return Math.Sqrt(odleglosc);
        }
    }
}