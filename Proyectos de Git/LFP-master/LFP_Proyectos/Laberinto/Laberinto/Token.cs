using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Token
    {
        public enum Tipos
        {
            ULTIMO,
            CORCHETE_IZQ,
            CORCHETE_DER,
            DOS_PUNTOS,
            LLAVE_IZQ,
            LLAVE_DER,
            PUNTO_COMA,
            PUNTO,
            COMA,
            PARENTESIS_IZQ,
            PARENTESIS_DER,
            IGUAL,
            SUMA,
            RESTA,
            MULTIPLICACION,
            DIVISION,
            PALABRA_RESERVADAS,
            VARIABLE,
            IDENTIFICADOR,
            NUMERO,
            LETRA,

            principal,
            intervalo,
            nivel,
            dimensiones,
            inicio_personaje,
            ubicacion_salida,
            pared,
            casilla,
            personaje,
            paso,
            caminata,
            enemigo,
            
            Varias_casillas,

            OTRO
        }

        public string lexemaValido;
        public Tipos tokens;
        public int fila;
        public int columna;

        //Constructor 
        public Token(String lexema, Tipos token, int fila, int columna)
        {
            this.lexemaValido = lexema;
            this.tokens = token;
            this.fila = fila;
            this.columna = columna;
        }

        //metodo para devolver el lexema guardado
        public String getLexema()
        {
            return lexemaValido;
        }
        //Metodo para devolver la fila
        public int getFila()
        {
            return fila;
        }
        //metodo para devolver la columan
        public int getColumna()
        {
            return columna;
        }
        public Tipos GetTipos()
        {
            return tokens;
        }
       
        //Metodo para devolver de que tipo es el lexema 
        public string getTipo()
        {
            switch (tokens)
            {

                case Tipos.CORCHETE_IZQ:
                    {
                        return "Corchete izquierda";
                    }

                case Tipos.CORCHETE_DER:
                    {
                        return "Corchete derecha";
                    }
                case Tipos.DOS_PUNTOS:
                    {
                        return "Dos puntos";
                    }
                case Tipos.LLAVE_IZQ:
                    {
                        return "Llave izquierda";
                    }
                case Tipos.LLAVE_DER:
                    {
                        return "Llave derecha";
                    }
                case Tipos.PUNTO_COMA:
                    {
                        return "Punto coma";
                    }
                case Tipos.PUNTO:
                    {
                        return "Punto";
                    }
                case Tipos.COMA:
                    {
                        return "Coma";
                    }
                case Tipos.PARENTESIS_IZQ:
                    {
                        return "Parentesis izquierda";
                    }
                case Tipos.PARENTESIS_DER:
                    {
                        return "Parentesis derecha";
                    }
                case Tipos.IGUAL:
                    {
                        return "Igual";
                    }
               
                case Tipos.PALABRA_RESERVADAS:
                    {
                        return "Palabra Reservada";
                    }
                case Tipos.VARIABLE:
                    {
                        return "Variable";
                    }
                case Tipos.IDENTIFICADOR:
                    {
                        return "Identificador";
                    }

                case Tipos.NUMERO:
                    {
                        return "Numero";
                    }
                case Tipos.LETRA:
                    {
                        return "Letra";
                    }
                case Tipos.SUMA:
                    {
                        return "Suma";
                        
                    }
                case Tipos.RESTA:
                    {
                        return "Resta";
                        
                    }
                case Tipos.MULTIPLICACION:
                    {
                        return "Multiplicacion";

                    }
                case Tipos.DIVISION:
                    {
                        return "Division";

                    }
                case Tipos.principal:
                    {
                        return "Principal";

                    }
                case Tipos.intervalo:
                    {
                        return "Intervalo";

                    }
                case Tipos.nivel:
                    {
                        return "nivel";

                    }
                case Tipos.dimensiones:
                    {
                        return "Dimensiones";

                    }
                case Tipos.inicio_personaje:
                    {
                        return "Inicio Personaje";

                    }
                case Tipos.ubicacion_salida:
                    {
                        return "Ubiacion Salid";

                    }
                case Tipos.pared:
                    {
                        return "Pared";

                    }
                case Tipos.casilla:
                    {
                        return "Casilla";

                    }
                case Tipos.personaje:
                    {
                        return "Personaje";

                    }
                case Tipos.paso:
                    {
                        return "Paso";

                    }
                case Tipos.caminata:
                    {
                        return "Caminate";

                    }
                case Tipos.enemigo:
                    {
                        return "Enemigo";

                    }
                case Tipos.Varias_casillas:
                    {
                        return "Varias casillas";

                    }
                default:
                    {
                        return "Desconocido";
                    }
            }
        }
    }
}
