///////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 12/12/2022
// Last Modified On : 
// Description: Parallelepiped
// Project: HW_13
///////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_13
{
    public class Parallelepiped : VolumetricFigures
    {
        #region FIELDS

        private int _width;
        private int _height;
        private RotatorEnum _rotator;

        #endregion FIELDS


        #region PROPERTIES

        /// <summary>
        /// Ширина
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Высота
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public RotatorEnum Rotator
        {
            get { return _rotator; }
            set { _rotator = value; }
        }

        #endregion PROPERTIES

        #region КОНСТРУКТОР

        public Parallelepiped(int x, int y, int width, int height) 
            : base(x, y)
        {
            _height = height;
            _width = width;
            _rotator = RotatorEnum.none;
        }

        public Parallelepiped(Parallelepiped parallelepiped)
            :base(parallelepiped.X, parallelepiped.Y)
        {
            _height = parallelepiped.Height;
            _width = parallelepiped.Width;
            _rotator = parallelepiped.Rotator;
        }

        #endregion КОНСТРУКТОР


        public override void Move(int deltaX, int deltaY)
        {
            UI.PrintParallelepiped(new Parallelepiped(this)
                , (char)Symbols.none);

            _x += deltaX;
            _y += deltaY;

            UI.PrintParallelepiped(new Parallelepiped(this)
                , (char)Symbols.symbolType1);
        }

        public override void Resize(double Present)
        {
            UI.PrintParallelepiped(new Parallelepiped(this)
                , (char)Symbols.none);


            _height = (int)(Math.Ceiling((double)(Height
                * (Present / 100 + 1))));

            _width = (int)(Math.Ceiling((double)(Width
                * (Present / 100 + 1))));

            UI.PrintParallelepiped(new Parallelepiped(this)
                , (char)Symbols.symbolType1);
        }

        public override void Rotate(RotatorEnum rotator)
        {
            UI.PrintParallelepiped(new Parallelepiped(this)
                 , (char)Symbols.none);

            _rotator = rotator;

            UI.PrintParallelepiped(new Parallelepiped(this)
               , (char)Symbols.symbolType1);
        }
    }
}