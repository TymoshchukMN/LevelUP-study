using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        
        
        public override void Move(int deltaX, int deltaY)
        {
            CustomMethods.ClearRhombus(new Rhombus(this));

            _x += deltaX;
            _y += deltaY;

            UI.PrintFigures(new Rhombus(this));
        }

        public override void Resize(double Present)
        {
            CustomMethods.ClearRhombus(new Rhombus(this));

            _height = (int)(Math.Ceiling((double)(Height
               * (Present / 100 + 1))));

            UI.PrintFigures(new Rhombus(this));
        }

      
    }
}