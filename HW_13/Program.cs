using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //test.circle();

            FlatFigures square      = new Square(3, 3, 5);
            FlatFigures triangle    = new Triangle(20, 3, 8, 8);
            FlatFigures rhombus     = new Rhombus(40, 3, 5);           

            Pictures pictures       = new Pictures(square, triangle, rhombus);

            pictures.PrintPictures();

            #region MOVE

            square.Move(0, 9);
            triangle.Move(-3, 0);
            rhombus.Move(3, -2);

            #endregion MOVE

            #region RESIZE

            // увеличение размера на 50 %
            square.Resize(50);
            triangle.Resize(20);

            #endregion

            Console.ReadKey();      

        }
    }
}
