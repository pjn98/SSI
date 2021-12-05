using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreedyPoint_Nazwisko_Imie
{
    public partial class FormGreedyPoint : Form
    {
        public const int poleSzerokosc = 5;
        public const int poleWysokosc  = 5;
        public const int bitmapkaLiczbaPikseli = 30; // liczba pikseli w poziomie i pionie przeznaczonych na zapis 1 pola
        
        protected bool[,]  pole;
        protected Bitmap bitmapka;

        public bool polePobierz(int x, int y)
        {
            return pole[x, y];
        }

        public bool poleUstaw(int x, int y, bool nowaWartosc)
        {
            bool staraWartosc = pole[x, y];
            pole[x, y] = nowaWartosc;

            for (int bmpY = y*bitmapkaLiczbaPikseli; bmpY < (y + 1)* bitmapkaLiczbaPikseli; bmpY++)
                for (int bmpX = x * bitmapkaLiczbaPikseli; bmpX < (x + 1) * bitmapkaLiczbaPikseli; bmpX++)
                {
                    if (nowaWartosc)
                        bitmapka.SetPixel(bmpX, bmpY, Color.Black);
                    else
                        bitmapka.SetPixel(bmpX, bmpY, Color.White);
                }

            pictureBoxPoletko.Refresh();
            return staraWartosc;
        }

        public void poleCaleWyczysc()
        {
            for (int y = 0; y < poleWysokosc; y++)
                for (int x = 0; x < poleSzerokosc; x++)
                    poleUstaw(x, y, false);
        }

        public bool[,] poleCalePobierz()
        {
            return (bool[,]) pole.Clone();
        }

        public void poleCaleUstaw(bool[,] nowaWartosc)
        {
            if (nowaWartosc.GetLength(0) != poleSzerokosc)
                throw new ArgumentException("nowaWartosc.GetLength(0) != poleSzerokosc");
            if (nowaWartosc.GetLength(1) != poleWysokosc)
                throw new ArgumentException("nowaWartosc.GetLength(1) != poleWysokosc");

            for (int y = 0; y < poleWysokosc; y++)
                for (int x = 0; x < poleSzerokosc; x++)
                    poleUstaw(x, y, nowaWartosc[x, y]);
        }

        public FormGreedyPoint()
        {
            InitializeComponent();

            pole = new bool[poleSzerokosc, poleWysokosc];

            bitmapka = new System.Drawing.Bitmap(poleSzerokosc * bitmapkaLiczbaPikseli, poleWysokosc * bitmapkaLiczbaPikseli, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            pictureBoxPoletko.Image = bitmapka;

            poleCaleWyczysc();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBoxPoletko_Click(object sender, EventArgs e)
        {        
        }

        private void pictureBoxPoletko_MouseMove(object sender, MouseEventArgs e)
        {
            int x, y;
            x = e.X / bitmapkaLiczbaPikseli;
            y = e.Y / bitmapkaLiczbaPikseli;

            if (x < 0 || x >= poleSzerokosc || y < 0 || y >= poleWysokosc)
                return;

            if (e.Button == MouseButtons.Left)
                poleUstaw(x, y, true);
            if (e.Button == MouseButtons.Right)
                poleUstaw(x, y, false);
        }

        private void pictureBoxPoletko_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBoxPoletko_MouseMove(sender, e);
        }

        private void DodajObrazDoBazyButton_Click(object sender, EventArgs e)
        {
            bool[,] obraz = poleCalePobierz();
            GreedyPointAlgorithm.dodajObrazDoBazy(obraz);
            
            StringBuilder wpisWBazie = new StringBuilder(poleSzerokosc * poleWysokosc);
            for (int y = 0; y < poleWysokosc; y++)
                for (int x = 0; x < poleSzerokosc; x++)
                    wpisWBazie.Append((polePobierz(x, y)) ? ('1') : ('0'));

            BazaObrazowListView.Items.Add(wpisWBazie.ToString());
        }

        private void ObrazRozpoznajButton_Click(object sender, EventArgs e)
        {
            int obrazRozpoznanyIdx = -1;
            bool[,] obraz = poleCalePobierz();
            obrazRozpoznanyIdx = GreedyPointAlgorithm.rozpoznajObraz(obraz);
            informacjeLabel.Text = "rozpoznany obraz nr: " + obrazRozpoznanyIdx.ToString();

            obrazRozpoznanyIdx = 0;
            if (obrazRozpoznanyIdx >= 0 && obrazRozpoznanyIdx < BazaObrazowListView.Items.Count)
            {
                BazaObrazowListView.Items[obrazRozpoznanyIdx].Checked = true;
                BazaObrazowListView.Items[obrazRozpoznanyIdx].Selected = true;
            }
        }

        private void BazaObrazowListView_Click(object sender, EventArgs e)
        {
            string obrazZBazyStr;
            if (BazaObrazowListView.SelectedItems.Count != 1)
                return;
            obrazZBazyStr = BazaObrazowListView.SelectedItems[0].Text;
            if (obrazZBazyStr.Length != poleWysokosc * poleSzerokosc)
                return;
            for (int y = 0; y < poleWysokosc; y++)
                for (int x = 0; x < poleSzerokosc; x++)
                    poleUstaw(x, y, (obrazZBazyStr[x + y * poleWysokosc] == '1') ? (true) : (false));
        }
        
    }
}
