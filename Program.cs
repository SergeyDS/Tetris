using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Tetris
{
    class Program
    {

        static private Object _lockObject = new object();

        const int TIMER_INTEVAL = 500;
        static System.Timers.Timer timer;

        static Figure currentFigure;
        static FigureGenerator generator;
        static void Main(string[] args)
        {
            
            
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);



            generator = new FigureGenerator(Field.Width/2, 0, Drawer.DEFAULT_SYMBOL);
            Figure currentFigure = generator.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    var result = HandlKey(currentFigure, key.Key);
                    ProcessResult(result, ref currentFigure);
                    Monitor.Exit(_lockObject);
                }
            }

        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();
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
        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTEVAL);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result,ref currentFigure);
            Monitor.Exit(_lockObject);

        }
    }
}