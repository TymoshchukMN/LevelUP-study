////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 17/11/2022
// Last Modified On : 
// Description: User interface
// Project: HW_11
////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11
{
    internal class UI
    {
        public static string board = new string('=', 50);
        public static void PrintErrorAddingStudent(ResultCodes resultCode)
        {
            Console.Write($"Студент не добавлен, ошибка:\t");

            ChangeColor(ConsoleColor.Red, resultCode.ToString());
        }

        /// <summary>
        /// Изменение печатаемого текста
        /// </summary>
        /// <param name="preferedColor">
        /// желаемы цвет текста
        /// </param>
        /// <param name="text">
        /// текст для печати
        /// </param>
        public static void ChangeColor(ConsoleColor preferedColor, string text)
        {
            ConsoleColor defColor = Console.ForegroundColor;

            Console.ForegroundColor = preferedColor;

            Console.Write(text);

            Console.ForegroundColor = defColor;
        }

        /// <summary>
        /// Печать сообщения об успешном создании и заполнении групп
        /// </summary>
        /// <param name="countGroups">
        /// количество групп
        /// </param>
        public static void PrintSuccessFilling(ushort countGroups)
        {
               
            Console.WriteLine("Cозданы и заполнены группы:\n");

            for (ushort i = 0; i < countGroups; i++)
            {

                ChangeColor(ConsoleColor.Green, ((GroupNames)i).ToString());
                Console.WriteLine();
            }
            Console.WriteLine("\n{0}\n",board);
        }

        /// <summary>
        /// печать ошибки заполнения группы
        /// </summary>
        public static void PintErrorFilleng()
        {
            Console.WriteLine("Группы не заполнены!!!!!!");
        }

        /// <summary>
        /// Изменение высоты консоли, чтобы все помещалось
        /// </summary>
        public static void ChangeConsoleHeight()
        {
            const ushort CONSOLE_HEIGHT = 50;
            Console.WindowHeight = CONSOLE_HEIGHT;
        }

        /// <summary>
        /// Печать групп студентов
        /// </summary>
        public static void PrintRequestGroups(StudentGroups[] groups)
        {
            for (ushort i = 0; i < groups.Count(); ++i)
            {
                Console.WriteLine($"{i+1}.\t{groups[i].groupName}");
            }

            Console.Write("\nУкажите название группы группу:\t");
        }

        /// <summary>
        /// ошибка выбранной группы
        /// </summary>
        public static void PrintErrorExistingGroup(string selectedGroup)
        {
            Console.WriteLine();
            Console.Write("Группы ");
            ChangeColor(ConsoleColor.DarkYellow, selectedGroup);
            Console.WriteLine(" - не существует, выберите группу из имеющихся:\n");
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
        /// Запрос данных студента для добавления
        /// </summary>
        public static void PrintRequestDataForNewStudent()
        {
            Console.WriteLine("Введите данные студента:\n");
        }

        /// <summary>
        /// Запрос first name пользователя
        /// </summary>
        public static void PrintRequestFirstName()
        {
            Console.Write("Имя:\t");
        }

        /// <summary>
        /// Запрос middle name пользователя
        /// </summary>
        public static void PrintRequestmiddleName()
        {
            Console.Write("Отчество:\t");
        }

        /// <summary>
        /// Запрос last name пользователя
        /// </summary>
        public static void PrintRequestLastName()
        {
            Console.Write("Фамилия:\t");
        }

        /// <summary>
        /// Запрос адреса прописки
        /// </summary>
        public static void PrintRequestAddresssRegistration()
        {
            Console.Write("Адрес прописки:\t");
        }

        /// <summary>
        /// Запрос адреса проживания
        /// </summary>
        public static void PrintRequestAddresssResidential()
        {
            Console.Write("Адрес проживания:\t");
        }

        /// <summary>
        /// печать запроса на ввод номера зачетки
        /// </summary>
        public static void PrintRequestRecordBooh()
        {
            const string RB_FORMAT = "XX000000";

            Console.Write("Введите номер зачетки в формате: ");
            ChangeColor(ConsoleColor.DarkYellow, RB_FORMAT);
            Console.WriteLine("\n\n");
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
            ChangeColor(ConsoleColor.Red, recordBook);
            Console.WriteLine(" record book isn't correct. Try one more time:\t");
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

        public static void PrintSuccess()
        {
            const string SUCCESS_MESSAGE = "Operation saccesfull";

            ChangeColor(ConsoleColor.Green, SUCCESS_MESSAGE);
            Console.WriteLine();
        }

        public static void PrintErrorAddingStudent()
        {
            Console.WriteLine("Группа переполнена, добавление не возможно");
        }

        /// <summary>
        /// Печать ошибке о не верном имени
        /// </summary>
        /// <param name="name"></param>
        public static void PrintWrongInput(string name)
        {
            ChangeColor(ConsoleColor.DarkYellow, name);
            Console.WriteLine(" - wrong input, Try again:\t");
        }

        /// <summary>
        /// Печать ошибки, что учетка уже есть
        /// </summary>
        /// <param name="RB">
        /// номер учетки
        /// </param>
        public static void PrintErrorRBExist(string RB)
        {
            Console.Write("Учетка с номером ");
            ChangeColor(ConsoleColor.Yellow, RB);
            Console.WriteLine(" уже есть");
        }

        /// <summary>
        /// Печать ошибки. номер УЗ не существует
        /// </summary>
        /// <param name="RB"></param>
        public static void PrintErrorRBNotExist(string RB)
        {
            Console.Write("Учетки с номером ");
            ChangeColor(ConsoleColor.Yellow, RB);
            Console.WriteLine(" не существует в выбранной группе. Попробуйте еще раз");
        }

        /// <summary>
        /// Печать запроса поля к изменению
        /// </summary>
        public static void PrintRequestFieldForChange()
        {
            Console.WriteLine("Поле для изменения:\n");
            ushort countFields = (ushort)Enum.GetNames(typeof(FieldForChange)).Length;
            const ushort STEP_FOR_NUM_DIGIT_SYMBOL = 96;

            for (int i = 97; i < countFields + STEP_FOR_NUM_DIGIT_SYMBOL; i++)
            {
                Console.WriteLine("{0}. {1}", i - STEP_FOR_NUM_DIGIT_SYMBOL, (FieldForChange)i);
            }
        }

        public static void PrintErrorChoosingField()
        {
            Console.WriteLine("Не верно выбрано поле, попробуйте еще раз:");
        }

        /// <summary>
        /// запрос нового значения для поля карточки студента
        /// </summary>
        public static void RequestNewVol()
        {
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
        /// перчать доступных групп к перемещению
        /// </summary>
        /// <param name="selectedGroup">
        /// группа из которой выполняется перемещение
        /// </param>
        public static void PrintAvailabledGroupForMoving(GroupNames selectedGroup)
        {
            ushort countGroups = (ushort)Enum.GetNames(typeof(GroupNames)).Length;

            Console.WriteLine("\nВыбериете группу для перемещения:\n");

            for (int i = 0; i < countGroups; i++)
            {
                if (selectedGroup != (GroupNames)i)
                {
                    Console.WriteLine("{0}", (GroupNames)i);
                }
            }
        }

        /// <summary>
        /// Печать что делать посте круд
        /// </summary>
        public static void PrintWhatToDoNext()
        {
            const string STR_FOR_PRINT = "\nДля выхода нажмите \"Esc\", " +
                "для продолжения нажмит любую клавишу";
            UI.ChangeColor(ConsoleColor.DarkCyan, STR_FOR_PRINT);
        }

        
    }
}
