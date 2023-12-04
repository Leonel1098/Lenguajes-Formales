using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reproductor
{
    public class Analizador
    {
        /* Variables para generar propiedades de la playlist*/
        public String NombrePlay ;
        public  List<Canciones> play;

        public static int NoPlaylist;


        //para generar
        public Boolean Generar;
        //lista token
        public List<Token> salida;
        public int estado;
        public String lexema;
        public int fila;
        public int columna;


        public List<Token> Escaner(String entrada)
        {
            Generar = false;
            columna = 1;
            fila = 1;
            entrada = entrada + "#";
            estado = 0;
            lexema="";
            salida = new List<Token>();
            char c;

            for(int i = 0; i <= entrada.Length - 1; i++)
            {
                c = entrada[i];

                switch (estado)
                {
                    case 0:
                        {
                            if (char.IsLetter(c))
                            {
                                
                                lexema += c;
                                estado = 1;
                                columna++;
                            }else if (c == '<')
                            {
                                
                                lexema += c;
                                AgregarToken(Token.TipoToken.MENOR_QUE);
                                columna++;
                            }else if (c == '=')
                            {
                                lexema += c;
                                AgregarToken(Token.TipoToken.IGUAL);
                                columna++;
                            }else if (c == '/')
                            {
                                lexema += c;
                                AgregarToken(Token.TipoToken.DIAGONAL);
                                columna++;
                            }else if (c == '>')
                            {
                                lexema += c;
                                AgregarToken(Token.TipoToken.MAYOR_QUE);
                                columna++;
                                estado = 5;
                            }else if(c== '"')
                            {
                                lexema += c;
                                estado = 3;
                                columna++;
                            }else if (c == (char)10)
                            {
                                estado = 0;
                                fila++;
                                columna = 1;
                            }else if (c == (char)13)
                            {
                                estado = 0;
                            }else if(c==' ')
                            {
                                columna++;
                                estado = 0;
                            }else if (c=='#' & i==entrada.Length-1)
                            {
                                Console.WriteLine("analisis correcto");
                            }else if (c=='\t')
                            {
                                estado = 0;
                            }
                            else
                            {
                                lexema += c;
                                AgregarToken(Token.TipoToken.DESCONOCIDO);
                                columna++;
                                Generar = true;
                                
                            }
                            
                            break;
                        }
                    case 1:
                        {
                            if (char.IsLetter(c) )
                            {
                                lexema += c;
                                estado = 1;
                                columna++;
                            }
                            else if (c == '=')
                            {
                                if (PalabraReservada(lexema))
                                {
                                    AgregarToken(Token.TipoToken.PALABRA_RESERVADA);
                                    lexema += c;
                                    AgregarToken(Token.TipoToken.IGUAL);
                                }
                                else
                                {
                                    AgregarToken(Token.TipoToken.LETRA);
                                    lexema += c;
                                    AgregarToken(Token.TipoToken.IGUAL);
                                    Generar = true;
                                }
                                columna++;
                            }
                            else if (c == '/')
                            {
                                if (PalabraReservada(lexema))
                                {
                                    AgregarToken(Token.TipoToken.PALABRA_RESERVADA);
                                    lexema += c;
                                    AgregarToken(Token.TipoToken.DIAGONAL);
                                }
                                else
                                {
                                    AgregarToken(Token.TipoToken.LETRA);
                                    lexema += c;
                                    AgregarToken(Token.TipoToken.DIAGONAL);
                                    Generar = true;
                                }
                                columna++;
                            }
                            else if (c == '"')
                            {
                                if (PalabraReservada(lexema))
                                {
                                    AgregarToken(Token.TipoToken.PALABRA_RESERVADA);
                                    lexema += c;
                                    estado = 3;
                                }
                                else
                                {
                                    AgregarToken(Token.TipoToken.LETRA);
                                    lexema += c;
                                    estado = 3;
                                    Generar = true;
                                }
                                columna++;
                            }
                            else if (c == '>')
                            {
                                if (PalabraReservada(lexema))
                                {
                                    AgregarToken(Token.TipoToken.PALABRA_RESERVADA);
                                    lexema += c;
                                    AgregarToken(Token.TipoToken.MAYOR_QUE);
                                    estado = 5;
                                }
                                else
                                {
                                    AgregarToken(Token.TipoToken.LETRA);
                                    AgregarToken(Token.TipoToken.MAYOR_QUE);
                                    lexema += c;
                                    estado = 5;
                                    Generar = true;
                                }
                                columna++;
                            }
                            else if (c == '<')
                            {
                                if (PalabraReservada(lexema))
                                {
                                    AgregarToken(Token.TipoToken.PALABRA_RESERVADA);
                                    lexema += c;
                                    AgregarToken(Token.TipoToken.MENOR_QUE);
                                    
                                }
                                else
                                {
                                    AgregarToken(Token.TipoToken.LETRA);
                                    lexema += c;
                                    AgregarToken(Token.TipoToken.MENOR_QUE);
                                    Generar = true;
                                }
                                columna++;
                            }
                            else if (c == ' ')
                            {
                                if (PalabraReservada(lexema))
                                {
                                    AgregarToken(Token.TipoToken.PALABRA_RESERVADA);
                                    
                                }
                                else
                                {
                                    AgregarToken(Token.TipoToken.LETRA);
                                    Generar = true;
                                }
                                columna++;
                            }
                            else if (c==(char)10)
                            {
                                if (PalabraReservada(lexema))
                                {
                                    AgregarToken(Token.TipoToken.PALABRA_RESERVADA);
                                   
                                }
                                else
                                {
                                    AgregarToken(Token.TipoToken.LETRA);
                                    Generar = true;
                                }
                                fila++;
                                columna = 1;
                            }
                            else if (c ==(char)13)
                            {
                                if (PalabraReservada(lexema))
                                {
                                    AgregarToken(Token.TipoToken.PALABRA_RESERVADA);
                                    
                                }
                                else
                                {
                                    AgregarToken(Token.TipoToken.LETRA);
                                    Generar = true;
                                }
                                fila++;
                                columna = 1;
                            }
                            else
                            {
                                AgregarToken(Token.TipoToken.LETRA);
                                lexema += c;
                                AgregarToken(Token.TipoToken.DESCONOCIDO);

                                columna++;
                                Generar = true;
                            }
                            break;
                        }
                    case 3:
                        {
                            if(c== ' ')
                            {
                                lexema += c;
                                columna++;

                            }else if (c == (char)10)
                            {
                                lexema += c;
                                fila++;
                                columna = 1;
                            }else if (c == (char)13)
                            {
                                estado = 5;
                            }else if(c!= '"')
                            {
                                lexema += c;
                                columna++;
                            }else if(c== '"')
                            {
                                lexema += c;
                                AgregarToken(Token.TipoToken.CADENA);
                            }
                            break;
                        }
                    case 5:
                        {
                            if(c==' ')
                            {
                                //lexema += c;
                                //columna++;
                                //estado = 5;

                                if (PalabraReservada(lexema))
                                {
                                    AgregarToken(Token.TipoToken.PALABRA_RESERVADA);
                                    estado = 5;
                                    Generar = true;
                                }
                                else
                                {
                                    AgregarToken(Token.TipoToken.PALABRAS_SIMBOLOS);
                                    estado = 5;
                                    
                                }
                                columna++;




                            }
                            else if (c == (char)10)
                            {
                                
                                estado = 5;
                                fila++;
                                columna = 1;
                            }else if (c == (char)13)
                            {
                                estado = 5;
                            }else if (c != '<')
                            {
                                lexema += c;
                                columna++;
                            }else if (c == '<')
                            {
                                if(String.IsNullOrEmpty(lexema) | lexema.Equals("\n") | lexema.Equals(" ") | lexema.Equals("\r"))
                                {
                                    lexema = "";
                                    lexema += c;
                                    AgregarToken(Token.TipoToken.MENOR_QUE);
                                }
                                else
                                {
                                    AgregarToken(Token.TipoToken.PALABRAS_SIMBOLOS);
                                    lexema += c;
                                    AgregarToken(Token.TipoToken.MENOR_QUE);
                                }
                                columna++;
                            }

                            break;
                        }
                }
            }
            return salida;
        }


        //para agregar tokens 

        public void AgregarToken(Token.TipoToken tipo)
        {
            salida.Add(new Token(lexema, tipo, fila, columna));
            lexema = "";
            estado = 0;
        }
        public void Mostrar(List<Token> aux)
        {
            foreach (Token to in aux)
                Console.WriteLine(to.getLexema() + "--->" + to.getTipo() + "--->" + to.getFila() + "---->>" + to.getColumna());
        }

        //comprobar palabras reservadas

        public Boolean PalabraReservada(String entrada)
        {
            bool valor = false;
            String[] reservadas = { "playlist","nombre","cancion","url","artista"
            ,"album","álbum","año","duracion","repeticion","nveces"};

            for(int i = 0; i <= reservadas.Length - 1; i++)
            {
                if(reservadas[i].Equals(entrada, StringComparison.CurrentCultureIgnoreCase)){

                    valor = true;
                    break;
                }
                else
                {
                    valor = false;
                }
            }
            return valor;
        }
        

        public List<Canciones> GenerarPlaylist(List<Token> entrada1)
        {
            List<Token> entrada = entrada1;
            play = new List<Canciones>();
            Analizador.NoPlaylist = 0;
            int j = 0;
            while (j <= entrada.Count - 1)
            {
                if (entrada.ElementAt(j).getLexema().Equals("playlist", StringComparison.CurrentCultureIgnoreCase))
                {
                    for (int k = j; k <= entrada.Count - 1; k++)
                    {
                        if (entrada.ElementAt(k).getTipo().Equals("CADENA"))
                        {
                            NombrePlay = entrada.ElementAt(k).getLexema().Trim(new char[] { '"' });
                            j = k;
                            break;
                        }
                    }
                    
                    for (int i = j; i <= entrada.Count - 1; i++)
                    {

                        if (entrada.ElementAt(i).getLexema().Equals("Repeticion", StringComparison.CurrentCultureIgnoreCase)
                            && entrada.ElementAt(i+1).getLexema().Equals("nveces", StringComparison.CurrentCultureIgnoreCase))
                        {

                            int repeticion = int.Parse(entrada.ElementAt(i + 3).getLexema().Trim(new char[] { '"' }));

                            //Metodo para agregar canciones
                            int nuevaPosicion = AgregarCancionesR(entrada, (i + 6), repeticion);
                            i = nuevaPosicion;
                        }
                        else if (entrada.ElementAt(i).getLexema().Equals("Cancion", StringComparison.CurrentCultureIgnoreCase))
                        {
                            int repeticion = 1;
                            int nuevaPosicion = CancionesSimples(entrada, i, repeticion);
                            i = nuevaPosicion;

                        }else if (entrada.ElementAt(i).getLexema().Equals("playlist", StringComparison.CurrentCultureIgnoreCase))
                        {

                            break;
                        }
                        j = i;
                    }

                }
                j++;
            }
                
                
            

            return play;

        }

        public int AgregarCancionesR(List<Token> token,int posicion,int repeticion)
        {
            int b = 0;
            for(int i = posicion; i <= token.Count - 1; i++)
            {
                String actual = token.ElementAt(i).getLexema();
                if (token.ElementAt(i).getLexema().Equals("Cancion", StringComparison.CurrentCultureIgnoreCase)){
                    b = i + 3;
                    string url = token.ElementAt(b).getLexema().Trim(new char[] { '"' });
                    b = b + 3;
                    string artista = token.ElementAt(b).getLexema().Trim(new char[] { '"' });
                    b = b + 3;
                    string album = token.ElementAt(b).getLexema().Trim(new char[] { '"' });
                    b = b + 3;
                    string año = token.ElementAt(b).getLexema().Trim(new char[] { '"' });
                    b = b + 3;
                    string duracion = token.ElementAt(b).getLexema().Trim(new char[] { '"' });
                    b = b + 2;

                    String nombre = "";
                    while (token.ElementAt(b).getTipo().Equals("Palabras_Simbolos"))
                    {
                        nombre = nombre+" "+token.ElementAt(b).getLexema();
                        b++;
                    }
                    

                    play.Add(new Canciones(nombre, artista, album, año, duracion, url, repeticion,NombrePlay));

                    b = b + 4;
                    i = b;
                }
                else if(token.ElementAt(i).getLexema().Equals("/"))
                {
                    break;
                }
            }
            return b+2;
            
        }

        public int CancionesSimples(List<Token> token, int posicion, int repeticion)
        {
            int b;
            b = posicion + 3;
            string url = token.ElementAt(b).getLexema().Trim(new char[] { '"' });
            b = b + 3;
            string artista = token.ElementAt(b).getLexema().Trim(new char[] { '"' });
            b = b + 3;
            string album = token.ElementAt(b).getLexema().Trim(new char[] { '"' });
            b = b + 3;
            string año = token.ElementAt(b).getLexema().Trim(new char[] { '"' });
            b = b + 3;
            string duracion = token.ElementAt(b).getLexema().Trim(new char[] { '"' });
            b = b + 2;

            String nombre = "";
            while (token.ElementAt(b).getTipo().Equals("Palabras_Simbolos"))
            {
                nombre = nombre + " " + token.ElementAt(b).getLexema();
                b++;
            }

            play.Add(new Canciones(nombre, artista, album, año, duracion, url, repeticion,NombrePlay));

            return b+3;


        }
        public void MostrarCanciones(List<Canciones> aux)
        {
            foreach (Canciones to in aux)
                Console.WriteLine(to.getNombre() + "--->" + to.getArtista() + "--->" + to.getAlbum() + "---->>" + to.getAño()+"----->"+ to.getDuracion()+"--->"+ to.getUrl()+"--->"+ to.getRepes()+"---"+to.getPlay());
        }

    }
}
