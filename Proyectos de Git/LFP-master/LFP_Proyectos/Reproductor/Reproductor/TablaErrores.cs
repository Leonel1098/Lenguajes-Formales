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
    public partial class TablaErrores : Form
    {
        public List<Token> entrada;
        public TablaErrores(List<Token> nueva)
        {
            InitializeComponent();
            this.entrada = nueva;
        }

        private void TablaErrores_Load(object sender, EventArgs e)
        {
            tablaError.Columns.Add("no", "No");
            tablaError.Columns.Add("lexema", "Lexema");
            tablaError.Columns.Add("tipo", "Tipo");
            tablaError.Columns.Add("fila", "Fila");
            tablaError.Columns.Add("columna", "Columna");
            int contador = 1;
            for (int i = 0; i <= entrada.Count - 1; i++)
            {

                if (entrada.ElementAt(i).getTipo().Equals("Desconocido"))
                {
                    tablaError.Rows.Add(contador + "", entrada.ElementAt(i).getLexema(), entrada.ElementAt(i).getTipo()
                       , entrada.ElementAt(i).getFila() + "", entrada.ElementAt(i).getColumna() + "");
                }
                
                contador++;
            }
        }
    }
}
