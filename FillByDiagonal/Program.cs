using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillByDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // минимальное значение для рандома
            const int START_RANDOM_RANGE = -100;

            // максимальное значение для рандома
            const int END_RANDOM_RANGE = 500;

            // инициализация переменных рамера многомерного массива
            const int ARRAY_SIZE = 25;

            // количество столбцов в многомерном массиве поумолчанию
            const int COLUMN_COUNT = 5;

            // количество строк в многомерном массиве поумолчанию
            const int ROW_COUNT = 5;

            // инициализация многомерного массива
            int[,] multiArray = new int[ROW_COUNT, COLUMN_COUNT];

            // инициализация одномерного массива
            int[] simpleArray = new int[ARRAY_SIZE];

            // заполнение 
            FillArray(simpleArray, START_RANDOM_RANGE, END_RANDOM_RANGE);

            // печать одномерного массива
            PrintArray(simpleArray);

            ProcessingArrayByDiagonal(multiArray, simpleArray, ROW_COUNT, COLUMN_COUNT);
        }
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
            Console.WriteLine("{0}\n",new string('=',60));
        }


        /// <summary>
        /// печать многомерного массива
        /// </summary>
        /// <param name="printedArray"></param>
        public static void PrintArray(int[,] printedArray, int[] simpleArray,
                int rowIndex, int columnIndex)
        {
            System.Threading.Thread.Sleep(700);
            Console.Clear();
            PrintArray(simpleArray);

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

        private static void ProcessingArrayByDiagonal(int[,] arrayForFilling, int[] simpleArray,
                   int rowCount, int columnCount)
        {
            // заполняем массива по дагоналям, запонение начинается с конца

            // переменные для хранения идексов, 
            // используемых, для заполнение многомерного массива
            int rowIndex;
            int columnIndex;

            rowIndex = rowCount - 1;
            columnIndex = columnCount - 1;

            // последний элемент одномерного массива
            // помещаем в конец двумерного
            // _ _ _
            // _ _ X
            arrayForFilling[rowIndex, columnIndex] = simpleArray[simpleArray.Length - 1];

            PrintArray(arrayForFilling, simpleArray, rowIndex, columnIndex);

            --columnIndex;

            // заполняем массива по диагонали, запонение начинается с конца
            for (int i = simpleArray.Length - 2; i >= 0; i--)
            {
                // _ _ _
                // _ _ _
                // _ x _
                if (rowIndex == rowCount - 1 && columnIndex != 0)
                {
                    // двигаемся снизу вверх
                    do
                    {
                        arrayForFilling[rowIndex, columnIndex] = simpleArray[i];

                        PrintArray(arrayForFilling, simpleArray, rowIndex, columnIndex);

                        // _ _ _   _ _ _
                        // _ x _ → _ _ x
                        // _ _ _   _ _ _
                        if (columnIndex + 1 != columnCount)
                        {
                            ++columnIndex;
                        }
                        else
                        {
                            break;
                        }

                        // _ _ _   _ _ _
                        // _ _ _ → _ x _
                        // _ x _   _ _ _                        
                        if (rowIndex - 1 >= 0)
                        {
                            --rowIndex;
                        }

                        // уменьшаем итератор одномерного массива
                        --i;

                    } while (columnIndex < columnCount);

                    // увеличиваем итератор на 1, т.к. в цикле с пост условием
                    // итератор может быть уменьшен, но второй раз в цикл не зайти
                    // и i-й элемент не будет использоваться, т.к. в основном цикле
                    // будет уменьшен еще на 1
                    //++i;
                }
                else
                {
                    // _ _ _
                    // _ _ x
                    // _ _ _
                    if (columnIndex == columnCount - 1 && rowIndex - 1 >= 0)
                    {
                        // _ _ _   _ _ _
                        // _ _ _   _ _ x
                        // _ _ x → _ _ _
                        // _ _ _   _ _ _
                        --rowIndex;

                        do
                        {
                            arrayForFilling[rowIndex, columnIndex] = simpleArray[i];
                            PrintArray(arrayForFilling, simpleArray, rowIndex, columnIndex);

                            if (rowIndex + 1 != rowCount)
                            {
                                // _ _ _   _ _ _
                                // _ _ x   _ _ _
                                // _ _ _ → _ _ x
                                // _ _ _   _ _ _
                                ++rowIndex;
                            }
                            else
                            {
                                // _ _ _   _ _ _
                                // _ _ _   _ _ _ 
                                // _ _ x → _ x _
                                // _ _ _   _ _ _
                                if (columnIndex - 1 >= 0)
                                {
                                    --columnIndex;
                                }

                                break;
                            }

                            // _ _ _   _ _ _
                            // _ _ _   _ _ _ 
                            // _ _ x → _ x _
                            // _ _ _   _ _ _
                            --columnIndex;

                            // уменьшаем итератор одномерного массива
                            --i;

                        } while (rowIndex < rowCount);

                    }
                    else
                    {
                        // _ _ _
                        // _ _ _
                        // _ _ _
                        // x _ _
                        if (rowIndex == rowCount - 1 && columnIndex == 0)
                        {
                            // _ _ _   _ _ _
                            // _ _ _   _ _ _
                            // _ _ _ → x _ _
                            // x _ _   _ _ _
                            --rowIndex;

                            // ДИАГОНАЛЬ снизу вверх
                            do
                            {
                                arrayForFilling[rowIndex, columnIndex] = simpleArray[i];
                                PrintArray(arrayForFilling, simpleArray, rowIndex, columnIndex);

                                if (rowIndex - 1 >= 0)
                                {
                                    // _ _ _   _ _ _
                                    // _ _ _   x _ _ 
                                    // x _ _ → _ _ _
                                    // _ _ _   _ _ _
                                    --rowIndex;
                                }
                                else
                                {
                                    break;
                                }

                                // _ _ _   _ _ _
                                // x _ _   _ x _
                                // _ _ _ → _ _ _
                                // _ _ _   _ _ _
                                ++columnIndex;

                                // уменьшаем итератор одномерного массива
                                --i;

                            } while (rowIndex >= 0);

                        }
                        else
                        {
                            if (rowIndex == 0 && columnIndex != columnCount - 1)
                            {
                                // _ _ x _   _ x _ _
                                // _ _ _ _   _ _ _ _
                                // _ _ _ _ → _ _ _ _
                                // _ _ _ _   _ _ _ _
                                --columnIndex;
                                do
                                {
                                    arrayForFilling[rowIndex, columnIndex] = simpleArray[i];
                                    PrintArray(arrayForFilling, simpleArray, rowIndex, columnIndex);

                                    if (columnIndex - 1 >= 0)
                                    {
                                        // _ _ x _   _ x _ _
                                        // _ _ _ _ → _ _ _ _
                                        // _ _ _ _   _ _ _ _
                                        --columnIndex;
                                    }
                                    else
                                    {
                                        break;
                                    }

                                    // _ x _ _   _ _ _ _
                                    // _ _ _ _   _ x _ _
                                    // _ _ _ _ → _ _ _ _
                                    // _ _ _ _   _ _ _ _
                                    ++rowIndex;

                                    --i;

                                } while (columnIndex >= 0);
                            }
                            else
                            {
                                // _ _ _ _
                                // _ _ _ _
                                // x _ _ _
                                // _ _ _ _
                                if (columnIndex == 0 && rowIndex != rowCount - 1)
                                {
                                    // _ _ _ _   _ _ _ _
                                    // _ _ _ _   x _ _ _
                                    // x _ _ _ → _ _ _ _
                                    // _ _ _ _   _ _ _ _
                                    --rowIndex;
                                    do
                                    {
                                        arrayForFilling[rowIndex, columnIndex] = simpleArray[i];
                                        PrintArray(arrayForFilling, simpleArray, rowIndex, columnIndex);
                                        if (rowIndex - 1 >= 0)
                                        {
                                            // _ _ _ _   x _ _ _
                                            // x _ _ _   _ _ _ _
                                            // _ _ _ _ → _ _ _ _
                                            // _ _ _ _   _ _ _ _
                                            --rowIndex;
                                        }
                                        else
                                        {
                                            // _ x _ _   x _ _ _
                                            // _ _ _ _ → _ _ _ _
                                            // _ _ _ _   _ _ _ _
                                            --columnIndex;

                                            // x _ _ _
                                            // _ _ _ _
                                            // _ _ _ _
                                            if (rowIndex == 0 && columnIndex == 0)
                                            {
                                                arrayForFilling[rowIndex, columnIndex] = simpleArray[--i];
                                                PrintArray(arrayForFilling, 
                                                    simpleArray, rowIndex, columnIndex);
                                            }
                                            break;
                                        }

                                        // x _ _ _   _ x _ _
                                        // _ _ _ _ → _ _ _ _
                                        // _ _ _ _   _ _ _ _
                                        ++columnIndex;

                                        --i;
                                    } while (rowIndex >= 0);
                                }
                            }
                        }
                    }

                }
            }


            Console.WriteLine("\n\n{0}",new string ('=',60));
            Console.WriteLine("Done!");
            Console.ReadKey();
        }

    }
}
