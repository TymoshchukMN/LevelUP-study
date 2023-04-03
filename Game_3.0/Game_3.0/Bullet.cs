////////////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 26/12/2022
// Last Modified On : 
// Description: Класс игрового элемента - пуля
// Project: Game
////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game3
{
    /// <summary>
    /// Игровой элемент (пуля)
    /// </summary>
    public class Bullet : GameItem
    {
        /// <summary>
        /// Позиция пули в консоли по оси X
        /// </summary>
        private ushort _x;

        public ushort X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Позиция пули в консоли по оси Y
        /// </summary>
        private ushort _y;

        public ushort Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Конструктор с координатиам
        /// </summary>
        /// <param name="x">
        /// позиция пули по оси X
        /// </param>
        /// <param name="y">
        /// позиция пули по оси Y
        /// </param>
        public Bullet(ushort x, ushort y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Bullet()
        {

        }

        #region METHODS

        

        /// <summary>
        /// Печать пули
        /// </summary>
        public void PrintBullet(ushort x, ushort y)
        {                      

            Console.SetCursorPosition(x, y);

            UI.ChangeItemColorAndPrint(ConsoleColor.Red,
                    (char)GameSymbols.boolet);

            Thread.Sleep(70);

            Console.SetCursorPosition(x, y);
            Console.Write((char)GameSymbols.none);

        }

        /// <summary>
        /// Обработка поведения пули
        /// </summary>
        /// <param name="beetles">
        /// массив жуков
        /// </param>
        /// <param name="score">
        /// структура очков
        /// </param>
        /// <param name="x">
        /// координата шутера по оси X
        /// </param>
        /// <param name="y">
        /// координата шутера по оси Y
        /// </param>
        public void ProcessingBullet(ref Beetle[] beetles,
               ref Score score, ushort x, ushort y)
        {
            bool isAccross = false;
            ushort resAccrossPosition;

            // 7 - количество строк от верхней границы консоли до
            // нижней линии жука
            const ushort BEETLES_LINES = 7;

            ushort beginCheckAccrossPos 
                    = START_TOP_CURSOR_POSITION + BEETLES_LINES;

            for (ushort i = (ushort)(y - 1); i >= START_TOP_CURSOR_POSITION; i--)
            {
                if (beginCheckAccrossPos < i)
                {
                    PrintBullet(x, y);
                    --y;
                }
                else
                {
                    short beetleIndex = -1;
                    isAccross = BL.CheckIfBulletAcrossBeetle(ref beetles, x, i
                            , out resAccrossPosition
                            ,ref beetleIndex);

                    if (isAccross)
                    {
                        Console.SetCursorPosition(x, y-1);
                        // очищаем жука с консоли
                        UI.ClearAccrossedBug(x, i, resAccrossPosition
                                , Beetle.BEETLE_LENGHT);

                        score.IncreaseScore(beetles[beetleIndex].BeetleType);
                        --score.CurrentBeetlesCount;
                        beetles[beetleIndex].BeetleType = BeetleTypes.none;

                        break;
                    }
                    else
                    {
                        PrintBullet(x, y);
                        --y;
                    }
                }
            }

        }
        
        #endregion METHODS
    }
}