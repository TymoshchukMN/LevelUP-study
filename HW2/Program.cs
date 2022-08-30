/*
 Author: TymoshchukMN
  
д/з 
    1. Пользователь вводит 5 чисел (любых). Нужно найти минимально и максимальное числа среди введенных
        1.2 Найти позицию минимального и максимального
        1.3 минимизировать количество сравнений
    2. Пользователь вводит целое число. Нужно определить, что число одноразрядное, 2-х разрядное или 3-х разрядное
    3. Польлзователь вводит название дня недели, нужно вывести порядновый номер, который соотвествует этому дню
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///<summary>
            ///проверка является ли введенное значение числом
            /// </summary>
            /// <param name="checkedStr">строка для проверки</param>
            bool CheckIsDigit(string checkedStr)
            {
                return int.TryParse(checkedStr, out _) || double.TryParse(checkedStr, out _);
            }

            ///<summary>Повторный запрос ввода числа</summary>
            ///<param name="usrString">строка, вводимая поьлзователем</param>
            string RepeatedRequestNumber(string usrString)
            {
                do
                {
                    Console.Write("'{0}'", usrString);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" - it isn't number", usrString);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Input number one more time: ");
                    usrString = Console.ReadLine();
                    CheckIsDigit(usrString);
                } while (!CheckIsDigit(usrString));
                return usrString;
            }

            ///<summary>получаем тип данных значения, указанного в строке</summary>
            string GetTypeString(string usrString)
            {
                if (int.TryParse(usrString, out _))
                {
                    //int.TryParse(usrString, out int intNum);
                    return "int";
                }
                else
                {
                    //double.TryParse(usrString, out double doubleNum);
                    return "double";
                }
            }

            ///<summary>получем целое число из введенной, пользователем строки</summary>
            int getIntNumFromString(string usrString)
            {
                int.TryParse(usrString, out int intNum);
                return intNum;
            }

            ///<summary>получем вещественно число из введенной, пользователем строки</summary>
            double GetDoubleNumFromString(string usrString)
            {
                double.TryParse(usrString, out double doubleNum);
                return doubleNum;
            }
            
            ///<summary>определения разрядности инта</summary>
            ///<param name="intNum">целочисленное число для определения разрядности</param>
            void GetIntDigit(int intNum)
            {
                if (intNum < 10)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("'{0}' - ", intNum);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("single digit");
                }
                else
                {
                    if (intNum < 100)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("'{0}' - ", intNum);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("two - digit");
                    }
                    else
                    {
                        if (intNum < 1000)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("'{0}' - ", intNum);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("three-digit");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("'{0}' - ", intNum);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("another digit");
                        }
                    }
                }
            }

            ///<summary>определение разрядности дабла</summary>
            void GetDoubleDigit(double doubleNum)
            {
                const double eps = 0.0001;
                if (Math.Abs(10.0 - doubleNum) < eps || doubleNum < 10.0f)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("single digit");
                }
                else
                {
                    if (Math.Abs(100 - doubleNum) < eps || doubleNum < 100.0f)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("'{0}' - ", doubleNum);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("two - digit");
                    }
                    else
                    {
                        if (Math.Abs(1000 - doubleNum) < eps || doubleNum < 1000)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("'{0}' - ", doubleNum);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("three-digit");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("'{0}' - ", doubleNum);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("another digit");
                        }
                    }
                }
            }
            


            #region Task 1
            /*
                1.Пользователь вводит 5 чисел(любых).Нужно найти минимально и максимальное числа среди введенных
                1.2 Найти позицию минимального и максимального
                1.3 минимизировать количество сравнений
            */

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String('=', 25));
            Console.WriteLine("\n        Task1\n");
            Console.WriteLine(new String('=', 25));
            Console.ForegroundColor = ConsoleColor.White;

            // запрос первого значения
            Console.Write("\nInput first Num: ");
            string firtsInput = Console.ReadLine();

            // проверяем является ли введенное значение 
            if (!CheckIsDigit(firtsInput))
            {
                firtsInput = RepeatedRequestNumber(firtsInput);
            }

            // получаем значение первого числа из строки
            double num1 = GetDoubleNumFromString(firtsInput);

            // запрос второго значения
            Console.Write("Input second Num: ");
            string secondInput = Console.ReadLine();

            // проверяем является ли введенное значение 
            if (!CheckIsDigit(secondInput))
            {
                secondInput = RepeatedRequestNumber(secondInput);
            }

            // получаем значение второго числа из строки
            double num2 = GetDoubleNumFromString(secondInput);

            //// запрос третьего значения
            Console.Write("Input third Num: ");
            string thirdInput = Console.ReadLine();

            // проверяем является ли введенное значение 
            if (!CheckIsDigit(thirdInput))
            {
                thirdInput = RepeatedRequestNumber(thirdInput);
            }

            // получаем значение третьего числа из строки
            double num3 = GetDoubleNumFromString(thirdInput);

            // запрос четвертого значения
            Console.Write("Input fourth Num: ");
            string fourthInput = Console.ReadLine();

            // проверяем является ли введенное значение 
            if (!CheckIsDigit(fourthInput))
            {
                fourthInput = RepeatedRequestNumber(fourthInput);
            }

            // получаем значение четвертого числа из строки
            double num4 = GetDoubleNumFromString(fourthInput);

            // запрос пятого значения
            Console.Write("Input fifth Num: ");
            string fifthInput = Console.ReadLine();

            // проверяем является ли введенное значение 
            if (!CheckIsDigit(fifthInput))
            {
                fifthInput = RepeatedRequestNumber(fifthInput);
            }

            // получаем значение пятого числа из строки
            double num5 = GetDoubleNumFromString(fifthInput);

            // первый eps используется в функции "GetDoubleDigit"
            const double eps2 = 0.0001;

            #region maxVol

            double max = num1;
            ushort positionMaxVol = 1;     // позиция максимального элемента

            if ((max - num2) < eps2)
            {
                max = num2;
                positionMaxVol = 2;
            }
            if ((max - num3) < eps2)
            {
                max = num3;
                positionMaxVol = 3;
            }
            if ((max - num4) < eps2)
            {
                max = num4;
                positionMaxVol = 4;
            }
            if ((max - num5) < eps2)
            {
                max = num5;
                positionMaxVol = 5;
            }

            #endregion maxVol

            #region minVol

            double min = max;
            ushort positionMinVol = 1;     // позиция минимального элемента

            if ((min - num2) > eps2)
            {
                min = num2;
                positionMinVol = 2;
            }
            if ((min - num3) > eps2)
            {
                min = num3;
                positionMinVol = 3;
            }
            if ((min - num4) > eps2)
            {
                min = num4;
                positionMinVol = 4;
            }
            if ((min - num5) > eps2)
            {
                min = num5;
                positionMinVol = 5;
                Console.WriteLine("num4 < min {0} < {1} ", num4, num5);
            }

            #endregion minVol

            // итоги первой таски:
            Console.WriteLine("\nMax vol = {0}, position = {1}", max, positionMaxVol);
            Console.WriteLine("Min vol = {0}, position = {1}\n", min, positionMinVol);
            #endregion Task 1 

            #region Task 2
            /*
             Пользователь вводит целое число. Нужно определить, что число одноразрядное, 2-х разрядное или 3-х разрядное

             1. Проверка является ли значение числом
             2. Определяем тип данных числа
             3. Получаем число
             4. Определяем разрядность основываясь на типе данных
            */
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String('=', 25));
            Console.WriteLine("\n        Task2\n");
            Console.WriteLine(new String('=', 25));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nInput number: ");
            string strUserNumber = Console.ReadLine();

            // проверка является ли ввиденное значение числом
            bool isNumber = CheckIsDigit(strUserNumber);

            if (isNumber)
            {
                // проверка типа int или double
                if (GetTypeString(strUserNumber) == "int")
                {
                    // получение целого числа из строки
                    int userNumber = getIntNumFromString(strUserNumber);

                    // получение разрядности инта
                    GetIntDigit(userNumber);
                }
                else
                {
                    // получение вещественного числа из строки
                    double userNumber = GetDoubleNumFromString(strUserNumber);

                    // получение разрядности дабла
                    GetDoubleDigit(userNumber);
                }
            }
            else
            {
                // вызов функции на поврорный запрос ввода числа
                strUserNumber = RepeatedRequestNumber(strUserNumber);

                // проверка типа int или double
                if (GetTypeString(strUserNumber) == "int")
                {
                    // получение целого числа из строки
                    int userNumber = getIntNumFromString(strUserNumber);

                    // получение разрядности
                    GetIntDigit(userNumber);
                }
                else
                {
                    // получение вещественного числа из строки
                    double userNumber = GetDoubleNumFromString(strUserNumber);

                    // получение разрядности дабла
                    GetDoubleDigit(userNumber);
                }
            }
            #endregion Task 2

            #region Task 3
            //3.Польлзователь вводит название дня недели, нужно вывести порядновый номер, который соотвествует этому дню

            ///<summary>проверка введеннго дня</summary>
            bool checkIsDayOfWeeak(string dayName)
            {
                // возвращаем тру, если день введен корректно
                return ((dayName == "monday") || (dayName == "tuesday") || (dayName == "wednesday") || (dayName == "thursday")
                    || (dayName == "friday") || (dayName == "saturday") || (dayName == "sunday"));

            }

            ///<summary>запрос повторного ввода дня недели</summary>
            string RepeatedRequestDayOfWeek(string dayName)
            {
                if (!checkIsDayOfWeeak(dayName))
                {
                    do
                    {
                        Console.Write("'{0}'", dayName);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" - it isn't day of week", dayName);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Input day one more time: ");
                        dayName = Console.ReadLine();
                        CheckIsDigit(dayName);
                    } while (!checkIsDayOfWeeak(dayName));
                }
                return dayName;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String('=', 25));
            Console.WriteLine("\n        Task3\n");
            Console.WriteLine(new String('=', 25));
            Console.ForegroundColor = ConsoleColor.White;


            // запрос для недели
            Console.Write("Input day of week, for example, monday:\t");
            string dayOfWeek = Console.ReadLine().ToLower();

            // проверяем корректно ли введен день недели
            if (!checkIsDayOfWeeak(dayOfWeek))
            {
                // повторный запрос дня недели, т.к. ввденное значение не соотвествует условию
                dayOfWeek = RepeatedRequestDayOfWeek(dayOfWeek);
            }

            // прямолинейное сравнение. Лучше бы switch
            if (dayOfWeek == "monday")
            {
                Console.WriteLine("Day 1");
            }
            else if (dayOfWeek == "tuesday")
            {
                Console.WriteLine("Day 2");
            }
            else if (dayOfWeek == "wednesday")
            {
                Console.WriteLine("Day 3");
            }
            else if (dayOfWeek == "thursday")
            {
                Console.WriteLine("Day 4");
            }
            else if (dayOfWeek == "friday")
            {
                Console.WriteLine("Day 5");
            }
            else if (dayOfWeek == "saturday")
            {
                Console.WriteLine("Day 6");
            }
            else if (dayOfWeek == "sunday")
            {
                Console.WriteLine("Day 7");
            }
            Console.ReadKey();
            #endregion Task 3
        }
    }
}