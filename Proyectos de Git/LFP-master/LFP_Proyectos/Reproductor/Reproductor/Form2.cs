using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reproductor
{
    public partial class Tokens : Form
    {

        public List<Token> entrada;
        public Tokens(List<Token> nuevos)
        {
            InitializeComponent();


            this.entrada = nuevos;


        }

        private void Tokens_Load(object sender, EventArgs e)
        {

            tablatoken.Columns.Add("no", "No");
            tablatoken.Columns.Add("lexema", "Lexema");
            tablatoken.Columns.Add("tipo", "Tipo");
            tablatoken.Columns.Add("fila", "Fila");
            tablatoken.Columns.Add("columna", "Columna");
            int contador = 1;
            for(int i = 0; i <= entrada.Count - 1; i++)
            {
                
                if (entrada.ElementAt(i).getTipo().Equals("Desconocido"))
                {

                }else
                {
                    tablatoken.Rows.Add(contador + "", entrada.ElementAt(i).getLexema(), entrada.ElementAt(i).getTipo()
                        , entrada.ElementAt(i).getFila() + "", entrada.ElementAt(i).getColumna() + "");
                }
                contador++;
            }
           



        }
    }
}
