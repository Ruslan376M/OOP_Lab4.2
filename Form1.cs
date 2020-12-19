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
        Model model;
        public Form1()
        {
            InitializeComponent();
            model = new Model(15, 34);
            model.observers[0] += new EventHandler(updateFromModel1);
            model.observers[1] += new EventHandler(updateFromModel2);

        }

        // Начало без MVC
        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (numericUpDown1.Value < numericUpDown2.Value)
                {
                    textBox1.Text = numericUpDown1.Value.ToString();
                    richTextBox1.Text = numericUpDown1.Value.ToString();
                }
                else
                    numericUpDown1.Value = int.Parse(textBox1.Text);
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
                    if (x < numericUpDown2.Value)
                    {
                        numericUpDown1.Value = x;
                        richTextBox1.Text = textBox1.Text;
                    }
                    else
                        textBox1.Text = numericUpDown1.Value.ToString();
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
                    if (x < numericUpDown2.Value)
                    {
                        textBox1.Text = richTextBox1.Text;
                        numericUpDown1.Value = x;
                    }
                    else
                        richTextBox1.Text = numericUpDown1.Value.ToString();
                }
            }
        }

        private void numericUpDown2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (numericUpDown1.Value < numericUpDown2.Value)
                {
                    textBox2.Text = numericUpDown2.Value.ToString();
                    richTextBox2.Text = numericUpDown2.Value.ToString();
                }
                else
                    numericUpDown2.Value = int.Parse(textBox2.Text);
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
                    if (x > numericUpDown1.Value)
                    {
                        numericUpDown2.Value = x;
                        richTextBox2.Text = textBox2.Text;
                    }
                    else
                        textBox2.Text = numericUpDown2.Value.ToString();
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
                    if (x > numericUpDown1.Value)
                    {
                        textBox2.Text = richTextBox2.Text;
                        numericUpDown2.Value = x;
                    }
                    else
                        richTextBox2.Text = numericUpDown2.Value.ToString();
                }
            }
        }

        // MVC
        public void updateFromModel1(object sender, EventArgs e)
        {
            numericUpDown3.Value = model.getValue(0);
            textBox3.Text = model.getValue(0).ToString();
            richTextBox3.Text = model.getValue(0).ToString();
        }

        public void updateFromModel2(object sender, EventArgs e)
        {
            numericUpDown4.Value = model.getValue(1);
            textBox4.Text = model.getValue(1).ToString();
            richTextBox4.Text = model.getValue(1).ToString();
        }

        private void numericUpDown3_KeyDown(object sender, KeyEventArgs e)
       {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                model.setValue(Convert.ToInt32(numericUpDown3.Value), 0);
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int x = 0;
                if (int.TryParse(textBox3.Text, out x))
                    model.setValue(x, 0);
            }
        }

        private void richTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int x = 0;
                if (int.TryParse(richTextBox3.Text, out x))
                    model.setValue(x, 0);
            }
        }

        private void numericUpDown4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                model.setValue(Convert.ToInt32(numericUpDown4.Value), 1);
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int x = 0;
                if (int.TryParse(textBox4.Text, out x))
                    model.setValue(x, 1);
            }
        }

        private void richTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int x = 0;
                if (int.TryParse(richTextBox4.Text, out x))
                    model.setValue(x, 1);
            }
        }
    }

    public class Model
    {
        private int[] value = new int[2];
        public EventHandler[] observers = new EventHandler[2];

        public Model(int value1, int value2)
        {
            value[0] = value1;
            value[1] = value2;
        }
        public void setValue(int value, int i)
        {
            if (i == 0 && value < this.value[1] || i == 1 && value > this.value[0])
                this.value[i] = value;
            observers[i].Invoke(this, null);
        }

        public int getValue(int i)
        {
            return value[i];
        }
    }
}
