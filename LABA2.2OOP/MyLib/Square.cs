using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Square : Rectagle
    {
        public Square(int x, int y, int w) : base(x, y, w, w)
        {

        }
        
        public override void ch_w(int w)
        {
            if (this.x + w >= 0 && this.x + w <= Init.pictureBox.Width && this.y + w >= 0 && this.y + w <= Init.pictureBox.Height)
            {
                this.w = w;
                this.h = w;
                this.DeleteF(this, false);
                this.Draw();
            }
        }
    }
}
