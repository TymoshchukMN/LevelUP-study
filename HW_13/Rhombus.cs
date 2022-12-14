using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_13
{
    public class Rhombus : FlatFigures
    {
        private int _height;

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        

        public Rhombus(int x, int y, int height):
            base(x,y)
        {
            _height = height;
        }


        public Rhombus(Rhombus rhombus):
            base(rhombus.X, rhombus.Y)
        {
            _height = rhombus.Height;
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

        }
    }
}