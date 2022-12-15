using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyLib
{
    public class Poly : Figure
    {
        public PointF[] points;
        public int versh;
        public Poly(PointF[] pnts, int vershins)
        {
            this.points = pnts;
            this.versh = vershins;
        }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, points);
            Init.pictureBox.Image = Init.bitmap;
        }

        public override void MoveTo(int x, int y)
        {
            for (int i = 0; i < this.versh; i++)
            {
                this.points[i].X += x;
                this.points[i].Y += y;
                this.DeleteF(this, false);
                this.Draw();
            }
        }
    }
}
