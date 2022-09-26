using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomClass;
using System.Threading;


namespace CustomClass
{
    /// <summary>
    /// Обшие функции для всех проектов
    /// </summary>
    public class CommonCustomFunctions
    {
        public const int START_RANDOM_RANGE = -100; // минимальное значение для рандома
        public const int END_RANDOM_RANGE = 500;    // максимальное значение для рандома
        public const int ARRAY_SIZE = 36;           // размер массимва по умолчанию

        /// <summary>
        /// Наполнение одномерного массива рандомными значенияеми
        /// </summary>
        /// <param name="arrayForFilling"> массив для заполнения </param>
        /// <param name="start"> минимальное число для рандома </param>
        /// <param name="last"> максимальное число для рандома </param>
        public static void FillArray(int[] arrayForFilling, int start, int last)
        {
            Random random = new Random();
            int randVol = 0;
            // наполнение массива значениями
            for (int i = 0; i < arrayForFilling.Length; i++)
            {
                do
                {
                    randVol = random.Next(start, last);

                } while (randVol == 0);

                arrayForFilling[i] = randVol;
            }
        }

        /// <summary>
        /// Заполнение многомерного массива 
        /// рандомными значениеми
        /// </summary>
        /// <param name="arrayForFilling">
        /// массив для заполнения
        /// </param>
        /// <param name="start">
        /// минимальное значение для рандома
        /// </param>
        /// <param name="last">
        /// максиммальное значение для рандома
        /// </param>
        public static void FillArray(int[,] arrayForFilling, int start, int last)
        {
            Random random = new Random();

            for (int row = 0; row < arrayForFilling.GetLength(0); row++)
            {
                for (int col = 0; col < arrayForFilling.GetLength(1); col++)
                {
                    arrayForFilling[row, col] = random.Next(start, last);
                }
            }

        }

        /// <summary>
        /// Печать массива
        /// </summary>
        /// <param name="printedArray">
        /// Одномерный массив для печати
        /// </param>
        public static void PrintArray(int[] printedArray)
        {
            Console.WriteLine("Одномерный массив:");
            for (int i = 0; i < printedArray.Length; i++)
            {
                Console.Write("{0} ", printedArray[i]);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// печать многомерного массива
        /// </summary>
        /// <param name="printedArray"></param>
        public static void PrintArray(int[,] printedArray,
                string fillingType = "Без типа")
        {
            #region banner

            Console.WriteLine();
            Console.WriteLine(new String('=', 50));
            Console.Write("тип заполнения:\t");
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}\n", fillingType);
            Console.ForegroundColor = defaultColor;

            #endregion

            for (int row = 0; row < printedArray.GetLength(0); row++)
            {
                for (int column = 0; column < printedArray.GetLength(1); column++)
                {
                    // если элемент массива отсутствует, т.е. равен нулю,
                    // то печатаем пустой символ
                    if (printedArray[row, column] == 0)
                    {
                        Console.Write("{0,10}", string.Empty);
                    }
                    else
                    {
                        Console.Write("{0,10}", printedArray[row, column]);
                    }
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// печать массива с "подсвечиваниме" минимумов и максимумов
        /// </summary>
        /// <param name="printedArray"></param>
        /// <param name="rowIndexMaxVol"></param>
        /// <param name="colIndexMaxVol"></param>
        /// <param name="rowIndexMinVol"></param>
        /// <param name="colIndexMinVol"></param>
        public static void PrintArray(int[,] printedArray, int rowIndexMaxVol,
                int colIndexMaxVol, int rowIndexMinVol, int colIndexMinVol)
        {
            Console.WriteLine();
            Console.WriteLine(new String('=', 50));
            Console.WriteLine("Смена местами минимума и максимума");
            ConsoleColor defaultColor = Console.ForegroundColor;

            for (int row = 0; row < printedArray.GetLength(0); row++)
            {
                for (int column = 0; column < printedArray.GetLength(1); column++)
                {

                    if (row == rowIndexMinVol && column == colIndexMinVol)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("{0,10}", printedArray[row, column]);
                        Console.ForegroundColor = defaultColor;
                    }
                    else
                    {
                        if (row == rowIndexMaxVol && column == colIndexMaxVol)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("{0,10}", printedArray[row, column]);
                            Console.ForegroundColor = defaultColor;
                        }
                        else
                        {
                            Console.Write("{0,10}", printedArray[row, column]);
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// печать массива после смены местами столбцов
        /// </summary>
        /// <param name="printedArray">
        /// массив для печати
        /// </param>
        /// <param name="indexMinVol">
        /// индекс столбца с минимальным значением в массиве
        /// </param>
        /// <param name="indexMaxVol">
        /// индекс столбца с максимальным значением в массиве
        /// </param>
        public static void PrintArray(int[,] printedArray, int indexMinVol, int indexMaxVol, ArrayPart ArrayPart)
        {
            Console.WriteLine();
            Console.WriteLine(new String('=', 50));
            ConsoleColor defaultColor = Console.ForegroundColor;

            switch (ArrayPart)
            {
                case ArrayPart.row:
                    Console.WriteLine("Смена {0}", ArrayPart);
                    for (int row = 0; row < printedArray.GetLength(1); row++)
                    {
                        for (int column = 0; column < printedArray.GetLength(0); column++)
                        {
                            if (row == indexMinVol)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("{0,10}", printedArray[row, column]);
                                Console.ForegroundColor = defaultColor;
                            }
                            else
                            {
                                if (row == indexMaxVol)
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write("{0,10}", printedArray[row, column]);
                                    Console.ForegroundColor = defaultColor;
                                }
                                else
                                {
                                    Console.Write("{0,10}", printedArray[row, column]);
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                case ArrayPart.column:
                    Console.WriteLine("Смена {0}", ArrayPart);
                    for (int col = 0; col < printedArray.GetLength(0); col++)
                    {
                        for (int row = 0; row < printedArray.GetLength(1); row++)
                        {
                            if (row == indexMinVol)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("{0,10}", printedArray[col, row]);
                                Console.ForegroundColor = defaultColor;
                            }
                            else
                            {
                                if (row == indexMaxVol)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("{0,10}", printedArray[col, row]);
                                    Console.ForegroundColor = defaultColor;
                                }
                                else
                                {
                                    Console.Write("{0,10}", printedArray[col, row]);
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
            }

        }

                
    }
}
