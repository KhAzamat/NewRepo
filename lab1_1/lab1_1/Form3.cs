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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            int z = int.Parse(textBox3.Text);
            double i = x;
            double u = y;
            double o = z;
            if (x > 0)
            {

                i = Math.Pow(i, 2);
            }
            else
            {

                i = Math.Pow(i, 4);
            }
            if (y > 0)
            {

                u = Math.Pow(u, 2);
            }
            else
            {

                u = Math.Pow(u, 4);
            }
            if (z > 0)
            {
                o = Math.Pow(o, 2);
            }
            else
            {
                o = Math.Pow(o, 4);
            }
            string a = i.ToString();
            string b = u.ToString();
            string c = o.ToString();
            textBox4.Text = a.ToString();
            textBox5.Text = b.ToString();
            textBox6.Text = c.ToString();
        }
    }
}
