////////////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 26/12/2022
// Last Modified On : 
// Description: Класс игровой консоли (игрового поля)
// Project: Game
////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game3
{
    /// <summary>
    /// Класс игровой консоли (игрового поля)
    /// </summary>
    public class GameConsole : GameItem
    {
        private const ushort COUNT_VERTICAL_SYMBOLS = 20;

        private const ushort COUNT_HORIZONTAL_LINES = 60;

        /// <summary>
        /// Позиция провой границы в консоли
        /// </summary>
        public ushort RightConsoleBoardPos
        {
            get
            {
                return START_LEFT_CURSOR_POSITION
                    + COUNT_HORIZONTAL_LINES - 1;
            }
        }
        /// <summary>
        /// Печать игровой консоли
        /// </summary>
        public void Print()
        {
            string horizontalLine = new string((char)GameSymbols.HORIZONTAL,
                    COUNT_HORIZONTAL_LINES);

            string topBox = string.Concat((char)GameSymbols.LEFT_TOP
                , horizontalLine, (char)GameSymbols.RIGHT_TOP);

            string downBox = string.Concat((char)GameSymbols.LEFT_DOWN
                , horizontalLine, (char)GameSymbols.RIGHT_DOWN);

            //утснавливаем крайнюю правую позицию консоли

            ushort rightBoardPosition = (ushort)(START_LEFT_CURSOR_POSITION
                    + (horizontalLine.Length + 1));

            Console.SetCursorPosition(START_LEFT_CURSOR_POSITION,
                    START_TOP_CURSOR_POSITION);
            ConsoleColor defColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // рисуем верхнюю часть границы
            Console.WriteLine(topBox);

            // рисуем боковые стороны
            for (ushort i = 1; i <= COUNT_VERTICAL_SYMBOLS; ++i)
            {
                // рисуем границу слева
                Console.SetCursorPosition(START_LEFT_CURSOR_POSITION
                    , START_TOP_CURSOR_POSITION + i);
                Console.WriteLine((char)GameSymbols.VERTICAL);

                // определяем позицию правой стороны
                Console.SetCursorPosition(rightBoardPosition
                    , START_TOP_CURSOR_POSITION + i);
                Console.WriteLine((char)GameSymbols.VERTICAL);
            }

            // рисуем нижнюю часть консоли
            Console.SetCursorPosition(START_LEFT_CURSOR_POSITION
                , START_TOP_CURSOR_POSITION + COUNT_VERTICAL_SYMBOLS);

            Console.WriteLine(downBox);

            Console.ForegroundColor = defColor;
        }

    }
}