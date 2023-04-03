using System;

namespace Game3
{
    public class BeetleType1 : Beetle
    {
        #region FIELDS

        /// <summary>
        /// Цвет жука по умолчанию 
        /// </summary>
        private ConsoleColor _beetle1Color1 = ConsoleColor.DarkRed;

        private ConsoleColor _beetle1Color2 = ConsoleColor.Red;

        /// <summary>
        /// Вид жука тип 1
        /// '\0/' 
        /// </summary>
        public static readonly char[] elementsBugType1
            = new char[BEETLE_LENGHT]
            {
                (char)GameSymbols.bugType1Side2,
                (char)GameSymbols.bugType1CentralItem1,
                (char)GameSymbols.bugType1Side1
            };

        /// <summary>
        /// Вид жука тип 2
        /// /o\
        /// </summary>
        public static readonly char[] elementsBugType2
            = new char[BEETLE_LENGHT]
            {
                (char)GameSymbols.bugType1Side1,
                (char)GameSymbols.bugType1CentralItem2,
                (char)GameSymbols.bugType1Side2
            };

        #endregion FIELDS

        #region КОНСТРУКТОРЫ

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>       
        public BeetleType1(ushort x, ushort y)
        {
            _x = x;
            _y = y;
            _beetleType = BeetleTypes.type1;
        }

        #endregion КОНСТРУКТОРЫ




        #region METHODS

        /// <summary>
        /// печать жука
        /// </summary>
        public void Print()
        {
            // жук печатается слева на право

            if (TypePrintFlag == 0b0)
            {
                for (ushort i = 0; i < BEETLE_LENGHT; ++i)
                {
                    Console.SetCursorPosition(_x + i, _y);
                    UI.ChangeItemColorAndPrint(_beetle1Color1, elementsBugType1[i]);
                }
            }
            else
            {
                for (ushort i = 0; i < BEETLE_LENGHT; ++i)
                {
                    Console.SetCursorPosition(_x + i, _y);
                    UI.ChangeItemColorAndPrint(_beetle1Color2, elementsBugType2[i]);
                }
            }
        }

        #endregion METHODS

    }
}