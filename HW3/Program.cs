/*
 Author: TymoshchukMN

1. Расписание тренировок, используея 1байт
        1.1 Пользователь задает 
        1.2 изменяет расписание
        1.3 видит текущее расписание
        1.4* сбросить расписание (только при вводе пароля)

2. Пользователь вводит нижние и верхние границы, можно вывести кодовую табцу на экран
2*. Пользователь задает колич-во столбцов и количество строк в кажной группе, количество элементов в группе
3. (строки) Пользователь вводит строку произвольной длины, проверить соответствие круглых фигурных и квадратных скобок внутри этой строки
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task 1
            ///<summary>Проверка символа</summary>
            bool CheckSymbol(char symbol)
            {
                if (symbol == '1' || symbol == '2' || symbol == '3' || symbol == '4' ||
                    symbol == '5' || symbol == '6' || symbol == '7' || symbol == '0' ||
                    symbol == '+' || symbol == '0')
                {
                    return true;
                }
                return false;
            }

            ///<summary>Запрос повторного вода символа</summary>
            char RequestNewChar(char symbol)
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\b'{0}'", symbol);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" - wrong symbol, try again: ");
                    symbol = Console.ReadKey().KeyChar;
                    ClearCurrentConsoleLine();
                } while (!CheckSymbol(symbol));
                return symbol;
            }

            ///<summary>возвращаем маску</summary>
            ///<param name="dayNum">номер днгя неели в формате char</param>
            byte GetMask(char dayNum)
            {
                switch (dayNum)
                {
                    case '1':
                        return 0b00000001;
                    case '2':
                        return 0b00000010;
                    case '3':
                        return 0b00000100;
                    case '4':
                        return 0b00001000;
                    case '5':
                        return 0b00010000;
                    case '6':
                        return 0b00100000;
                    case '7':
                        return 0b01000000;
                    default:
                        break;
                }
                return 0b00000000;
            }

            ///<summary>проверка установлен ли бит, указываемый пользователем
            ///если текущее состояние расписания совпадает с тем которое может быть 
            ///установлена с помощью маски, то считаем, чтобит установлен
            /// </summary>
            bool IsBitSetUp(byte checkedSchedule, byte mask)
            {
                if (checkedSchedule == (byte)(checkedSchedule | mask))
                {
                    return true;
                }
                return false;
            }

            ///<summary>отображение желаемого расписания</summary>
            void DisplayPreferedSchedule(byte scheduleForDisplay)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(0, 6);
                Console.WriteLine("Prefered Schedule:\t{0,8}", Convert.ToString(scheduleForDisplay, 2));
                Console.ForegroundColor = ConsoleColor.White;
            }

            ///<summary>отображение действующего расписания</summary>
            void DisplayCurrentSchedule(byte scheduleForDisplay)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Current Schedule:\t{0,8}", Convert.ToString(scheduleForDisplay, 2));
                Console.ForegroundColor = ConsoleColor.White;
            }

            ///<summary>очистка текущей строки</summary>
            void ClearCurrentConsoleLine()
            {
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
            }

            byte preferedSchedule = 0b00000000; // предпочитаемое расписание
            byte currentSchedule = 0b00000000;  // фактическое расписание
            char zero = '0';
            char plus = '+';
            ushort encryptMask = 0x12AD;        // маска для криптования
            string userPass = "";

            ///<summary>создание расписания</summary>
            void CreateSchedule()
            {
                // вывод банера
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("To schedule, press the number corresponding to the day.\nFor example, 1 - Monday, 2 - Tuesday." +
                    "\nTo save the schedule, press '+'" +
                    "\nTo exit edit mode, press '0'");
                DisplayPreferedSchedule(preferedSchedule);
                DisplayCurrentSchedule(currentSchedule);
                Console.SetCursorPosition(0, 7);

                char userInput;
                do
                {
                    userInput = Console.ReadKey().KeyChar;
                    if (CheckSymbol(userInput))
                    {
                        Console.WriteLine("\b{0:8}", Convert.ToString(preferedSchedule, 2));

                        // проверка на наличие бита. Если бит установлен, то убираем его

                        if (IsBitSetUp(preferedSchedule, GetMask(userInput)))
                        {
                            // чтобы убрать бит, преобразовываем маску используя побитовое НЕ
                            // затем побитовое И 00000010 & 11111101
                            preferedSchedule = (byte)(preferedSchedule & ~GetMask(userInput));
                            DisplayPreferedSchedule(preferedSchedule);
                        }
                        else
                        {
                            preferedSchedule = (byte)(preferedSchedule | GetMask(userInput));
                            DisplayPreferedSchedule(preferedSchedule);
                        }
                    }
                    else
                    {
                        userInput = RequestNewChar(userInput);
                        preferedSchedule = (byte)(preferedSchedule | GetMask(userInput));
                        DisplayPreferedSchedule(preferedSchedule);
                    }
                    if (userInput == plus)
                    {
                        // присваеваем желаемое расписание действительному
                        currentSchedule = preferedSchedule;

                        Console.SetCursorPosition(0, 9);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("You printed '+', schedule was saved");
                        Console.ForegroundColor = ConsoleColor.White;
                        DisplayCurrentSchedule(currentSchedule);

                        // установка пароля
                        Console.SetCursorPosition(0, 10);
                        Console.Write("set up password for changing:\t");

                        // запрос у пользователя желаемого пароля для шифрования
                        string tempUserPass = Console.ReadLine();

                        for (ushort i = 0; i < tempUserPass.Length; ++i)
                        {
                            userPass += (char)((ushort)tempUserPass[i] ^ encryptMask);
                        }
                        ClearCurrentConsoleLine();
                        Console.WriteLine("Password was ecrypted:\t{0}\n", userPass);
                    }
                    else
                    {
                        if (userInput == zero)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("You printed '0', schedule changing was declined");
                            Console.ForegroundColor = ConsoleColor.White;
                            DisplayCurrentSchedule(currentSchedule);
                        }
                    }
                } while (userInput != zero && userInput != plus);
            }

            // вывод текущего расписания
            DisplayCurrentSchedule(currentSchedule);

            // отображение предпочитаемого расписания
            DisplayPreferedSchedule(preferedSchedule);

            // создание расписания
            CreateSchedule();

            Console.WriteLine("For reseting pass, press '-', for changing, press '/', or any another symbol for finish");
            ClearCurrentConsoleLine();

            char usersAnswer = Console.ReadKey().KeyChar;

            if (usersAnswer == '-')
            {
                // сброс расписания
                ClearCurrentConsoleLine();
                Console.Write("Input password: ");
                string tempPassword = Console.ReadLine();
                string tempUserPass = "";
                for (int i = 0; i < tempPassword.Length; i++)
                {
                    tempUserPass += (char)((ushort)tempPassword[i] ^ encryptMask);
                }
                if (tempUserPass == userPass)
                {
                    ClearCurrentConsoleLine();
                    // сброс расписания используя побитовые НЕ и И
                    currentSchedule = (byte)(~currentSchedule & currentSchedule);
                    DisplayCurrentSchedule(currentSchedule);
                }
                else
                {
                    Console.WriteLine("Password doesn't mutch... Bye...");
                }
            }
            else
            {
                if (usersAnswer == '/')
                {
                    // изменение расписания
                    Console.Clear();
                    CreateSchedule();
                }
            }

            //Console.ReadKey();
            #endregion task 1

            #region task 2

            #region Task 2 Part 1

            // 2.Пользователь вводит нижние и верхние границы, можно вывести кодовую табцу на экран

            Console.Write("Input start num:\t");
            int.TryParse(Console.ReadLine(), out int startVol);

            Console.Write("Input last num:\t\t");
            int.TryParse(Console.ReadLine(), out int finishVol);

            for (int i = startVol; i <= finishVol; i++)
            {
                Console.WriteLine("Num {0} : {1} \t", i, (char)i);
            }

            #endregion Task 2 Part 1

            #region Task 2 Part 2

            // 2*.Пользователь задает колич-во столбцов и количество строк в кажной группе, количество элементов в группе

            // запрашиваем количество групп
            Console.Write("\nInpunt groupCount:\t\t\t\t");
            int.TryParse(Console.ReadLine(), out int groupCount);

            // запрашиваем количество групп в строке
            Console.Write("Inpunt count groups in string:\t\t\t");
            int.TryParse(Console.ReadLine(), out int groupCountPerString);

            // запрашиваем количество строк в группе
            Console.Write("Inpunt string count in group:\t\t\t");
            int.TryParse(Console.ReadLine(), out int stringCount);

            // запрашиваем количество элементов в строке группы
            Console.Write("Inpunt count of elements in string of gorup:\t");
            int.TryParse(Console.ReadLine(), out int elementCount);

            int charOutPut = startVol;
            ushort leftCursorPosition = 0;
            ushort topCursorPosition = (ushort)(Console.CursorTop + 5);

            // обработка количества групп
            for (int i = 0; i <= groupCount + 1; i++)
            {
                for (int kk = 0; kk < groupCountPerString; kk++)
                {
                    // обработка количества групп в троке
                    if (charOutPut <= finishVol && i <= groupCount)
                    {
                        // обработка количества строк в группе
                        for (int j = 0; j < stringCount; j++)
                        {
                            if (charOutPut <= finishVol)
                            {
                                // обработка элементов в строке
                                for (int k = 0; k < elementCount; k++)
                                {
                                    if (charOutPut <= finishVol)
                                    {
                                        Console.SetCursorPosition(leftCursorPosition + k, topCursorPosition + j);
                                        Console.WriteLine((char)charOutPut);

                                        // увеличиваем счетчик следующего символа в диапазое, введенном пользователем
                                        ++charOutPut;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }

                    // увеличиваем счетчик групп, т.к. она уже нарисована
                    ++i;

                    // смещаем позицию курсора влево на количество элементов в группе + 3, для зазора между колонками 
                    leftCursorPosition += (ushort)(3 + elementCount);
                }
                // обнуляем поцию курсора от левой части, что выводилось с начала строки
                leftCursorPosition = 0;

                // смещаем позицию курсора от верхнй части на количество строк в стобце + 1, для зазора между колонками 
                topCursorPosition += (ushort)(stringCount + 1);
            }

            #endregion Task 2 Part 2



            #endregion task 2

            #region Task 3
            // 3. (строки) Пользователь вводит строку произвольной длины, проверить соответствие круглых фигурных и квадратных скобок внутри этой строки

            Console.Clear();
            Console.WriteLine("Input expression: "); // ())
            string userExpresion = Console.ReadLine();
            string stringToTest = "";

            // убираем все символы кроме скобок
            for (int i = 0; i < userExpresion.Length; i++)
            {
                if (userExpresion[i] == '(' || userExpresion[i] == ')' ||
                    userExpresion[i] == '[' || userExpresion[i] == ']' ||
                    userExpresion[i] == '{' || userExpresion[i] == '}')
                {
                    stringToTest += userExpresion[i];
                }
            }

            short circularBracket = 0;      // счетчик открытых скобок
            short curlyBracket = 0;         // счетчик открытых скобок
            short squareBrachet = 0;        // счетчик квадратных скобок
            bool crossingBracket = false;   // пересечение символов, например (]

            // проверяем первые и последние символы
            if (stringToTest[0] == ')' || stringToTest[stringToTest.Length - 1] == '(' ||
                stringToTest[0] == ']' || stringToTest[stringToTest.Length - 1] == '[' ||
                stringToTest[0] == '}' || stringToTest[stringToTest.Length - 1] == '{')
            {
                Console.WriteLine("Не верно расположены начальные/последние скобки");
            }
            else
            {
                for (int i = 0; i < stringToTest.Length; i++)
                {
                    // проверка круглых скобок
                    // проверка круглых скобок начинается, если счетчик скобок больше или равен 0, а так же, если неи пересечение скобок, например, (}
                    if (stringToTest[i] == '(' && !crossingBracket && circularBracket >= 0 && curlyBracket >= 0)
                    {
                        // увеличиваем счетчик открытых скобок
                        ++circularBracket;

                        if (stringToTest[i + 1] == '}' || stringToTest[i + 1] == ']')
                        {
                            // устанавливаем флаг пересекающихся скобок и прерываем выполнение цикла
                            crossingBracket = true;
                            break;
                        }
                    }
                    else
                    {
                        if (circularBracket < 0)
                        {
                            Console.WriteLine("Закрывающим КРУГЛЫМ скобкам не соотвествуют открывающие");
                            break;
                        }
                        else
                        {
                            if (stringToTest[i] == ')')
                            {
                                // уменьшаем счетчик на количество открытых КРУГЛЫХ скобок
                                --circularBracket;
                            }
                            else
                            {
                                //=============================
                                #region Проверка фигурных скобок

                                if (stringToTest[i] == '{' && !crossingBracket && curlyBracket >= 0)
                                {
                                    // увеличиваем счетчик открытых ФИГУРНЫХ скобок
                                    ++curlyBracket;

                                    if (stringToTest[i + 1] == ')' || stringToTest[i + 1] == ']')
                                    {
                                        // устанавливаем флаг пересекающихся скобок и прерываем выполнение цикла
                                        crossingBracket = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (curlyBracket < 0)
                                    {
                                        Console.WriteLine("Закрывающим ФИГУРНЫМ скобкам не соотвествуют открывающие");
                                        break;
                                    }
                                    else
                                    {
                                        if (stringToTest[i] == '}')
                                        {
                                            // уменьшаем счетчик на количество ФИГУРНЫХ  скобок
                                            --curlyBracket;
                                        }
                                        else
                                        {
                                            if (stringToTest[i] == '[' && !crossingBracket && squareBrachet >= 0)
                                            {
                                                // увеличиваем счетчик открытых ФИГУРНЫХ скобок
                                                ++squareBrachet;

                                                if (stringToTest[i + 1] == ')' || stringToTest[i + 1] == '}')
                                                {
                                                    // устанавливаем флаг пересекающихся скобок и прерываем выполнение цикла
                                                    crossingBracket = true;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if (stringToTest[i] == ']')
                                                {
                                                    // уменьшаем счетчик на количество КВАДРАТНЫХ  скобок
                                                    --squareBrachet;
                                                }
                                                if (squareBrachet < 0)
                                                {
                                                    Console.WriteLine("Закрывающим КВАДРАТНЫМ скобкам не соотвествуют открывающие");
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }

                                #endregion Проверка фигурных скобок

                            }
                        }
                    }
                }

                // уведомления на основе обработки
                if (crossingBracket)
                {
                    Console.WriteLine("Не верно выбран тип закрывающей или открывающей скобки ");
                }
                else
                {
                    if (circularBracket > 0)
                    {
                        Console.WriteLine("Не хватает закрывающих КРУГЛЫХ скобок");
                    }
                    else
                    {
                        if (circularBracket < 0)
                        {
                            Console.WriteLine("Не хватает открывающих КРУГЛЫХ скобок");
                        }
                        else
                        {
                            if (curlyBracket > 0)
                            {
                                Console.WriteLine("Не хватает закрывающих ФИГУРНЫХ скобок");
                            }
                            else
                            {
                                if (curlyBracket < 0)
                                {
                                    Console.WriteLine("Не хватает открывающих ФИГУРНЫХ скобок");
                                }
                                else
                                {
                                    if (squareBrachet > 0)
                                    {
                                        Console.WriteLine("Не хватает закрывающих КВАДРАТНЫХ скобок");
                                    }
                                    else
                                    {
                                        if (squareBrachet < 0)
                                        {
                                            Console.WriteLine("Не хватает открывающих КВАДРАТНЫХ скобок");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Выражение составлено верно");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            #endregion Task 3
            Console.ReadKey();
        }
    }
}
