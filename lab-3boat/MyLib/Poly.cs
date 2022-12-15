using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlTypes;

namespace MyLib
{
    public class Poly : Figure
    {
        public PointF[] points;
        public int peak;
        public Poly(PointF[] pts, int peaks)
        {
            this.points = pts;
            this.peak = peaks;
        }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, points);
            Init.pictureBox.Image = Init.bitmap;
        }

        public override void MoveTo(int mx, int my)
        {
            int w = Init.pictureBox.Width;
            int h = Init.pictureBox.Height;
            float x; 
            float y;
            for (int i = 0; i < points.Length; i++)
            {
                x = points[i].X;
                y = points[i].Y;
                if (x + mx >= 0 && x + mx <= w && y + my >= 0 && y + my <= h)
                {
                    points[i].X = x + mx;
                    points[i].Y = y + my;
                }
               
                
            }
            this.DeleteF(this, false);
            this.Draw();
            
        }
      

        public void Del()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
            Init.pictureBox.Image = Init.bitmap;
        }

       
        public void move(float x, float y, bool flag)
        {
            
            for (int i = 0; i < points.Length; i++)
            {
                int w = Init.pictureBox.Width;
                int h = Init.pictureBox.Height;
                if (points[i].X + x >= 0 && points[i].X + y <= w && points[i].Y + y >= 0 && points[i].Y + y <= h)
                {
                    points[i].X += x;
                    points[i].Y += y;
                }
                else
                {
                    flag = false;
                }
            }
            x = points[0].X;
            y = points[0].Y;
            if (flag == true)
            {
                this.DeleteF(this, false);
                this.Draw();
            }
            else
            {
                MessageBox.Show("Фигура выходит за пределы!");
            }
            
        }
    }

}
