using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico
{
    class Nodos
    {
        public int nodo;
        public int codigo;
        public String nombre;
        public List<int> superiores;

        public Nodos(int  nodo,int codigo,String nombre, List<int> superiores)
        {
            this.nodo = nodo;
            this.codigo = codigo;
            this.nombre = nombre;
            this.superiores = superiores;
        }

        public int getCodigo()
        {
            return codigo;
        }

        public String getNombre()
        {
            return nombre;
        }

        public int getNodo()
        {
            return nodo;
        }
        public List<int> gerLista()
        {
            return superiores;
        }

        public String getSuperiores()
        {
            string valor = "";
            if (superiores.Count==-1)
            {
                valor = "No tiene superiores";
            }
            else
            {

                for (int a = 0; a < superiores.Count; a++)
                {
                    valor += superiores.ElementAt(a).ToString() + ",";
                }
                    
            }

            return valor;

        }


        
        

    }

}
