///////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 12/12/2022
// Last Modified On : 14/12/2022
// Description: Класс пользовательские методы
// Project: HW_13
///////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    /// <summary>
    /// Класс пользовательских методов
    /// </summary>
    internal class CustomMethods
    {
        /// <summary>
        /// Получаем новые размеры сторон фигуры
        /// </summary>
        /// <param name="present">
        /// процент на который меняется размер
        /// </param>
        /// <param name="lendth">
        /// 1-я сторона фигуры
        /// </param>
        /// <param name="side2">
        /// 2-я сторона фигуры
        /// </param>
        public static void GetNewSizeSquare(int present, out int lendth)
        {
            lendth = 0;
            
        }

        /// <summary>
        /// Очистка старой прорисовки квадрата
        /// </summary>
        /// <param name="square">
        /// квадрат для изменения
        /// </param>
        public static void ClearSquare(Square square)
        {
            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;

            // создаем READonly объект
            //Square square = new Square(square);

            Console.SetCursorPosition(square.X, square.Y);

            #region ПЕЧАТЬ КВАДРАТА

            for (int i = square.X; i <= square.X + square.Length; i++)
            {
                Console.SetCursorPosition(i, square.Y);
                Console.Write(" ");
                Console.SetCursorPosition(i, square.Y + square.Length);
                Console.Write(" ");
            }

            for (int i = square.Y; i <= square.Y + square.Length; i++)
            {
                Console.SetCursorPosition(square.X, i);
                Console.Write(" ");
                Console.SetCursorPosition(square.X + square.Length, i);
                Console.Write(" ");
            }

            #endregion

            Console.SetCursorPosition(oldLeft, oldTop);
        }

        /// <summary>
        /// Очистка старой прорисовки nhteujkmybrf
        /// </summary>
        /// <param name="triangle">
        /// треугольник для изменения
        /// </param>
        /// <param name="rotator"> 
        /// градусы на которые нужно вращать фигуру
        /// </param>
        public static void ClearTriangle(Triangle triangle)
        {

            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;

            int tmpLeft = triangle.X;
            int tmpTop = triangle.Y;

            switch (triangle.Rotator)
            {
                case RotatorEnum.none:

                    for (ushort i = 0; i < triangle.Cathetus1; i++)
                    {
                        if (i == 0)
                        {
                            Console.SetCursorPosition(tmpLeft, tmpTop);
                            Console.Write(" ");
                        }
                        else
                        {
                            ++tmpTop;
                            Console.SetCursorPosition(tmpLeft, tmpTop);
                            Console.Write(" ");
                            Console.SetCursorPosition(tmpLeft + i, tmpTop);
                            Console.Write(" ");
                        }
                    }

                    tmpLeft = triangle.X;
                    tmpTop = Console.CursorTop;

                    for (ushort i = 0; i < triangle.Cathetus2; i++)
                    {
                        Console.SetCursorPosition(tmpLeft + i, tmpTop);
                        Console.Write(" ");
                    }

                    break;

                case RotatorEnum.rotate_90:

                    for (int i = 0; i < triangle.Cathetus1; i++)
                    {
                        Console.SetCursorPosition(tmpLeft, tmpTop);
                        Console.Write(" ");

                        ++tmpLeft;
                    }

                    tmpLeft = triangle.X;

                    for (int i = 0; i <= triangle.Cathetus2; i++)
                    {
                        ++tmpTop;
                        Console.SetCursorPosition(tmpLeft, tmpTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(tmpLeft + triangle.Cathetus1 - i - 2, tmpTop);
                        Console.Write(" ");
                    }

                    break;

                case RotatorEnum.rotate_180:

                    for (int i = 0; i < triangle.Cathetus2; i++)
                    {
                        Console.SetCursorPosition(tmpLeft, tmpTop);
                        Console.Write(" ");

                        ++tmpLeft;
                    }

                    tmpLeft = triangle.X;

                    for (int i = 0; i <= triangle.Cathetus1; i++)
                    {
                        ++tmpTop;
                        int rightSide = triangle.X
                            + triangle.Cathetus1 - 1;
                        Console.SetCursorPosition(rightSide, tmpTop);

                        Console.Write(" ");

                        tmpLeft = triangle.X + i + 1;

                        if (tmpLeft < rightSide)
                        {
                            Console.SetCursorPosition(tmpLeft, tmpTop);
                            Console.Write(" ");
                        }
                        else
                        {
                            break;
                        }
                    }

                    break;
            }

        }

        /// <summary>
        /// Очистка старой прорисовки ромба
        /// </summary>
        /// <param name="rhombus">
        /// ромб для изменения
        /// </param>
        public static void ClearRhombus(Rhombus rhombus)
        {
            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;

            Console.SetCursorPosition(rhombus.X, rhombus.Y);

            int tmpLeft = rhombus.X;
            int tmpTop = rhombus.Y;

           
            for (int i = 0; i < rhombus.Height / 2; i++)
            {
                Console.SetCursorPosition(tmpLeft, tmpTop);
                Console.Write((char)0);
                --tmpLeft;
                ++tmpTop;
            }

            for (int i = 0; i < rhombus.Height / 2; i++)
            {
                Console.SetCursorPosition(tmpLeft, tmpTop);
                Console.Write((char)0);
                ++tmpLeft;
                ++tmpTop;
            }

            tmpLeft = rhombus.X;
            tmpTop = rhombus.Y;

            for (int i = 0; i < rhombus.Height / 2; i++)
            {
                Console.SetCursorPosition(tmpLeft, tmpTop);
                Console.Write((char)0);
                ++tmpLeft;
                ++tmpTop;
            }

            for (int i = 0; i <= rhombus.Height / 2; i++)
                    {
                        Console.SetCursorPosition(tmpLeft, tmpTop);
                        Console.Write((char)0);
                        --tmpLeft;
                        ++tmpTop;
                    }

        }

        public static void ClearParallelepiped(Parallelepiped figure)
        {
            int offset = 0;

            int tmpLeft = figure.X;
            int tmpTop = figure.Y;

            Console.SetCursorPosition(tmpLeft, tmpTop);

            PrintParallelipiped();

            offset = 3;
            tmpLeft = figure.X + offset;
            tmpTop = figure.Y - offset;

            Console.ForegroundColor = ConsoleColor.DarkRed;

            PrintParallelipiped();

            void PrintParallelipiped()
            {
                for (ushort i = 0; i <= figure.Width; i++)
                {
                    Console.SetCursorPosition(tmpLeft, tmpTop);
                    Console.Write(' ');
                    Console.SetCursorPosition(tmpLeft, tmpTop + figure.Height);
                    Console.Write(' ');
                    ++tmpLeft;
                }

                tmpLeft = figure.X + offset;
                tmpTop = figure.Y + 1 - offset;

                for (ushort i = 0; i < figure.Height; i++)
                {
                    Console.SetCursorPosition(tmpLeft, tmpTop);
                    Console.Write(' ');
                    Console.SetCursorPosition(tmpLeft + figure.Width, tmpTop);
                    Console.Write(' ');
                    ++tmpTop;
                }
            }
        }
    }
}
