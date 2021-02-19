using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
  abstract class Figure
    {
        const int LENGHT = 4;
        
        protected Point[] points = new Point[LENGHT];

        public void Draw()
        {
            foreach (Point p in points)
            {
                p.Draw();
            }
        }

        public void Move(Direction dir)
        {
            Hide();
            foreach(Point p in points)
            {
                p.Move(dir);
            }
            Draw();
            
            
        }
 internal void TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            clone[0].Move(dir);

            Draw();
        }
        private Point[] Clone()
        {
            var newPoints = new Point[LENGHT];
            for(int i=0; i< LENGHT; i++)
            {
                newPoints[i] = points[i];
            }
            return newPoints;
        }

        public  abstract void Rotate();
        

        public void Hide()
        {
            foreach (Point p in points)
            {
                p.Hide();
            }
        }

       
    }
}
