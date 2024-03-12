using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesafioTarget
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Btn_Fibonacci_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(Txt_Fibonacci.Text);
                List<string> fibonacci = GenerateFibonacciSequence(number);
                Lbl_Numbers.Text = string.Join(", ", fibonacci);
                NumberIsInFibonacci(number, fibonacci);
            }
            catch (Exception)
            {
                MessageBox.Show("Entre com um número válido.", "Desafio Target", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NumberIsInFibonacci(int number, List<string> fibonacci)
        {
            foreach (string item in fibonacci)
            {
                if (number.ToString() == item)
                {
                    Lbl_ResultFibonacci.ForeColor = Color.Green;
                    Lbl_ResultFibonacci.Text = $"O número {number} está na sequencia de Fibonacci.";
                    return;
                }
            }
            Lbl_ResultFibonacci.ForeColor = Color.Red;
            Lbl_ResultFibonacci.Text = $"O número {number} não está na sequencia de Fibonacci.";
        }

        private List<string> GenerateFibonacciSequence(int count)
        {
            List<string> fibonacci = new List<string>();
            if (count == 0)
            {
                MessageBox.Show("Entre com um número válido.", "Desafio Target", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fibonacci.Add("0");
                fibonacci.Add("1");
                for (int i = 2; i < count; i++)
                {
                    if (i >= 2 && i - 1 < fibonacci.Count && i - 2 < fibonacci.Count)
                    {
                        BigInteger nextNumber = BigInteger.Parse(fibonacci[i - 1]) + BigInteger.Parse(fibonacci[i - 2]);
                        string nextNumberStr = nextNumber.ToString();
                        fibonacci.Add(nextNumberStr);
                    }
                }
                return fibonacci;
            }
            return fibonacci;
        }

        private void Btn_Palavra_Click(object sender, EventArgs e)
        {
            string word = Txt_Palavra.Text;
            string reversedWord = ReversedWord(word);
            Lbl_ResultadoPalavra.Text = reversedWord;
        }

        private string ReversedWord(string word)
        {
            string reversed = "";
            for (int i = word.Length -1; i >= 0; i--)
            {
                reversed += word[i];
            }
            return reversed;
        }
    }
}
