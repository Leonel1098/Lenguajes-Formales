using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reproductor
{
    public class Token
    {

        public enum TipoToken
        {
            LETRA,
            NUMERO,
            PALABRA_RESERVADA,
            CADENA,
            MAYOR_QUE,
            MENOR_QUE,
            IGUAL,
            DIAGONAL,
            PALABRAS_SIMBOLOS,
            DESCONOCIDO
        }
        //variables 
        public String lexema;
        public TipoToken toke;
        public int fila;
        public int columna;

        public Token(String lexema,TipoToken tokens,int fila,int columna)
        {
            this.lexema = lexema;
            this.toke = tokens;
            this.fila = fila;
            this.columna = columna;
        }


        //metodo para devolver el lexema guardado
        public String getLexema()
        {
            return lexema;
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

        public string getTipo()
        {
            switch (toke)
            {
                case TipoToken.CADENA:
                    {
                        return "CADENA";
                    }

                case TipoToken.PALABRA_RESERVADA:
                    {
                        return "PALABRA RESERVADA";
                    }

                case TipoToken.NUMERO:
                    {
                        return "NUMERO";
                    }

                case TipoToken.MAYOR_QUE:
                    {
                        return "MAYOR QUE";
                    }
                case TipoToken.MENOR_QUE:
                    {
                        return "MENOR QUE";
                    }
                case TipoToken.DIAGONAL:
                    {
                        return "DIAGONAL";
                    }
                case TipoToken.IGUAL:
                    {
                        return "IGUAL";
                    }
                case TipoToken.LETRA:
                    {
                        return "LETRAS";
                    }
                case TipoToken.PALABRAS_SIMBOLOS:
                    {
                        return "Palabras_Simbolos";
                    }
                case TipoToken.DESCONOCIDO:
                    {
                        return "Desconocido";
                    }
                default:
                    {
                        return "Otro";
                    }
            }
        }



    }
}
