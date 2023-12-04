using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Enemigo
    {
        
        public int x1;
        public int x2;
        public int y1;
        public int y2;
        public int tipo;
        //para manejar que tipo de caminata tien el enemigo:
        //0----> horizontal, //1----vertical
        public Enemigo()
        {

        }
        public int getX1()
        {
            return x1;
        }
        public int getX2()
        {
            return x2;
        }
        public int getY1()
        {
            return y1;
        }
        public int getY2()
        {
            return y2;
        }
        public int getTipo()
        {
            return tipo;
        }
        public void CaminataHorizontal(int x1,int x2,int y1)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.tipo = 0;

        }
        public void CaminataVertical(int x1,int y1,int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.y2 = y2;
            this.tipo = 1;

        }
    }
}
