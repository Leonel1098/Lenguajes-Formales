using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ManejoErrores
    {

        public string erro;
        public string tipo;
        public string descripcion;
        public int fila;
        public int columan; 

        public ManejoErrores(string error,string tipo,string descripcion,int fila, int columa)
        {
            this.erro = error;
            this.tipo = tipo;
            this.descripcion = descripcion;
            this.fila = fila;
            this.columan = columa;
        }

        public string getError()
        {
            return erro;
        }
        public string getTipo()
        {
            return tipo;
        }

        public string getDescripcion()
        {
            return descripcion;
        }
        public int getColumna()
        {
            return columan;
        }

        public int getFila()
        {
            return fila;
        }

    }
}
