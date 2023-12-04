using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class AnalizadorSintactico
    {
        public Token.Tipos Preanalisis ;
        public int posicion;
        public List<Token> lista;
        public static Boolean errorSintactico;
       
        public AnalizadorSintactico(List<Token> tokem)
        {
            AnalizadorSintactico.errorSintactico = true;
            this.lista = tokem;
            lista.Add(new Token("#", Token.Tipos.ULTIMO, 0, 0));
            posicion = 0;
            Preanalisis = lista.ElementAt(posicion).GetTipos();
            Inicio();
            
        }
        //metodo que me sirve para saber si hay algun error
        
        public void Match(Token.Tipos tipos)
        {
            if (Preanalisis != tipos)
            {
                //posicion--;
                AnalizadorLexico.errores.Add(new ManejoErrores(lista.ElementAt(posicion).getLexema(), "Sintactico", "se esperaba "+tipos,
                    lista.ElementAt(posicion).getFila(), lista.ElementAt(posicion).getColumna()));
                Console.WriteLine("Se esperaba " + tipos);

                AnalizadorSintactico.errorSintactico = false;
                
            }
           

            if (Preanalisis!=Token.Tipos.ULTIMO)
            {
                posicion++;
                Preanalisis = lista.ElementAt(posicion).GetTipos();
            }

            if (Preanalisis == Token.Tipos.ULTIMO)
            {
                Console.WriteLine("Se ha finalizado ");
            }
        }


        public void Inicio()
        {
            Match(Token.Tipos.CORCHETE_IZQ);
            Match(Token.Tipos.principal);
            Match(Token.Tipos.CORCHETE_DER);
            Match(Token.Tipos.DOS_PUNTOS);
            Match(Token.Tipos.LLAVE_IZQ);

            //mando a llmar al metodo del cuerpo principal

            CuerpoPrincipal();

            Match(Token.Tipos.LLAVE_DER);
        }
        //PRIMERA PASADA  DEL CUERPO PRINCIPAL
        //*************************************************************PRINCIPAL**************************************************************
        public void CuerpoPrincipal()
        {
            Match(Token.Tipos.CORCHETE_IZQ);

            if (Preanalisis==Token.Tipos.intervalo)
            {
                Match(Token.Tipos.intervalo);
                Match(Token.Tipos.CORCHETE_DER);
                Match(Token.Tipos.DOS_PUNTOS);
                Bloque_Intervalo();
                RepetirCuerpoPrincipal();
                
            }else if(Preanalisis == Token.Tipos.nivel)
            {
                Match(Token.Tipos.nivel);
                Match(Token.Tipos.CORCHETE_DER);
                Match(Token.Tipos.DOS_PUNTOS);
                Bloque_Nivel();
                RepetirCuerpoPrincipal();

            }
            else if (Preanalisis == Token.Tipos.enemigo)
            {
                Match(Token.Tipos.enemigo);
                Match(Token.Tipos.CORCHETE_DER);
                Match(Token.Tipos.DOS_PUNTOS);
                BloqueEnemigo();
                RepetirCuerpoPrincipal();
            }
            else if (Preanalisis == Token.Tipos.personaje)
            {
                Match(Token.Tipos.personaje);
                Match(Token.Tipos.CORCHETE_DER);
                Match(Token.Tipos.DOS_PUNTOS);
                BloquePersonaje();
                RepetirCuerpoPrincipal();
            }
            else
            {
                Match(Token.Tipos.PALABRA_RESERVADAS);
                Preanalisis = Token.Tipos.CORCHETE_DER;
                Match(Token.Tipos.CORCHETE_DER);
                Preanalisis = Token.Tipos.DOS_PUNTOS;
                Match(Token.Tipos.DOS_PUNTOS);
                //probar si viene otro bloque
                
                RepetirCuerpoPrincipal();
            }
            
        }
        //DEFINICION DEL INTERVALO
        public void Bloque_Intervalo()
        {
            Match(Token.Tipos.PARENTESIS_IZQ);
            Match(Token.Tipos.NUMERO);
            Match(Token.Tipos.PARENTESIS_DER);
            Match(Token.Tipos.PUNTO_COMA);
        }
        //N PASADAS DEL CUERPO PRINCIPAL********
        public void RepetirCuerpoPrincipal()
        {
            if (Preanalisis == Token.Tipos.CORCHETE_IZQ)
            {
                Match(Token.Tipos.CORCHETE_IZQ);
                if (Preanalisis == Token.Tipos.intervalo)
                {
                    Match(Token.Tipos.intervalo);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    Bloque_Intervalo();
                    RepetirCuerpoPrincipal();

                }
                else if (Preanalisis == Token.Tipos.nivel)
                {
                    Match(Token.Tipos.nivel);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    Bloque_Nivel();
                    RepetirCuerpoPrincipal();

                }
                else if (Preanalisis == Token.Tipos.enemigo)
                {
                    Match(Token.Tipos.enemigo);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    BloqueEnemigo();
                    RepetirCuerpoPrincipal();
                }
                else if (Preanalisis == Token.Tipos.personaje)
                {
                    Match(Token.Tipos.personaje);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    BloquePersonaje();
                    RepetirCuerpoPrincipal();
                }

                else
                {
                    Match(Token.Tipos.PALABRA_RESERVADAS);
                    Preanalisis = Token.Tipos.CORCHETE_DER;
                    Match(Token.Tipos.CORCHETE_DER);
                    Preanalisis = Token.Tipos.DOS_PUNTOS;
                    Match(Token.Tipos.DOS_PUNTOS);
                    //definicion de otro bloque 

                    RepetirCuerpoNivel();

                }
            }

        }
        //*************************************************************--- FIN DE PRINCIPAL----**************************************************************


        //*******************************************************************--- INICIO DE BLOQUE NIVEL********************************************************
        public void Bloque_Nivel()
        {
            Match(Token.Tipos.LLAVE_IZQ);
            CuerpoNivel();
            Match(Token.Tipos.LLAVE_DER);
        }
        //METODO QUE REALIZAR LA PARTE DEL BLOQUE NIVEL 
        public void CuerpoNivel()
        {
            Match(Token.Tipos.CORCHETE_IZQ);

            //verifico que bloque puede venir
            if (Preanalisis==Token.Tipos.dimensiones)
            {
                Match(Token.Tipos.dimensiones);
                Match(Token.Tipos.CORCHETE_DER);
                Match(Token.Tipos.DOS_PUNTOS);
                BloqueDimensiones();
                RepetirCuerpoNivel();

            }
            else if (Preanalisis == Token.Tipos.inicio_personaje)
            {
                Match(Token.Tipos.inicio_personaje);
                Match(Token.Tipos.CORCHETE_DER);
                Match(Token.Tipos.DOS_PUNTOS);
                BloqueDimensiones();
                RepetirCuerpoNivel();
            }
            else if (Preanalisis==Token.Tipos.ubicacion_salida)
            {
                Match(Token.Tipos.ubicacion_salida);
                Match(Token.Tipos.CORCHETE_DER);
                Match(Token.Tipos.DOS_PUNTOS);
                BloqueDimensiones();
                RepetirCuerpoNivel();
            }
            else if (Preanalisis==Token.Tipos.pared)
            {
                Match(Token.Tipos.pared);
                Match(Token.Tipos.CORCHETE_DER);
                Match(Token.Tipos.DOS_PUNTOS);
                Match(Token.Tipos.LLAVE_IZQ);
                BloquePared();
                Match(Token.Tipos.LLAVE_DER);
                RepetirCuerpoNivel();
            }
            else
            {
                Match(Token.Tipos.PALABRA_RESERVADAS);
                Preanalisis = Token.Tipos.CORCHETE_DER;
                Match(Token.Tipos.CORCHETE_DER);
                Preanalisis = Token.Tipos.DOS_PUNTOS;
                Match(Token.Tipos.DOS_PUNTOS);
               
                RepetirCuerpoNivel();
            }
        }
        //METODO QUE SE ENCARGA DE REPETIR ALGUM BLOQUE DEL CUERPO NIVEL 
        public void RepetirCuerpoNivel()
        {
            if (Preanalisis == Token.Tipos.CORCHETE_IZQ)
            {
                Match(Token.Tipos.CORCHETE_IZQ);

                //verifico que bloque puede venir
                if (Preanalisis == Token.Tipos.dimensiones)
                {
                    Match(Token.Tipos.dimensiones);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    BloqueDimensiones();
                    RepetirCuerpoNivel();
                }
                else if (Preanalisis == Token.Tipos.inicio_personaje)
                {
                    Match(Token.Tipos.inicio_personaje);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    BloqueDimensiones();
                    RepetirCuerpoNivel();
                }
                else if (Preanalisis == Token.Tipos.ubicacion_salida)
                {
                    Match(Token.Tipos.ubicacion_salida);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    BloqueDimensiones();
                    RepetirCuerpoNivel();

                }
                else if (Preanalisis == Token.Tipos.pared)
                {
                    Match(Token.Tipos.pared);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    Match(Token.Tipos.LLAVE_IZQ);
                    BloquePared();
                    Match(Token.Tipos.LLAVE_DER);
                    RepetirCuerpoNivel();
                }
                else
                {
                    Match(Token.Tipos.PALABRA_RESERVADAS);
                    Preanalisis = Token.Tipos.CORCHETE_DER;
                    Match(Token.Tipos.CORCHETE_DER);
                    Preanalisis = Token.Tipos.DOS_PUNTOS;
                    Match(Token.Tipos.DOS_PUNTOS);
                    //probar si viene otro bloque
                    
                    RepetirCuerpoNivel();
                }
            }
        }

        public void BloqueDimensiones()
        {
            Match(Token.Tipos.PARENTESIS_IZQ);
            Match(Token.Tipos.NUMERO);
            Match(Token.Tipos.COMA);
            Match(Token.Tipos.NUMERO);
            Match(Token.Tipos.PARENTESIS_DER);
            Match(Token.Tipos.PUNTO_COMA);
        }
        //*******************************************************************--- FIN DE BLOQUE NIVEL-----********************************************************



        //*******************************************************************--- INICIO DE BLOQUE PARED********************************************************
        //METODO PARA EL BLOQUE PARED

        public void BloquePared()
        {
            if (Preanalisis == Token.Tipos.CORCHETE_IZQ)
            {
                Match(Token.Tipos.CORCHETE_IZQ);
                if (Preanalisis == Token.Tipos.casilla)
                {
                    Match(Token.Tipos.casilla);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    Espacio();
                    RepPared();
                }
                else if (Preanalisis == Token.Tipos.Varias_casillas)
                {
                    Match(Token.Tipos.Varias_casillas);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    Espacios();
                    RepPared();

                }
                else if (Preanalisis == Token.Tipos.VARIABLE)
                {
                    Match(Token.Tipos.VARIABLE);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    DeclaracionVariable();
                    RepPared();
                }else
                {
                    Match(Token.Tipos.PALABRA_RESERVADAS);
                    Preanalisis = Token.Tipos.CORCHETE_DER;
                    Match(Token.Tipos.CORCHETE_DER);
                    Preanalisis = Token.Tipos.DOS_PUNTOS;
                    Match(Token.Tipos.DOS_PUNTOS);
                    RepPared();
                }
            }
            else if (Preanalisis==Token.Tipos.IDENTIFICADOR)
            {
                Match(Token.Tipos.IDENTIFICADOR);
                
                Match(Token.Tipos.DOS_PUNTOS);
                Match(Token.Tipos.IGUAL);
                AsignarVariable();
                RepPared();
            }
            
        }
        public void RepPared()
        {
            if (Preanalisis==Token.Tipos.CORCHETE_IZQ)
            {
                Match(Token.Tipos.CORCHETE_IZQ);
                if (Preanalisis == Token.Tipos.casilla)
                {
                    Match(Token.Tipos.casilla);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    Espacio();
                    RepPared();
                }
                else if (Preanalisis == Token.Tipos.Varias_casillas)
                {
                    Match(Token.Tipos.Varias_casillas);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    Espacios();
                    RepPared();

                }
                else if (Preanalisis == Token.Tipos.VARIABLE)
                {
                    Match(Token.Tipos.VARIABLE);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    DeclaracionVariable();
                    RepPared();

                }else
                {
                    Match(Token.Tipos.PALABRA_RESERVADAS);
                    Preanalisis = Token.Tipos.CORCHETE_DER;
                    Match(Token.Tipos.CORCHETE_DER);
                    Preanalisis = Token.Tipos.DOS_PUNTOS;
                    Match(Token.Tipos.DOS_PUNTOS);
                    //definicion de otro bloque 
                    RepPared();
                }

            }
            else if (Preanalisis == Token.Tipos.IDENTIFICADOR)
            {
                Match(Token.Tipos.IDENTIFICADOR);
                
                Match(Token.Tipos.DOS_PUNTOS);
                Match(Token.Tipos.IGUAL);
                AsignarVariable();
                RepPared();
            }
        }
        public void NUmId()
        {
            if (Preanalisis==Token.Tipos.NUMERO)
            {
                Match(Token.Tipos.NUMERO);
            }else if (Preanalisis==Token.Tipos.IDENTIFICADOR)
            {
                Match(Token.Tipos.IDENTIFICADOR);
            }
            else
            {
                Match(Token.Tipos.NUMERO);
                posicion++;
                Preanalisis = lista.ElementAt(posicion).GetTipos();
                //agregar un mensaje para agregar error 
            }
        }
        public void Espacio()
        {
            Match(Token.Tipos.PARENTESIS_IZQ);
            NUmId();
            Match(Token.Tipos.COMA);
            NUmId();
            Match(Token.Tipos.PARENTESIS_DER);
            Match(Token.Tipos.PUNTO_COMA);
        }
        public void DosPuntos()
        {
            Match(Token.Tipos.PUNTO);
            Match(Token.Tipos.PUNTO);
        }
        public void Espacios()
        {
            Match(Token.Tipos.PARENTESIS_IZQ);
            NUmId();
            if (Preanalisis==Token.Tipos.PUNTO)
            {
                DosPuntos();
                NUmId();
                Match(Token.Tipos.COMA);
                NUmId();
                if (Preanalisis==Token.Tipos.PARENTESIS_DER)
                {
                    Match(Token.Tipos.PARENTESIS_DER);
                    
                }else if (Preanalisis==Token.Tipos.PUNTO)
                {
                    DosPuntos();
                    NUmId();
                    Match(Token.Tipos.PARENTESIS_DER);
                }else
                {
                    Match(Token.Tipos.PUNTO);
                    posicion++;
                    Preanalisis = lista.ElementAt(posicion).GetTipos();
                }
            }else if (Preanalisis==Token.Tipos.COMA)
            {
                Match(Token.Tipos.COMA);
                NUmId();
                DosPuntos();
                NUmId();
                Match(Token.Tipos.PARENTESIS_DER);

            }
            else
            {
                Match(Token.Tipos.PUNTO);
                posicion++;
                Preanalisis = lista.ElementAt(posicion).GetTipos();
            }
            Match(Token.Tipos.PUNTO_COMA);

        }
        
        public void DeclaracionVariable()
        {
            Match(Token.Tipos.IDENTIFICADOR);
            RepetirID();
            Match(Token.Tipos.PUNTO_COMA);
        }
        public void RepetirID()
        {
            if (Preanalisis==Token.Tipos.COMA)
            {
                Match(Token.Tipos.COMA);
                if (Preanalisis==Token.Tipos.IDENTIFICADOR)
                {
                    Match(Token.Tipos.IDENTIFICADOR);
                    RepetirID();
                }
                else
                {
                    Match(Token.Tipos.IDENTIFICADOR);
                }
                
            }
        }
        public void AsignarVariable()
        {
            
            NUmId();
            if (Preanalisis == Token.Tipos.PUNTO_COMA)
            {
                Match(Token.Tipos.PUNTO_COMA);
            }
            else
            {
                if (Preanalisis == Token.Tipos.SUMA)
                {
                    Match(Token.Tipos.SUMA);
                    NUmId();
                    Match(Token.Tipos.PUNTO_COMA);
                }
                else if (Preanalisis == Token.Tipos.RESTA)
                {
                    Match(Token.Tipos.RESTA);
                    NUmId();
                    Match(Token.Tipos.PUNTO_COMA);
                }
                else if (Preanalisis == Token.Tipos.MULTIPLICACION)
                {
                    Match(Token.Tipos.MULTIPLICACION);
                    NUmId();
                    Match(Token.Tipos.PUNTO_COMA);
                }
                else if (Preanalisis == Token.Tipos.DIVISION)
                {
                    Match(Token.Tipos.DIVISION);
                    NUmId();
                    Match(Token.Tipos.PUNTO_COMA);
                }
                else
                {
                    Match(Token.Tipos.SUMA);
                }
            }
           
        }

        //*******************************************************************--- FIN DE BLOQUE PARED********************************************************


        //*******************************************************************--- INICIO DEL BLOQUE ENEMIGO----********************************************************

        public void BloqueEnemigo()
        {
            Match(Token.Tipos.LLAVE_IZQ);
            CuerpoEnemigo();
            OtraCaminata();
            Match(Token.Tipos.LLAVE_DER);
        }
        public void CuerpoEnemigo()
        {
            if (Preanalisis == Token.Tipos.CORCHETE_IZQ)
            {
                Match(Token.Tipos.CORCHETE_IZQ);
                Match(Token.Tipos.caminata);
                Match(Token.Tipos.CORCHETE_DER);
                Match(Token.Tipos.DOS_PUNTOS);
                Match(Token.Tipos.PARENTESIS_IZQ);
                Caminar();
                Match(Token.Tipos.PARENTESIS_DER);
                Match(Token.Tipos.PUNTO_COMA);

            }

        }
        public void Caminar()
        {
            Match(Token.Tipos.NUMERO);
            if (Preanalisis==Token.Tipos.PUNTO)
            {
                Match(Token.Tipos.PUNTO);
                Match(Token.Tipos.PUNTO);
                Match(Token.Tipos.NUMERO);
                Match(Token.Tipos.COMA);
                Match(Token.Tipos.NUMERO);

            }else if (Preanalisis==Token.Tipos.COMA)
            {
                Match(Token.Tipos.COMA);
                Match(Token.Tipos.NUMERO);
                Match(Token.Tipos.PUNTO);
                Match(Token.Tipos.PUNTO);
                Match(Token.Tipos.NUMERO);
            }else {
                Match(Token.Tipos.PUNTO);
                //poner un errror que pueden venir dos cosas distintas
            }
        }
        public void OtraCaminata()
        {
            if (Preanalisis == Token.Tipos.CORCHETE_IZQ)
            {
                Match(Token.Tipos.CORCHETE_IZQ);
                Match(Token.Tipos.caminata);
                Match(Token.Tipos.CORCHETE_DER);
                Match(Token.Tipos.DOS_PUNTOS);
                Match(Token.Tipos.PARENTESIS_IZQ);
                Caminar();
                Match(Token.Tipos.PARENTESIS_DER);
                Match(Token.Tipos.PUNTO_COMA);
                OtraCaminata();
            }
        }

        //*******************************************************************--- FIN DEL BLOQUE ENEMIGO----********************************************************

        //*******************************************************************--- INICIO DEL BLOQUE PERSONAJE----********************************************************

        public void BloquePersonaje()
        {
            Match(Token.Tipos.LLAVE_IZQ);
            CuerpoPersonaje();
            Match(Token.Tipos.LLAVE_DER);
        }

        public void CuerpoPersonaje()
        {
            if (Preanalisis==Token.Tipos.CORCHETE_IZQ)
            {
                Match(Token.Tipos.CORCHETE_IZQ);

                if (Preanalisis == Token.Tipos.paso)
                {
                    Match(Token.Tipos.paso);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    Paso();
                    RepetirCuerpoPersonaje();
                }
                else if (Preanalisis == Token.Tipos.caminata)
                {
                    Match(Token.Tipos.caminata);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    Moverse();
                    RepetirCuerpoPersonaje();
                }
                else if (Preanalisis == Token.Tipos.VARIABLE)
                {
                    Match(Token.Tipos.VARIABLE);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    DeclaracionVariable();
                    RepetirCuerpoPersonaje();
                }
                else
                {
                    Match(Token.Tipos.PALABRA_RESERVADAS);
                }
            }else if (Preanalisis==Token.Tipos.IDENTIFICADOR)
            {
                Match(Token.Tipos.IDENTIFICADOR);
                Match(Token.Tipos.DOS_PUNTOS);
                Match(Token.Tipos.IGUAL);
                AsignarVariable();
                RepetirCuerpoPersonaje();
            }
            else
            {
                ///agregar un error 
                Match(Token.Tipos.CORCHETE_IZQ);
            }
        
        }
        public void RepetirCuerpoPersonaje()
        {
            if (Preanalisis == Token.Tipos.CORCHETE_IZQ)
            {
                Match(Token.Tipos.CORCHETE_IZQ);

                if (Preanalisis == Token.Tipos.paso)
                {
                    Match(Token.Tipos.paso);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    Paso();
                    RepetirCuerpoPersonaje();

                }
                else if (Preanalisis == Token.Tipos.caminata)
                {
                    Match(Token.Tipos.caminata);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    Moverse();
                    RepetirCuerpoPersonaje();
                }
                else if (Preanalisis == Token.Tipos.VARIABLE)
                {
                    Match(Token.Tipos.VARIABLE);
                    Match(Token.Tipos.CORCHETE_DER);
                    Match(Token.Tipos.DOS_PUNTOS);
                    AsignarVariable();
                    RepetirCuerpoPersonaje();
                }
                else
                {
                    Match(Token.Tipos.PALABRA_RESERVADAS);
                }
            }
            else if (Preanalisis == Token.Tipos.IDENTIFICADOR)
            {
                Match(Token.Tipos.IDENTIFICADOR);
                Match(Token.Tipos.DOS_PUNTOS);
                Match(Token.Tipos.IGUAL);
                AsignarVariable();
                RepetirCuerpoPersonaje();
            }
        }

        public void Paso()
        {
            Match(Token.Tipos.PARENTESIS_IZQ);
            NUmId();
            Match(Token.Tipos.COMA);
            NUmId();
            Match(Token.Tipos.PARENTESIS_DER);
            Match(Token.Tipos.PUNTO_COMA);
        }
        public void Moverse()
        {
            Match(Token.Tipos.PARENTESIS_IZQ);
            NUmId();
            if (Preanalisis == Token.Tipos.PUNTO)
            {
                Match(Token.Tipos.PUNTO);
                Match(Token.Tipos.PUNTO);
                NUmId();
                Match(Token.Tipos.COMA);
                NUmId();

            }
            else if (Preanalisis == Token.Tipos.COMA)
            {
                Match(Token.Tipos.COMA);
                NUmId();
                Match(Token.Tipos.PUNTO);
                Match(Token.Tipos.PUNTO);
                NUmId();
            }
            else
            {
                Match(Token.Tipos.PUNTO);
                //poner un errror que pueden venir dos cosas distintas
            }
            Match(Token.Tipos.PARENTESIS_DER);
            Match(Token.Tipos.PUNTO_COMA);
        }
    }
}
