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
            //Triangle triangle1 = new Triangle(20, 3, 10, 8);
            //triangle1.Rotator = RotatorEnum.rotate_90;

            //UI.PrintFigures(triangle1);

            FlatFigures square      = new Square(3, 3, 5);
            FlatFigures triangle    = new Triangle(20, 3, 8, 8);
            FlatFigures rhombus     = new Rhombus(40, 3, 5);           

            Pictures pictures       = new Pictures(square, triangle, rhombus);

            pictures.PrintPictures();

            #region MOVE

            square.Move(0, 9);
            triangle.Move(-3, 0);
            rhombus.Move(3, -2);

            pictures.Move(3,3);

            #endregion MOVE

            #region RESIZE

            // увеличение размера на 50 %
            square.Resize(50);

            triangle.Resize(20);

            //rhombus.Resize(40);

            pictures.Resize(30);

            #endregion RESIZE

            #region ROTATE

            triangle.Rotate(RotatorEnum.rotate_180);

            #endregion ROTATE

            Console.ReadKey();      

        }
    }
}
