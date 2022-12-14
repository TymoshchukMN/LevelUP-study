////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 23/11/2022
// Last Modified On : 
// Description: Custom Functions
// Project: HW_11
////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12
{
    /// <summary>
    /// пользовательские методы
    /// </summary>
    internal class CustomMethods
    {
        /// <summary>
        /// Поиск наименьшего общего кратного
        /// </summary>
        /// <param name="vol1">
        /// знаменатель первой дроби
        /// </param>
        /// <param name="vol2">
        /// знаменатель второй дроби
        /// </param>
        /// <returns>
        /// Наименьшее общее кратное
        /// </returns>
        public static int DetermineLCM(int vol1, int vol2)
        {
            int num1, num2;
            if (vol1 > vol2)
            {
                num1 = vol1; num2 = vol2;
            }
            else
            {
                num1 = vol2; num2 = vol1;
            }

            for (int i = 1; i < num2; i++)
            {
                int mult = num1 * i;
                if (mult % num2 == 0)
                {
                    return mult;
                }
            }

            return num1 * num2;
        }

        /// <summary>
        /// the greatest common divisor
        /// (Наибольший общий делитель)
        /// </summary>
        /// <param name="vol1"></param>
        /// <param name="vol2"></param>
        /// <returns>
        /// наибольший общий делитель НОД
        /// </returns>
        private static int GCD(int vol1, int vol2)
        {
            while (vol1 != 0 && vol2 != 0)
            {
                if (vol1 > vol2)
                {
                    vol1 %= vol2;
                }
                else
                {
                    vol2 %= vol1;
                }
            }

            return vol1 | vol2;
        }

        /// <summary>
        /// сокращение дроби
        /// </summary>
        /// <param name="fraction">
        /// Дробь к сокращению
        /// </param>
        public static void CutFraction(Fractions fraction)
        {
            
            bool isNegative = false;

            if (fraction.Numerator < 0)
            {
                fraction.Numerator *= -1;
                isNegative = true;
            }
            else
            {
                if (fraction.Denominator < 0)
                {
                    fraction.Denominator *= -1;
                    isNegative = true;
                }
            }
            if (fraction.Numerator != 0 && fraction.Denominator!=0)
            {
                // LCMFirst - первое НОД
                int GCD = CustomMethods.GCD(fraction.Numerator, fraction.Denominator);

                fraction.Numerator = fraction.Numerator / GCD;
                fraction.Denominator = fraction.Denominator / GCD;

            }

            if (isNegative)
            {
                fraction.Numerator *= -1;
            }
        }

        /// <summary>
        /// Преобразование неправильной дроби в смешанную дробь
        /// </summary>
        /// <param name="fraction">
        /// дробь для преобразования
        /// </param>
        public static void Transform(Fractions fraction)
        {

            // поделить числитель дроби на ее знаменатель;
            // остаток от деления записать в числитель знаменатель оставить прежним;
            // результат от деления записать в качестве целой части.

            bool isNegative = false;


            if (fraction.Numerator < 0)
            {
                fraction.Numerator *= -1;
                isNegative = true;
            }
            else
            {
                if (fraction.Denominator < 0)
                {
                    fraction.Denominator *= -1;
                    isNegative = true;
                }
            }

            if (fraction.Whole != 0)
            {
                fraction.Whole = fraction.Whole  
                    + (fraction.Numerator / fraction.Denominator);
                fraction.Numerator = fraction.Numerator % fraction.Denominator;
            }
            else
            {
                fraction.Whole = fraction.Numerator / fraction.Denominator;
                fraction.Numerator = fraction.Numerator % fraction.Denominator;
            }

            if (isNegative)
            {
                if (fraction.Whole != 0)
                {
                    fraction.Whole *= -1;
                }
                else
                {
                    fraction.Numerator *= -1;
                }   
            }
        }

        /// <summary>
        /// Проверка наличия целого числа и обработка дроби
        /// </summary>
        /// <param name="fraction">
        /// дробь к обработке
        /// </param>
        public static void CheckAndFetWhole(Fractions fraction)
        {
            if (fraction.Numerator % fraction.Denominator == 0)
            {
                fraction.Whole = fraction.Numerator
                    / fraction.Denominator;
                fraction.Numerator = 0;
                fraction.Denominator = 0;
            }
        }
    }
}
