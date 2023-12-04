using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorLexico
{
    public partial class Form1 : Form
    {
        public string NombreArchivo;
        public static string entrada1;


        public Form1()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(areaTra.TextLength);
            Form1.entrada1 = areaTra.Text;
            //Console.WriteLine(entrada1);
            
            Archivos archivos = new Archivos();
            //string entrada1 = entrada.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            //Console.WriteLine(entrada1);
            Analizador analisi = new Analizador();
            List<Token> tokens = analisi.entrada(entrada1);
            //Console.Write(tokens.Count());
            //analisi.Mostrar(tokens);

            

            if (analisi.Generar)
            {

                MessageBox.Show("Archivo de entrada invalido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                archivos.GenerarTablaErrores(tokens);
                archivos.GenerarTablaToken(tokens);

            }
            else
            {

                MessageBox.Show("Analisis Correcto", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Lista con los nodos
                Pintar(tokens);


                List<Nodos> nuevo = analisi.AgregarNodo(tokens);
                Console.WriteLine(nuevo.Count);

                //analisi.MostrarNodos(nuevo);

                //Console.WriteLine(Analizador.titulo);
                //Creacion del archivo dot++++++++++


                String salida = archivos.ArchivoDot(nuevo);

                String direccion = Path.GetDirectoryName(salida);

                //Creacion de la iamgen++++++++++++

                Console.WriteLine(direccion);
                String Imagen = archivos.EjecutarConsola(direccion);
                String ruta_image = Path.GetFullPath(Imagen);
                //Creacion del archivo html con el organigrama++++++++++

                archivos.GenerarHtml(ruta_image);
                //creacion de la tabla de tokens++++++++++++++


                archivos.GenerarTablaToken(tokens);


                //Pintar parte del archivo



            }


        }
        //Para abrir el archivo
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
        //Metodo para guardar Archivos
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

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
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

        public  void Pintar(List<Token> entrada )
        {
            int inicio =0;
            int posicion = 0;
            //Console.WriteLine(Form1.entrada1);
            

            for (int i = 0; i < entrada.Count; i++)
            {
                if (entrada.ElementAt(i).getTipo().Equals("Palabra Reservada"))
                {
                    string cadena = entrada.ElementAt(i).getLexema();
                    int finCadena = entrada.ElementAt(i).getLexema().Length;


                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);

                    if (inicio != -1)
                    {
                        this.areaTra.Select(inicio, cadena.Length);
                        this.areaTra.SelectionColor = Color.Blue;
                        this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    }
                    
                }
                else if (entrada.ElementAt(i).getTipo().Equals("Dos puntos"))
                {
                    string cadena = entrada.ElementAt(i).getLexema();
                    int finCadena = entrada.ElementAt(i).getLexema().Length;


                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);
                    if (inicio != -1)
                    {
                        this.areaTra.Select(inicio, cadena.Length);
                        this.areaTra.SelectionColor = Color.Purple;
                        this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    }
                    

                } else if (entrada.ElementAt(i).getTipo().Equals("Cadena"))
                {
                    string cadena = entrada.ElementAt(i).getLexema();
                    int finCadena = entrada.ElementAt(i).getLexema().Length;


                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);

                    if (inicio != -1)
                    {
                        this.areaTra.Select(inicio, cadena.Length);
                        this.areaTra.SelectionColor = Color.Green;
                        this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    }

                    

                } else if (entrada.ElementAt(i).getTipo().Equals("Llave Izquierda") | entrada.ElementAt(i).getTipo().Equals("Llave Derecha"))
                {
                    string cadena = entrada.ElementAt(i).getLexema();
                    int finCadena = entrada.ElementAt(i).getLexema().Length;


                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);

                    if (inicio != -1)
                    {
                        this.areaTra.Select(inicio, cadena.Length);
                        this.areaTra.SelectionColor = Color.Pink;
                        this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    }
                    

                }else if (entrada.ElementAt(i).getTipo().Equals("Punto Coma"))
                {
                    string cadena = entrada.ElementAt(i).getLexema();
                    int finCadena = entrada.ElementAt(i).getLexema().Length;


                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);

                    if (inicio != -1)
                    {
                        this.areaTra.Select(inicio, cadena.Length);
                        this.areaTra.SelectionColor = Color.Red;
                        this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    }
                    
                }else if (entrada.ElementAt(i).getTipo().Equals("Coma"))
                {
                    string cadena = entrada.ElementAt(i).getLexema();
                    int finCadena = entrada.ElementAt(i).getLexema().Length;


                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);
                    if (inicio != -1)
                    {
                        this.areaTra.Select(inicio, cadena.Length);
                        this.areaTra.SelectionColor = Color.SkyBlue;
                        this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    }
                    
                }else if (entrada.ElementAt(i).getTipo().Equals("Numero"))
                {
                    string cadena = entrada.ElementAt(i).getLexema();
                    int finCadena = entrada.ElementAt(i).getLexema().Length;


                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);
                    if (inicio != -1)
                    {
                        this.areaTra.Select(inicio, cadena.Length);
                        this.areaTra.SelectionColor = Color.Yellow;
                        this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    }
                    
                }else if (entrada.ElementAt(i).getTipo().Equals("Desconocido"))
                {
                    string cadena = entrada.ElementAt(i).getLexema();
                    int finCadena = entrada.ElementAt(i).getLexema().Length;


                    posicion = posicion + finCadena;

                    inicio = this.areaTra.Text.IndexOf(cadena, posicion - finCadena);
                    if (inicio != -1)
                    {
                        this.areaTra.Select(inicio, cadena.Length);
                        this.areaTra.SelectionColor = Color.Black;
                        this.areaTra.SelectionStart = this.areaTra.Text.Length;
                    }
                    
                }



            } 
            
            
            


        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
