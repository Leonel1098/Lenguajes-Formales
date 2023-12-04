using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico
{
    class Analizador
    {
        public Analizador()
        {
           

        }
        
        public Boolean Generar;
        //declaracion de una lista: List<tipo> nombre;
        public List<Token> devolver; //insertar los token encontrados;
        public int estado; //pasa saber en que estado estamos
        public string lexema;
        public int fila;
        public int columna;
        //Titulo del organigrama
        public static String titulo;

       


        //Como necesito devolver una lista donde esten los tokens validos, hacemos lo siguiente:

        public List<Token> entrada(String fichero)
        {
            //para pintar los lexemas
            
            
            
            
            //PARA EL ANALISIS
            Generar = false;
            columna = 1;
            fila = 1;
            fichero = fichero + "#";
            estado = 0;
            lexema = "";
            devolver = new List<Token>();
            char c;

            for (int i = 0; i <= fichero.Length - 1; i++) {

                c = fichero[i];

                switch (estado)
                {
                    case 0:
                        {
                            //  
                            if (Char.IsLetter(c))
                            {

                                estado = 4;
                                lexema = lexema + c;
                                columna++;
                                



                            } else if (Char.IsDigit(c))
                            {
                                estado = 1;
                                lexema = lexema + c;
                                columna++;
                                
                            }
                            else if (c == ';')
                            {
                                lexema += c;
                                
                                estado = 0;

                                AgregarToken(Token.Tipos.PUNTO_COMA);

                            } else if (c == ':')
                            {
                                lexema += c;
                                

                                estado = 0;
                                AgregarToken(Token.Tipos.DOS_PUNTOS);

                            }
                            else if (c == '{')
                            {
                                lexema += c;
                                

                                estado = 0;
                                columna++;
                                AgregarToken(Token.Tipos.LLAVE_IZQUIERDA);

                            }
                            else if (c == '}')
                            {

                                lexema += c;
                                
                                estado = 0;
                                columna++;
                                AgregarToken(Token.Tipos.LLAVE_DERECHA);
                            }
                            else if (c == ',')
                            {
                                lexema += c;
                                

                                estado = 0;
                                AgregarToken(Token.Tipos.COMA);

                            }
                            else if (c == '"')
                            {
                                lexema += c;
                                columna++;
                                estado = 2;
                            } else if (c == ' ') // Para espacios 
                            {
                                
                                columna++;
                                estado = 0;
                            } else if (c == (char)10) // "\n" nueva linea
                            {
                                columna = 0;
                                fila = fila + 1;
                                estado = 0;

                            } else if (c == (char)13) //    "\r" retorno de carro
                            {
                                estado = 0;
                            }
                            else if ((c == '#' & i == fichero.Length - 1))
                                // Hemos concluido el análisis léxico.
                                Console.WriteLine("Hemos concluido el análisis léxico satisfactoriamente");
                            else
                            {
                                //Una transicion del estado 0 no existe,// Uso de una Variable booleana
                                lexema += c;
                                columna++;
                                Console.WriteLine("Error" + c);
                                AgregarToken(Token.Tipos.DESCONOCIDO);
                                Generar = true;

                            }

                            break;
                        }
                    case 1:
                        {
                            if (Char.IsDigit(c))
                            {
                                estado = 1;
                                lexema = lexema + c;
                                columna++;
                                
                            }
                            else if (c == ',')
                            {
                                columna--;
                                
                                
                                AgregarToken(Token.Tipos.NUMERO);
                                lexema += c;

                                

                                columna++;
                                AgregarToken(Token.Tipos.COMA);

                            }
                            else if (c == ';')
                            {
                                columna--;
                                

                                
                                AgregarToken(Token.Tipos.NUMERO);

                                
                                

                                lexema += c;

                                

                                columna++;
                                AgregarToken(Token.Tipos.PUNTO_COMA);
                                estado = 0;
                            }
                            else if (c == '}')
                            {
                                columna--;
                                
                                
                                AgregarToken(Token.Tipos.NUMERO);
                                lexema += c;

                                
                                

                                columna++;
                                AgregarToken(Token.Tipos.LLAVE_DERECHA);
                                estado = 0;

                            }
                            else if (c == '{')
                            {
                                
                                
                                AgregarToken(Token.Tipos.NUMERO);
                                estado = 0;
                                lexema += c;

                                

                                AgregarToken(Token.Tipos.LLAVE_IZQUIERDA);
                                Generar = true;
                                columna++;
                            }
                            else if (c == ':')
                            {
                                
                                
                                AgregarToken(Token.Tipos.NUMERO);
                                estado = 0;
                                lexema += c;

                                

                                AgregarToken(Token.Tipos.DOS_PUNTOS);
                                Generar = true;
                                columna++;

                            }
                            else if (Char.IsLetter(c))
                            {
                                
                                
                                AgregarToken(Token.Tipos.NUMERO);

                                lexema += c;

                                Generar = true;
                                columna++;
                                
                            }
                            else if (c == ' ') // Para espacios 
                            {
                                columna++;
                                
                                estado = 0;
                            }
                            else if (c == (char)10) // "\n" nueva linea
                            {
                                columna = 0;
                                fila = fila + 1;

                                AgregarToken(Token.Tipos.NUMERO);


                            }
                            else if (c == (char)13) //    "\r" retorno de carro
                            {
                                estado = 0;
                                AgregarToken(Token.Tipos.NUMERO);
                            }
                            else if ((c == '#' & i == fichero.Length - 1))
                            {
                                // Hemos concluido el análisis léxico.
                                AgregarToken(Token.Tipos.NUMERO);
                                Console.WriteLine("Hemos concluido el análisis léxico satisfactoriamente");
                            }
                            else
                            {
                                //Si en los numeros se escribe algun caracter que no existe, variable booleana
                                lexema += c;
                                Console.WriteLine("Error" + c);
                                AgregarToken(Token.Tipos.DESCONOCIDO);
                                Generar = true;
                            }



                            break;
                        }

                    case 2:
                        {
                            if (c!='"')
                            {
                                
                                lexema += c;
                                estado = 2;
                                columna++;
                            } else if (c == '"')
                            {

                                lexema += c;
                                
                                AgregarToken(Token.Tipos.CADENA);

                            }
                            


                            break;
                        }

                    case 4:
                        {
                            if (Char.IsLetter(c))
                            {

                                estado = 4;
                                lexema += c;
                                columna++;
                                
                                //AgregarToken(Token.Tipos.LETRAS);
                            }
                            else if (c == ':')
                            {

                                if (lexema.Equals("organigrama", StringComparison.CurrentCultureIgnoreCase) 
                                    | lexema.Equals("trabajador", StringComparison.CurrentCultureIgnoreCase)
                                    | lexema.Equals("codigo", StringComparison.CurrentCultureIgnoreCase)
                                    | lexema.Equals("nombre", StringComparison.CurrentCultureIgnoreCase)
                                    |lexema.Equals("superiores", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    
                                    
                                    

                                    AgregarToken(Token.Tipos.PALABRA_RESERVADA);
                                }
                                else
                                {

                                    AgregarToken(Token.Tipos.LETRA);
                                    Generar = true;
                                }

                                estado = 0;
                                lexema += c;
                                columna++;

                                

                                AgregarToken(Token.Tipos.DOS_PUNTOS);

                            }
                            else if (Char.IsDigit(c))
                            {

                                AgregarToken(Token.Tipos.LETRA);
                                estado = 0;
                                lexema += c;



                                AgregarToken(Token.Tipos.NUMERO);
                                Generar = true;
                                columna++;
                            }
                            else if (c == '{')
                            {
                                
                                

                                AgregarToken(Token.Tipos.LETRA);
                                estado = 0;
                                lexema += c;

                                

                                AgregarToken(Token.Tipos.LLAVE_IZQUIERDA);
                                Generar = true;
                                columna++;
                            }
                            else if (c == '}')
                            {
                                
                                
                                AgregarToken(Token.Tipos.LETRA);
                                estado = 0;
                                lexema += c;

                                

                                AgregarToken(Token.Tipos.LLAVE_DERECHA);
                                Generar = true;
                                columna++;
                            }
                            else if (c == ';')
                            {
                                
                                

                                AgregarToken(Token.Tipos.LETRA);
                                estado = 0;
                                lexema += c;

                                

                                AgregarToken(Token.Tipos.PUNTO_COMA);
                                Generar = true;
                                columna++;
                            }
                            else if (c == ',')
                            {
                                AgregarToken(Token.Tipos.LETRA);
                                estado = 0;
                                lexema += c;
                                

                                AgregarToken(Token.Tipos.COMA);
                                Generar = true;
                                columna++;
                            }
                            else if (c==' ')
                            {
                                columna++;
                            }
                            else if (c == (char)10) // "\n" nueva linea
                            {
                                columna = 0;
                                fila = fila + 1;

                                AgregarToken(Token.Tipos.LETRA);


                            }
                            else if (c == (char)13) //    "\r" retorno de carro
                            {
                                estado = 0;
                                AgregarToken(Token.Tipos.LETRA);
                            }
                            else if ((c == '#' & i == fichero.Length - 1))
                            {
                                // Hemos concluido el análisis léxico.
                                AgregarToken(Token.Tipos.LETRA);
                                Console.WriteLine("Hemos concluido el análisis léxico satisfactoriamente");
                            }
                            else
                            {
                                AgregarToken(Token.Tipos.LETRA);
                                lexema += c;
                                Console.WriteLine("Error " + c);
                                AgregarToken(Token.Tipos.DESCONOCIDO);

                                estado = 0;
                                Generar = true;

                            }
                            break;
                        }
                }


            }
            return devolver;
        }


        //Con este metodo agrego elementos a mi lista de tokens;
        public void AgregarToken(Token.Tipos tipo)
        {

            devolver.Add(new Token(lexema, tipo, fila, columna));
            lexema = "";
            estado = 0;
        }

        public void Mostrar(List<Token> aux)
        {
            foreach (Token to in aux)
                Console.WriteLine(to.getLexema() + "--->" + to.getTipo() + "--->" + to.getFila() + "---->>" + to.getColumna());
        }
        public void MostrarNodos(List<Nodos> aux)
        {
            int contador = aux.Count;
            for (int i = 0; i < contador; i++) {
                Console.WriteLine(aux.ElementAt(i).getCodigo() + "-->" + aux.ElementAt(i).getNombre());
                string superiores = aux.ElementAt(i).getSuperiores();
                Console.WriteLine(superiores);


            }
        }


        public Boolean GenerarGrafico()
        {
            return Generar;
        }
        
        public string getTitulo()
        {
            return titulo;
        }
        

        public List<Nodos> AgregarNodo(List<Token> entrada) {
            
            List<Nodos> nodos = new List<Nodos>();
            List<Token> toque = entrada;
            int toquens = toque.Count;
            int contador = 0;

            for (int i = 1; i < toquens; i++)
            {
                if (toque.ElementAt(i - 1).getLexema().Equals("organigrama", StringComparison.CurrentCultureIgnoreCase))
                {
                    Analizador.titulo = toque.ElementAt(i + 1).getLexema().Trim(new char[] { '"' });

                }



                int j = i;

                if (toque.ElementAt(i).getLexema().Equals("trabajador", StringComparison.CurrentCultureIgnoreCase))
                {

                    for (int k = j; k < toquens; k++)
                    {
                        int codigo;
                        String nombre;
                        List<int> superiores;
                        int a = k;

                        ///************CUANDO PRIMERO VIENE CODIGO
                        if (toque.ElementAt(k).getTipo().Equals("Palabra Reservada") & toque.ElementAt(k).getLexema().Equals("codigo", StringComparison.CurrentCultureIgnoreCase))
                        {
                            //obtengo el codigo;
                            codigo = TomarCodigo(a, toque, toquens);


                            for (int b = a; b < toquens; b++)
                                
                            {
                                int c = b;

                                if (toque.ElementAt(b).getTipo().Equals("Palabra Reservada") & toque.ElementAt(b).getLexema().Equals("nombre", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    nombre = TomarNombre(c, toque, toquens);

                                    for(int h = c; h < toquens; h++)
                                    {

                                        if(toque.ElementAt(h).getTipo().Equals("Palabra Reservada") & toque.ElementAt(h).getLexema().Equals("superiores", StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            superiores = new List<int>();
                                            superiores = TomarSuperiores(h, toque, toquens);
                                            nodos.Add(new Nodos(contador, codigo, nombre, superiores));
                                            contador++;

                                            break;
                                        }
                                    }
                                    break;
                                }else if (toque.ElementAt(k).getTipo().Equals("Palabra Reservada") & toque.ElementAt(k).getLexema().Equals("superiores", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    superiores = new List<int>();
                                    superiores = TomarSuperiores(c, toque, toquens);
                                    

                                    for (int h = c; h < toquens; h++)
                                    {

                                        if (toque.ElementAt(h).getTipo().Equals("Palabra Reservada") & toque.ElementAt(h).getLexema().Equals("nombre", StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            nombre = TomarNombre(h, toque, toquens);
                                            nodos.Add(new Nodos(contador, codigo, nombre, superiores));
                                            contador++;

                                            break;
                                        }
                                    }
                                    break;


                                }
                            }

                            break;
///************CUANDO PRIMERO VIENE NOMBRE
                        }else if(toque.ElementAt(k).getTipo().Equals("Palabra Reservada") & toque.ElementAt(k).getLexema().Equals("nombre", StringComparison.CurrentCultureIgnoreCase))
                        {
                            nombre = TomarNombre(a, toque, toquens);
                            for (int b = a; b < toquens; b++)

                            {
                                int c = b;

                                if (toque.ElementAt(b).getTipo().Equals("Palabra Reservada") & toque.ElementAt(b).getLexema().Equals("codigo", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    codigo = TomarCodigo(c, toque, toquens);

                                    for (int h = c; h < toquens; h++)
                                    {

                                        if (toque.ElementAt(h).getTipo().Equals("Palabra Reservada") & toque.ElementAt(h).getLexema().Equals("superiores", StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            superiores = new List<int>();
                                            superiores = TomarSuperiores(h, toque, toquens);
                                            nodos.Add(new Nodos(contador, codigo, nombre, superiores));
                                            contador++;

                                            break;
                                        }
                                    }
                                    break;
                                }
                                else if (toque.ElementAt(k).getTipo().Equals("Palabra Reservada") & toque.ElementAt(k).getLexema().Equals("superiores", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    superiores = new List<int>();
                                    superiores = TomarSuperiores(c, toque, toquens);

                                    for (int h = c; h < toquens; h++)
                                    {

                                        if (toque.ElementAt(h).getTipo().Equals("Palabra Reservada") & toque.ElementAt(h).getLexema().Equals("codigo", StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            codigo = TomarCodigo(h, toque, toquens);
                                            nodos.Add(new Nodos(contador, codigo, nombre, superiores));
                                            contador++;

                                            break;
                                        }
                                    }
                                    break;


                                }
                            }

                            break;

                        }
                        ///************CUANDO PRIMERO VIENE SUPERIORES
                        else if (toque.ElementAt(k).getTipo().Equals("Palabra Reservada") & toque.ElementAt(k).getLexema().Equals("superiores", StringComparison.CurrentCultureIgnoreCase))
                        {
                            superiores = new List<int>();
                            superiores = TomarSuperiores(a, toque, toquens);
                            for (int b = a; b < toquens; b++)

                            {
                                int c = b;

                                if (toque.ElementAt(b).getTipo().Equals("Palabra Reservada") & toque.ElementAt(b).getLexema().Equals("nombre", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    nombre = TomarNombre(c, toque, toquens);

                                    for (int h = c; h < toquens; h++)
                                    {

                                        if (toque.ElementAt(h).getTipo().Equals("Palabra Reservada") & toque.ElementAt(h).getLexema().Equals("codigo", StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            codigo = TomarCodigo(h, toque, toquens);
                                            nodos.Add(new Nodos(contador, codigo, nombre, superiores));
                                            contador++;

                                            break;
                                        }
                                    }
                                    break;
                                }
                                else if (toque.ElementAt(k).getTipo().Equals("Palabra Reservada") & toque.ElementAt(k).getLexema().Equals("codigo", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    codigo = TomarCodigo(c, toque, toquens);
                                    for (int h = c; h < toquens; h++)
                                    {

                                        if (toque.ElementAt(h).getTipo().Equals("Palabra Reservada") & toque.ElementAt(h).getLexema().Equals("nombre", StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            nombre = TomarNombre(h, toque, toquens);
                                            nodos.Add(new Nodos(contador, codigo, nombre, superiores));
                                            contador++;
                                            

                                            break;
                                        }
                                    }
                                    break;


                                }
                            }

                            break;


                        }


                    }




                }
            }
                return nodos;
        }






        public int TomarCodigo(int actual,List<Token> tokenActual,int tamaño)
        {
            int retorno = 0;
            for(int i = actual; i < tamaño; i++)
            {
                if (tokenActual.ElementAt(i).getTipo().Equals("Numero"))
                {
                    retorno = Convert.ToInt32(tokenActual.ElementAt(i).getLexema());
                    break;
                }

            }

            return retorno;
        }

        public string TomarNombre(int actual, List<Token> tokenActual, int tamaño)
        {
            String retornar="";
            for (int i = actual; i < tamaño; i++)
            {
                if (tokenActual.ElementAt(i).getTipo().Equals("Cadena"))
                {
                    retornar= tokenActual.ElementAt(i).getLexema().Trim(new char[] { '"' });
                    break;
                }

            }
            return retornar;
        }


        public List<int> TomarSuperiores(int actual, List<Token> tokenActual,int tamaño)
        {
            List<int> superiores=new List<int>();
            for (int i = actual; i < tamaño; i++)
            {
                if (tokenActual.ElementAt(i).getTipo().Equals("Llave Izquierda"))
                {
                    if (tokenActual.ElementAt(i + 1).getTipo().Equals("Llave Derecha"))
                    {
                     
                        break;
                    }
                    else if (tokenActual.ElementAt(i + 1).getTipo().Equals("Numero"))
                    {
                        
                        int z = i;
                        for (int x = z; x < tamaño; x++)
                        {
                            if (tokenActual.ElementAt(x).getTipo().Equals("Numero"))
                            {
                                int numero = Convert.ToInt32(tokenActual.ElementAt(x).getLexema());
                                superiores.Add(numero);
                            }
                            else if (tokenActual.ElementAt(x).getTipo().Equals("Llave Derecha"))
                            {
                                
                                break;
                            }

                        }
                        break;
                    }
                }

            }

            return superiores;

        }


    }


 }
            


    

