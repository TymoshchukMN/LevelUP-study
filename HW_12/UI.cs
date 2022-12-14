////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 23/11/2022
// Last Modified On : 
// Description: User interface
// Project: HW_11
////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12
{
    internal class UI
    {
        public static void ChangeColor(ConsoleColor color, string text)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(" {0} ",text);

            Console.ForegroundColor = defaultColor;
        }

        /// <summary>
        /// Запрос целого числа первой дроби
        /// </summary>
        public static void RequestFirstWhole()
        {
            Console.Write("Введите целое число");
            ChangeColor(ConsoleColor.Cyan, "первой");
            Console.Write("дроби:\t");

        }

        /// <summary>
        /// Запрос целого числа второй дроби
        /// </summary>
        public static void RequestSecondWhole()
        {
            Console.Write("Введите целое число");
            ChangeColor(ConsoleColor.Magenta, "второй");
            Console.Write("дроби:\t");
        }


        /// <summary>
        /// Запрос числителя первой дроби
        /// </summary>
        public static void RequestFirstNumerator()
        {
            Console.Write("Введите числитель");
            ChangeColor(ConsoleColor.Cyan, "первой");
            Console.Write("дроби:\t\t");
        }

        /// <summary>
        /// Запрос знаменателя первой дроби
        /// </summary>
        public static void RequestFirstDenominator()
        {
            Console.Write("Введите знаменатель");
            ChangeColor(ConsoleColor.Cyan, "первой");
            Console.Write("дроби:\t");
        }

        /// <summary>
        /// Запрос числителя первой дроби
        /// </summary>
        public static void RequestSecondNumerator()
        {
            Console.Write("Введите числитель");
            ChangeColor(ConsoleColor.Magenta, "второй");
            Console.Write("дроби:\t\t");
        }

        /// <summary>
        /// Запрос знаменателя первой дроби
        /// </summary>
        public static void RequestSecondDenominator()
        {
            Console.Write("Введите знаменатель");
            ChangeColor(ConsoleColor.Magenta, "второй");
            Console.Write("дроби:\t");
        }

        public static void PrintErrorInput()
        {
            Console.WriteLine("Ошибка ввода! Пробуйте еще раз");
        }

        public static void PrintFraction(Fractions fraction, int left, int top)
        {
            if (fraction.Whole != 0)
            {
                Console.SetCursorPosition(left, top + 1);
                Console.WriteLine(fraction.Whole);
                Console.SetCursorPosition(left + 2, top);
                Console.WriteLine(fraction.Numerator);
                Console.SetCursorPosition(left + 2, ++top);
                Console.WriteLine("-");
                Console.SetCursorPosition(left + 2, ++top);
                Console.WriteLine(fraction.Denominator);
            }
            else 
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine(fraction.Numerator);
                Console.SetCursorPosition(left, ++top);
                Console.WriteLine("-");
                Console.SetCursorPosition(left, ++top);
                Console.WriteLine(fraction.Denominator);
            }
        }

        public static void PrintOperatorSymbol(char symbol, int left, int top)
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(left, top);
            Console.WriteLine(symbol);

            Console.ForegroundColor = def;
        }

        public static void PrintCompareResult(bool res, int left, int top)
        {
            if (res)
            {
                Console.SetCursorPosition(left, top);
                ChangeColor(ConsoleColor.Green, ">");
            }
            else
            {
                Console.SetCursorPosition(left, top);
                ChangeColor(ConsoleColor.Red, "<");
            }

        }
    }
}
