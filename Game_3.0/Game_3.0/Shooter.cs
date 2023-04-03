////////////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 26/12/2022
// Last Modified On : 
// Description: Стреляющий элемент
// Project: Game
////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Game3
{
    public class Shooter : GameItem
    {
        /// <summary>
        /// Координата шутера по оси X
        /// </summary>
        private ushort _x;

        public ushort X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Координата шутера по оси Y
        /// </summary>
        private ushort _y;

        public ushort Y
        {
            get 
            {
                return _y;
            }
        }


        /// <summary>
        /// Позиция шутера по оси Y
        /// </summary>
        private const ushort TOP_SHOOTER_POSITION = 21;

        /// <summary>
        /// конструктор
        /// </summary>
        public Shooter()
        {
            _x = START_LEFT_CURSOR_POSITION + 1;
            _y = TOP_SHOOTER_POSITION;
        }

        /// <summary>
        /// Печать шутера
        /// </summary>
        public void Print()
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.SetCursorPosition(_x, _y);
            UI.ChangeItemColorAndPrint(ConsoleColor.Yellow, GameSymbols.shooter);

            Console.ForegroundColor = def;
        }

        public void Move(ControlSymbols symbol, ushort leftBoardPosition, ushort rightBoardPosition)
        {            
            if (symbol == ControlSymbols.RightArrow)
            {
                if (_x < rightBoardPosition)
                {
                    Console.SetCursorPosition(_x,
                            _y);

                    Console.Write((char)GameSymbols.none);
                    ++_x;
                    Print();
                }
            }
            else
            {
                if (symbol == ControlSymbols.LeftArrow)
                {
                    if (_x > leftBoardPosition)
                    {
                        Console.SetCursorPosition(_x,
                            _y);

                        Console.Write((char)GameSymbols.none);

                        --_x;

                        Print();
                    }
                }
            }
            
        }
    }
}