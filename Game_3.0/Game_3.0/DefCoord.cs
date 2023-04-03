using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game3
{
    /// <summary>
    /// Координаты по умолчанию
    /// </summary>
    public struct DefCoord
    {
        /// <summary>
        /// Координата X по умолчанию
        /// </summary>
        private int _x;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Координата X по умолчанию
        /// </summary>
        private int _y;

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

    }
}