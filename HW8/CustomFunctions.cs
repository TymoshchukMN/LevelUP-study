using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomClass;

namespace HW8
{
    /// <summary>
    /// Пользовательские методы проекта
    /// </summary>
    internal class CustomFunctions
    {
        #region константы

        // инициализация переменных рамера многомерного массива
        const int ARRAY_SIZE = 25;

        // количество столбцов в многомерном массиве поумолчанию
        const int COLUMN_COUNT = 5;

        // количество строк в многомерном массиве поумолчанию
        const int ROW_COUNT = 5;

        #endregion константы

        /// <summary>
        /// Вызов первой задачи
        /// </summary>
        public static void LaunchTask1()
        {           
            // инициализация одномерного массива
            int[] simpleArray = new int[ARRAY_SIZE];

            // заполнение одномерного массива
            // CommonCustomFunctions - библиотека классов
            CommonCustomFunctions.FillArray(simpleArray,
                    CommonCustomFunctions.START_RANDOM_RANGE,
                    CommonCustomFunctions.END_RANDOM_RANGE);

            // печать одномерного массива
            CommonCustomFunctions.PrintArray(simpleArray);


            // инициализация многомерного массива
            int[,] multiArray = new int[ROW_COUNT, COLUMN_COUNT];
            
            // переменная для хранениея типа заполнения массива 
            string fillingType;

            #region Обработка массива по столбцам "← →"

            // вызов функции на заполнение многомерного массива
            ProcessingArryByRows(multiArray, simpleArray, ROW_COUNT, COLUMN_COUNT);

            fillingType = "По стоблцам,  \"← →\"";

            // печать многомерного массива по СТРОКАМ
            CommonCustomFunctions.PrintArray(multiArray, fillingType);

            #endregion Обработка массива по столбцам "← →"

            // Очищаем многомерный массив для последующего заполнения
            Array.Clear(multiArray, 0, multiArray.Length);

            #region Обработка массива по столбцам "↓↑"

            // вызов функции на заполнение многомерного массива по СТОЛБЦАМ
            ProcessingArryByColumns(multiArray, simpleArray, ROW_COUNT, COLUMN_COUNT);

            fillingType = "По строкам,  \"↓↑\"";

            // печать многомерного массива 
            CommonCustomFunctions.PrintArray(multiArray, fillingType);

            #endregion Обработка массива по столбцам "↓↑"

            Console.ReadKey();
        }

