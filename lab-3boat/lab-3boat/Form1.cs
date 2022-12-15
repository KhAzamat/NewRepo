using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;

namespace lab_3boat
{
    public partial class Form1 : Form
    {

        public Poly poly;
        public Boat boat;
        Bitmap bitmap;
        Pen pen = new Pen(Color.Black, 5);
        PointF[] points;
        int flag = 0;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            this.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Init.pen = this.pen;
            Init.bitmap = this.bitmap;
            Init.pictureBox = pictureBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
            Init.pictureBox.Image = Init.bitmap;
            this.boat = new Boat(200, 300);
            boat.Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (boat != null)
            {
                boat.Del();
                boat = null;
            }
            else
            {
                MessageBox.Show("Фигура не существует");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (boat != null)
            {
                int x, y;
                if (int.TryParse(textBox1.Text, out x) && int.TryParse(textBox2.Text, out y))
                {
                    boat.move(x, y);
                }
                else
                {
                    MessageBox.Show("Неверное значение для координат");
                }
            }
            else
            {
                MessageBox.Show("Фигура не существует");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(textBox3.Text, out n))
            {
                points = new PointF[n];
                flag = 1;
                label3.Text = points.Length.ToString();
            }
            else
            {
                MessageBox.Show("неверное значение");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                int x, y;
                if (i < points.Length)
                {
                    if (int.TryParse(textBox4.Text, out x) && int.TryParse(textBox5.Text, out y))
                    {
                        points[i].X = x;
                        points[i].Y = y;
                        i++;
                        label3.Text = (points.Length - i).ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Количество точек не выбрано");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (poly != null)
            {
                poly.Del();
                poly = null;
            }
            i = 0;
            poly = new Poly(points, points.Length);
            poly.Draw();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            float x, y;
            if (float.TryParse(textBox4.Text, out x) && float.TryParse(textBox5.Text, out y))
            {
                poly.move(x, y, true);

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (poly != null)
            {
                poly.DeleteF(poly, true);
            }
            else
            {
                MessageBox.Show("Фигура не существует");
            }
        }
    }
}
