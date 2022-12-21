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



            VolumetricFigures paralellip = new Parallelepiped(30, 15, 5, 12);

            FlatFigures square      = new Square(3, 3, 5);
            FlatFigures triangle    = new Triangle(20, 3, 8, 8);
            FlatFigures rhombus     = new Rhombus(40, 3, 5);           

            
            Pictures pictures       = new Pictures(square, triangle, rhombus, paralellip);


            pictures.PrintPictures();

            // ссылка базового класса содержит объекты дочерних классов
            Figures [] figures = { square, triangle, rhombus, paralellip };

            for (int i = 0; i < figures.Length; i++)
            {
                figures[i].Move(2, 3);
            }

            // ссылка базового класса содержит 1 объект базового класса
            //Figures figure = square;
            //figures.Move(1, 2);
            
            #region MOVE

            square.Move(0, 9);
            triangle.Move(-3, 0);
            rhombus.Move(3, -2);
            
            // отдельный класс, содержащий фигуры
            pictures.Move(3,3);

            #endregion MOVE

            #region RESIZE

            // увеличение размера на 50 %
            square.Resize(50);

            triangle.Resize(20);

            rhombus.Resize(40);

            pictures.Resize(30);

            paralellip.Resize(30);

            #endregion RESIZE

            #region ROTATE

            triangle.Rotate(RotatorEnum.rotate_180);

            paralellip.Rotate(RotatorEnum.rotate_90);

            #endregion ROTATE



            Console.ReadKey();      

        }
    }
}
