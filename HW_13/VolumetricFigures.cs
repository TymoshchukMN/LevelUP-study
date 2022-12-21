///////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 12/12/2022
// Last Modified On : 
// Description: Класс объмной фигуры
// Project: HW_13
///////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_13
{
    public abstract class VolumetricFigures : Figures
    {
        #region КОНСТРУКТОР

        protected VolumetricFigures(int x, int y) : base(x, y)
        {
        }

        #endregion КОНСТРУКТОР

        private int _z;

        public int Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public virtual void Rotate(RotatorEnum rotator)
        {
        }
    }
}