using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class AnalizadorLexico
    {
        public static List<ManejoErrores> errores;
        public AnalizadorLexico()
        {
            
        }
        public static Token.Tipos Tipo;
        public static bool Error;
        public List<Token> salida;
        public int estado;
        public string lexema;
        public int fila;
        public int columna;
        
       

        public List<Token> AnalizadorLex(String entrada)
        {
            AnalizadorLexico.errores = new List<ManejoErrores>();
            Error = true;
            salida = new List<Token>();
            entrada = entrada + "#";
            estado = 0;
            lexema = "";
            fila = 1;
            columna = 0;
            char c;

            for (int i=0;i<=entrada.Length-1;i++)
            {

                c = entrada[i];

                switch (estado)
                {
                    case 0:
                        {
                            if (char.IsLetter(c))
                            {
                                estado = 1;
                                lexema+= c;
                                columna++;

                            }else if (char.IsNumber(c))
                            {
                                estado = 5;
                                lexema += c;
                                columna++;
                            }else if (c=='[')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.CORCHETE_IZQ);
                            }
                            else if (c == ']')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.CORCHETE_DER);
                            }
                            else if (c == ':')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.DOS_PUNTOS);
                            }
                            else if (c == '{')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.LLAVE_IZQ);
                            }
                            else if (c == '}')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.LLAVE_DER);
                            }
                            else if (c == ';')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.PUNTO_COMA);
                            }
                            else if (c == '.')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.PUNTO);
                            }
                            else if (c == ',')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.COMA);
                            }
                            else if (c == '(')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.PARENTESIS_IZQ);
                            }
                            else if (c == ')')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.PARENTESIS_DER);
                            }
                            else if (c == '=')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.IGUAL);
                            }
                            else if (c == '+')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.SUMA);
                            }
                            else if (c == '-')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.RESTA);
                            }
                            else if (c == '*')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.MULTIPLICACION);
                            }
                            else if (c == '/')
                            {
                                lexema += c;
                                columna++;
                                AgregarToken(Token.Tipos.DIVISION);
                            }
                            else if (c == (char)10)
                        {
                            estado = 0;
                            fila++;
                            columna = 1;
                        }
                        else if (c == (char)13)
                        {
                            estado = 0;
                        }
                        else if (c == ' ')
                        {
                            columna++;
                            estado = 0;
                        }
                        else if (c == '#' & i == entrada.Length - 1)
                        {
                            Console.WriteLine("analisis Lexico Correcto");
                        }
                        else if (c == '\t')
                        {
                            estado = 0;
                        }
                        else
                        {
                            lexema += c;
                                AnalizadorLexico.errores.Add(new ManejoErrores(lexema, "lexico", "Elemento lexico Desconocido", fila, columna));
                            AgregarToken(Token.Tipos.OTRO);
                                
                            columna++;
                            Error = false;

                        }

                        break;
                        }
                    case 1:
                        {
                            if (char.IsLetter(c))
                            {
                                estado = 1;
                                lexema += c;
                                columna++;
                            }else if (c=='_')
                            {
                                estado = 2;
                                lexema += c;
                                columna++;
                            }else if (char.IsDigit(c))
                            {
                                estado = 4;
                                lexema += c;
                                columna++;
                            }
                            else
                            {
                                if (PalabrasReservadas(lexema))
                                {
                                    AgregarToken(AnalizadorLexico.Tipo);
                                    i--;
                                }else if (lexema.Equals("Variable", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    AgregarToken(Token.Tipos.VARIABLE);
                                    i--;
                                }
                                else
                                {
                                    AgregarToken(Token.Tipos.IDENTIFICADOR);
                                    i--;
                                }

                            }
                            break;
                        }
                    case 2:
                        {
                            if (char.IsLetter(c))
                            {
                                estado = 3;
                                lexema += c;
                                columna++;
                            }
                            else
                            {
                                AnalizadorLexico.errores.Add(new ManejoErrores(lexema, "lexico", "Elemento lexico Desconocido", fila, columna));
                                AgregarToken(Token.Tipos.OTRO);
                                Error = false;
                                i--;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (char.IsLetter(c))
                            {
                                estado = 3;
                                lexema += c;
                            }
                            else
                            {
                                if (PalabrasReservadas(lexema))
                                {
                                    AgregarToken(AnalizadorLexico.Tipo);
                                    i--;
                                }
                                else
                                {
                                    AnalizadorLexico.errores.Add(new ManejoErrores(lexema, "lexico", "Elemento lexico Desconocido", fila, columna));
                                    AgregarToken(Token.Tipos.OTRO);
                                    Error = false;
                                    i--;
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            if (char.IsDigit(c))
                            {
                                estado = 4;
                                lexema += c;
                                columna++;

                            }else if (char.IsLetter(c)){
                                estado = 4;
                                lexema += c;
                                columna++;
                            }
                            else
                            {
                                AgregarToken(Token.Tipos.IDENTIFICADOR);
                                i--;
                            }
                            break;
                        }
                    case 5:
                        {
                            if (char.IsDigit(c))
                            {
                                estado = 5;
                                lexema += c;
                                columna++;
                            }
                            else
                            {
                                AgregarToken(Token.Tipos.NUMERO);
                                i--;
                            }
                            break;
                        }

                }
                
            }
            return salida;
        }

        public void AgregarToken(Token.Tipos tipo)
        {
            salida.Add(new Token(lexema, tipo, fila, columna));
            lexema = "";
            estado = 0;
        }

        public bool PalabrasReservadas(String lexema)
        {
            bool valor = false;
            String[] reservadas = { "Principal","intervalo","nivel","dimensiones","inicio_personaje",
            "ubicacion_salida","pared","casilla",
            "personaje","paso","caminata","enemigo","Ubicación_Salida","Varias_Casillas"};

            
            if (reservadas[0].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.principal;
                    valor = true;
                    
            }else if (reservadas[1].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.intervalo;
                valor = true;
            }
            else if (reservadas[2].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.nivel;
                valor = true;
            }
            else if(reservadas[3].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.dimensiones;
                valor = true;
            }
            else if (reservadas[4].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.inicio_personaje; ;
                valor = true;
            }
            else if (reservadas[5].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.ubicacion_salida;
                valor = true;
            }
            else if (reservadas[6].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.pared;
                valor = true;
            }
            else if (reservadas[7].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.casilla;
                valor = true;
            }
            else if (reservadas[8].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.personaje;
                valor = true;
            }
            else if (reservadas[9].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.paso;
                valor = true;
            }
            else if (reservadas[10].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.caminata;
                valor = true;
            }
            else if (reservadas[11].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.enemigo;
                valor = true;
            }
            else if (reservadas[12].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.ubicacion_salida;
                valor = true;
            }
            else if (reservadas[13].Equals(lexema, StringComparison.CurrentCultureIgnoreCase))
            {
                AnalizadorLexico.Tipo = Token.Tipos.Varias_casillas;
                valor = true;
            }
            
            else
                {
                    valor = false;
                }
            
            return valor;
        }

        


        public void Mostrar(List<Token> aux)
        {
            foreach (Token to in aux)
                Console.WriteLine(to.getLexema() + "--->" + to.getTipo() + "--->" + to.getFila() + "---->>" + to.getColumna());
        }

    }
}
