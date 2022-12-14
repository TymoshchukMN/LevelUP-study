using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_13
{
    /// <summary>
    /// Класс треугольника
    /// </summary>
    public class Triangle : FlatFigures
    {
        #region FIELDS

        /// <summary>
        /// Перывый катет
        /// </summary>
        private int _cathetus1;

        /// <summary>
        /// Второй катет
        /// </summary>
        private int _cathetus2;

        /// <summary>
        /// Угол между катетами
        /// </summary>
        private ushort _angle;

        /// <summary>
        /// Полождение "по вращению"
        /// </summary>
        private RotatorEnum _rotator;

        #endregion FIELDS

        #region Properties

        /// <summary>
        /// Свойства первого катета
        /// </summary>
        public int Cathetus1
        {
            get { return _cathetus1; }
            set { _cathetus1 = value; }
        }

        /// <summary>
        /// Свойства второго катета
        /// </summary>
        public int Cathetus2
        {
            get { return _cathetus2; }
            set { _cathetus2 = value; }
        }

        /// <summary>
        /// Свойства угла между катетами
        /// </summary>
        public ushort Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }
              

        public RotatorEnum Rotator
        {
            get { return _rotator; }
            set { _rotator = value; }
        }

        #endregion Properties

        #region КОНСТРУКТОР

        /// <summary>
        /// Констурктор по умолчанию
        /// </summary>
        /// <param name="x"> координата искодной точнки на оси Х </param>
        /// <param name="y"> координата искодной точнки на оси У </param>
        /// <param name="cathetus1"> длина первого катета </param>
        /// <param name="cathetus2"> длина второго катета </param>
        public Triangle(int x, int y, int cathetus1, int cathetus2)
            : base(x, y)
        {
            _cathetus1 = cathetus1;
            _cathetus2 = cathetus2;
            _rotator = RotatorEnum.none;
        }

        public Triangle(Triangle triangle)
            :base(triangle.X, triangle.Y)
        {
            _cathetus1 = triangle._cathetus1;
            _cathetus2 = triangle._cathetus2;
            _rotator = triangle.Rotator;
        }

        #endregion КОНСТРУКТОР

        public override void Move(int deltaX, int deltaY)
        {
            CustomMethods.ClearTriangle(new Triangle(this));

            _x += deltaX;
            _y += deltaY;

            UI.PrintFigures(new Triangle(this));
        }

        public override void Resize(double Present)
        {
            CustomMethods.ClearTriangle(new Triangle(this));

            _cathetus1 = (int)(Math.Ceiling((double)(Cathetus1
                * (Present / 100 + 1))));
            
            _cathetus2 = (int)(Math.Ceiling((double)(Cathetus2
                * (Present / 100 + 1))));

            UI.PrintFigures(new Triangle(this));
        }

        /// <summary>
        /// вращение треугольника 
        /// </summary>
        /// <param name="rotator">
        /// насколько вращать
        /// </param>
        public override void Rotate(RotatorEnum rotator)
        {
            CustomMethods.ClearTriangle(new Triangle(this));

            _rotator = rotator;

            UI.PrintFigures(new Triangle(this));
        }
    }
}