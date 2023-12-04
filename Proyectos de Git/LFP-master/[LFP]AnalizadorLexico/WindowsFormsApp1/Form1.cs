using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtentrada.Text = "4.125 * (5 + 6.1781 * (8 / 2 ^ 3) - 7) - 1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string entrada = txtentrada.Text;
            // Proceso de análisis léxico
            AnalizadorLexico lex = new AnalizadorLexico();
            List<Token> lTokens = lex.escanear(entrada);
            // Luego del analisis léxico obtenemos como salida una lista de tokens
            // en este caso es lTokens, ahora procedemos a imprimirla para mostrar en 
            // consola su contenido.
            lex.imprimirLista(lTokens);
        }

        private void txtentrada_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
