////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 25/10/2022
// Last Modified On : 
// Description: UI functions
// Project: HW_10
////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10
{
    /// <summary>
    /// User interface class
    /// </summary>
    internal class UI
    {
        /// <summary>
        /// Изменение высоты консоли, чтобы все помещалось
        /// </summary>
        public static void ChangeConsoleHeight()
        {
            const ushort CONSOLE_HEIGHT = 50;
            Console.WindowHeight = CONSOLE_HEIGHT;
        }

        /// <summary>
        /// Банер доступный групп, на основе Enum GroupNames
        /// </summary>
        public static void PrintRequestGroup()
        {
            Console.WriteLine("Выберите группу:");

            ushort countGroups = (ushort)Enum.GetNames(typeof(GroupNames)).Length;

            for (ushort i = 0; i < countGroups; ++i)
            {
                Console.Write($"\n{i + 1}. {(GroupNames)i}");
            }
        }

        /// <summary>
        /// запрос на выбор операции
        /// </summary>
        public static void PrintRequestCRUD()
        {
            Console.WriteLine("Выберите операцию");

            ushort countCRUD = (ushort)(Enum.GetNames(typeof(CRUD)).Length - 1);

            const ushort FIRST_CHAR_NUM_IN_CRUD_ENUM = 97;

            for (ushort i = 0; i < countCRUD; ++i)
            {
                Console.Write($"\n{i + 1}. {(CRUD)FIRST_CHAR_NUM_IN_CRUD_ENUM + i}");
            }
        }

        /// <summary>
        /// Печать ошибки выбора группы
        /// </summary>
        public static void PrintErrorSelectedGroup()
        {
            Console.Clear();
            Console.WriteLine("Selected group doesn't exist, select another");
            PrintRequestGroup();
            Console.WriteLine();

        }

        /// <summary>
        /// Печать строки другим цветом
        /// </summary>
        /// <param name="strForPrint"></param>
        public static void PrintStritgOtherColor(string strForPrint,
                ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(strForPrint);
            Console.ForegroundColor = defaultColor;
        }

        /// <summary>
        /// Печать что делать посте круд
        /// </summary>
        public static void PrintWhatToDoNext()
        {
            const string strForPrint = "\nFor exit press \"Esc\", for continue, press any key";
            PrintStritgOtherColor(strForPrint, ConsoleColor.DarkCyan);
        }

        /// <summary>
        /// печать запроса на ввод номера зачетки
        /// </summary>
        public static void PrintRequestRecordBooh()
        {
            const string RB_FORMAT = "XX000000";

            Console.Write("Введите номер зачетки в формате: ");
            PrintStritgOtherColor(RB_FORMAT, ConsoleColor.DarkYellow);
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Печать ошибки о неверном номере зачетки
        /// </summary>
        /// <param name="recordBook">
        /// введенный номер зачетки
        /// </param>
        public static void PrintErrorRBWrong(string recordBook)
        {
            ClearPreviousConsoleLine();
            PrintStritgOtherColor(recordBook, ConsoleColor.Red);
            Console.WriteLine(" record book isn't correct. Try one more time:\t");
        }

        /// <summary>
        /// Печать ошибки, УЗ не существует
        /// </summary>
        /// <param name="recordBook">
        /// введенный номер зачетки
        /// </param>
        public static void PrintErrorRBnotExist(string recordBook)
        {
            ClearPreviousConsoleLine();
            PrintStritgOtherColor(recordBook, ConsoleColor.Red);
            Console.WriteLine(" record book NOT EXIST. Try one more time:\t");
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        /// <summary>
        /// удаленеи перыдущей строки
        /// </summary>
        public static void ClearPreviousConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        /// <summary>
        /// Запрос данных студента для добавления
        /// </summary>
        public static void PrintRequestDataForNewStudent()
        {
            Console.WriteLine("Input studenst data:\n");
        }

        /// <summary>
        /// Запрос first name пользователя
        /// </summary>
        public static void PrintRequestFirstName()
        {
            Console.Write("first name:\t");
        }

        /// <summary>
        /// Запрос middle name пользователя
        /// </summary>
        public static void PrintRequestmiddleName()
        {
            Console.Write("middle name:\t");
        }

        /// <summary>
        /// Запрос last name пользователя
        /// </summary>
        public static void PrintRequestLastName()
        {
            Console.Write("last name:\t");
        }

        /// <summary>
        /// Запрос phoneNumber пользователя
        /// </summary>
        public static void PrintRequestPhoneNumber()
        {            
            Console.Write("phoneNumber:\t");
        }

        /// <summary>
        /// Запрос address пользователя
        /// </summary>
        public static void PrintRequestAddress()
        {
            Console.Write("address:\t");
        }

        /// <summary>
        /// Запрос email пользователя
        /// </summary>
        public static void PrintRequestEmail()
        {
            Console.Write("email:\t\t");
        }

        /// <summary>
        /// Печать ошибке о не верном имени
        /// </summary>
        /// <param name="name"></param>
        public static void PrintWrongInput(string name)
        {
            PrintStritgOtherColor(name, ConsoleColor.DarkYellow);
            Console.WriteLine(" - wrong input, Try again:\t");
        }

        public static void PrintSuccess()
        {
            const string SUCCESS_MESSAGE = "Operation saccesfull";

            PrintStritgOtherColor(SUCCESS_MESSAGE,ConsoleColor.Green);
        }

        /// <summary>
        /// Печать запроса поля к изменению
        /// </summary>
        public static void PrintRequestFieldForChange()
        {
            Console.WriteLine("Fields for change:\n");
            ushort countFields = (ushort)Enum.GetNames(typeof(FieldForChange)).Length;
            const ushort STEP_FOR_NUM_DIGIT_SYMBOL = 96;

            for (int i = 97; i < countFields + STEP_FOR_NUM_DIGIT_SYMBOL; i++)
            {
                Console.WriteLine("{0}. {1}",i - STEP_FOR_NUM_DIGIT_SYMBOL, (FieldForChange)i);
            }           
        }

        public static void PrintErrorChoosingField()
        {
            Console.WriteLine("Wrong field. Try one more time:");
        }

        public static void PrintErrorAddingStudent()
        {
            Console.WriteLine("Группа переполнена, добавление не возможно");
        }
        /// <summary>
        /// запрос нового значения для поля карточки студента
        /// </summary>
        public static void RequestNewVol()
        {
            ClearCurrentConsoleLine();
            Console.WriteLine("\nВведите новое значение:\t");
        }

        /// <summary>
        /// Печать Оповещение об успешной операции
        /// </summary>
        public static void PrintSucess()
        {
            Console.WriteLine("Операция выполнена успешно");
        }

        public static void PrintError()
        {
            Console.WriteLine("Ошибка, в операции!!!!");
        }

        /// <summary>
        /// Запрос зачетки студента для удаления
        /// </summary>
        public static void PrintRequestRBForDelete()
        {
            Console.WriteLine("Укажите номер зачетки студента для удаления");
        }
    
    }

}
