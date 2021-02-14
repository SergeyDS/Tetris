using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);

            Square s = new Square(10,15,'*');
            s.Draw();

            Point p1 = new Point();

            p1.x = 2;
            p1.y = 3;
            p1.c = '*';

            p1.Draw();

            Point p2 = new Point()
            {
                x = 4,
                y = 5,
                c = '#',
            };


            p2.Draw();

            Console.ReadLine();
        }

    }
}