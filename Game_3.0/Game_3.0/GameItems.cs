////////////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 26/12/2022
// Last Modified On : 
// Description: Родительский класс игровых ЭЛЕМЕНТОВ
// Project: Game
////////////////////////////////////////////////////


namespace Game3
{
    /// <summary>
    /// Родительский класс игровых ЭЛЕМЕНТОВ
    /// </summary>
    public abstract class GameItem
    {
        /// <summary>
        /// Печать игровых элементов
        /// </summary>
        //public virtual void PrintItem() { }

        protected const ushort START_TOP_CURSOR_POSITION = 2;
        protected const ushort START_LEFT_CURSOR_POSITION = 5;


        public ushort GetTopStartCursorPos
        {
            get
            {
                return START_TOP_CURSOR_POSITION;
            }
        }

        public ushort GetLeftStartCursorPos
        {
            get
            {
                return START_LEFT_CURSOR_POSITION;
            }
        }
    }
}