////////////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 31/03/2023
// Last Modified On : 
// Description: Структура ведения счета очков 
// Project: Game
////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game3  
{
    /// <summary>
    /// Подсчет очков игры
    /// </summary>
    public struct Score
    {
        public const ushort LEFT_CURSORE_POS_SCORE = 80;
        public const ushort TOP_CURSORE_POS_SCORE = 3;
  
        private const ushort SCORE_TYPE1 = 30;
        private const ushort SCORE_TYPE2 = 20;
        private const ushort SCORE_TYPE3 = 10;

        private const ConsoleColor BEETLE_TYPE1_SCORE_COLOR = ConsoleColor.Red;
        private const ConsoleColor BEETLE_TYPE2_SCORE_COLOR = ConsoleColor.Cyan;
        private const ConsoleColor BEETLE_TYPE3_SCORE_COLOR = ConsoleColor.Blue;
        private const ConsoleColor TOTAL_SCORE_COLOR        = ConsoleColor.Green;

        /// <summary>
        /// Фактическое количеств жуков
        /// </summary>
        ushort _currentBeetlesCount;

        public ushort CurrentBeetlesCount { 
            get
            {
                return _currentBeetlesCount;
            }
            set 
            {
                _currentBeetlesCount = value;
            } 
        }

        /// <summary>
        /// Подсчет очков на жука с типом 1
        /// </summary>
        private ushort _scoreType1;

        public ushort ScoreType1
        {
            get { return _scoreType1; }
            private set { _scoreType1 += value; }
        }

        /// <summary>
        /// Подсчет очков на жука с типом 2
        /// </summary>
        private ushort _scoreType2;


        /// <summary>
        /// Подсчет очков на жука с типом 3
        /// </summary>
        private ushort _scoreType3;

        

        private ushort _totalScore;

      
        /// <summary>
        /// Увкличение счета при попвдании в жука с типом 1
        /// </summary>
        private void IncreaseScore1()
        {
            _scoreType1 += SCORE_TYPE1;
            _totalScore += SCORE_TYPE1;
        }

        /// <summary>
        /// Увкличение счета при попвдании в жука с типом 2
        /// </summary>
        private void IncreaseScore2()
        {
            _scoreType2 += SCORE_TYPE2;
            _totalScore += SCORE_TYPE2;
        }

        /// <summary>
        /// Увкличение счета при попвдании в жука с типом 3
        /// </summary>
        private void IncreaseScore3()
        {
            _scoreType3 += SCORE_TYPE3;
            _totalScore += SCORE_TYPE3;
        }


        /// <summary>
        /// Увеличение счета игры
        /// </summary>
        /// <param name="beetleType">
        /// типы жуков
        /// </param>
        public void IncreaseScore(BeetleTypes beetleType)
        {
            switch (beetleType)
            {
                case BeetleTypes.type1:
                    IncreaseScore1();
                    Print();
                    break;
                case BeetleTypes.type2:
                    IncreaseScore2();
                    Print();
                    break;
                case BeetleTypes.type3:
                    IncreaseScore3();
                    Print();
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Печать игрового счета
        /// </summary>
        public void Print()
        {

            Console.SetCursorPosition(LEFT_CURSORE_POS_SCORE, TOP_CURSORE_POS_SCORE);

            UI.ChangeItemColorAndPrint(BEETLE_TYPE1_SCORE_COLOR, $"Score bug \\0/:\t{_scoreType1}");

            Console.SetCursorPosition(LEFT_CURSORE_POS_SCORE, TOP_CURSORE_POS_SCORE + 1);
            UI.ChangeItemColorAndPrint(BEETLE_TYPE2_SCORE_COLOR, $"Score bug <ő>:\t{_scoreType2}");

            Console.SetCursorPosition(LEFT_CURSORE_POS_SCORE, TOP_CURSORE_POS_SCORE+2);
            UI.ChangeItemColorAndPrint(BEETLE_TYPE3_SCORE_COLOR, $"Score bug _ő_:\t{_scoreType3}");                     

            Console.SetCursorPosition(LEFT_CURSORE_POS_SCORE, TOP_CURSORE_POS_SCORE + 4);

            UI.ChangeItemColorAndPrint(TOTAL_SCORE_COLOR, $"Total score:\t" +
                $"{_totalScore}");
        }
    }
}