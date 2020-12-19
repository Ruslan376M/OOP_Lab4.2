using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лабораторная_работа__4_ч._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Начало без MVC
        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox1.Text = numericUpDown1.Value.ToString();
                richTextBox1.Text = numericUpDown1.Value.ToString();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int x = 0;
                if (int.TryParse(textBox1.Text, out x))
                {
                    numericUpDown1.Value = x;
                    richTextBox1.Text = textBox1.Text;
                }
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int x = 0;
                if (int.TryParse(richTextBox1.Text, out x))
                {
                    textBox1.Text = richTextBox1.Text;
                    numericUpDown1.Value = x;
                }
            }
        }

        private void numericUpDown2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox2.Text = numericUpDown2.Value.ToString();
                richTextBox2.Text = numericUpDown2.Value.ToString();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int x = 0;
                if (int.TryParse(textBox2.Text, out x))
                {
                    numericUpDown2.Value = x;
                    richTextBox2.Text = textBox2.Text;
                }
            }
        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int x = 0;
                if (int.TryParse(richTextBox2.Text, out x))
                {
                    textBox2.Text = richTextBox2.Text;
                    numericUpDown2.Value = x;
                }
            }
        }


    }


}