        /// <summary>
        /// Выполнение задачи №2
        /// </summary>
        public static void LaunchTask2()
        {
            // инициализация многомерного массива
            int[,] multiArray = new int[ROW_COUNT, COLUMN_COUNT];

            // запонение многомерного массива рандомными значениями
            CommonCustomFunctions.FillArray(multiArray, 
                    CommonCustomFunctions.START_RANDOM_RANGE, 
                    CommonCustomFunctions.END_RANDOM_RANGE);

            //печать рандомного массива
            CommonCustomFunctions.PrintArray(multiArray);
                       

            #region замена минимума и максимума

            // поиск минимумов и максимумов с их индексами
            FindMinMax(multiArray, out int rowIndexMaxVol, out int colIndexMaxVol,
                    out int rowIndexMinVol, out int colIndexMinVol);

            // печать массива ДО изменения менстами мин и макс
            CommonCustomFunctions.PrintArray(multiArray, rowIndexMaxVol,
                    colIndexMaxVol, rowIndexMinVol, colIndexMinVol);

            // меняем местами минимум и максимум
            int tmpVol = multiArray[rowIndexMinVol, colIndexMinVol];
            multiArray[rowIndexMinVol, colIndexMinVol] = multiArray[rowIndexMaxVol, colIndexMaxVol];
            multiArray[rowIndexMaxVol, colIndexMaxVol] = tmpVol;

            // поиск минимумов и максимумов с их индексами
            FindMinMax(multiArray, out rowIndexMaxVol, out colIndexMaxVol,
                    out rowIndexMinVol, out colIndexMinVol);

            // печать массива ПОСЛЕ изменения менстами мин и макс
            CommonCustomFunctions.PrintArray(multiArray, rowIndexMaxVol,
                    colIndexMaxVol, rowIndexMinVol, colIndexMinVol);

            #endregion замена минимума и максимума

            #region меняем местами СТОЛБЦЫ с мин и макс

            // поиск минимумов и максимумов с их индексами
            FindMinMax(multiArray, out rowIndexMaxVol, out colIndexMaxVol,
                    out rowIndexMinVol, out colIndexMinVol);

            // печатаем массив ДО замены столбцов местами
            CommonCustomFunctions.PrintArray(multiArray, colIndexMinVol, colIndexMaxVol, ArrayPart.column);
            // меняем местами столбцы
            ReplaceColumn(multiArray, colIndexMaxVol, colIndexMinVol);

            // поиск минимумов и максимумов с их индексами
            FindMinMax(multiArray, out rowIndexMaxVol, out colIndexMaxVol,
                    out rowIndexMinVol, out colIndexMinVol);

            // печатаем массив ПОСЛЕ замены столбцов местами
            CommonCustomFunctions.PrintArray(multiArray, colIndexMinVol, colIndexMaxVol, ArrayPart.column);
           
            #endregion меняем местами СТОЛБЦЫ с мин и макс

            #region меняем местами СТРОКИ с мин и макс

            // поиск минимумов и максимумов с их индексами
            FindMinMax(multiArray, out rowIndexMaxVol, out colIndexMaxVol,
                    out rowIndexMinVol, out colIndexMinVol);

            // печатаем массив до замены строк местами
            CommonCustomFunctions.PrintArray(multiArray, rowIndexMinVol, rowIndexMaxVol, ArrayPart.row);
            
            ReplaceRows(multiArray, rowIndexMaxVol, rowIndexMinVol);

            // поиск минимумов и максимумов с их индексами
            FindMinMax(multiArray, out rowIndexMaxVol, out colIndexMaxVol,
                    out rowIndexMinVol, out colIndexMinVol);

            // печатаем массив ПОСЛЕ замены строк местами
            CommonCustomFunctions.PrintArray(multiArray, rowIndexMinVol, rowIndexMaxVol, ArrayPart.row);


            #endregion меняем местами СТРОКИ с мин и макс


            Console.ReadKey();
        }

        /// <summary>
        /// Запуск третьей задачи (Помеять местами элементы 
        /// основной и дополнительной диагонали в квадратной матрице)
        /// </summary>
        public static void LaunchTask3()
        {
            // инициализация многомерного массива
            int[,] multiArray = new int[ROW_COUNT, COLUMN_COUNT];

            // заполнение одномерного массива
            // CommonCustomFunctions - библиотека классов
            CommonCustomFunctions.FillArray(multiArray,
                    CommonCustomFunctions.START_RANDOM_RANGE,
                    CommonCustomFunctions.END_RANDOM_RANGE);

            // печать одномерного массива
            CommonCustomFunctions.PrintArray(multiArray);

            // столбец до которого будет выполняться работа цикла
            // в замене элементов диагонали
            int centralColumn;

            // если сзначения ((ROW_COUNT / 2.0) != ROW_COUNT / 2 
            // не равны, то число дробное, поэтому столбец 
            // centralColumn увеличиваем на 1
            if ((ROW_COUNT / 2.0) != ROW_COUNT / 2)
            {
                // число дробное

                centralColumn = (ROW_COUNT / 2) + 1;
            }
            else
            {
                // число НЕ дробное

                centralColumn = (ROW_COUNT / 2);
            }


            Console.ReadKey();
        }


