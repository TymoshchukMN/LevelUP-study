using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_13
{
    /// <summary>
    /// Класс содержащий в себе фигуры в виде массива
    /// </summary>
    public class Pictures
    {
        /// <summary>
        /// Массив фигур
        /// </summary>
        FlatFigures[] _figures;

        #region КОНСТРУКТОРЫ

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="figures">
        /// фигуры
        /// </param>
        public Pictures(params FlatFigures[] figures)
        {
            _figures = (FlatFigures[])figures.Clone();
        }

        #endregion КОНСТРУКТОРЫ


        /// <summary>
        /// Печать всех фигур
        /// </summary>
        public void PrintPictures()
        {
            for (int i = 0; i < _figures.Length; i++)
            {
                UI.PrintFigures(_figures[i]);
            }
        }

        public virtual void Resize(FlatFigures[] figures)
        { 
        
        }
    }
}