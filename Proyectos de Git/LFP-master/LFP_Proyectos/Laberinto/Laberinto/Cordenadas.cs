using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Cordenadas
    {
        public int x;
        public int y;

        public Cordenadas(int c_x, int c_y)
        {
            x = c_x;
            y = c_y;
        }
        
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
    }
}
