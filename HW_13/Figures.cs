///////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 12/12/2022
// Last Modified On : 
// Description: Figures
// Project: HW_13
///////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_13
{
    public abstract class Figures
    {

        #region Fields

        protected int _x;
        protected int _y;

        #endregion

        #region Properties

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        #endregion Properties

        #region Конструктор

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="x"> координата искодной точнки на оси Х </param>
        /// <param name="y"> координата искодной точнки на оси У </param>
        public Figures(int x, int y)
        {
            _x = x;
            _y = y;
        }

        #endregion Конструктор


        /// <summary>
        /// Абстрактный метод смещения фигуры
        /// </summary>
        /// <param name="deltaX"> наколько смещаем по оси Х </param>
        /// <param name="deltaY"> наколько смещаем по оси Х </param>
        public abstract void Move(int deltaX, int deltaY);

        /// <summary>
        /// Изменение размера фигуры
        /// </summary>
        /// <param name="Present">
        /// % на который меняется размер
        /// </param>
        public abstract void Resize(double Present);
    }
}