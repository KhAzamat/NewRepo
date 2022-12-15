using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;

namespace LABA2._2OOP
{
    public partial class Form1 : Form
    {
        public Rectagle rectagle;
        public Square square;
        public Ellips ellips;
        public Circle circle;
        Bitmap bitmap;
        Pen pen = new Pen(Color.Black, 5);
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
            int x, y, w, h;
            if (int.TryParse(textBox1.Text, out x) && int.TryParse(textBox2.Text, out y) && int.TryParse(textBox3.Text, out w) && int.TryParse(textBox4.Text, out h) &&
                x >= 0 && x <= pictureBox1.ClientSize.Width && y >= 0 && y <= pictureBox1.ClientSize.Height)
            {
                if (rectagle != null)
                {
                    rectagle.DeleteF(rectagle, true);
                    FigureList.Items.Remove(rectagle);
                }
                rectagle = new Rectagle(x, y, w, h);
                ShapeContainer.AddFigure(rectagle);
                FigureList.Items.Add(rectagle);
                rectagle.Draw();
            }
            else
            {
                MessageBox.Show("Неверное значение");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x, y, w, h;
            if (int.TryParse(textBox5.Text, out x) && int.TryParse(textBox6.Text, out y) && int.TryParse(textBox7.Text, out w) && int.TryParse(textBox8.Text, out h) &&
                x >= 0 && x <= pictureBox1.ClientSize.Width && y >= 0 && y <= pictureBox1.ClientSize.Height)
            {
                if (ellips != null)
                {
                    ellips.DeleteF(ellips, true);
                    FigureList.Items.Remove(ellips);
                }
                ellips = new Ellips(x, y, w, h);
                ShapeContainer.AddFigure(ellips);
                FigureList.Items.Add(ellips);
                ellips.Draw();
            }
            else
            {
                MessageBox.Show("Неверное значение");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x, y, w;
            if (int.TryParse(textBox10.Text, out x) && int.TryParse(textBox11.Text, out y) && int.TryParse(textBox12.Text, out w) && x >= 0 && x <= pictureBox1.ClientSize.Width && y >= 0 && y <= pictureBox1.ClientSize.Height)
            {
                if (square != null)
                {
                    square.DeleteF(square, true);
                    FigureList.Items.Remove(square);
                }
                square = new Square(x, y, w);
                ShapeContainer.AddFigure(square);
                FigureList.Items.Add(square);
                square.Draw();
            }
            else
            {
                MessageBox.Show("Неверное значение");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x, y, w;
            if (int.TryParse(textBox14.Text, out x) && int.TryParse(textBox13.Text, out y) && int.TryParse(textBox9.Text, out w) && x >= 0 && x <= pictureBox1.ClientSize.Width && y >= 0 && y <= pictureBox1.ClientSize.Height)
            {
                if (circle != null)
                {
                    circle.DeleteF(circle, true);
                    FigureList.Items.Remove(circle);
                }
                circle = new Circle(x, y, w);
                ShapeContainer.AddFigure(circle);
                FigureList.Items.Add(circle);
                circle.Draw();
            }
            else
            {
                MessageBox.Show("Неверное значение");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int x, y;
            if (FigureList.SelectedItem == null)
            {
                MessageBox.Show("Фигура не выбрана");
            }
            else if (int.TryParse(textBox15.Text, out x) && int.TryParse(textBox16.Text, out y))
            {
                Figure figure = (Figure)FigureList.SelectedItem;
                figure.MoveTo(x, y);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            if (FigureList.SelectedItem == square || FigureList.SelectedItem == circle)
            {
                textBox18.ReadOnly = true;
            }
            else
            {
                textBox18.ReadOnly = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int w, h;
            if (FigureList.SelectedItem == null)
            {
                MessageBox.Show("Фигура не выбрана");
            }
            else if (FigureList.SelectedItem == rectagle)
            {
                if (int.TryParse(textBox17.Text, out w) && int.TryParse(textBox18.Text, out h))
                {
                    rectagle.ch_h(h);
                    rectagle.ch_w(w);
                }
            }
            else if (FigureList.SelectedItem == ellips)
            {
                if (int.TryParse(textBox17.Text, out w) && int.TryParse(textBox18.Text, out h))
                {
                    ellips.ch_h(h);
                    ellips.ch_w(w);
                }
            }
            else if (FigureList.SelectedItem == square)
            {
                if (int.TryParse(textBox17.Text, out w))
                {
                    square.ch_w(w);
                }
            }
            else if (FigureList.SelectedItem == circle)
            {
                if (int.TryParse(textBox17.Text, out w))
                {
                    circle.ch_w(w);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (FigureList.SelectedItem == null)
            {
                MessageBox.Show("Фигура не выбрана");
            }
            else
            {
                Figure fig = (Figure)FigureList.SelectedItem;
                FigureList.Items.Remove(FigureList.SelectedItem);
                fig.DeleteF(fig, true);
            }
        }
    }
}
