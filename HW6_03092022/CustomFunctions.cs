using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_03092022
{
/// <summary>
/// Пользовательские функции
/// </summary>
    internal class CustomFunctions
    {
        /// <summary>
        /// Проверерка на палиндром
        /// </summary>
        /// <param name="verifiableString">
        /// строка для проверки
        /// </param>
        /// <param name="lastPosition">
        /// позиция послежнего символа для проверки
        /// </param>
        /// <param name="startPosition">
        /// позиция начального символа для проверки
        /// </param>
        /// <param name="isPalindrom">
        /// бинарное значение, для маски в проверке на палиндром
        /// </param>
        /// <returns>true/false</returns>
        public static bool IsPalindrom(string verifiableString, ref byte isPalindrom, int lastPosition, int startPosition = 0)
        {
            if (startPosition <= verifiableString.Length / 2)
            {
                // всеряем символ вначале строки с символом в конце (двигаемся на встречу друг другу)
                if (verifiableString[startPosition] == verifiableString[lastPosition])
                {
                    ++startPosition;
                    --lastPosition;

                    // вызов рекурсии
                    IsPalindrom(verifiableString, ref isPalindrom, lastPosition, startPosition);
                }
                else
                {
                    // увеличиваем на 1 бит, из-за того, что символы не совпадают
                    isPalindrom |= 0b1;
                }
            }
            
            // true означает, что строка палендром 
            return isPalindrom == 0b0;
        }

        /// <summary>
        /// задача # 1 (палиндром)
        /// </summary>
        public static void LaunchTask1()
        {
            // 1.Полендром.Пользователь вводит строку произвольную.
            // Проверяем что данная строка является полиндромом. 
            // Написать рекрсивную функцию, которая проверяет,
            // что входная строка является полиндромом

            Console.Clear();

            Console.WriteLine("Введите строку для проверки на палиндром:");
            string userInput = Console.ReadLine();
            
            userInput = userInput.Replace(" ", string.Empty).Replace(",", string.Empty).Replace(".", string.Empty).ToLower();

            //CustomFunctions.IsPalindrom(userInput, userInput.Length-1);
            byte isPalindrom = 0b0;

            if (CustomFunctions.IsPalindrom(userInput, ref isPalindrom, userInput.Length - 1))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }


        /// <summary>
        /// Вывод символов
        /// </summary>
        /// <param name="str">
        /// Входная строка
        /// </param>
        /// <param name="startPosPunctuation ">
        /// Счетчик для прохождению по строке
        /// </param>
        public static void printSymbols(string str, int startPosPunctuation = 0)
        {
            if (startPosPunctuation < str.Length)
            {
                if (Char.IsPunctuation(str[startPosPunctuation]))
                {
                    Console.Write(str[startPosPunctuation]);
                }

                printSymbols(str, startPosPunctuation + 1);

            }

            if (str.Length - startPosPunctuation < str.Length)
            {
                if (Char.IsLetter(str[str.Length - startPosPunctuation]))
                {
                    Console.Write(str[str.Length - startPosPunctuation]);
                }
            }
        }

        /// <summary>
        /// Задача 3
        /// Реку-я функция, которая выводит содержимое исходной строки
        /// </summary>
        /// <param name="verifiableString">
        /// строка для вывода
        /// </param>
        public static void LaunchTask3()
        {
            Console.WriteLine("Укажите строку: ");
            string userinput = Console.ReadLine();

            // вызов метода на вывод символов
            CustomFunctions.printSymbols(userinput);
        }
    
    }
}
