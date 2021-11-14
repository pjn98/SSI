using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Zadanie4_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mu = 4;
            var lambda = 10;
            var tournamentSize = 2;
            var mutationLevel = 10;
            var iterations = 20;
            var parameterNumbers = 2;

            var muPlusLambda = new MuPlusLambda();
            var MuPlusLambdaPool = muPlusLambda.MuPlusLambdaAlgorithm(mu, parameterNumbers, lambda, tournamentSize,
                mutationLevel, iterations);
        }
    }
}
