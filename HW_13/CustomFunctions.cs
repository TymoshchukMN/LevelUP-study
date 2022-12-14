///////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 12/12/2022
// Last Modified On : 
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
        public static void ClearTriangle(Triangle triangle)
        {

            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;

            //Triangle triangle = new Triangle(triangle);

            int tmpLeft = triangle.X;
            int tmpTop = triangle.Y;

            for (int i = 0; i < triangle.Cathetus1; i++)
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

            for (int i = 0; i < triangle.Cathetus2; i++)
            {
                Console.SetCursorPosition(tmpLeft + i, tmpTop);
                Console.Write(" ");
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

            //Rhombus rhombus = new Rhombus(rhombus);

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
    
    }
}
