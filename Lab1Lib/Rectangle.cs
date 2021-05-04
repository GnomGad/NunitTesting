using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Lib
{
    public class Rectangle
    {
        private double[] _x,_y;
        private double[] sides;
        public Rectangle()
        {
        }

        public Rectangle(double[] x, double[] y)
        {
            SetVertices(x,y);
        }
        public void SetVertices(double[] x, double[] y)
        {
            IsReqctangle(x, y);
            _x = x;
            _y = y;
        }

        public double Diagonal()
        {
            return Math.Sqrt(Math.Pow(sides[0],2)+Math.Pow(sides[1],2));
        }

        /*
         * Как понять, прямоугольник ли это?
         * У прямоугольника 4 точки, а значит 4 пары координат
         * К примеру 0,0  10,0  10,-10  0,-10 
         * К примеру -10,5  -10,1  0,1  0,5
         * Нужно найти каждую из 4х вершин
         * Найти расстояние между вершинами
         */

        public bool IsReqctangle(double[] x, double[] y)
        {
            int indexTopLeft = 0; // x<a y>b
            int indexTopRight = 0; // x>a y>b
            int indexBotLeft = 0; // x<a y<b
            int indexBotRight = 0; // x>a y<b
            for (int i = 0; i < 4; i++)
            {
                if (x[indexTopLeft] >= x[i] && y[indexTopLeft] <= y[i])
                    indexTopLeft = i;

                if (x[indexTopRight] <= x[i] && y[indexTopRight] <= y[i])
                    indexTopRight = i;

                if (x[indexBotLeft] >= x[i] && y[indexBotLeft] >= y[i])
                    indexBotLeft = i;

                if (x[indexBotRight] <= x[i] && y[indexBotRight] >= y[i])
                    indexBotRight = i;
            }

            double leftHeight = y[indexTopLeft] - y[indexBotLeft];
            double rightHeight = y[indexTopRight] - y[indexBotRight];
            if (leftHeight != rightHeight)
                throw new ArgumentException("Разные длины высоты");

            double topWidth = x[indexTopRight] - x[indexTopLeft];
            double botWidth = x[indexBotRight] - x[indexBotLeft];
            if (topWidth != botWidth)
                throw new ArgumentException("Разные длины ширины");

            if(topWidth+botWidth == 0.0f || leftHeight+rightHeight==0.0f)
                throw new ArgumentException("Разные длины ширины");

            sides = new double[2]{ leftHeight, topWidth };
            return true;
        }
    }
}
