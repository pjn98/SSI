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

        public static int MiaraNiepodobienstwa(bool[,] BA, bool[,] BB)
        {
            var miara = 0;

            for(var pay = 0; pay < BA.GetLength(0); pay++)
            {
                for (var pax = 0; pax < BA.GetLength(1); pax++)
                {
                    //double odl_min = -999;
                }
            }

            return miara;
        }

        public static int RozpoznajObraz(bool[,] obraz)
        {
            // ... 
            // zwróc numer rozpoznanego obrazu albo -1
            return -1; 
        }
 
    }
}
