using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3 
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DefCoord defCoord       = new DefCoord()
            {
                X = 10,
                Y = 10
            };
            
            GameConsole gameConsole = new GameConsole();
            Shooter shooter         = new Shooter();
            Beetle[] bugs           = new Beetle[Beetle.BEERLES_COUNT];
            Bullet bullet           = new Bullet();
            Score score             = new Score();

            score.CurrentBeetlesCount = Beetle.BEERLES_COUNT;

            gameConsole.Print();
            shooter.Print();
            score.Print();

            byte directionPrintFlag = 0b0;
            BL.FillBugs(ref bugs);
            UI.PrintBugs(bugs);


            ControlSymbols usreInput = ControlSymbols.none;
            
            ulong timer = 0;

            do
            {
                if (timer % 10 == 0)
                {

                    BL.MoveBugsInsideConsole(ref bugs
                            , (ushort)(gameConsole.GetLeftStartCursorPos + 1)
                            , gameConsole.RightConsoleBoardPos,
                            ref directionPrintFlag);

                    UI.PrintBugs(bugs);
                }

                usreInput = ControlSymbols.none;
                Console.CursorVisible = false;
                if (Console.KeyAvailable)
                {
                    usreInput = (ControlSymbols)Console.ReadKey().Key;
                }

                if (Enum.IsDefined(typeof(ControlSymbols), usreInput))
                {
                    switch (usreInput)
                    {
                        case ControlSymbols.RightArrow:

                            shooter.Move(usreInput
                                , (ushort)(gameConsole.GetLeftStartCursorPos+1)
                                , gameConsole.RightConsoleBoardPos);

                            shooter.Print();

                            break;

                        case ControlSymbols.LeftArrow:

                            shooter.Move(usreInput
                                , (ushort)(gameConsole.GetLeftStartCursorPos + 1)
                                , gameConsole.RightConsoleBoardPos);

                            shooter.Print();

                            break;

                        case ControlSymbols.Spacebar:
                                                        
                            bullet.ProcessingBullet(ref bugs, ref score, shooter.X
                                    , (ushort)(shooter.Y - 1));

                            break;

                        case ControlSymbols.Escape:

                            break;

                        case ControlSymbols.Pause:

                            ushort xTempCursorPosition = (ushort)Console.CursorLeft;
                            ushort yTempCursorPosition = (ushort)Console.CursorTop;

                            usreInput = ControlSymbols.none;

                            do
                            {
                                UI.PrintPause();

                                Thread.Sleep(500);

                                if (Console.KeyAvailable)
                                {
                                    usreInput = (ControlSymbols)Console.ReadKey().Key;
                                }

                                UI.ClearPauseMessage();

                                Thread.Sleep(500);
                            } while (usreInput != ControlSymbols.Pause);

                            Console.SetCursorPosition(xTempCursorPosition,
                                    yTempCursorPosition);
                            break;

                        default:
                            break;
                    }
                }

                Thread.Sleep(50);
                ++timer;
            } while (usreInput != ControlSymbols.Escape && score.CurrentBeetlesCount != 0);

            if (score.CurrentBeetlesCount == 0)
            {
                UI.PrintCongrats();
            }

            Console.ReadKey();
                        
        }
    }
}
