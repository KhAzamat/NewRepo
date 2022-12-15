using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib
{
    public class Rectagle : Figure
    {
        public Rectagle()
        {
            this.x = 0;
            this.y = 0;
            this.h = 0;
            this.w = 0;
        }
        public Rectagle(String name, int x, int y, int w, int h)
        {
            if (x >= 0 && y >= 0 && x + w >= 0 && y + h >= 0 && x + w <= Init.pictureBox.Width && y + h <= Init.pictureBox.Height)
            {
                this.name = name;
                this.x = x;
                this.y = y;
                this.h = h;
                this.w = w;
            }
        }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(Init.pen, this.x, this.y, this.w, this.h);
            Init.pictureBox.Image = Init.bitmap;
        }

        public override void MoveTo(string name, int x, int y)
        {
            if (x >= 0 && y >= 0 && x + this.w >= 0 && y + this.h >= 0 && x + this.w <= Init.pictureBox.Width && y + this.h <= Init.pictureBox.Height)
            {
                this.x = x;
                this.y = y;
                this.DeleteF(this, false);
                this.Draw();
            }
        }
        public override void ch_w(int w)
        {
            if (this.x + w >= 0 && this.x + w <= Init.pictureBox.Width)
            {
                this.w = w;
                this.DeleteF(this, false);
                this.Draw();
            }
        }

        public override void ch_h(int h)
        {
            if (this.y + h >= 0 && this.y + h <= Init.pictureBox.Height)
            {
                this.h = h;
                this.DeleteF(this, false);
                this.Draw();
            }
        }

    }
}
