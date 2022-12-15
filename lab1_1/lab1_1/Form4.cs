using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);
            double c = double.Parse(textBox3.Text);
            double d = double.Parse(textBox4.Text);
            double f = double.Parse(textBox5.Text);
            
            a = Math.Round(a, 5);
            b = Math.Round(b, 5);
            c = Math.Round(c, 5);
            d = Math.Round(d, 5);
            f = Math.Round(f, 5);

            double a1 = Math.Truncate(a);
            double b1 = Math.Truncate(b); 
            double c1 = Math.Truncate(c);
            double d1 = Math.Truncate(d);
            double f1 = Math.Truncate(f);
            textBox6.Text = a1.ToString();
            textBox7.Text = b1.ToString();
            textBox8.Text = c1.ToString();
            textBox9.Text = d1.ToString();
            textBox10.Text = f1.ToString();

            if (a >= 0)
            {
                textBox16.Text = "0";
            }
            else
            {
                textBox16.Text = "1";
            }

            if (b >= 0)
            {
                textBox17.Text = "0";
            }
            else
            {
                textBox17.Text = "1";
            }

            if (c >= 0)
            {
                textBox18.Text = "0";
            }
            else
            {
                textBox18.Text = "1";
            }

            if (d >= 0)
            {
                textBox19.Text = "0";
            }
            else
            {
                textBox19.Text = "1";
            }

            if (f >= 0)
            {
                textBox20.Text = "0";
            }
            else
            {
                textBox20.Text = "1";
            }

            if (a >= 0)
            {
                textBox16.Text = "0";
            }
            else
            {
                textBox16.Text = "1";
            }

            

            String h = a.ToString();
            h = h.Remove(0, a1.ToString().Length + 1);
            textBox11.Text = h;

            String j = b.ToString();
            j = j.Remove(0, b1.ToString().Length + 1);
            textBox12.Text = j;

            String k = c.ToString();
            k = k.Remove(0, c1.ToString().Length + 1);
            textBox13.Text = k;

            String l = d.ToString();
            l = l.Remove(0, d1.ToString().Length + 1);
            textBox14.Text = l;

            String m = f.ToString();
            m = m.Remove(0, f1.ToString().Length + 1);
            textBox15.Text = m;



        }
    }
}
