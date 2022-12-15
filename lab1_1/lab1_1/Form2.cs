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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            int z = int.Parse(textBox3.Text);
            if (x < y + z && y < x + z && z < x + y)
            {
                MessageBox.Show("Треугольник может существовать!");
            }
            else
            {
                MessageBox.Show("Треугольник не может существовать!");
            }
        }
    }
}
