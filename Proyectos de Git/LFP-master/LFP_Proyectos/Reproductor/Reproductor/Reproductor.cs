using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Reproductor
{
    public partial class Reproductor : Form
    {
        public List<Canciones> canciones;
        int PosicionActual;
       
        int ElementosLista;
       
        int FinalLista;
       
        public Reproductor(List<Canciones> entrada,String nombre)
        {
            InitializeComponent();
            this.canciones = entrada;
            this.Text = nombre;
        }

        private void Reproductor_Load(object sender, EventArgs e)
        {


            //MisCanciones.View = View.Details;

            foreach(Canciones s in canciones)
            {
                int repeticiones = 1;
                while (repeticiones<=s.getRepes())
                {
                    ListViewItem agregar = new ListViewItem(s.getNombre());
                    agregar.SubItems.Add(s.getArtista());
                    agregar.SubItems.Add(s.getAlbum());
                    agregar.SubItems.Add(s.getAño());
                    agregar.SubItems.Add(s.getDuracion());
                    agregar.SubItems.Add(s.getUrl());
                    MisCanciones.Items.Add(agregar);
                    repeticiones++;
                }
                

            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            reproducir.BackColor = Color.Turquoise;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            reproducir.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //posicion donde inicia la reproduccion
           PosicionActual = EncontrarPosicion();

          
     

            //Numero de lista de cancion

            ElementosLista = MisCanciones.Items.Count;


            //Agrego el evento al controlador de Windows media

            MiReproductor.URL = MisCanciones.Items[PosicionActual].SubItems[5].Text;

            IWMPMedia nextVedio = MiReproductor.newMedia(MiReproductor.URL);
            MiReproductor.currentPlaylist.appendItem(nextVedio);

            MiReproductor.Ctlcontrols.play();

            
            //LLevar el control de la posicion 
            


        }

      
        public int EncontrarPosicion()
        {
            int i;
            //con el MisCanciones.SelectedItems!=null verifico si hay un elemento seleccionado
            if (MisCanciones.SelectedItems.Count>0 )
            {
                i = MisCanciones.SelectedIndices[0];
                FinalLista = i;
                //MisCanciones.SelectedIndices[0]; obtengo la posicion del elmento que si esta seleccionado
            }
            else 
            {
                i = 0;
                FinalLista = 0;
            }



            return i;
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            
            //con el MisCanciones.SelectedItems!=null verifico si hay un elemento seleccionado
            if (MisCanciones.SelectedItems.Count>0)
            {
                foreach (ListViewItem lista in MisCanciones.SelectedItems)
                {
                    lista.Remove();
                    ElementosLista--;
                }
               
            }
            else
            {
                MessageBox.Show("Seleccione una cancion", "Informacion", MessageBoxButtons.OK);


            }
        }
        
        public void Siguiente()
        {
            PosicionActual++;

            MiReproductor.URL = MisCanciones.Items[PosicionActual].SubItems[5].Text;

            IWMPMedia nextVedio = MiReproductor.newMedia(MiReproductor.URL);
            MiReproductor.currentPlaylist.appendItem(nextVedio);

            MiReproductor.Ctlcontrols.play();

        }

        private void MiReproductor_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {

               FinalLista++;
                 if (FinalLista <= ElementosLista - 1)
                 {
                    Siguiente();             
                 }
                 else
                 {
                        MessageBox.Show("La Lista ha llegado a su fin", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }

            }
        }

        
    }
}
