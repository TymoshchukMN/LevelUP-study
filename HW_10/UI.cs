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
        /// Банер доступный групп, на основе Enum GroupNames
        /// </summary>
        public static void PrintRequestGroup()
        {
            Console.WriteLine("Выберите группу:");

            ushort countGroups = (ushort)Enum.GetNames(typeof(GroupNames)).Length;
            
            for (ushort i = 0; i < countGroups; ++i)
            {
                Console.Write($"\n{i+1}. {(GroupNames)i}");
            }           
        }

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
            Console.WriteLine("\nFor exit press \"Esc\", for continue, press any key");
        }

        public static void PrintRequestRecordBookForSearch()
        {
            Console.WriteLine("Введите номер зачетки: в формате XX000000" +
                "\nили укажите символы для поиска");
        }


    }
}
