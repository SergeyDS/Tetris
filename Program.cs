using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.WIDHT,Field.HEIGHT);
            Console.SetBufferSize(Field.WIDHT, Field.HEIGHT);

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure currentFigure = generator.GetNewFigure();

            while(true)
            {
               if(Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    HandlKey(currentFigure, key);
                }
            }
           
        }

        private static void HandlKey(Figure currentFigure, ConsoleKeyInfo key)
        {
              switch(key.Key)
            {
                case ConsoleKey.LeftArrow:
                    currentFigure.TryMove(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    currentFigure.TryMove(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    currentFigure.TryMove(Direction.DOWN);
                    break;
                case ConsoleKey.Spacebar:
                     currentFigure.TryRotate();
                     break;
            }
        }
    }
}