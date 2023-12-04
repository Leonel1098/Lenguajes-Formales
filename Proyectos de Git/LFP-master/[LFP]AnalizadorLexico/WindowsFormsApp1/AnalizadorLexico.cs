using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;

namespace WindowsFormsApp1
{
    public class AnalizadorLexico
    {
        // Variable que representa la lista de tokens
        private List<Token> salida;
        // Variable que representa el estado actual
        private int estado;
        // Variable que representa el lexema que actualmente se esta acumulando
        private string auxLex;
        public List<Token> escanear(string entrada)
        {
            // Le agrego caracter de fin de cadena porque hay lexemas que aceptan con 
            // el primer caracter del siguiente lexema y si este caracter no existe entonces
            // perdemos el lexema
            entrada = entrada + "#";
            salida = new List<Token>();
            estado = 0;
            auxLex = "";
            char c;
            // Ciclo que recorre de izquierda a derecha caracter por caracter la cadena de entrada
            for (int i = 0; i <= entrada.Length - 1; i += 1)
            {
                c = entrada[i];
                // Select en el que cada caso representa cada uno de los estados del conjunto de estados
                switch (estado)
                {
                    case 0:
                        {
                            // Para cada caso (o estado) hay un if elseif elseif ... else que representan el conjunto de transiciones que 
                            // salen de dicho estado, por ejemplo, estando en el estado 0 si el caracter reconocido es un dígito entonces, 
                            // pasamos al estado 1 y acumulamos el caracter reconocido en auxLex, que es el auxiliar de lexemas.
                            if (char.IsDigit(c))
                            {
                                estado = 1;
                                auxLex += c;
                            }
                            else if ((c == '+'))
                            {
                                auxLex += c;
                                addToken(Token.Tipo.SIGNO_MAS);
                            }
                            else if ((c == '-'))
                            {
                                auxLex += c;
                                addToken(Token.Tipo.SIGNO_MEN);
                            }
                            else if ((c == '*'))
                            {
                                auxLex += c;
                                addToken(Token.Tipo.SIGNO_POR);
                            }
                            else if ((c == '/'))
                            {
                                auxLex += c;
                                addToken(Token.Tipo.SIGNO_DIV);
                            }
                            else if ((c == '^'))
                            {
                                auxLex += c;
                                addToken(Token.Tipo.SIGNO_POW);
                            }
                            else if ((c == '('))
                            {
                                auxLex += c;
                                addToken(Token.Tipo.PARENTESIS_IZQ);
                            }
                            else if ((c == ')'))
                            {
                                auxLex += c;
                                addToken(Token.Tipo.PARENTESIS_DER);
                            }
                            else if (char.IsLetter(c))
                            {
                                auxLex += c;
                                estado = 4;

                            }

                            else if ((c == '#' & i == entrada.Length - 1))
                                // Hemos concluido el análisis léxico.
                                Console.WriteLine("Hemos concluido el análisis léxico satisfactoriamente");
                            else
                            {
                                Console.WriteLine("Error léxico con: " + c);
                                estado = 0;
                            }

                            break;
                        }

                    case 1:
                        {
                            if ((char.IsDigit(c)))
                            {
                                estado = 1;
                                auxLex += c;
                            }
                            else if ((c == '.'))
                            {
                                estado = 2;
                                auxLex += c;
                            }
                            else
                            {
                                addToken(Token.Tipo.NUMERO_ENTERO);
                                i -= 1;
                            }

                            break;
                        }

                    case 2:
                        {
                            if ((char.IsDigit(c)))
                            {
                                estado = 3;
                                auxLex += c;
                            }
                            else
                            {
                                Console.WriteLine("Error léxico con: " + c + " despues del punto decimal se espera uno o más números.");
                                estado = 0;
                            }

                            break;
                        }

                    case 3:
                        {
                            if ((char.IsDigit(c)))
                            {
                                estado = 3;
                                auxLex += c;
                            }
                            else
                            {
                                addToken(Token.Tipo.NUMERO_REAL);
                                i -= 1;
                            }

                            break;
                        }
                    case 4:
                        {
                            if ((char.IsLetter(c)))
                            {
                                estado = 4;
                                auxLex += c;
                            }
                            else
                            {

                         
                                    addToken(Token.Tipo.PALABRA);
                                    i -= 1;
                            


                            }
                            break;
                        }

                        }
            }
            return salida;
        }
        private void addToken(Token.Tipo tipo)
        {
            salida.Add(new Token(tipo, auxLex));
            auxLex = "";
            estado = 0;
        }
        public void imprimirLista(List<Token> l)
        {
            foreach (Token t in l)
                Console.WriteLine(t.getTipoEnString() + "<-->" + t.getValor());
        }
    }
}