using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//***Si ingresan una letra sin " antes puede ser una palabra reservada
namespace AnalizadorLexico
{
    public class Token { 

        public enum Tipos //para llevar el control de los tokens definidos
        {
           
            NUMERO, 
            COMILLAS,
            LLAVE_IZQUIERDA,
            LLAVE_DERECHA,
            DOS_PUNTOS,
            PUNTO_COMA,
            COMA,
            CADENA,
            PALABRA_RESERVADA,
            LETRA,
            DESCONOCIDO



           

        }
        //al final me piden devolver, el lexema, el tipo, fila, hace falta poner columna
        
        public string lexemaValido;
        public Tipos tokens;
        public int fila;
        public int columna;

        //Constructor 
        public Token(String lexema,Tipos token, int fila,int columna)
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
        //Metodo para devolver de que tipo es el lexema 
        public string getTipo()
        {
            switch (tokens)
            {
                
                case Tipos.NUMERO:
                    {
                        return "Numero";
                    }
                
                case Tipos.LLAVE_IZQUIERDA:
                    {
                        return "Llave Izquierda";
                    }
                case Tipos.LLAVE_DERECHA:
                    {
                        return "Llave Derecha";
                    }
                case Tipos.DOS_PUNTOS:
                    {
                        return "Dos puntos";
                    }
                case Tipos.PUNTO_COMA:
                    {
                        return "Punto Coma";
                    }
                case Tipos.COMA:
                    {
                        return "Coma";
                    }
                case Tipos.CADENA:
                    {
                        return "Cadena";
                    }
                case Tipos.PALABRA_RESERVADA:
                    {
                        return "Palabra Reservada";
                    }
                case Tipos.DESCONOCIDO:
                    {
                        return "Desconocido";
                    }
                case Tipos.LETRA:
                    {
                        return "Letras";
                    }
                case Tipos.COMILLAS:
                    {
                        return "Comillas";
                    }
                default:
                    {
                        return "Otro";
                    }
            }


        }


    }
}
