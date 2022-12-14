using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    /// <summary>
    /// Класс поьзовательского интерфейса
    /// </summary>
    internal class UI
    {
        /// <summary>
        /// Запрос % для изменения размера фигуры
        /// </summary>
        public static void PrintRequestPresent()
        {
            Console.Write("Укажите процент, на который нужно изменить размер фигуры:\t");
        }

        /// <summary>
        /// Печать фигуры
        /// </summary>
        /// <param name="figure">
        /// фигура для печати
        /// </param>
        public static void PrintFigures(FlatFigures figure)
        {
            if (figure is Square)
            {
                PrintSquare(new Square((Square)figure));

                return;
            }
            else
            {
                if (figure is Circle)
                {
                    ///*ConsoleColor defColor = Console.ForegroundColor;
                    //Console.ForegroundColor = ConsoleColor.Green;

                    //int oldLeft = Console.CursorLeft;
                    //int oldTop = Console.CursorTop;

                    //Circle circle = new Circle((Circle)figure);

                    //Console.SetCursorPosition(circle.X, circle.Y);

                    //#region test_solution
                    ////double radius = (double)circle.Radius;
                    ////double thickness = 0.1;
                    ////char symbol = '*';

                    //////Console.WriteLine();
                    ////double rIn = radius - thickness, rOut = radius + thickness;

                    ////for (double y = radius; y >= -radius; --y)
                    ////{
                    ////    for (double x = -radius; x < rOut; x += 0.5)
                    ////    {
                    ////        double value = x * x + y * y;

                    ////        if (value >= rIn * rIn && value <= rOut * rOut)
                    ////        {
                    ////            Console.Write(symbol);
                    ////        }/*
                    ////        else
                    ////        {
                    ////            Console.Write(" ");
                    ////        }*/
                    ////    }
                    ////    //Console.Write();
                    ////}
                    ////#endregion test_solution

                    //int tmpLeft = circle.X;
                    //int tmpTop = circle.Y;

                    //for (int i = 0; i < circle.Radius; i++)
                    //{
                    //    Console.SetCursorPosition(tmpLeft, tmpTop);
                    //    Console.Write('*');
                    //    --tmpLeft;
                    //    ++tmpTop;
                    //}

                    //Console.ForegroundColor = defColor;
                    //Console.SetCursorPosition(oldLeft, oldTop);
                    //*/
                    return;
                }
                else
                {
                    if (figure is Triangle)
                    {
                        Printtriangle(new Triangle((Triangle)figure));
                        return;
                    }
                    else
                    {
                        if (figure is CircleInSquare)
                        {
                            return;
                        }
                        else
                        {
                            if (figure is Rhombus)
                            {
                                PrintRhombus(new Rhombus((Rhombus)figure));

                                return;
                            }
                        }
                    }
                }
            }
        }

        private static void PrintRhombus(Rhombus rhombus)
        {
            ConsoleColor defColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;

            //Rhombus rhombus = new Rhombus(rhombus);

            Console.SetCursorPosition(rhombus.X, rhombus.Y);

            int tmpLeft = rhombus.X;
            int tmpTop = rhombus.Y;

            for (int i = 0; i < rhombus.Height / 2; i++)
            {
                Console.SetCursorPosition(tmpLeft, tmpTop);
                Console.Write('*');
                --tmpLeft;
                ++tmpTop;
            }

            for (int i = 0; i < rhombus.Height / 2; i++)
            {
                Console.SetCursorPosition(tmpLeft, tmpTop);
                Console.Write('*');
                ++tmpLeft;
                ++tmpTop;
            }

            tmpLeft = rhombus.X;
            tmpTop = rhombus.Y;

            for (int i = 0; i < rhombus.Height / 2; i++)
            {
                Console.SetCursorPosition(tmpLeft, tmpTop);
                Console.Write('*');
                ++tmpLeft;
                ++tmpTop;
            }

            for (int i = 0; i <= rhombus.Height / 2; i++)
            {
                Console.SetCursorPosition(tmpLeft, tmpTop);
                Console.Write('*');
                --tmpLeft;
                ++tmpTop;
            }

            Console.ForegroundColor = defColor;
            Console.SetCursorPosition(oldLeft, oldTop);
        }

        private static void Printtriangle(Triangle triangle)
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;

            //Triangle triangle = new Triangle((Triangle)triangle);

            int tmpLeft = triangle.X;
            int tmpTop = triangle.Y;

            for (int i = 0; i < triangle.Cathetus1; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(tmpLeft, tmpTop);
                    Console.Write("*");
                }
                else
                {
                    ++tmpTop;
                    Console.SetCursorPosition(tmpLeft, tmpTop);
                    Console.Write("*");
                    Console.SetCursorPosition(tmpLeft + i, tmpTop);
                    Console.Write("*");
                }
            }

            tmpLeft = triangle.X;
            tmpTop = Console.CursorTop;

            for (int i = 0; i < triangle.Cathetus2; i++)
            {
                Console.SetCursorPosition(tmpLeft + i, tmpTop);
                Console.Write("*");
            }

            Console.SetCursorPosition(oldLeft, oldTop);
            Console.ForegroundColor = def;
        }

        private static void PrintSquare(Square square)
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;

            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;

            // создаем READonly объект
            //Square square = new Square(figure);

            Console.SetCursorPosition(square.X, square.Y);

            #region ПЕЧАТЬ КВАДРАТА

            for (int i = square.X; i <= square.X + square.Length; i++)
            {
                Console.SetCursorPosition(i, square.Y);
                Console.Write('.');
                Console.SetCursorPosition(i, square.Y + square.Length);
                Console.Write('.');
            }

            for (int i = square.Y; i <= square.Y + square.Length; i++)
            {
                Console.SetCursorPosition(square.X, i);
                Console.Write('.');
                Console.SetCursorPosition(square.X + square.Length, i);
                Console.Write('.');
            }

            #endregion

            Console.ForegroundColor = def;
            Console.SetCursorPosition(oldLeft, oldTop);
        }
    }
}
