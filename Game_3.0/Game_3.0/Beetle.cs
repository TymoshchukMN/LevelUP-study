using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game3
{
    /// <summary>
    /// Класс жуков
    /// </summary>
    public class Beetle : GameItem
    {
        // total number of beetles
        public const ushort BEERLES_COUNT = 42;

        // количество символов в жуке
        public const ushort BEETLE_LENGHT = 3;

        /// <summary>
        /// Переключатель для определения как печатать жука,
        /// например, \0/ или /0\
        /// </summary>
        protected byte _typePrintFlag = 0b0;

        /// <summary>
        /// тип жука 
        /// </summary>
        protected private BeetleTypes _beetleType;

        public BeetleTypes BeetleType
        {
            get
            {
                return _beetleType;
            }
            set
            {
                _beetleType = value;
            }
        }


        /// <summary>
        /// Позиция первого (левого) элемента жука по оси X
        /// </summary>
        protected ushort _x;

        public ushort X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Позиция первого (левого) жука по оси Y
        /// </summary>
        protected ushort _y;

        public ushort Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Направление печати жуков
        /// </summary>
        public byte TypePrintFlag
        {
            get
            {
                return _typePrintFlag;
            }
            set
            {
                _typePrintFlag = value;
            }
        }

        public virtual void Move(ushort leftBoardPosition,
                ushort rightBoardPosition, ref byte directionPrintFlag)
        {
            // шаг печати следующего жука (3 элемента жука + 1 пробел)
            const ushort STEP = 4;
            
        
            if (directionPrintFlag == 0b0)
            {
                BL.ClerBugInConsole(_x, _y, BEETLE_LENGHT);
                _x += STEP;

            }
            else
            {
                BL.ClerBugInConsole(_x, _y, BEETLE_LENGHT);
                _x -= STEP;
            }
        }
    }
}
