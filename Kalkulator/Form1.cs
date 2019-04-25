using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        Double value = 0.0;
        String op = "";
        bool opPressed = false;
        bool dotPressed = false;
        bool eqPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    
        private void button_Click(object sender, EventArgs e)
        {
            if (eqPressed)
                textBox1.Text = "0";
            eqPressed = false;
            
            if (textBox1.Text == "0")
               textBox1.Clear();
            opPressed = false;
            Button b = (Button)sender;
            if (textBox1.Text.Length < 12)
            {
                textBox1.Text = textBox1.Text + b.Text;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            dotPressed = false;
            
        }

        private void opClick(object sender, EventArgs e)
        {
            opPressed = true;
            eqPressed = false;
            dotPressed = false;
            Button b = (Button)sender;
            op = b.Text;
            value = double.Parse(textBox1.Text);
            label1.Text = (value + op).ToString();
            textBox1.Text = "0";

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (op != "")
            {
                eqPressed = true;
                label1.Text = value.ToString() + op + textBox1.Text + "=";
                switch (op)
                {
                    case "+":
                        if ((value + double.Parse(textBox1.Text)).ToString().Length < 14)
                            textBox1.Text = ((value + double.Parse(textBox1.Text))).ToString();
                        else if (Math.Abs(value + double.Parse(textBox1.Text))>9999999999999)
                        {
                            MessageBox.Show("The number is too big for the display: \n " + ((value + double.Parse(textBox1.Text))).ToString());
                            value = 0;
                            label1.Text = "";
                            textBox1.Text = "0";
                            op = "";
                        }
                        else
                            textBox1.Text = ((value + double.Parse(textBox1.Text))).ToString().Substring(0,13);
                        break;
                    case "-":
                        if ((value - double.Parse(textBox1.Text)).ToString().Length < 12)
                            textBox1.Text = ((value - double.Parse(textBox1.Text))).ToString();
                        else if (Math.Abs(value - double.Parse(textBox1.Text))>9999999999999)
                        {
                            MessageBox.Show("The number is too big for the display: \n" + ((value - double.Parse(textBox1.Text)).ToString()));
                            value = 0;
                            label1.Text = "";
                            textBox1.Text = "0";
                            op = "";
                        }
                        else 
                            textBox1.Text = ((value - double.Parse(textBox1.Text))).ToString().Substring(0,13);
                        break;
                    case "*":
                        if ((value * double.Parse(textBox1.Text)).ToString().Length < 12)
                            textBox1.Text = ((value * double.Parse(textBox1.Text))).ToString();
                        else if ((Math.Abs(value * double.Parse(textBox1.Text))>9999999999999))
                        {
                            MessageBox.Show("The number is too big for the display: \n" + ((value * double.Parse(textBox1.Text)).ToString()));
                            value = 0;
                            label1.Text = "";
                            textBox1.Text = "0";
                            op = "";
                        }
                        else
                            textBox1.Text = ((value * double.Parse(textBox1.Text))).ToString().Substring(0,13);
                        break;
                    case "/":
                        if (double.Parse(textBox1.Text) != 0)
                        {
                            if ((value / double.Parse(textBox1.Text)).ToString().Length < 12)
                                textBox1.Text = (value / double.Parse(textBox1.Text)).ToString();
                            else if (Math.Abs(value / double.Parse(textBox1.Text))>9999999999999)
                            {
                                MessageBox.Show("The number is too big for the display: \n" + ((value / double.Parse(textBox1.Text)).ToString()));
                                value = 0;
                                label1.Text = "";
                                textBox1.Text = "0";
                                op = "";
                            }
                            else
                                textBox1.Text = (value / double.Parse(textBox1.Text)).ToString().Substring(0,13);
                        }
                        else
                        {
                            MessageBox.Show("Can't divide by zero!");
                            label1.Text = "";
                            op = "";
                            value = 0;
                        }
                        break;
                    default:
                        break;
                }
                dotPressed = false;
                //value = 0.0;
                op = "";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            value = 0.0;
            textBox1.Text = "0";
            label1.Text = "";
            opPressed = false;
            dotPressed = false;
            eqPressed = false;
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            if (eqPressed)
                textBox1.Text = "0";
            eqPressed = false;
            if (dotPressed==false)
            {
           
                    textBox1.Text = textBox1.Text + ",";
            }
                
            dotPressed = true;
        }
    }
}
