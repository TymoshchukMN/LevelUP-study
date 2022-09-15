using HW7;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Пользовательские функции
/// </summary>
internal class CustomFunctions
{
    public const int START_RANDOM_RANGE = -100; // минимальное значение для рандома
    public const int END_RANDOM_RANGE = 500;    // максимальное значение для рандома
    public const int ARRAY_SIZE = 15;           // размер массимва по умолчанию

    /// <summary>
    /// Наполнение массива рандомніми значенияеми
    /// </summary>
    /// <param name="array"> массив для заполнения </param>
    /// <param name="start"> минимальное число для рандома </param>
    /// <param name="last"> максимальное число для рандома </param>
    public static void ArrayFilling(ref int[] array, int start, int last)
    {
        Random random = new Random();

        // наполнение массива значениями
        for (int i = 0; i < array.Length; i++)
        {
             array[i] = random.Next(START_RANDOM_RANGE, END_RANDOM_RANGE);
        }
    }

    /// <summary>
    /// Подсчет количества символов в массиве, преобразованном в строку
    /// </summary>
    /// <param name="array">
    /// массив для подсчета символов
    /// </param>
    /// <returns>
    /// Количество символов
    /// </returns>
    public static int CalculateCharCount(int [] array)
    {
        return string.Join(" ", array).Length;
    }
    
