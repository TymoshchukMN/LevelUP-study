using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Пользовательские функции 
/// </summary>

internal class CustomFunctions
{
    /// <summary>
    /// Запрос повторного вода символа
    /// </summary>
    /// 
    public static char RequestNewChar(char symbol)
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

    /// <summary>
    /// Проверка символа
    /// </summary>
    public static bool CheckSymbol(char symbol)
    {
        if (symbol == '1' || symbol == '2' || symbol == '3' || symbol == '4' ||
            symbol == '5' || symbol == '6' || symbol == '7' || symbol == '0' ||
            symbol == '+' || symbol == '0')
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// возвращаем маску
    /// </summary>
    /// <param name="dayNum">
    /// номер дня недели в формате char
    /// </param>
    public static byte GetMask(char dayNum)
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

    /// <summary>проверка установлен ли бит, указываемый пользователем
    /// если текущее состояние расписания совпадает с тем которое может быть 
    /// установлена с помощью маски, то считаем, чтобит установлен
    /// </summary>
    public static bool IsBitSetUp(byte checkedSchedule, byte mask)
    {
        if (checkedSchedule == (byte)(checkedSchedule | mask))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// отображение желаемого расписания
    /// </summary>
    public static void DisplayPreferedSchedule(byte scheduleForDisplay)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(0, 6);
        Console.WriteLine("Prefered Schedule:\t{0,8}", Convert.ToString(scheduleForDisplay, 2));
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// отображение действующего расписания
    /// </summary>
    public static void DisplayCurrentSchedule(byte scheduleForDisplay)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(0, 5);
        Console.WriteLine("Current Schedule:\t{0,8}", Convert.ToString(scheduleForDisplay, 2));
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// очистка текущей строки
    /// </summary>
    public static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

    public static void CreateSchedule(ref byte preferedSchedule, ref byte currentSchedule, char zero, char plus)
    {
        // вывод банера
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.SetCursorPosition(0, 0);
        Console.Write("To schedule, press the number corresponding to the day.\nFor example, ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("1");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" - Monday, ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("2");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" - Tuesday. etc" +
            "\nTo save the schedule, press:\t");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("+\n");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("To exit edit mode, press:\t");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("0");
        Console.ForegroundColor = ConsoleColor.Gray;

        DisplayPreferedSchedule(preferedSchedule);
        DisplayCurrentSchedule(currentSchedule);
        Console.SetCursorPosition(0, 7);

        // инициализация переменной для дальнейшего использования в цикле
        char userInput;
        do
        {
            userInput = Console.ReadKey().KeyChar;
            ClearCurrentConsoleLine();
            if (CheckSymbol(userInput))
            {
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

}

