using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private string makeAnEquation(int[] coeficcients, int degreePower, int n)
        {
            string equation = "";
            for(int i = 0; i < n; i++)
            {
                if (coeficcients[i] != 1)
                {
                    equation += coeficcients[i];
                }
                if(degreePower == 1)
                {
                    equation += "x+";
                    degreePower--;
                    continue;
                }
                else if (degreePower == 0 && coeficcients[i] == 1)
                {
                    equation += coeficcients[i];
                    break;
                }
                else if (degreePower == 0)
                {
                    break;
                }
                else
                {
                    equation += "x^" + degreePower + "+";
                    degreePower--;
                    continue;
                }
            }
            return equation;
        }
        private double solveAnEquation(int[] coeficcients, double x, double power, int n)
        {
            double result = 0;
            for(int i = 0; i < n; i++)
            {
                result += coeficcients[i] * Math.Pow(x, power - i);
            }
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int XValue = textBox1.Text[0] - '0';
            int degreePower = textBox2.Text[0] - '0';
            int[] coeficcients = new int[degreePower + 1];
            string coeficcientsInput = richTextBox1.Text;

            int a = 0;
            for(int i = 0; i < coeficcientsInput.Length; i++)
            {
                if (coeficcientsInput[i] == '\n')
                {
                    continue;
                } else
                {
                    coeficcients[a] = coeficcientsInput[i] - '0';
                    a++;
                }
            }
            string equation = makeAnEquation(coeficcients, degreePower, coeficcients.Length);
            label4.Text = equation;
            double result = solveAnEquation(coeficcients, XValue, degreePower, coeficcients.Length);
            textBox3.Text = result.ToString();
        }
    }
}
