﻿using System;
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

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure s = null;

            while(true)
            {
                FigureFall(ref s,generator);
                s.Draw();

            }
           
        }
        static void FigureFall(ref Figure fig,FigureGenerator generator)
        {
            fig = generator.GetNewFigure();
            fig.Draw();

            for (int i = 0; i < 15; i++)
            {
                fig.Hide();
                fig.Move(Direction.DOWN);
                fig.Draw();
                Thread.Sleep(200);
            }
        }

    }
}