///////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 12/12/2022
// Last Modified On : 14/12/2022
// Description: Square
// Project: HW_13
///////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_13
{
    /// <summary>
    /// Класс квадрата
    /// </summary>
    public class Square : FlatFigures
    {
        #region Fields

        /// <summary>
        /// Длина стороны квадрата
        /// </summary>
        private int _length;

        #endregion

        #region Properties

        /// <summary>
        /// Свойства длины квадрата
        /// </summary>
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        #endregion Properties

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="x"> координата искодной точнки на оси Х  </param>
        /// <param name="y"> координата искодной точнки на оси У </param>
        /// <param name="length"> длина стороны квадрата </param>
        public Square(int x, int y, int length)
            :base(x,y)
        {
            _length = length;
        }

        /// <summary>
        /// Доп. конструктор для READonly
        /// </summary>
        /// <param name="square"></param>
        public Square(Square square)
            :base (square.X, square.Y)
        {
            _length = square.Length;
        }

        #endregion Конструкторы

        #region METHODS

        /// <summary>
        /// Смещение квадрата
        /// </summary>
        /// <param name="deltaX">
        /// на сколько сместить по оси X
        /// </param>
        /// <param name="deltaY">
        /// на сколько сместить по оси Y
        /// </param>
        public override void Move(int deltaX, int deltaY)
        {
            //UI.PrintFigures(new Square(this), (char)Symbols.none);

            UI.PrintSquare(new Square(this), (char)Symbols.none);

            _x += deltaX;
            _y += deltaY;
            
            UI.PrintFigures(new Square(this), (char)Symbols.symbolType1);
        }

        public override void Resize(double Present)
        {
            UI.PrintFigures(new Square(this), (char)Symbols.none);

            _length = (int)(Math.Ceiling((double)(Length 
                * (Present / 100 + 1))));

            UI.PrintFigures(new Square(this), (char)Symbols.symbolType1);
        }


        #endregion METHODS


    }
}