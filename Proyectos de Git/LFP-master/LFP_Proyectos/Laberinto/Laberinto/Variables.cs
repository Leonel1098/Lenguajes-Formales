using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Variables
    {
        public String id;
        public int valor;

        public Variables(String id)
        {
            this.id = id;
            
        }

        public string getId()
        {
            return id;
        }
        public int getValor()
        {
            return valor;
        }

        public void setValor(int valor)
        {
            this.valor = valor;
        }
    }
}