        /// <summary>
        /// Запуск 4-й задачи (погодный агрегатор)
        /// </summary>
        public static void LaunchTask4()
        {
            // количество месяцев в агрегаторе
            const ushort mounthCount = 12;

            // количество часов в агрегаторе 24
            const ushort hours = 24;

            #region инициализация массива

            EnumTypeWeather[][][] weatherAggregator = new EnumTypeWeather[mounthCount][][];

            // переменная для хранения колчества дней в менсяце
            ushort countDaysPerMoths;
            Random rand = new Random();

            for (int month = 0; month < mounthCount; month++)
            {
                // получаем количество дней в месяце
                countDaysPerMoths = GetCountDays((EnumMonth)month + 1);

                // задаем размерность второго "измерения"
                // (колчество дней в месяце)
                weatherAggregator[month] = new EnumTypeWeather[countDaysPerMoths][];

                for (int day = 0; day < countDaysPerMoths; day++)
                {
                    // задаем размерность 3-го "измерения",
                    // во всех случаях равен 24
                    weatherAggregator[month][day] = new EnumTypeWeather[hours];
                    for (int hour = 0; hour < hours; hour++)
                    {
                        // наполнение массива значениями
                        weatherAggregator[month][day][hour] = (EnumTypeWeather)rand.Next(1, 30);
                    }
                }
            }

            #endregion

            #region справочники

            ushort windyDays = 0;

            // среднее количество ветренных дней в менсяц
            for (int month = 0; month < mounthCount; month++)
            {
                // получаем количество дней в месяце
                countDaysPerMoths = GetCountDays((EnumMonth)month + 1);

                for (int day = 0; day < countDaysPerMoths; day++)
                {

                    for (int hour = 0; hour < hours; hour++)
                    {

                        if (weatherAggregator[month][day][hour].HasFlag(EnumTypeWeather.windy))
                        {
                            ++windyDays;
                            break;
                        }

                    }
                }
            }

            // среднее количество ветренных дней в менсяц
            Console.WriteLine("Общее количество ветренных дней в году\t {0}", windyDays);
            windyDays = (ushort)(windyDays / mounthCount);

            Console.WriteLine("Среднее колчиество ветренныз дней\t {0}", windyDays);

            #endregion справочники


            Console.ReadKey();


        }

        /// <summary>
        /// замена местами столбцов
        /// </summary>
        /// <param name="arrayForReplace">
        /// массив для замены
        /// </param>
        /// <param name="colIndexMaxVol">
        /// индекс столбца с максимальным значением
        /// </param>
        /// <param name="colIndexMinVol">
        /// индекс столбца с минимальным значением
        /// </param>
        public static void ReplaceColumn(int[,] arrayForReplace, int colIndexMaxVol, 
                int colIndexMinVol)
        {
            int tmpVol = 0;
            for (int row = 0; row < arrayForReplace.GetLength(0); row++)
            {
                tmpVol = arrayForReplace[row, colIndexMaxVol];
                arrayForReplace[row, colIndexMaxVol] = arrayForReplace[row, colIndexMinVol];
                arrayForReplace[row, colIndexMinVol] = tmpVol;
            }
        }

        /// <summary>
        /// замена местами строк
        /// </summary>
        /// <param name="arrayForReplace"> массив для замены </param>
        /// <param name="rowIndexMaxVol"> 
        /// индекс строки с максимальным значением </param>
        /// <param name="rowIndexMinVol">
        /// индекс строки с минимальным значением
        /// </param>
        public static void ReplaceRows(int[,] arrayForReplace, int rowIndexMaxVol,
                int rowIndexMinVol)
        {
            int tmpVol = 0;
            for (int column = 0; column < arrayForReplace.GetLength(1); column++)
            {
                tmpVol = arrayForReplace[rowIndexMaxVol, column];
                arrayForReplace[rowIndexMaxVol, column] = arrayForReplace[rowIndexMinVol, column];
                arrayForReplace[rowIndexMinVol, column] = tmpVol;
            }
        }

