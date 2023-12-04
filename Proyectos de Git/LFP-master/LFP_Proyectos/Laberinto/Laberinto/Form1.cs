using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public String NombreArchivo;
        public  String entrada;
        public static List<Token> tokens;
        public AnalizadorLexico analizador;
        public Juego juego;
        
        public Form1()
        {
            InitializeComponent();
            tokens = new List<Token>();
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            analizador = new AnalizadorLexico();

            entrada = areaTra.Text;
            tokens = analizador.AnalizadorLex(entrada);
          


            if (AnalizadorLexico.Error)
            {
                Reportes reportes = new Reportes();
                reportes.Tabla(tokens);
                PintarLexemas(entrada);
                AnalizadorSintactico sintactico = new AnalizadorSintactico(tokens);
                
            }else
            {
                Reportes reportes = new Reportes();
                reportes.TablaErrores(AnalizadorLexico.errores);
                PintarLexemas(entrada);
            }

            if (AnalizadorSintactico.errorSintactico)
            {
                

            }
            else
            {
                Reportes reportes = new Reportes();
                reportes.TablaErrores(AnalizadorLexico.errores);
            }

        }



        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (explorador.ShowDialog() == DialogResult.OK)
            {
                //TextReader para leer y TextWrite para escribir 

                NombreArchivo = explorador.FileName;//Nombre del Archivo Abierto

                StreamReader ArchEntrada;
                ArchEntrada = new StreamReader(NombreArchivo);
                areaTra.Text = ArchEntrada.ReadToEnd(); //readToEnd para leer todo
                ArchEntrada.Close();

            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //posiblemente vamos a quitar el if para que solo se guarden archivos que nunca han sido guardado
            if (File.Exists(NombreArchivo))
            {

                StreamWriter SobreEs = new StreamWriter(NombreArchivo);
                SobreEs.Flush();//Metodo Flush para limpiar
                SobreEs.Write(areaTra.Text);
                SobreEs.Close();
                MessageBox.Show("El archivo se guardo en:" + NombreArchivo, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                if (Guardar.ShowDialog() == DialogResult.OK)
                {

                    Stream archivo = Guardar.OpenFile();
                    StreamWriter escribir = new StreamWriter(archivo);
                    escribir.Write(areaTra.Text);
                    escribir.Close();
                    archivo.Close();
                    MessageBox.Show("Archivo Guardado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GuardarComo.ShowDialog() == DialogResult.OK)
            {

                Stream archivo = GuardarComo.OpenFile();

                StreamWriter escribir = new StreamWriter(archivo);
                escribir.Write(areaTra.Text);
                escribir.Close();
                archivo.Close();
                MessageBox.Show("Archivo Guardado Con Exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tableroJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pasa a generar el juego
            juego = new Juego();
            List<Variables> var = juego.Variables(tokens);

            //MANDAMOS A OBTENER LOS DATOS
            juego.GuardarDatos(tokens, var);

            //obtener el intervalo

            int intervalo = juego.getIntervalo();
            int TamaX = juego.getTamaX();
            int TamaY=juego.getTamaY();
            int InicioX = juego.getInicioX();
            int InicioY = juego.getInicioY();
            int FinX = juego.getFinX();
            int FinY = juego.getFinY();
            List<Cordenadas> recorrido = juego.getRecorrido();
            List<Cordenadas> obstaculos = juego.getObstaculos();
            List<Enemigo> enemigos = juego.getEnemigo();
            int TotalEn = juego.getTotalEn();

            VistaJuego vistaJuego = new VistaJuego(intervalo,TamaX,TamaY,InicioX,InicioY,FinX,FinY,recorrido,obstaculos,enemigos,TotalEn);
            vistaJuego.Show();
        }

        public void PintarLexemas(String entrada)
        {
            int inicio = 0;
            int posicion = 0;
            string cadena = "";
            char c;

            for (int i=0;i<=entrada.Length-1;i++)
            {
                c = entrada[i];



                if (char.IsLetter(c) | c == '_')
                {
                    char tem = entrada[i + 1];
                    if (char.IsLetter(tem) | tem=='_' | char.IsDigit(tem))
                    {
                        cadena += c;
                    }
                    else
                    {
                        cadena += c;

                        if (PalabrasReservadas(cadena))
                        {
                            int finCadena = cadena.Length;

                            posicion = posicion + finCadena;

                            inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);
                            this.areaTra.Select(inicio, cadena.Length);
                            this.areaTra.SelectionColor = Color.Blue;
                            this.areaTra.SelectionStart = this.areaTra.Text.Length;
                            cadena = "";
                        }
                        else
                        {
                            
                            int finCadena = cadena.Length;

                            posicion = posicion + finCadena;

                            inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);
                            this.areaTra.Select(inicio, cadena.Length);
                            this.areaTra.SelectionColor = Color.Black;
                            this.areaTra.SelectionStart = this.areaTra.Text.Length;
                            cadena = "";
                        }
                    }
                }else if (char.IsDigit(c))
                {
                    char tem = entrada[i + 1];
                    if (char.IsDigit(tem))
                    {
                        cadena += c;
                    }else
                    {
                        cadena += c;
                        int finCadena = cadena.Length;

                        posicion = posicion + finCadena;

                        inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);
                        this.areaTra.Select(inicio, cadena.Length);
                        this.areaTra.SelectionColor = Color.Red;
                        this.areaTra.SelectionStart = this.areaTra.Text.Length;
                        cadena = "";
                    }
                }else if (c==':')
                {
                    cadena += c;
                    int finCadena = cadena.Length;

                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);
                    this.areaTra.Select(inicio, cadena.Length);
                    this.areaTra.SelectionColor = Color.Yellow;
                    this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    cadena = "";
                }else if (c==';')
                {
                    cadena += c;
                    int finCadena = cadena.Length;

                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);
                    this.areaTra.Select(inicio, cadena.Length);
                    this.areaTra.SelectionColor = Color.Purple;
                    this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    cadena = "";
                }else if (c=='{' | c=='}')
                {
                    cadena += c;
                    int finCadena = cadena.Length;

                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);
                    this.areaTra.Select(inicio, cadena.Length);
                    this.areaTra.SelectionColor = Color.Pink;
                    this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    cadena = "";
                }else if (c=='[' | c==']')
                {
                    cadena += c;
                    int finCadena = cadena.Length;

                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);
                    this.areaTra.Select(inicio, cadena.Length);
                    this.areaTra.SelectionColor = Color.SkyBlue;
                    this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    cadena = "";
                }
                else if (c == ' ')
                {
                    posicion++;
                    cadena = "";
                }
                else if (c == '\n')
                {

                    cadena = "";
                    posicion++;
                }
                else if (c == '\t')
                {
                    cadena = "";
                    posicion++;
                }else if (c==',' | c=='.' | c=='=' | c=='(' | c==')' | c=='+' | c == '-' |c == '/' | c == '*')
                {
                    cadena += c;
                    int finCadena = cadena.Length;

                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);
                    this.areaTra.Select(inicio, cadena.Length);
                    this.areaTra.SelectionColor = Color.Violet;
                    this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    cadena = "";
                }
            }

        }
        public bool PalabrasReservadas(string entrada)
        {
            bool valor = false;
            String[] reservadas = { "Principal","intervalo","nivel","dimensiones","inicio_personaje",
            "ubicacion_salida","pared","casilla",
            "personaje","paso","caminata","enemigo","Ubicación_Salida","Varias_Casillas"};

            for (int i=0;i<=reservadas.Length-1;i++)
            {
                if (reservadas[i].Equals(entrada, StringComparison.CurrentCultureIgnoreCase))
                {
                    valor = true;
                    break;
                }
            }

            return valor;
        }
    }
}
