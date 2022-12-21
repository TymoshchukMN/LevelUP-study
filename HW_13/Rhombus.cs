///////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 12/12/2022
// Last Modified On : 
// Description: Rhombus
// Project: HW_13
///////////////////////////////

using System;


namespace HW_13
{
    public class Rhombus : FlatFigures
    {
        #region FIELDS

        private int _height;
        private RotatorEnum _rotator;

        #endregion FIELDS

        #region PROPERTIES

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

        public Rhombus(int x, int y, int height):
            base(x,y)
        {
            _height = height;
        }

        public Rhombus(Rhombus rhombus):
            base(rhombus.X, rhombus.Y)
        {
            _height = rhombus.Height;
            _rotator = rhombus.Rotator;
        }

        #endregion КОНСТРУКТОР

        public override void Move(int deltaX, int deltaY)
        {
            UI.PrintRhombus(new Rhombus(this), (char)Symbols.none);

            _x += deltaX;
            _y += deltaY;

            UI.PrintRhombus(new Rhombus(this), (char)Symbols.point);
        }

        public override void Resize(double Present)
        {
            UI.PrintFigures(new Rhombus(this), (char)Symbols.none);

            _height = (int)(Math.Ceiling((double)(Height
               * (Present / 100 + 1))));

            UI.PrintFigures(new Rhombus(this), (char)Symbols.point);
        }

      
    }
}