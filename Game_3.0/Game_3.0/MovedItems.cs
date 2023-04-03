///////////////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 26/12/2022
// Last Modified On : 
// Description: Абстрактній класс перемещаемых элементов
// Project: Game
///////////////////////////////////////////////////////


namespace Game3
{

    /// <summary>
    /// Абстрактній класс перемещаемых элементов
    /// </summary>
    public abstract class MovedItem : GameItem
    {
        /// <summary>
        /// Перемещение элемента внутри консоли
        /// </summary>
        public abstract void Move();

        ///// <summary>
        ///// Позиция в консоли по оси X по умолчнию.
        ///// Используется как промежуточное хранение координаты,
        ///// т.е. не во время печати элементов
        ///// </summary>
        //private ushort _defaultX;


        //public ushort DefaultX
        //{
        //    get { return _defaultX; }
        //    set { _defaultX = value; }
        //}


        ///// <summary>
        ///// Позиция в консоли по оси Y по умолчнию.
        ///// Используется как промежуточное хранение координаты,
        ///// т.е. не во время печати элементов
        ///// </summary>
        //private ushort _defaultY;

        //public ushort DefaultY
        //{
        //    get { return _defaultY; }
        //    set { _defaultY = value; }
        //}

    }
}