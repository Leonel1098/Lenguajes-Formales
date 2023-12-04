using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo_Animacion
{
    // Programa desarrollado por César Javier Solares Orozco
    // Auxiliar de cátedra del curso Lenguajes Formales y de Programación
    // Facultad de Ingeniería
    // Universidad de San Carlos de Guatemala

    public partial class Form1 : Form
    {
        // Variable que almacena la posición de la casilla en x
        public int posicion_x = 1;
        // Variable que almacena la posición de la casilla en y
        public int posicion_y = 1;

        public int[,] obstaculos = new int[,] { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 1, 1, 0, 0, 0, 1, 1, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
        { 1, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // Seteamos doble buffer para que las imagenes no parpadeen al refrescar el Form
            this.Size = new System.Drawing.Size(516, 538); // Cambiamos el tamaño para que quepa la imagen de fondo que mide 500 x 500

        }


        private void animacion(List<Coordenada> lista)
        {
            foreach (var c in lista)
            {
                // Actualizamos la posición en x segun la coordenada del elemento de la lista
                posicion_x = c.x;
                // Actualizamos la posición en y segun la coordenada del elemento de la lista
                posicion_y = c.y;

                

                // Esperamos 200 milisegundos
                Thread.Sleep(150);
                // Refrescamos el formulario para que se repinte el fondo y la casilla en sus nuevas coordenadas
                this.Refresh();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Llenamos la lista de coordenadas para formar la ruta que va a recorrer la casilla
            List<Coordenada> lista = new List<Coordenada>();
            lista.Add(new Coordenada(2, 1));
            lista.Add(new Coordenada(3, 1));
            lista.Add(new Coordenada(4, 1));
            lista.Add(new Coordenada(5, 1));
            lista.Add(new Coordenada(6, 1));
            lista.Add(new Coordenada(7, 1));
            lista.Add(new Coordenada(8, 1));
            lista.Add(new Coordenada(8, 2));
            lista.Add(new Coordenada(8, 3));
            lista.Add(new Coordenada(7, 3));
            lista.Add(new Coordenada(6, 3));
            lista.Add(new Coordenada(5, 3));
            lista.Add(new Coordenada(4, 3));
            lista.Add(new Coordenada(3, 3));
            lista.Add(new Coordenada(2, 3));
            lista.Add(new Coordenada(1, 3));
            lista.Add(new Coordenada(1, 4));
            lista.Add(new Coordenada(1, 5));
            lista.Add(new Coordenada(2, 5));
            lista.Add(new Coordenada(3, 5));
            lista.Add(new Coordenada(4, 5));
            lista.Add(new Coordenada(5, 5));
            lista.Add(new Coordenada(6, 5));
            lista.Add(new Coordenada(7, 5));
            lista.Add(new Coordenada(8, 5));
            lista.Add(new Coordenada(8, 6));
            lista.Add(new Coordenada(8, 7));
            lista.Add(new Coordenada(8, 8));
            lista.Add(new Coordenada(7, 8));
            lista.Add(new Coordenada(6, 8));
            lista.Add(new Coordenada(5, 8));
            lista.Add(new Coordenada(4, 8));
            lista.Add(new Coordenada(3, 8));
            lista.Add(new Coordenada(2, 8));
            lista.Add(new Coordenada(1, 8));



            // Ejecutamos la animación
            animacion(lista);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Cada vez que llamemos al método refresh del Form, se ejecutará este método, que es el del evento paint
            // Definimos un objeto Graphics que se usará para dibujar sobre el formulario
            Graphics g = e.Graphics;

            // Dibujamos el fondo
            Bitmap imagen = new Bitmap("fondo.png");
            g.DrawImage(imagen, 0, 0);

            // Dibujamos la casilla según el lugar en el que esté
            imagen = new Bitmap("casilla.png");
            g.DrawImage(imagen, 50 * posicion_x, 50 * posicion_y); // Lo multiplico por 50 porque la imagen casilla es de 50*50

            
            // Dibujamos los obstaculos
            imagen = new Bitmap("obstaculo.png");
            for (var i = 0; i <= obstaculos.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= obstaculos.GetUpperBound(1); j++)
                {
                    if ((obstaculos[i, j] == 1))
                        g.DrawImage(imagen, 50 * j, 50 * i);// Lo multiplico por 50 porque la imagen obstaculo es de 50*50
                }
            }
        }
    }
}
