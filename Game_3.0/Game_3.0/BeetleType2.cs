using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game3
{
    public class BeetleType2 : Beetle
    {
        #region FIELDS

        /// <summary>
        /// Цвет жука по умолчанию 
        /// </summary>
        private ConsoleColor _beetle1Color = ConsoleColor.Magenta;


        /// <summary>
        /// Вид жука тип 1
        /// <¤> 
        /// </summary>
        public static readonly char[] elementsBugType1
            = new char[BEETLE_LENGHT]
            {
                (char)GameSymbols.bugType2Side2,
                (char)GameSymbols.bugType2CentralItem1,
                (char)GameSymbols.bugType2Side1
            };

        /// <summary>
        /// Вид жука тип 2
        /// <^>
        /// </summary>
        public static readonly char[] elementsBugType2
            = new char[BEETLE_LENGHT]
            {
                (char)GameSymbols.bugType2Side1,
                (char)GameSymbols.bugType2CentralItem1,
                (char)GameSymbols.bugType2Side2
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
        public BeetleType2(ushort x, ushort y)
        {
            _x = x;
            _y = y;
            _beetleType = BeetleTypes.type2;
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
                    UI.ChangeItemColorAndPrint(_beetle1Color, elementsBugType1[i]);
                }
            }
            else
            {
                for (ushort i = 0; i < BEETLE_LENGHT; ++i)
                {
                    Console.SetCursorPosition(_x + i, _y);
                    UI.ChangeItemColorAndPrint(_beetle1Color, elementsBugType2[i]);
                }
            }

        }

        #endregion METHODS
    }
}