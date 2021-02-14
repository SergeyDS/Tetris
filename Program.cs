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

            //Square s = new Square(10,15,'*');
            //s.Draw();
            Stick stick = new Stick(6, 6, '*');
            stick.Draw();

            

            Console.ReadLine();
        }

    }
}