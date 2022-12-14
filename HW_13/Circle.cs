///////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 12/12/2022
// Last Modified On : 
// Description: Circle
// Project: HW_13
///////////////////////////////


using System;

namespace HW_13
{
    /// <summary>
    /// Класс круга
    /// </summary>
    public class Circle : FlatFigures
    {
        #region FIELDS

        /// <summary>
        /// Радиус акружности
        /// </summary>
        private int _radius;

        #endregion FIELDS

        #region PROPERTIES

        /// <summary>
        /// Свойства радиуса акружности
        /// </summary>
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        #endregion PROPERTIES


        #region КОНСТРУКТОР

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="x"> координата искодной точнки на оси Х </param>
        /// <param name="y"> координата искодной точнки на оси У </param>
        /// <param name="radius"> радиус </param>
        public Circle(int x, int y, int radius) : base(x, y)
        {
            _radius = radius;
        }

        /// <summary>
        /// Доп. конструктор для READonly
        /// </summary>
        /// <param name="circle"> ссылка на объект circle </param>
        public Circle(Circle circle)
            :base(circle.X, circle.Y)
        {
            _radius = circle.Radius;
        }

        #endregion КОНСТРУКТОР

        public override void Move(int deltaX, int deltaY)
        {
           
        }

        public override void Resize(double Present)
        {
            throw new NotImplementedException();
        }
    }
}