using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyLib
{
    public class Triangle : Poly
    {
        public PointF[] points;
        public Triangle(PointF[] points) : base(points, 3)
        {

        }


    }
}
