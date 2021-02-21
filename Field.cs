using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class Field
    {
        private static int _width = 40;
        private static int _height = 40;
        public static int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
                Console.SetWindowSize(_width, Field.Height);
                Console.SetBufferSize(_width, Field.Height);
            }

        }

        public static int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
                Console.SetWindowSize(value, Field.Height);
                Console.SetBufferSize(value, Field.Height);
            }

        }




    }
}
