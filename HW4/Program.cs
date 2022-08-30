/*
    Author: TymoshchukMN 
 
    1. Найти мин и максимум для N-чисел (произвольного количества). Делайть используя while, do while, for
    2. Посмотреть Enumы FLAGS 
    3. Массивы
    4. Придумать любое перечисление из реальной жизни. Сделать ввод, валидацияю, свитч, вывод на экран.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace HW4
{
    internal class Program
    {
        /// <summary>
        /// Первое задание (поиск максимума используя циклы do, do while, for)
        /// </summary>
        private static void ExecTask1()
        {
            // 1.Найти мин и максимум для N - чисел(произвольного количества).Делайть используя while, do while, for

            // запрашиваем количество 
            Console.Write("Input count of numbers: ");

            // запрос количества чисел, которое будет вводить пользователь
            ushort.TryParse(Console.ReadLine(), out ushort countNumbers);

            // временный счетчик для наполнения массива
            ushort tmpCounter = 0;

            // массив чисел, введенных пользователем
            double[] numbers = new double[countNumbers];

            // запрос ввода чисел
            Console.WriteLine("Input numbers: ");

            // наполнение массива чисел. Без него ни как, т.к. необходим итерируемый объект для сравнения
            do
            {
                double.TryParse(Console.ReadLine(), out double tmp);
                numbers[tmpCounter] = tmp;

                ++tmpCounter;
            } while (tmpCounter < countNumbers);

            #region while

            // параметры разделителя
            string separatorLine = new string('*', 40);
            ConsoleColor defaultColor = ConsoleColor.Gray;
            ConsoleColor separatorLineColor = ConsoleColor.Cyan;

            // рисуем разделитель 
            Console.ForegroundColor = separatorLineColor;
            Console.WriteLine(separatorLine);
            Console.ForegroundColor = defaultColor;

            // переменная для итерации вне цикла for
            tmpCounter = 0;

            // присваеваем переменной max и min начальные значения. 
            double max = numbers[tmpCounter];
            double min = numbers[tmpCounter];

            // использование цикла while для сравнения
            // в условии используем прекремент, т.к. переменной max уже присвоенно значение нулевого элемента массива,
            // а так же используется для увеличения счетчика и предварительной проверке в условии while
            while (++tmpCounter < numbers.Count())
            {
                if (max < numbers[tmpCounter])
                {
                    max = numbers[tmpCounter];
                }
                if (min > numbers[tmpCounter])
                {
                    min = numbers[tmpCounter];
                }
            }

            Console.WriteLine("while max = {0}", max);
            Console.WriteLine("while min = {0}", min);

            #endregion while

            #region do while

            // рисуем разделитель 
            Console.ForegroundColor = separatorLineColor;
            Console.WriteLine(separatorLine);
            Console.ForegroundColor = defaultColor;

            // обнуляем переменную для итерации
            tmpCounter = 0;

            // присваеваем переменной max начальное значение.
            max = numbers[tmpCounter];
            do
            {
                // проверка максимума
                if (max < numbers[tmpCounter + 1])
                {
                    max = numbers[tmpCounter + 1];
                }

                // проверка минимума
                if (min > numbers[tmpCounter + 1])
                {
                    min = numbers[tmpCounter + 1];
                }

                ++tmpCounter;

            } while (tmpCounter < numbers.Count() - 1);

            Console.WriteLine("do while max = {0}", max);
            Console.WriteLine("do while min = {0}", min);
            #endregion do while

            #region for

            // рисуем разделитель 
            Console.ForegroundColor = separatorLineColor;
            Console.WriteLine(separatorLine);
            Console.ForegroundColor = defaultColor;

            max = numbers[0];

            for (int i = 0; i < numbers.Count() - 1; i++)
            {
                // проверка максимума
                if (max < numbers[i + 1])
                {
                    max = numbers[i + 1];
                }

                // проверка минимума
                if (min > numbers[i + 1])
                {
                    min = numbers[i + 1];
                }
            }

            Console.WriteLine("for max = {0}", max);
            Console.WriteLine("for min = {0}", min);

            #endregion for

            Console.ReadKey();
        }

        /// <summary>
        /// "второе" задание, использование enum
        /// </summary>
        private static void ExecTask2()
        {
            // Придумать любое перечисление из реальной жизни. Сделать ввод, валидацияю, свитч, вывод на экран.
            // Выбрать страну и валюту для оплаты билета

            Console.WriteLine("Type country, which you want to visit:\n" +
                "\n1. USA" +
                "\n2. France" +
                "\n3. Italy" +
                "\n4. Greece" +
                "\n5. Poland");

            // TODO: как в enum использовать текст? т.е. не запрашивать у пользователя цифру. а текст

            int country = int.Parse(Console.ReadLine());

            ConsoleColor curencyColor = ConsoleColor.Yellow;
            ConsoleColor defaultColor = ConsoleColor.Gray;

            // проверяем страну в Enum. На основании выбранной страны,
            // используя CountriesList отображаем валюту, которую нужно купить
            switch ((CountriesList)country)
            {
                case CountriesList.USA:

                    Console.WriteLine("Country:\t{0}", (CountriesList)country);
                    Console.Write("You have to buy ");
                    Console.ForegroundColor = curencyColor;

                    // вывод на экран валюты выбранной страны
                    Console.WriteLine((CurencyList)(CountriesList)country);
                    Console.ForegroundColor = defaultColor;

                    break;
                case CountriesList.France:

                    Console.WriteLine("Country:\t{0}", (CountriesList)country);
                    Console.Write("You have to buy ");
                    Console.ForegroundColor = curencyColor;

                    // вывод на экран валюты выбранной страны
                    Console.WriteLine((CurencyList)(CountriesList)country);
                    Console.ForegroundColor = defaultColor;

                    break;
                case CountriesList.Italy:

                    Console.WriteLine("Country:\t{0}", (CountriesList)country);
                    Console.Write("You have to buy ");
                    Console.ForegroundColor = curencyColor;

                    // вывод на экран валюты выбранной страны
                    Console.WriteLine((CurencyList)(CountriesList)country);
                    Console.ForegroundColor = defaultColor;

                    break;
                case CountriesList.Greece:

                    Console.WriteLine("Country:\t{0}", (CountriesList)country);
                    Console.Write("You have to buy ");
                    Console.ForegroundColor = curencyColor;

                    // вывод на экран валюты выбранной страны
                    Console.WriteLine((CurencyList)(CountriesList)country);
                    Console.ForegroundColor = defaultColor;

                    break;
                case CountriesList.Poland:

                    Console.WriteLine("Country:\t{0}", (CountriesList)country);
                    Console.Write("You have to buy ");
                    Console.ForegroundColor = curencyColor;

                    // вывод на экран валюты выбранной страны
                    Console.WriteLine((CurencyList)(CountriesList)country);
                    Console.ForegroundColor = defaultColor;

                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }

        }
        //TODO: использование switch для сравнения целочисленных значений?
        static void Main(string[] args)
        {
            Console.WriteLine("Choose task for launching:\n\n" +
                              "1. Find min/max using cycles\n" +
                              "2. Using Enums\n");
            Console.Write("Task for launching:\t");

            int.TryParse(Console.ReadLine(), out int taskNum);

            // параметры строки разделителя
            string separatorLine = new string('*', 40);
            ConsoleColor defaultColor = ConsoleColor.Gray;
            ConsoleColor separatorLineColor = ConsoleColor.Cyan;

            // рисуем разделитель 
            Console.ForegroundColor = separatorLineColor;
            Console.WriteLine(separatorLine);
            Console.ForegroundColor = defaultColor;

            // выбор задачи для запуска
            switch ((TasksList)taskNum)
            {
                case TasksList.task1:

                    // вызов первой задачи
                    ExecTask1();

                    break;
                case TasksList.task2:

                    // вызов второй задачи
                    ExecTask2();

                    break;
                default:

                    Console.WriteLine("Choosen task doesn't exist");
                    break;
            }
            Console.ReadKey();

        }


    }
}
