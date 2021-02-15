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
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);

            

            Square s = new Square(2,5,'*');
            s.Draw();
            
            Thread.Sleep(500);
            s.Hide();
            s.Move(Direction.LEFT);
            s.Draw();

            

            //Stick stick = new Stick(6, 6, '*');
            //stick.Draw();



            Console.ReadLine();
        }

    }
}