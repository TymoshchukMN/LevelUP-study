///////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 12/12/2022
// Last Modified On : 
// Description: FlatFigures
// Project: HW_13
///////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_13
{
    /// <summary>
    /// Абстрактный класс (плоской фигуры)
    /// </summary>
    public abstract class FlatFigures : Figures
    {
        #region КОНСТРУКТОР
        public FlatFigures(int x, int y)
            : base(x, y)
        {

        }

        #endregion КОНСТРУКТОР

        public virtual void Rotate(RotatorEnum rotator)
        { 
        }
    }
}