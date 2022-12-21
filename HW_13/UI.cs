///////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 12/12/2022
// Last Modified On : 14/12/2022
// Description: Пользовательсякий интерфес
// Project: HW_13
///////////////////////////////

using System;


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
        public static void PrintFigures(Figures figure
            , char symbol = (char)Symbols.symbolType1)
        {
            if (figure is Square)
            {
                PrintSquare(new Square((Square)figure), symbol);

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
                        Printtriangle(new Triangle((Triangle)figure), symbol);
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
                                PrintRhombus(new Rhombus((Rhombus)figure)
                                    , symbol);

                                return;
                            }
                            else
                            {
                                if (figure is Parallelepiped)
                                {
                                    PrintParallelepiped(
                                        new Parallelepiped((Parallelepiped)figure)
                                        , symbol);
                                    return;
                                }
                                
                            }
                        }
                    }
                }
            }
        }

        public static void PrintRhombus(Rhombus rhombus, char symbol)
        {
            ConsoleColor defColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;

            Console.SetCursorPosition(rhombus.X, rhombus.Y);

            int tmpLeft = rhombus.X;
            int tmpTop = rhombus.Y;
                       
            for (int i = 0; i < rhombus.Height / 2; i++)
            {
                Console.SetCursorPosition(tmpLeft, tmpTop);
                Console.Write(symbol);
                --tmpLeft;
                ++tmpTop;
            }

            for (int i = 0; i < rhombus.Height / 2; i++)
            {
                Console.SetCursorPosition(tmpLeft, tmpTop);
                Console.Write(symbol);
                ++tmpLeft;
                ++tmpTop;
            }

            tmpLeft = rhombus.X;
            tmpTop = rhombus.Y;

            for (int i = 0; i < rhombus.Height / 2; i++)
            {
                Console.SetCursorPosition(tmpLeft, tmpTop);
                Console.Write(symbol);
                ++tmpLeft;
                ++tmpTop;
            }

            for (int i = 0; i <= rhombus.Height / 2; i++)
            {
                Console.SetCursorPosition(tmpLeft, tmpTop);
                Console.Write(symbol);
                --tmpLeft;
                ++tmpTop;
            }


            Console.ForegroundColor = defColor;
            Console.SetCursorPosition(oldLeft, oldTop);
        }

        public static void Printtriangle(Triangle triangle
            , char symbol)
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;

            int tmpLeft = triangle.X;
            int tmpTop = triangle.Y;

            switch (triangle.Rotator)
            {
                case RotatorEnum.none:

                    for (int i = 0; i < triangle.Cathetus1; i++)
                    {
                        if (i == 0)
                        {
                            Console.SetCursorPosition(tmpLeft, tmpTop);
                            Console.Write(symbol);
                        }
                        else
                        {
                            ++tmpTop;
                            Console.SetCursorPosition(tmpLeft, tmpTop);
                            Console.Write(symbol);
                            Console.SetCursorPosition(tmpLeft + i, tmpTop);
                            Console.Write(symbol);
                        }
                    }

                    tmpLeft = triangle.X;
                    tmpTop = Console.CursorTop;

                    for (int i = 0; i < triangle.Cathetus2; i++)
                    {
                        Console.SetCursorPosition(tmpLeft + i, tmpTop);
                        Console.Write(symbol);
                    }

                    break;

                case RotatorEnum.rotate_90:

                    for (int i = 0; i < triangle.Cathetus1; i++)
                    {
                        Console.SetCursorPosition(tmpLeft, tmpTop);
                        Console.Write(symbol);

                        ++tmpLeft;
                    }

                    tmpLeft = triangle.X;

                    for (int i = 0; i <= triangle.Cathetus2; i++)
                    {
                        ++tmpTop;
                        Console.SetCursorPosition(triangle.X, tmpTop);
                        Console.Write(symbol);

                        tmpLeft = triangle.X + triangle.Cathetus1 - i - 2;

                        if (tmpLeft > triangle.X)
                        {
                            Console.SetCursorPosition(tmpLeft, tmpTop);
                            Console.Write(symbol);
                        }
                        else
                        {
                            break;
                        }
                    }

                    break;
                case RotatorEnum.rotate_180:

                    for (int i = 0; i < triangle.Cathetus2; i++)
                    {
                        Console.SetCursorPosition(tmpLeft, tmpTop);
                        Console.Write(symbol);

                        ++tmpLeft;
                    }

                    tmpLeft = triangle.X;

                    for (int i = 0; i <= triangle.Cathetus1; i++)
                    {
                        ++tmpTop;
                        int rightSide = triangle.X
                            + triangle.Cathetus1 - 1;
                        Console.SetCursorPosition(rightSide, tmpTop);

                        Console.Write(symbol);

                        tmpLeft = triangle.X + i + 1;

                        if (tmpLeft < rightSide)
                        {
                            Console.SetCursorPosition(tmpLeft, tmpTop);
                            Console.Write(symbol);
                        }
                        else
                        {
                            break;
                        }
                    }

                    break;

            }

            Console.SetCursorPosition(oldLeft, oldTop);
            Console.ForegroundColor = def;
        }

        public static void PrintSquare(Square square, char symbol)
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
                Console.Write(symbol);
                Console.SetCursorPosition(i, square.Y + square.Length);
                Console.Write(symbol);
            }

            for (int i = square.Y; i <= square.Y + square.Length; i++)
            {
                Console.SetCursorPosition(square.X, i);
                Console.Write(symbol);
                Console.SetCursorPosition(square.X + square.Length, i);
                Console.Write(symbol);
            }

            #endregion

            Console.ForegroundColor = def;
            Console.SetCursorPosition(oldLeft, oldTop);
        }

        public static void PrintParallelepiped(Parallelepiped figure
            , char symbol)
        {
            ConsoleColor defColor   = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            int offset = 0;
            const int OFFSET_STEP = 3;
            int tmpLeft = figure.X;
            int tmpTop = figure.Y;

            Console.SetCursorPosition(tmpLeft, tmpTop);

            switch (figure.Rotator)
            {
                case RotatorEnum.none:

                    PrintParallelipiped90();

                    offset += OFFSET_STEP;
                    tmpLeft = figure.X + offset;
                    tmpTop = figure.Y - offset;

                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    PrintParallelipiped90();

                    break;
                case RotatorEnum.rotate_90:

                    PrintParallelipiped180();

                    offset += OFFSET_STEP;
                    tmpLeft = figure.X - offset;
                    tmpTop = figure.Y - offset;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(tmpLeft, tmpTop);
                    PrintParallelipiped180();

                    break;
            }

           
                     
            void PrintParallelipiped90()
            {
                for (ushort i = 0; i <= figure.Width; i++)
                {
                    Console.SetCursorPosition(tmpLeft, tmpTop);
                    Console.Write(symbol);
                    Console.SetCursorPosition(tmpLeft, tmpTop 
                        + figure.Height);
                    Console.Write(symbol);
                    ++tmpLeft;
                }

                tmpLeft = figure.X + offset;
                tmpTop = figure.Y + 1 - offset;

                for (ushort i = 0; i < figure.Height; i++)
                {
                    Console.SetCursorPosition(tmpLeft, tmpTop);
                    Console.Write(symbol);
                    Console.SetCursorPosition(tmpLeft 
                        + figure.Width, tmpTop);
                    Console.Write(symbol);
                    ++tmpTop;
                }
            }

            Console.ForegroundColor = defColor;

            void PrintParallelipiped180()
            {
                for (ushort i = 0; i < figure.Height; i++)
                {
                    Console.SetCursorPosition(tmpLeft, tmpTop);
                    Console.Write(symbol);
                    Console.SetCursorPosition(tmpLeft, tmpTop
                        + figure.Width);
                    Console.Write(symbol);
                    ++tmpLeft;
                }

                tmpLeft = figure.X - offset;
                tmpTop = figure.Y - offset + 1;

                for (ushort i = 0; i < figure.Width; i++)
                {
                    Console.SetCursorPosition(tmpLeft, tmpTop);
                    Console.Write(symbol);
                    Console.SetCursorPosition(tmpLeft
                        + figure.Height, tmpTop);
                    Console.Write(symbol);
                    ++tmpTop;
                }
            }
        }
    }
}
