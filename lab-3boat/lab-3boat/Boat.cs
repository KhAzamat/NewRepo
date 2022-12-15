using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;

namespace lab_3boat
{
    public class Boat
    {
        Poly ship;
        Triangle right;
        Triangle left;
        Rectagle flag;
        PointF[] ships;
        PointF[] rightTri;
        PointF[] leftTri;

        public Boat(int x, int y)
        {
            if (ship != null)
            {
                this.Del();
            }
            ships = new PointF[4];
            ships[0].X = x; ships[0].Y = y;
            ships[1].X = x + 400; ships[1].Y = y;
            ships[2].X = x + 350; ships[2].Y = y + 100;
            ships[3].X = x + 50; ships[3].Y = y + 100;
            ship = new Poly(ships, 4);
            
            rightTri = new PointF[3];
            rightTri[0].X = x + 200; rightTri[0].Y = y;
            rightTri[1].X = x + 300; rightTri[1].Y = y;
            rightTri[2].X = x + 200; rightTri[2].Y = y - 250;
            right = new Triangle(rightTri);

            leftTri = new PointF[3];
            leftTri[0].X = x + 75; leftTri[0].Y = y;
            leftTri[1].X = x + 200; leftTri[1].Y = y;
            leftTri[2].X = x + 200; leftTri[2].Y = y - 200;
            left = new Triangle(leftTri);

            flag = new Rectagle(x + 100, y - 250, 100, 50);
        }

        public void Draw()
        {
            this.ship.Draw();
            this.right.Draw();
            this.left.Draw();
            this.flag.Draw();
        }

        public void Del()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
            Init.pictureBox.Image = Init.bitmap;
        }

        public void move(int x, int y)
        {
            if (x >= 0 && x + 400 <= Init.pictureBox.Width && 100 + y <= Init.pictureBox.Height && y - 250 >= 0)
            {
                this.Del();
                ships = new PointF[4];
                ships[0].X = x; ships[0].Y = y;
                ships[1].X = x + 400; ships[1].Y = y;
                ships[2].X = x + 350; ships[2].Y = y + 100;
                ships[3].X = x + 50; ships[3].Y = y + 100;
                ship = new Poly(ships, 4);

                rightTri = new PointF[3];
                rightTri[0].X = x + 200; rightTri[0].Y = y;
                rightTri[1].X = x + 300; rightTri[1].Y = y;
                rightTri[2].X = x + 200; rightTri[2].Y = y - 250;
                right = new Triangle(rightTri);

                leftTri = new PointF[3];
                leftTri[0].X = x + 75; leftTri[0].Y = y;
                leftTri[1].X = x + 200; leftTri[1].Y = y;
                leftTri[2].X = x + 200; leftTri[2].Y = y - 200;
                left = new Triangle(leftTri);

                flag = new Rectagle(x + 100, y - 250, 100, 50);
                this.Draw();
            }
            else
            {
                MessageBox.Show("Укажите другие координаты!");
            }
        }
    }
}
