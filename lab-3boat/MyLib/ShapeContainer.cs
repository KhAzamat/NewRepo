using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class ShapeContainer
    {
        public static List<Figure> figureList = new List<Figure>();
        public ShapeContainer()
        {
            figureList = new List<Figure>();
        }
        public static void AddFigure(Figure figure)
        {
            figureList.Add(figure);
        }
    }
}
