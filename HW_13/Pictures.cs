///////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 12/12/2022
// Last Modified On : 14/12/2022
// Description: Класс, хранящий в себе все фигуры
// Project: HW_13
///////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_13
{
    /// <summary>
    /// Класс содержащий в себе фигуры в виде массива,
    /// НЕ ЯВЛЯЕТСЯ участником наследования
    /// </summary>
    public class Pictures
    {
        /// <summary>
        /// Массив фигур
        /// </summary>
        //FlatFigures[] _figures;
        Figures[] _figures; 


        public Figures[] Figures
        {
            get { return _figures; }
        }

        #region КОНСТРУКТОРЫ

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="figures">
        /// фигуры
        /// </param>
        public Pictures(params Figures[] figures)
        {
            _figures = (Figures[])figures.Clone();
        }

        #endregion КОНСТРУКТОРЫ


        /// <summary>
        /// Печать всех фигур
        /// </summary>
        public void PrintPictures()
        {
            for (ushort i = 0; i < _figures.Length; i++)
            {
                UI.PrintFigures(_figures[i]);
            }
        }

        public void Move(int deltaX, int deltaY)
        {
            for (ushort i = 0; i < Figures.Length; ++i)
            {
                Figures[i].Move(2,2);
            }
        }

        public void Resize(double present)
        {
            for (ushort i = 0; i < Figures.Length; ++i)
            {
                Figures[i].Resize(present);
            }
        }
    }
}