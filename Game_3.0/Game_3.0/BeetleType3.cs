using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game3
{
    public class BeetleType3 : Beetle
    {
        #region FIELDS

        /// <summary>
        /// Цвет жука по умолчанию 
        /// </summary>
        private ConsoleColor _beetle3Color1 = ConsoleColor.Blue;
        private ConsoleColor _beetle3Color2 = ConsoleColor.DarkBlue;
        

        /// <summary>
        /// Вид жука тип 1
        /// '\0/' 
        /// </summary>
        public static readonly char[] elementsBugType1
            = new char[BEETLE_LENGHT]
            {
                (char)GameSymbols.bugType3Side2,
                (char)GameSymbols.bugType3CentralItem1,
                (char)GameSymbols.bugType3Side1
            };

        /// <summary>
        /// Вид жука тип 2
        /// /o\
        /// </summary>
        public static readonly char[] elementsBugType2
            = new char[BEETLE_LENGHT]
            {
                (char)GameSymbols.bugType3Side1,
                (char)GameSymbols.bugType3CentralItem2,
                (char)GameSymbols.bugType3Side2
            };

        #endregion FIELDS


        #region КОНСТРУКТОРЫ

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="x">
        /// Позиция первого (левого) элемента жука по оси X
        /// </param>
        /// <param name="y">
        /// Позиция первого (левого) элемента жука по оси Y
        /// </param>
        public BeetleType3(ushort x, ushort y)
        {
            _x = x;
            _y = y;
            _beetleType = BeetleTypes.type3;
        }

        #endregion КОНСТРУКТОРЫ

        #region METHODS

        /// <summary>
        /// печать жука
        /// </summary>
        public void Print()
        {
            // жук печатается слева на право

            if (_typePrintFlag == 0b0)
            {
                for (ushort i = 0; i < BEETLE_LENGHT; ++i)
                {
                    Console.SetCursorPosition(_x + i, _y);
                    UI.ChangeItemColorAndPrint(_beetle3Color1, elementsBugType1[i]);
                }
            }
            else
            {
                for (ushort i = 0; i < BEETLE_LENGHT; ++i)
                {
                    Console.SetCursorPosition(_x + i, _y);
                    UI.ChangeItemColorAndPrint(_beetle3Color2, elementsBugType2[i]);
                }
            }
        }

        #endregion METHODS

    }
}