using MyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab_3boat
{
    public partial class Form2 : Form
    {
        public Triangle tri;
        PointF[] points;
        Bitmap bitmap;
        Pen pen = new Pen(Color.Black, 5);
        int flag = 0;
        int i = 0;
        public Form2()
        {
            
            InitializeComponent();
            this.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Init.pen = this.pen;
            Init.bitmap = this.bitmap;
            Init.pictureBox = pictureBox1;
            points = new PointF[3];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int x, y;
            if (i < 3)
            {
                if (int.TryParse(textBox1.Text, out x) && int.TryParse(textBox2.Text, out y))
                {
                    points[i].X = x;
                    points[i].Y = y;
                    i++;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tri != null)
            {
                tri.DeleteF(tri, true);
                tri = null;
            }
            i = 0;
            tri = new Triangle(points);
            tri.Draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x, y;
            if (int.TryParse(textBox1.Text, out x) && int.TryParse(textBox2.Text, out y))
            {
                tri.move(x, y, true);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tri != null)
            {
                tri.DeleteF(tri, true);
            }
            else
            {
                MessageBox.Show("Фигура не существует");
            }
        }
    }
}