        /// <summary>
        /// Нахождение размерности многомерного массива
        /// </summary>
        /// <param name="num">
        /// длина одномерного масссива
        /// </param>
        /// <param name="columnSize">
        /// количество столбцов
        /// </param>
        /// <param name="rowSize">
        /// количество строк
        /// </param>
        public static void CalcMultidimensionalArraySize(int num, out int columnSize,
                out int rowSize, out bool isEven)
        {
            // инициализируем переменные xSize и ySize
            // т.к. при инициализации только внутри if
            // получаем ошибку
            columnSize = 0;
            rowSize = 0;

            // true - четное, false - не четное
            isEven = false;
            int i = 1;

            // Переменная для проверки второго числа для деления без остатка
            ushort secondVol = 0;

            // выполняем поиск делителя для четного числа
            if (num % 2 == 0)
            {
                // устанавливаем флаг, что массив четный
                isEven = true;
                while (i <= num)
                {
                    i++;

                    // нахоим первое число, которое делит длину массива без остатка
                    // например, 16/3 = 5
                    if (num % i == 0)
                    {
                        // количество столбцов будет равно длине массива, деленному
                        columnSize = num / i;

                        // количество строк равно второму множителю
                        rowSize = i;

                        // увеличиваем счетчик. т.е. один делитель нашли
                        // ищем следующий, если второй делитель будет найдет, 
                        // цикл прервется
                        //++secondVol;

                        // если нашли второй делитель по счету делитель,
                        // то прерываем проверку
                        if (i > 2)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                // устанавливаем флаг, что массив НЕ четный
                isEven = false;

                // выполняем поиск делителя для НЕ четного числа
                while (i <= num - 1)
                {
                    i++;

                    // нахоим первое число, которое делит длину массива без остатка
                    // например, 15/3 = 5
                    if ((num - 1) % i == 0)
                    {
                        // количество столбцов будет равно длине массива, деленному
                        columnSize = num / i;

                        // количество строк равно второму множителю
                        rowSize = i;

                        // увеличиваем счетчик. т.е. один делитель нашли
                        // ищем следующий, если второй делитель будет найдет, 
                        // цикл прервется
                        //++secondVol;

                        // если нашли второй делитель по счету делитель,
                        // то прерываем проверку
                        if (i > 1)
                        {
                            // досбавляем к строке единицу, т.к. отнимали ее для поиска делителя
                            ++rowSize;
                            break;
                        }
                    }
                }
            }            
        }

        /// <summary>
        /// обработка многомерного массива для заполнения
        /// </summary>
        /// <param name="arrayForFilling">
        /// многомерный массив для заполнения
        /// </param>
        /// <param name="simpleArray">
        /// одномерный массив, из которого берем значения
        /// </param>
        /// <param name="rowCount">
        /// количество строк
        /// </param>
        /// <param name="columnCount">
        /// количество столбцов
        /// </param>
        public static void ProcessingArryByRows(int[,] arrayForFilling, int[] simpleArray,
                int rowCount, int columnCount)
        {
            // заполняем массива по типу →←, запонение начинается с конца

            // переменная определяющая направление заполнение по строкам
            // 0b0 с права на лево, 0b1 с лева на право
            byte columnFlag = 0b0;

            // заполняем массива по типу →←, запонение начинается с конца
            for (int i = simpleArray.Length - 1; i >= 0; i--)
            {
                FillArrayByRows(arrayForFilling, simpleArray, rowCount, columnCount, ref columnFlag, ref i);
            }
        }
        /// <summary>
        /// запол
        /// </summary>
        /// <param name="arrayForFilling">
        /// многомерный массив для заполнения
        /// </param>
        /// <param name="simpleArray">
        /// одномерный массив из которого берем данные
        /// </param>
        /// <param name="columnCount">
        /// оличество столбцов многомерного массива
        /// </param>
        /// <param name="columnFlag">
        /// флаг, определяющий направление заполнения
        /// 0b0 с права на лево, 0b1 с лева на право
        /// </param>
        /// <param name="i">
        /// итератор одномерного массива
        /// </param>
        private static void FillArrayByRows(int[,] arrayForFilling, int[] simpleArray,
                int rowCount, int columnCount, ref byte columnFlag, ref int i)
        {
            // проход по "строкам"
            for (int row = rowCount - 1; row >= 0; row--)
            {

                // проверка направления движения
                // 0b0 с права на лево
                // 0b1 с лева на право

                if (columnFlag == 0b0)
                {
                    // проход по столбцам с права на лево
                    for (int column = columnCount - 1; column >= 0; column--)
                    {
                        arrayForFilling[row, column] = simpleArray[i];

                        // уменьшаем итератор цикла по перебору
                        // элементов одномерного массива
                        if (i == 0)
                        {
                            break;
                        }
                        --i;
                    }

                    // меняем флаг для смены направления обработки строк
                    // следующая обработка пойдет с лева на право
                    columnFlag = (byte)~columnFlag;
                }
                else
                {
                    // проход по столбцам с лева на право
                    for (int column = 0; column < columnCount; column++)
                    {
                        arrayForFilling[row, column] = simpleArray[i];

                        // уменьшаем итератор цикла по перебору
                        // элементов одномерного массива
                        --i;
                    }
                    // меняем флаг для смены направления обработки строк
                    // следующая обработка пойдет с право на лево
                    columnFlag = (byte)~columnFlag;
                }

            }
        }

        /// <summary>
        /// обработка массива по столбцам ↓↑
        /// </summary>
        /// <param name="arrayForFilling">
        /// многомерный массив для заполнения
        /// </param>
        /// <param name="simpleArray">
        /// одномерный массив из которого берем данные
        /// </param>
        /// <param name="isEven">
        /// указываем число элементов одномерного массива четное или нет
        /// </param>
        /// <param name="rowCount">
        /// количество строк многомерного массива
        /// </param>
        /// <param name="columnCount">
        /// количество столбцов многомерного массива
        /// </param>
        public static void ProcessingArryByColumns(int[,] arrayForFilling, int[] simpleArray,
                int rowCount, int columnCount)
        {
            // заполняем массива по типу ↓↑, запонение начинается с конца

            // переменная определяющая направление заполнение по столбцам
            // сверху вниз или снизу верх
            byte rowFlag = 0b0;

            // заполняем массива по типу →←, запонение начинается с конца
            for (int i = simpleArray.Length - 1; i >= 0; i--)
            {
                FillArrayByColumns(arrayForFilling, simpleArray, rowCount, columnCount, ref rowFlag, ref i);
            }
        }

        /// <summary>
        /// запол
        /// </summary>
        /// <param name="arrayForFilling">
        /// многомерный массив для заполнения
        /// </param>
        /// <param name="simpleArray">
        /// одномерный массив из которого берем данные
        /// </param>
        /// <param name="columnCount">
        /// оличество столбцов многомерного массива
        /// </param>
        /// <param name="rowFlag">
        /// флаг, определяющий направление заполнения
        /// 0b0 снизу в верх, 0b1 сверху вниз
        /// </param>
        /// <param name="i">
        /// итератор одномерного массива
        /// </param>
        private static void FillArrayByColumns(int[,] arrayForFilling, int[] simpleArray,
                int rowCount, int columnCount, ref byte rowFlag, ref int i)
        {
            // проход по "столбцам"

            for (int column = columnCount - 1; column >= 0; column--)
            {
                // проверка направления движения
                // 0b0 снизу в верх
                // 0b1 сверху вниз

                if (rowFlag == 0b0)
                {
                    for (int row = rowCount - 1; row >= 0; row--)
                    {
                        arrayForFilling[row, column] = simpleArray[i];
                                                
                        if (i == 0)
                        {
                            break;
                        }
                        // уменьшаем итератор цикла по перебору
                        // элементов одномерного массива
                        --i;
                    }
                    // меняем флаг для смены направления обработки столбцов
                    // следующая обработка пойдет снизу в верх
                    rowFlag = (byte)~rowFlag;
                }
                else
                {
                    for (int row = 0; row < rowCount; row++)
                    {
                        arrayForFilling[row, column] = simpleArray[i];

                        if (i == 0)
                        {
                            break;
                        }
                        // уменьшаем итератор цикла по перебору
                        // элементов одномерного массива
                        --i;
                    }
                    // меняем флаг для смены направления обработки столбцов
                    // следующая обработка пойдет сверху вниз
                    rowFlag = (byte)~rowFlag;
                }

            }

            //// проход по "строкам"
            ////for (int row = rowCount - 1; row >= 0; row--)
            //{

            //    // проверка направления движения
            //    // 0b0 снизу в верх
            //    // 0b1 сверху вниз

            //    if (rowFlag == 0b0)
            //    {
            //        // проход по столбцам с права на лево
            //        for (int column = columnCount - 1; column >= 0; column--)
            //        {
            //            arrayForFilling[row, column] = simpleArray[i];

            //            // уменьшаем итератор цикла по перебору
            //            // элементов одномерного массива
            //            if (i == 0)
            //            {
            //                break;
            //            }
            //            --i;
            //        }

            //        // меняем флаг для смены направления обработки строк
            //        // следующая обработка пойдет снизу в верх
            //        rowFlag = (byte)~rowFlag;
            //    }
            //    else
            //    {
            //        // проход по столбцам с лева на право
            //        for (int column = 0; column < columnCount; column++)
            //        {
            //            arrayForFilling[row, column] = simpleArray[i];

            //            // уменьшаем итератор цикла по перебору
            //            // элементов одномерного массива
            //            --i;
            //        }
            //        // меняем флаг для смены направления обработки строк
            //        // следующая обработка пойдет снизу в верх
            //        rowFlag = (byte)~rowFlag;
            //    }

            //}
        }

        /// <summary>
        /// поисе индексов столбцов с мин и макс значениями
        /// </summary>
        /// <param name="arrayForParse">
        /// массив для поиска
        /// </param>
        /// <param name="rowIndexMaxVol">
        /// индекс строки с макс значением
        /// </param>
        /// <param name="colIndexMaxVol">
        /// индекс столбца с макс значением
        /// </param>
        /// <param name="rowIndexMinVol">
        /// индекс строки с мин значением
        /// </param>
        /// <param name="colIndexMinVol">
        /// индекс столбца с мин значением
        /// </param>
        public static void FindMinMax(int[,] arrayForParse, out int rowIndexMaxVol,
        out int colIndexMaxVol, out int rowIndexMinVol, out int colIndexMinVol)
        {
            // инициализация переменных ждя поиска мин и максм значений в массиве
            int minVolInArray = int.MaxValue;
            int maxVolInArray = int.MinValue;

            // индексы максимального значения
            rowIndexMaxVol = 0;
            colIndexMaxVol = 0;

            // инексы минимального значения
            rowIndexMinVol = 0;
            colIndexMinVol = 0;

            for (int row = 0; row < arrayForParse.GetLength(0); row++)
            {
                for (int column = 0; column < arrayForParse.GetLength(1); column++)
                {
                    if (arrayForParse[row, column] > maxVolInArray)
                    {
                        maxVolInArray = arrayForParse[row, column];
                        rowIndexMaxVol = row;
                        colIndexMaxVol = column;
                    }
                    if (arrayForParse[row, column] < minVolInArray)
                    {
                        minVolInArray = arrayForParse[row, column];
                        rowIndexMinVol = row;
                        colIndexMinVol = column;
                    }
                }
            }
        }
       
        /// <summary>
        /// Получаем количество дней в месяце
        /// </summary>
        /// <returns>
        /// количество дней в месяце
        /// </returns>
        public static ushort GetCountDays(EnumMonth month)
        {
            switch (month)
            {
                case EnumMonth.January:
                    return 31;
                case EnumMonth.February:
                    return 28;
                case EnumMonth.March:
                    return 31;
                case EnumMonth.April:
                    return 30;
                case EnumMonth.May:
                    return 31;
                case EnumMonth.June:
                    return 30;
                case EnumMonth.July:
                    return 31;
                case EnumMonth.August:
                    return 31;
                case EnumMonth.September:
                    return 30;
                case EnumMonth.October:
                    return 31;
                case EnumMonth.November:
                    return 30;
                case EnumMonth.December:
                    return 31;
            }
            return 0;
        }

        //public static void Replace
    }
}