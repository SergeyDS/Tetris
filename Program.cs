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
        static FigureGenerator generator;
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);



            generator = new FigureGenerator(20, 0, '*');
            Figure currentFigure = generator.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    var result = HandlKey(currentFigure,key.Key);
                    ProcessResult(result, ref currentFigure);
                }
            }

        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                currentFigure = generator.GetNewFigure();
                return true;
            }
            else
                return false;
        }

        private static Result HandlKey(Figure f, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    f.TryMove(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    f.TryMove(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    f.TryMove(Direction.DOWN);
                    break;
                case ConsoleKey.Spacebar:
                    f.TryRotate();
                    break;
            }
            return Result.SUCCESS;
        }
    }
}