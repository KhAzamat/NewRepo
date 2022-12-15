using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab1_1
{


    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int radio;
            if (radioButton1.Checked)
            {
                radio = 0;
                EngMer lenght = new EngMer();

                lenght.a = int.Parse(textBox1.Text);
                lenght.b = int.Parse(textBox2.Text);
                int save_a = lenght.a;
                int save_b = lenght.b;
                
                lenght.a = EngMer.EngMer_func(lenght.a, radio);

                int sum = lenght.a + lenght.b;
                int raz = Math.Abs(lenght.a - lenght.b);
                textBox3.Text = sum.ToString();
                textBox6.Text = raz.ToString();

                int pr = lenght.a * lenght.b;
                double del = Convert.ToDouble(lenght.a) / Convert.ToDouble(lenght.b);
                del = Math.Round(del, 3);
                textBox4.Text = pr.ToString();
                textBox7.Text = del.ToString();

                if (lenght.a > lenght.b)
                {
                    textBox5.Text = (save_a).ToString() + " фунтов, больше чем " + (save_b).ToString() + " дюймов!";
                }
                else
                {
                    textBox5.Text = (save_b).ToString() + " дюймов, больше чем " + (save_a).ToString() + " фунтов!";
                }
            }
            else if (radioButton2.Checked)
            {
                radio = 1;
                EngMer lenght = new EngMer();

                lenght.a = int.Parse(textBox1.Text);
                lenght.b = int.Parse(textBox2.Text);
                int save_a = lenght.a;
                int save_b = lenght.b;

                lenght.b = EngMer.EngMer_func(lenght.b, radio);

                int sum = lenght.a + lenght.b;
                int raz = Math.Abs(lenght.a - lenght.b);
                textBox3.Text = sum.ToString();
                textBox6.Text = raz.ToString();

                int pr = lenght.a * lenght.b;
                double del = Convert.ToDouble(lenght.a) / Convert.ToDouble(lenght.b);
                del = Math.Round(del, 3);
                textBox4.Text = pr.ToString();
                textBox7.Text = del.ToString();

                if (lenght.a > lenght.b)
                {
                    textBox5.Text = (save_a).ToString() + " фунтов, больше чем " + (save_b).ToString() + " дюймов!";
                }
                else
                {
                    textBox5.Text = (save_b).ToString() + " дюймов, больше чем " + (save_a).ToString() + " фунтов!";
                }
            }



        }
    }
}
