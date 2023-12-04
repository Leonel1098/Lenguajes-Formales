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

namespace Reproductor
{
    public partial class Form1 : Form
    {
        public List<Token> tokens;
        public Analizador analisis;
        public String entrada1;
        public static String NombreArchivo;
        public List<Canciones> rolas;
        public Form1()
        {
            InitializeComponent();
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entrada1 = Texto.Text;
            analisis = new Analizador();
            tokens = analisis.Escaner(entrada1);
            // analisis.Mostrar(tokens);
            


            if (analisis.Generar)
            {
                MessageBox.Show("Archivo de entrada invalido","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //generar tabla de tokens 


            }
            else
            {
                MessageBox.Show("Analisis correcto", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Pintar(entrada1);
                rolas = analisis.GenerarPlaylist(tokens);
                int j = 0;
                Console.WriteLine(rolas.Count + "");
                while (j<=rolas.Count-1)
                {
                    List<Canciones> Rolonas = new List<Canciones>();
                    String NoActual = rolas.ElementAt(j).getPlay();
                    for(int i = j; i <= rolas.Count - 1; i++)
                    {

                        if (rolas.ElementAt(i).getPlay().Equals(NoActual))
                        {
                            Rolonas.Add(new Canciones(rolas.ElementAt(i).getNombre(), rolas.ElementAt(i).getArtista(),
                                rolas.ElementAt(i).getAlbum(), rolas.ElementAt(i).getAño(), rolas.ElementAt(i).getDuracion(),
                                rolas.ElementAt(i).getUrl(), rolas.ElementAt(i).getRepes(), rolas.ElementAt(i).getPlay()));
                            j++;
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                    
                    Reproductor form5 = new Reproductor(Rolonas,NoActual);
                    form5.Show();
                    
                }
                analisis.MostrarCanciones(rolas);
                
            }

            


        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AbrirArchivos.ShowDialog() == DialogResult.OK)
            {
                NombreArchivo = AbrirArchivos.FileName;
                TextReader ArchEntrada;
                ArchEntrada = new StreamReader(NombreArchivo,System.Text.Encoding.Default);
                Texto.Text = ArchEntrada.ReadToEnd();
                ArchEntrada.Close();
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(NombreArchivo))
            {
                StreamWriter Escribir = new StreamWriter(NombreArchivo);
                Escribir.Flush();//quitamos todo lo que tenia
                Escribir.Write(Texto.Text);
                Escribir.Close();
                MessageBox.Show("El archivo se guardo Exitosamente","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }else //el archivo no existe
            {
                if (Guardar.ShowDialog() == DialogResult.OK)
                {
                    Stream archivo = Guardar.OpenFile();
                    StreamWriter escribir = new StreamWriter(archivo);
                    escribir.Write(Texto.Text);
                    escribir.Close();
                    archivo.Close();
                    MessageBox.Show("Archivo guardado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Guardar.ShowDialog() == DialogResult.OK)
            {
                Stream archivo = Guardar.OpenFile();
                StreamWriter escribir = new StreamWriter(archivo);
                escribir.Write(Texto.Text);
                escribir.Close();
                archivo.Close();
                MessageBox.Show("Archivo guardado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void tablaTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tokens form2 = new Tokens(tokens);
            form2.Show();
        }

        private void erroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TablaErrores form3 = new TablaErrores(tokens);
            form3.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Datos form4 = new Datos();
            form4.Show();
        }


        public void Pintar(string entrada)
        {
            int inicio = 0;
            int posicion = 0;
            string cadena = "";
            char c;
            for(int i = 0; i <= entrada.Length-1; i++)
            {
                c = entrada[i];
                

                if (char.IsLetter(c)) 
                {
                    char tem = entrada[i + 1];
                    if (char.IsLetter(tem))
                    {
                        cadena += c;
                    }
                    else
                    {
                        cadena += c;

                        if (analisis.PalabraReservada(cadena))
                        {
                            int finCadena = cadena.Length;

                            posicion = posicion + finCadena;

                            inicio = this.Texto.Text.IndexOf(cadena, posicion - finCadena);
                            this.Texto.Select(inicio, cadena.Length);
                            this.Texto.SelectionColor = Color.Purple;
                            this.Texto.SelectionStart = this.Texto.Text.Length;
                            cadena = "";
                        }
                        else
                        {
                            int finCadena = cadena.Length;

                            posicion = posicion + finCadena;

                            inicio = this.Texto.Text.IndexOf(cadena, posicion - finCadena);
                            this.Texto.Select(inicio, cadena.Length);
                            this.Texto.SelectionColor = Color.Black;
                            this.Texto.SelectionStart = this.Texto.Text.Length;
                            cadena = "";
                        }
                    }

                    

                }else if (c=='=')
                {
                    cadena += c;
                    int finCadena = cadena.Length;
                    
                    posicion = posicion + finCadena;

                    inicio = this.Texto.Text.IndexOf(cadena, posicion - finCadena);
                    this.Texto.Select(inicio, cadena.Length);
                    this.Texto.SelectionColor = Color.Yellow;
                    this.Texto.SelectionStart = this.Texto.Text.Length;
                    cadena = "";

                }else if (c=='/')
                {
                    cadena += c;
                    int finCadena = cadena.Length;
                    
                    posicion = posicion + finCadena;

                    inicio = this.Texto.Text.IndexOf(cadena, posicion - finCadena);
                    this.Texto.Select(inicio, cadena.Length);
                    this.Texto.SelectionColor = Color.Blue;
                    this.Texto.SelectionStart = this.Texto.Text.Length;
                    cadena = "";
                }else if (c=='>')
                {
                    cadena += c;
                    int finCadena = cadena.Length;


                    posicion = posicion + finCadena;

                    inicio = this.Texto.Text.IndexOf(cadena, posicion - finCadena);
                    this.Texto.Select(inicio, cadena.Length);
                    this.Texto.SelectionColor = Color.Green;
                    this.Texto.SelectionStart = this.Texto.Text.Length;
                    cadena = "";
                   
                }else if (c=='<')
                {
                    cadena += c;
                    int fincadena = cadena.Length;
                    
                    posicion = posicion + fincadena;

                    inicio = this.Texto.Text.IndexOf(cadena, posicion - fincadena);
                    this.Texto.Select(inicio, cadena.Length);
                    this.Texto.SelectionColor = Color.Red;
                    this.Texto.SelectionStart = this.Texto.Text.Length;
                    cadena = "";
                }
                else if (c=='"')
                {
                    cadena += c;
                    do
                    {
                        
                        i++;
                        c = entrada[i];
                        cadena += c;
                    } while (c!= '"');

                    
                    int finCadena = cadena.Length;


                    posicion = posicion + finCadena;

                    inicio = this.Texto.Text.IndexOf(cadena, posicion - finCadena);
                    this.Texto.Select(inicio, cadena.Length);
                    this.Texto.SelectionColor = Color.SkyBlue;
                    this.Texto.SelectionStart = this.Texto.Text.Length;
                    cadena = "";
                }
                else if(c==' ')
                {
                    posicion++;
                    cadena = "";
                }else if (c=='\n')
                {
                    
                    cadena = "";
                    posicion++;
                }else if (c=='\t')
                {
                    cadena = "";
                    posicion++;
                }
                
               
            }

        }
    }
}
