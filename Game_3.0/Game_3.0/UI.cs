using Game3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    public class UI
    {
        const string PAUSE_MESSAGE = "P A U S E";
        const string FINAL_MESSAGE = "Congratulations you won!!!!";

        /// <summary>
        /// функция изменения цвета элемента
        /// </summary>
        /// <param name="preferedColor">
        /// желаемый цвет
        /// </param>
        /// <param name="item">
        /// элемент для печати
        /// </param>
        public static void ChangeItemColorAndPrint(ConsoleColor preferedColor
            , GameSymbols symbol)
        {

            ConsoleColor defColor = Console.ForegroundColor;

            Console.ForegroundColor = preferedColor;

            Console.Write((char)symbol);

            Console.ForegroundColor = defColor;
        }

        /// <summary>
        /// функция изменения цвета элемента
        /// </summary>
        /// <param name="preferedColor">
        /// желаемый цвет
        /// </param>
        /// <param name="str">
        /// строка для печати
        /// </param>
        public static void ChangeItemColorAndPrint(ConsoleColor preferedColor,
            string str)
        {
            ConsoleColor defColor = Console.ForegroundColor;

            Console.ForegroundColor = preferedColor;

            Console.Write(str);

            Console.ForegroundColor = defColor;
        }


        public static void ChangeItemColorAndPrint(ConsoleColor preferedColor
            , char symbol)
        {

            ConsoleColor defColor = Console.ForegroundColor;

            Console.ForegroundColor = preferedColor;

            Console.Write(symbol);

            Console.ForegroundColor = defColor;
        }


        /// <summary>
        /// вывод на экран сообщения о паузе
        /// </summary>
        public static void PrintPause()
        {
            const ushort PAUSE_MESSAGE_POSITION_X = Score.LEFT_CURSORE_POS_SCORE;
            const ushort PAUSE_MESSAGE_POSITION_y = 20;
            

            Console.SetCursorPosition(PAUSE_MESSAGE_POSITION_X,
                    PAUSE_MESSAGE_POSITION_y);

            ConsoleColor def = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(PAUSE_MESSAGE);

            Console.ForegroundColor = def;
        }

        /// <summary>
        /// очистка сообщения о паузе
        /// </summary>
        public static void ClearPauseMessage()
        {
            const ushort PAUSE_MESSAGE_POSITION_X = Score.LEFT_CURSORE_POS_SCORE;
            const ushort PAUSE_MESSAGE_POSITION_y = 20;

            for (int i = 0; i < PAUSE_MESSAGE.Length; i++)
            {

                Console.SetCursorPosition(i + PAUSE_MESSAGE_POSITION_X,
                    PAUSE_MESSAGE_POSITION_y);
                Console.Write((char)GameSymbols.none);
            }
        }

        /// <summary>
        /// Печать  жуков на консоли
        /// </summary>
        /// <param name="bugs">
        /// список жуков
        /// </param>
        public static void PrintBugs(Beetle[] bugs)
        {
            for (ushort i = 0; i < bugs.Length; i++)
            {
                if (bugs[i].BeetleType == BeetleTypes.none)
                {
                    continue;
                }
                
                if ((bugs[i] is BeetleType1))
                {
                    (bugs[i] as BeetleType1).Print();
                    bugs[i].TypePrintFlag = (byte)~bugs[i].TypePrintFlag;
                }
                else
                {
                    if ((bugs[i] is BeetleType2))
                    {
                        (bugs[i] as BeetleType2).Print();
                        bugs[i].TypePrintFlag = (byte)~bugs[i].TypePrintFlag;
                    }
                    else
                    {
                        if ((bugs[i] is BeetleType3))
                        {
                            (bugs[i] as BeetleType3).Print();
                            bugs[i].TypePrintFlag = (byte)~bugs[i].TypePrintFlag;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// чистка символов жука из консоли после попадания
        /// </summary>
        /// <param name="x">
        /// координата пули
        /// </param>
        /// <param name="y">
        /// координата пули
        /// </param>
        /// <param name="accrossPosition">
        /// позиция пересечения
        /// </param>
        public static void ClearAccrossedBug(ushort x, ushort y,
            ushort accrossPosition, ushort countElements)
        {

            switch (accrossPosition)
            {
                case 1:

                    for (ushort i = 0; i < countElements; ++i)
                    {
                        Console.SetCursorPosition(x + i, y);
                        Console.Write((char)GameSymbols.none);
                    }

                    break;

                case 2:

                    --x;

                    for (ushort i = 0; i < countElements; ++i)
                    {
                        Console.SetCursorPosition(x + i, y);
                        Console.Write((char)GameSymbols.none);
                    }

                    break;

                case 3:

                    x = (ushort)(x - 2);

                    for (ushort i = 0; i < countElements; ++i)
                    {
                        Console.SetCursorPosition(x + i, y);
                        Console.Write((char)GameSymbols.none);
                    }
                    break;

            }
        }


        public static void PrintCongrats()
        {
            Console.SetCursorPosition(15, 12);
            
            ChangeItemColorAndPrint(ConsoleColor.Green, FINAL_MESSAGE);
            Console.WriteLine();
        }
    }
}