    /// <summary>
    /// Вывод сдержимого массива в консоль
    /// </summary>
    /// <param name="sourceArray">
    /// массив для печати в консоль
    /// </param>
    /// <param name="countBoardSymbols">
    /// Количество символов для отрисовки границы
    /// </param>
    /// <param name="preferedConsoleColor">
    /// желаемый цвет символов массива
    /// </param>
    /// <param name="indexMin">
    /// позиция МИНИМАЛЬНОГО элемента в массиве
    /// </param>
    /// <param name="indexMax">
    /// позиция МАКСИМАЛЬНОГО элемента в массиве
    /// </param>
    /// <param name="currentConsoleColor">
    /// цвет консоли до вызова функции
    /// </param>
    public static void PrintArray(int[] sourceArray, int countBoardSymbols, 
            int indexMin, int indexMax, 
            ConsoleColor preferedConsoleColor, ConsoleColor currentConsoleColor)
    {
        Console.WriteLine(new string('=', countBoardSymbols));
        Console.WriteLine('\n');

        for (int i = 0; i < sourceArray.Length; i++)
        {
            if (i == indexMin)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0} ", sourceArray[i]);
                Console.ForegroundColor = currentConsoleColor;
            }
            else
            {
                if (i == indexMax)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("{0} ", sourceArray[i]);
                    Console.ForegroundColor = currentConsoleColor;
                }
                else
                {
                    Console.Write("{0} ", sourceArray[i]);
                }
            }
           
        }

        Console.WriteLine('\n');
        
        // возвращаем исходный цвет консоли (тот, что был до вызова функции)
        Console.ForegroundColor = currentConsoleColor;
    }

    /// <summary>
    /// Вывод содержимого массива в консоль
    /// </summary>
    /// <param name="sourceArray">
    /// массив для вывода на экран
    /// </param>
    /// <param name="countBoardSymbols">
    /// Количество символов для отрисовки границы
    /// </param>
    public static void PrintArray(int[] sourceArray, int countBoardSymbols)
    {
        // отрисовка границы
        Console.WriteLine(new string('=', countBoardSymbols));
        
        // печать массива
        for (int i = 0; i < sourceArray.Length; i++)
        {
            Console.Write("{0} ", sourceArray[i]);
        }
        Console.WriteLine('\n');

        // отрисовка границы
        Console.WriteLine(new string('=', countBoardSymbols));
    }

    /// <summary>
    /// Поменять местами значения минимума и максимума в массиве
    /// </summary>
    public static void ReplaceArrayElenents()
    {
        

        // создание и инициализация массива
        int[] customArray = new int[ARRAY_SIZE];
        
        // наполение массива
        ArrayFilling(ref customArray, START_RANDOM_RANGE, END_RANDOM_RANGE);

        // количество символов в массиве при выводе на консоль (для красоты)
        int charsCountInArray = CalculateCharCount(customArray);

        // поиск индекса минимального значения в массиве
        int indexMin = Array.IndexOf(customArray, customArray.Min());

        // поиск индекса максимального значения в массиве
        int indexMax = Array.IndexOf(customArray, customArray.Max());


        // печать массива ДО ИЗМЕНЕНИЯ 
        CustomFunctions.PrintArray(customArray, charsCountInArray,
                indexMin, indexMax,
                ConsoleColor.Green, Console.ForegroundColor);

        // временная переменна для замены местами
        int tmpVol = customArray[indexMin];

        // максимальное значение помещаем вместо минимального
        customArray[indexMin] = customArray[indexMax];

        // минимальное значение помещаем вместо максимального
        customArray[indexMax] = tmpVol;


        // повторно находим мин и макс для передачи в функцию вывода на консоль
        indexMin = Array.IndexOf(customArray, customArray.Min());
        indexMax = Array.IndexOf(customArray, customArray.Max());


        // печать массива ПОСЛЕ ИЗМЕНЕНИЯ 
        CustomFunctions.PrintArray(customArray, charsCountInArray,
               indexMin, indexMax,
               ConsoleColor.Green, Console.ForegroundColor);
    }


    /// <summary>
    /// запуск задачи на смещение
    /// </summary>
    public static void LaunchTask2()
    {

        Console.Write("Укажите количество элементов в массиве:\t\t");
        int arraySize = int.Parse(Console.ReadLine());

        // инициализация массива
        int [] customArray = new int[arraySize];

        // заполнение массива значениями
        ArrayFilling(ref customArray, START_RANDOM_RANGE, END_RANDOM_RANGE);
                
        Console.Write("Укажите количество элементов для смещения:\t");
        
        string userInput = Console.ReadLine();
        int countPositions = int.Parse(userInput);

        Console.Write("Укажите направление смещения:\t");
        EnumDirectionOffset direction = (EnumDirectionOffset)Console.ReadKey().Key;
        Console.WriteLine(direction);

        // вызов фун-ии на смещение элементов массива
        ShiftArrayElements(direction, countPositions, countPositions, ref customArray);
    }

    /// <summary>
    /// функ-я смещения элементов в массиве
    /// </summary>
    /// <param name="Direction">
    /// направление смещения
    /// </param>
    /// <param name="customArray"> 
    /// массив для смещения 
    /// </param>
    /// <param name="countPositions">
    /// коли-во элементов на которые необходимо выполнить смещение в массиве
    /// </param>
    /// <param name="countBoardSymbols">
    /// соличество символов в массиве, преобразованном в строку
    /// </param>
    public static void ShiftArrayElements(EnumDirectionOffset Direction, 
            int countBoardSymbols, int countPositions, ref int[] customArray)
    {
        int[] tempArray = new int[customArray.Length];
        
        // количество символов в массиве, преобразованном в строку
        int charsCountInArray = 0;
        switch (Direction)
        {
            case EnumDirectionOffset.left:

                #region Смещение в лево

                // количество символов в массиве при выводе на консоль (для красоты)
                charsCountInArray = CalculateCharCount(customArray);

                Console.WriteLine("\nМассив ДО смещение на {0} позиций", countPositions);
                PrintArray(customArray, charsCountInArray);

                // количество смещений влево до того, как итератор - количество позиций будет равен нулю
                // нужна для добавления значений в конец массива
                ushort countOffsetLeft = 0;

                for (int i = customArray.Length - 1; i >= 0; i--)
                {
                    if (i - countPositions >= 0)
                    {
                        // [1, 3, 4, 5] → [0, 0, 5, 0]
                        // [1, 3, 4, 5] → [0, 4, 5, 0]
                        tempArray[i - countPositions] = customArray[i];
                        ++countOffsetLeft;
                    }
                    else
                    {
                        // помещение в последнюю пощицию темпового массива
                        // значение первого элемента основного массива
                        // [1, 3, 4, 5, 15, 10] → [5, 15, 10, 0, 0, 4]
                        // [1, 3, 4, 5, 15, 10] → [5, 15, 10, 0, 3, 4]

                        tempArray[countOffsetLeft+i] = customArray[i];
                    }
                }

                // передаем основному массиву значение временного
                customArray = tempArray;

                Console.WriteLine("\nМассив ПОСЛЕ смещение на {0} позиций", countPositions);
                PrintArray(customArray, charsCountInArray);

                Console.ReadKey();

                #endregion Смещение в лево

                break;

            case EnumDirectionOffset.right:

                #region Смещение в право

                // количество символов в массиве при выводе на консоль (для красоты)
                charsCountInArray = CalculateCharCount(customArray);

                Console.WriteLine("\nМассив ДО смещение на {0} позиций", countPositions);
                PrintArray(customArray, charsCountInArray);

                for (int i = 0; i < tempArray.Length; i++)
                {
                    if (!(i + countPositions >= customArray.Length))
                    {
                        // заполняем временный массив значениями из основного
                        // запонение начинаем с полизиции, на которую выполняется смещение
                        // например при смещении на 2 [1,2,4,8] → [0,0,1,2]
                        tempArray[i + countPositions] = customArray[i];
                    }
                    else
                    {
                        // берем модуль от tempArray.Length - (countPositions + i))
                        // чтобы получить начальные индексы массива
                        // теперь заполняем начало временного массива
                        // при смещении на 2 [1,2,4,8] → [4,8,1,2]
                        tempArray[Math.Abs(tempArray.Length - (countPositions + i))] = customArray[i];
                    }
                }

                // передаем основному массиву значение временного
                customArray = tempArray;

                Console.WriteLine("\nМассив ПОСЛЕ смещение на {0} позиций", countPositions);
                PrintArray(customArray, charsCountInArray);

                Console.ReadKey();

                #endregion Смещение в право

                break;
        } 
    }

    /// <summary>
    /// Выполнение задачи #3 на сортировку массива
    /// </summary>
    /// <param name="arraySize">
    /// Размер массива
    /// </param>
    public static void LaunchTask3(int arraySize = ARRAY_SIZE)
    {
        Console.Clear();
        
        // создание массива для сортивовки
        int[] sortedArray = new int[ARRAY_SIZE];

        // заполнение массива значениями
        ArrayFilling(ref sortedArray, START_RANDOM_RANGE, END_RANDOM_RANGE);

        // печатаем массив ДО сортировки
        //Console.WriteLine("Массив ДО сортировок: ");
        //PrintArray(sortedArray, CalculateCharCount(sortedArray));

        #region сортировка ВСТАВКАМИ

        PrintBanner("ВСТАВКАМИ");
        
        Stopwatch stopWatch = new Stopwatch();

        // запуск секундомера
        stopWatch.Start();

        // вызов сортировки  ВСТАВКАМИ
        SortArrayByInsertion(sortedArray);
        
        // остановка секундомера
        stopWatch.Stop();

        TimeSpan TSSortArrayByInsertion = stopWatch.Elapsed;
        string elapsedTime = String.Format("{1:00}:{2:00}.{3:00}",
            TSSortArrayByInsertion.Hours, TSSortArrayByInsertion.Minutes, TSSortArrayByInsertion.Seconds,
            TSSortArrayByInsertion.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);

        #endregion сортировка ВСТАВКАМИ

        #region сортировка ВЫБОРОМ

        PrintBanner("ВЫБОРОМ");

        // запуск секундомера
        stopWatch.Start();

        // вызов сортировки ВЫБОРОМ
        SortArrayByChoise(sortedArray);

        // остановка секундомера
        stopWatch.Stop();

        TSSortArrayByInsertion = stopWatch.Elapsed;
        elapsedTime = String.Format("{1:00}:{2:00}.{3:00}",
            TSSortArrayByInsertion.Hours, TSSortArrayByInsertion.Minutes, TSSortArrayByInsertion.Seconds,
            TSSortArrayByInsertion.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);

        #endregion сортировка ВЫБОРОМ

    }

    /// <summary>
    /// печать банера на выбранный тип сортировки
    /// </summary>
    /// <param name="sortType">
    /// тип сортировки в строковом виду
    /// </param>
    public static void PrintBanner(string sortType)
    {
        Console.Write("Сортировка ");
        // получаем текущий цвет консоли 
        ConsoleColor defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("{0}", sortType);
        Console.ForegroundColor = defaultColor;
    }

    /// <summary>
    /// сортировка массива 
    /// </summary>
    /// <param name="arrayForSort">
    /// массив для сортировки
    /// </param>
    public static int [] SortArray(ref int [] arrayForSort, int temVol = 0)
    {


        for (int i = 0; i < arrayForSort.Length; i++)
        {
            if (i + 1 < arrayForSort.Length)
            {
                if (arrayForSort[i] > arrayForSort[i + 1])
                {
                    // сохраняем значение меньшего числа
                    temVol = arrayForSort[i + 1];

                    // перемещаем значение большего числа на 1 позицию вправо 
                    arrayForSort[i + 1] = arrayForSort[i];

                    // присваиваем значение меньшего числа элементу слева
                    arrayForSort[i] = temVol;

                    SortArray(ref arrayForSort);
                    return arrayForSort;
                }
            }
        }
        return arrayForSort;
    }

    /// <summary>
    /// Печать одного числа цветным 
    /// </summary>
    /// <param name="printedItem"></param>
    public static void PrintOneItem(int printedItem)
    {
        ConsoleColor defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(printedItem);
        Console.ForegroundColor = defaultColor;

    }
    /// <summary>
    /// Прорисовка массива в сортировке вставкой
    /// </summary>
    /// <param name="sourceArray"></param>
    /// <param name="MinVol"></param>
    /// <param name="movedVol"></param>
    public static void PrintArray(ref int [] sourceArray, int MinVol, int movedVol )
    {
        ConsoleColor defaultColor = Console.ForegroundColor;
        
        Console.Write("Проверяемое значение: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(MinVol);
        
        Console.ForegroundColor = defaultColor;

        Console.WriteLine("");
        int MinVolPos = Array.IndexOf(sourceArray, MinVol);

        for (int i = 0; i < sourceArray.Length; i++)
        {
            if (!(sourceArray[i] == MinVolPos))
            {
                if (!(sourceArray[i] == movedVol))
                {
                    Console.Write(" {0}", sourceArray[i]);
                }
                else
                {
                    PrintOneItem(sourceArray[i]);
                }                
            }
            else
            {
                Console.Write(" _ ");
            }
        }
    }

    public static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

    /// <summary>
    /// сортировка массива ВСТАВКАМИ
    /// </summary>
    /// <param name="arrayForSort">
    /// массив для сортировки
    /// </param>
    public static void SortArrayByInsertion(int[] arrayForSort, int temVol = 0, 
            int compareIndex = 0)
    {
        for (int i = 1; i < arrayForSort.Length; i++)
        {
            // индекс элемента для сравнения 
            compareIndex = i - 1;

            // переменная для хранения минимального значения,
            // которое будет смещено влево
            temVol = arrayForSort[i];
            
            // проверку выполняем до тех пор, пока не дойдем
            // в сравнении до нулевого индекса, или цикл не прервется, 
            // в случае, когда  предыдущее число меньше
            do
            {
                if (temVol < arrayForSort[compareIndex])
                {

                    arrayForSort[compareIndex + 1] = arrayForSort[compareIndex];
                    arrayForSort[compareIndex] = 0;
                    if (compareIndex == 0)
                    {
                        // присваиваем значению слева от тикущего индекса
                        // минимальное значение
                        arrayForSort[compareIndex] = temVol;

                        // прерываем цикк, т.к. 0 - это минимальный элемент массива
                        break;
                    }

                    // уменьшаем счетчик, для смещения по массиву от текущего индекса к началу
                    // [_, _, X, _] → [_, X, _, _] → [_, X, _, _] и т.д.
                    --compareIndex;
                }
                else
                {
                    // прелылущее значение мешь проверяемого, поэтому
                    // устанавливаем значение минимума в текщую позицию
                    arrayForSort[compareIndex + 1] = temVol;

                    // прерываем цикл, т.к. следующее значение меньше проверяемого
                    break;
                }

            } while (compareIndex >= 0);

        }

        // печатаем массив ПОСЛЕ сортировки ВСТАВКАМИ
        //Console.WriteLine("\nМассив после сортировки вставками:\n");
        //PrintArray(arrayForSort, CalculateCharCount(arrayForSort));

    }

    /// <summary>
    /// получение индекса минимального элемента
    /// </summary>
    /// <returns>
    /// индекс минимального элемента
    /// </returns>
    public static int GetIndexMinElement(ref int[] arrayForSort, int startPosition)
    {
        // временная переменная для хранения и возврата минимума
        int tmpMin = int.MaxValue;
        for (int i = startPosition; i < arrayForSort.Length; i++)
        {
            if (tmpMin > arrayForSort[i])
            {
                tmpMin = arrayForSort[i];
            }
        }
        // возвращаем индекс минимального элемента
        return Array.IndexOf(arrayForSort, tmpMin);
    }
    
    /// <summary>
    /// сортировка массива ВЫБОРОМ
    /// </summary>
    /// <param name="arrayForSort">
    /// сортируемый массив
    /// </param>
    public static void SortArrayByChoise(int[] arrayForSort)
    {
        int tmpVol = 0;
        for (int i = 0; i < arrayForSort.Length; i++)
        {
            // поиск минимума и его индекса внутри массива
            int indexMinVol = GetIndexMinElement(ref arrayForSort, i);
            
            if (arrayForSort[i] > arrayForSort[indexMinVol])
            {
                tmpVol = arrayForSort[i];
                arrayForSort[i] = arrayForSort[indexMinVol];
                arrayForSort[indexMinVol] = tmpVol;
            }
        }
        // печатаем массив ПОСЛЕ сортировки ВЫБОРОМ
        //Console.WriteLine("\nМассив после сортировки ВЫБОРОМ:\n");
        //PrintArray(arrayForSort, CalculateCharCount(arrayForSort));
    }

    /// <summary>
    /// БЫСТРАЯ сортировка массива
    /// </summary>
    /// <param name="arrayForSort">
    /// массив для сортировки
    /// </param>
    public static void SortAraayByQuick(ref int[] arrayForSort,
            int startIndex, int stopIndex)
    {
        // получаем "опорный" индекс
        int targetIndex = (stopIndex - startIndex) / 2 + startIndex;
        
        // переменная временного хранение элментов при замене местами 
        int tmpVol = 0;

        // выполняем просмотр значений слева до опорного индекса
        do
        {
            if (arrayForSort[startIndex] > arrayForSort[targetIndex])
            {
                // ищем значение больше опорного индекса (поиск с конца массива)
                for (int i = stopIndex; i > targetIndex; i--)
                {
                    // если элемени справа меньше опорного
                    if (arrayForSort[targetIndex] > arrayForSort[i])
                    {
                        // запоминаем значение, которое меньше и находится
                        // справа от опорного индекса
                        tmpVol = arrayForSort[i];

                        // меняем местами элементы справа и слева от опорного индекса
                        arrayForSort[i] = arrayForSort[startIndex];
                        arrayForSort[startIndex] = tmpVol;

                        // завершаем поиск элементов справа от опорного индекса
                        break;
                    }
                }
            }

            ++startIndex;

        // проверяем до тех пор, пока начальный индекс меньше опорного 
        } while (startIndex < targetIndex);
        
    }

}

