using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reproductor
{
    public class Canciones
    {
        private String nombre;
        private String artista;
        private String album;
        private String año;
        private String duracion;
        private String url;
        private int repeticion;
        private String NombrePlaylist;

        public Canciones(String nombre, String artista, String album, String año,String duracion,String url, int repeticion,String playlist)
        {
            this.nombre = nombre;
            this.artista = artista;
            this.album = album;
            this.año = año;
            this.duracion = duracion;
            this.url = url;
            this.repeticion = repeticion;
            this.NombrePlaylist = playlist;
        }


        public String getNombre()
        {
            return nombre;
        }
        public String getArtista()
        {
            return artista;
        }
        public String getAlbum()
        {
            return album;
        }
        public String getAño()
        {
            return año;
        }
        public String getDuracion()
        {
            return duracion;
        }
        public String getUrl()
        {
            return url;
        }
        public int getRepes()
        {
            return repeticion;
        }

        public String getPlay()
        {
            return NombrePlaylist;
        }

    }
}
