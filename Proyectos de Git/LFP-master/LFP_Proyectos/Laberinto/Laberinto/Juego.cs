using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Juego
    {
        public int intervalo;
        public int TamañoX;
        public  int TamañoY;
        public int InicioX;
        public int InicioY;
        public int FinX;
        public int FinY;
        public List<Cordenadas> recorrido;
        public List<Cordenadas> obstaculos;
        public List<Variables> variables;
        public List<Enemigo> enemigos;
        public int i;
        public int ContadorEnemigos;
        public bool acepta;
        public bool aceptarPer;
        public bool aceptarPared;
        public bool VarPared;
        public bool VarPer;
        public Juego()
        {
           
        }
        //+++++++++++++++++++++++++++++++++ METODOS PARA DEVOLVER LOS DATOS DE INTERES+++++++++++++++++++++++++++++++
        public int getIntervalo()
        {
            return intervalo;
        }
        public int getTamaX()
        {
            return TamañoX;
        }
        public int getTamaY()
        {
            return TamañoY;
        }
        public int getInicioX()
        {
            return InicioX;
        }
        public int getInicioY()
        {
            return InicioY;
        }
        public int getFinX()
        {
            return FinX;
        }
        public int getFinY()
        {
            return FinY;
        }
        public List<Cordenadas> getRecorrido()
        {
            return recorrido;
        }
        public List<Cordenadas> getObstaculos()
        {
            return obstaculos;
        }
        public List<Enemigo> getEnemigo()
        {
            return enemigos;
        }
        public int getTotalEn()
        {
            return ContadorEnemigos;
        }

        public List<Variables>  Variables(List<Token> tokens)
        {
            VarPared = true;
            VarPer = true;
            variables = new List<Variables>();
            for(int i=0; i <= tokens.Count - 1; i++)
            {
                if (Token.Tipos.pared == tokens.ElementAt(i).GetTipos() && VarPared)
                {
                    
                    while (Token.Tipos.LLAVE_DER != tokens.ElementAt(i).GetTipos())
                    {
                        i++;
                        int pos = i;
                        if (Token.Tipos.VARIABLE == tokens.ElementAt(pos).GetTipos())
                        {
                            pos++;
                            if (Token.Tipos.CORCHETE_DER == tokens.ElementAt(pos).GetTipos())
                            {
                                pos++;
                                if (Token.Tipos.DOS_PUNTOS == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    do
                                    {
                                        if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                        {
                                            variables.Add(new Variables(tokens.ElementAt(pos).getLexema()));

                                        }
                                        pos++;

                                    } while (Token.Tipos.PUNTO_COMA != tokens.ElementAt(pos).GetTipos());
                                    i = pos;
                                }

                            }
                        }
                        
                    }
                    VarPared = false;
                }
                if (Token.Tipos.personaje == tokens.ElementAt(i).GetTipos() && VarPer)
                {
                    
                    while (Token.Tipos.LLAVE_DER != tokens.ElementAt(i).GetTipos())
                    {
                        i++;
                        int pos = i;
                        if (Token.Tipos.VARIABLE == tokens.ElementAt(pos).GetTipos())
                        {
                            pos++;
                            if (Token.Tipos.CORCHETE_DER == tokens.ElementAt(pos).GetTipos())
                            {
                                pos++;
                                if (Token.Tipos.DOS_PUNTOS == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    do
                                    {
                                        if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                        {
                                            variables.Add(new Variables(tokens.ElementAt(pos).getLexema()));

                                        }
                                        pos++;

                                    } while (Token.Tipos.PUNTO_COMA != tokens.ElementAt(pos).GetTipos());
                                    i = pos;
                                }

                            }
                        }

                    }
                    VarPer = false;
                }
            }
            return variables;

        }
        public void imprimiVariable(List<Variables> l)
        {
            foreach (Variables t in l)
                Console.WriteLine(t.getId());
        }

        public void GuardarDatos(List<Token> tokens,List<Variables> variables)
        {
            acepta = true;
            aceptarPer = true;
            aceptarPared = true;
            ContadorEnemigos = 0;
            recorrido = new List<Cordenadas>();
            obstaculos = new List<Cordenadas>();
            enemigos = new List<Enemigo>();

            for (i=0;i<=tokens.Count-1;i++)
            {
                // ******************************---INTERVALO-----*******************************************

                if (Token.Tipos.intervalo==tokens.ElementAt(i).GetTipos())
                {
                    i=i+4;
                    intervalo = int.Parse(tokens.ElementAt(i).getLexema());

                }
                // ******************************---DIMENSIONES-----*******************************************
                if (Token.Tipos.dimensiones==tokens.ElementAt(i).GetTipos())
                {
                    i = i + 4;
                    TamañoX = int.Parse(tokens.ElementAt(i).getLexema());
                    i=i+2;
                    TamañoY = int.Parse(tokens.ElementAt(i).getLexema());

                }
                // ******************************---INICIO PERSONAJE-----*******************************************
                if (Token.Tipos.inicio_personaje == tokens.ElementAt(i).GetTipos())
                {
                    i = i + 4;
                    InicioX = int.Parse(tokens.ElementAt(i).getLexema());
                    i=i+2;
                    InicioY = int.Parse(tokens.ElementAt(i).getLexema());

                }
                // ******************************---UBICACION SALIDA-----*******************************************
                if (Token.Tipos.ubicacion_salida == tokens.ElementAt(i).GetTipos())
                {
                    i = i + 4;
                    FinX = int.Parse(tokens.ElementAt(i).getLexema());
                    i = i + 2;
                    FinY = int.Parse(tokens.ElementAt(i).getLexema());

                }

                if (Token.Tipos.pared == tokens.ElementAt(i).GetTipos() & aceptarPared)
                {
                    while (Token.Tipos.LLAVE_DER != tokens.ElementAt(i).GetTipos())
                    {

                        i++;

                        // // ******************************---PARA MANEJAR LAS VARIABLES-----*******************************************
                        if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                        {
                            int pos = i;
                            String id = tokens.ElementAt(pos).getLexema();
                            int posicion = 0;
                            for (int k = 0; k <= variables.Count - 1; k++)
                            {
                                if (id.Equals(variables.ElementAt(k).getId()))
                                {
                                    posicion = k;
                                }
                            }
                            pos++;
                            if (Token.Tipos.DOS_PUNTOS == tokens.ElementAt(pos).GetTipos())
                            {
                                pos++;
                                if (Token.Tipos.IGUAL == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    //CUANDO EL PRIMER ELEMENTO ES UN NUMERO
                                    if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                    {

                                        int valor = int.Parse(tokens.ElementAt(pos).getLexema());
                                        pos++;
                                        //el caso de la forma a:=234
                                        if (Token.Tipos.PUNTO_COMA == tokens.ElementAt(pos).GetTipos())
                                        {
                                            //voy a buscar la variable
                                            for (int j = 0; j <= variables.Count - 1; j++)
                                            {
                                                if (id.Equals(variables.ElementAt(j).getId()))
                                                {
                                                    variables.ElementAt(j).setValor(valor);
                                                    i = pos;
                                                }
                                            }
                                            //caso de la forma a:=23+56,a:=23-b,a:=23*7,a:=23/b
                                        }//CUANDO SE VA A SUMAR +++++++++++++++++++++++++++++++
                                        else if (Token.Tipos.SUMA == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor2 = int.Parse(tokens.ElementAt(pos).getLexema());
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        variables.ElementAt(j).setValor(valor + valor2);
                                                        i = pos;
                                                    }
                                                }
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                string id2 = tokens.ElementAt(pos).getLexema();
                                                int pos1 = 0;
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos1 = j;
                                                    }
                                                    else if (id2.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(pos1).setValor(valor + variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }//CUANDO SE VA A RESTAR---------------------------   
                                        else if (Token.Tipos.RESTA == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor2 = int.Parse(tokens.ElementAt(pos).getLexema());
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        variables.ElementAt(j).setValor(valor - valor2);
                                                        i = pos;
                                                    }
                                                }
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                string id2 = tokens.ElementAt(pos).getLexema();
                                                int pos1 = 0;
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos1 = j;
                                                    }
                                                    else if (id2.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(pos1).setValor(valor - variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }//CUANDO SE VA MULTIPLICAR LOS NUMEROS***********
                                        else if (Token.Tipos.MULTIPLICACION == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor2 = int.Parse(tokens.ElementAt(pos).getLexema());
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        variables.ElementAt(j).setValor(valor * valor2);
                                                        i = pos;
                                                    }
                                                }
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                string id2 = tokens.ElementAt(pos).getLexema();
                                                int pos1 = 0;
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos1 = j;
                                                    }
                                                    else if (id2.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(pos1).setValor(valor * variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }
                                        else if (Token.Tipos.DIVISION == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor2 = int.Parse(tokens.ElementAt(pos).getLexema());
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        variables.ElementAt(j).setValor(valor / valor2);
                                                        i = pos;
                                                    }
                                                }
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                string id2 = tokens.ElementAt(pos).getLexema();
                                                int pos1 = 0;
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos1 = j;
                                                    }
                                                    else if (id2.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(pos1).setValor(valor / variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }
                                    }//cuando es una variable primero
                                    else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                    {
                                        string ide = tokens.ElementAt(pos).getLexema();
                                        int pos1 = 0;
                                        for (int k = 0; k <= variables.Count - 1; k++)
                                        {
                                            if (ide.Equals(variables.ElementAt(k).getId()))
                                            {
                                                pos1 = k;
                                            }
                                        }
                                        pos++;
                                        if (Token.Tipos.PUNTO_COMA == tokens.ElementAt(pos).GetTipos())
                                        {

                                            variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor());
                                            i = pos;

                                        }
                                        else if (Token.Tipos.SUMA == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor = int.Parse(tokens.ElementAt(pos).getLexema());
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() + valor);
                                                i = pos;
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (ide.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() + variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }//CUANDO SE RESTAN
                                        else if (Token.Tipos.RESTA == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor = int.Parse(tokens.ElementAt(pos).getLexema());
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() - valor);
                                                i = pos;
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (ide.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() - variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }//CUANDO SE MULTIPLICAN
                                        else if (Token.Tipos.MULTIPLICACION == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor = int.Parse(tokens.ElementAt(pos).getLexema());
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() * valor);
                                                i = pos;
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (ide.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() * variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }//CUANDO SE DIVIDEN
                                        else if (Token.Tipos.MULTIPLICACION == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor = int.Parse(tokens.ElementAt(pos).getLexema());
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() / valor);
                                                i = pos;
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (ide.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() / variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }
                                    }
                                }

                            }

                        }
                        // ******************************---DATOS PARA LA PARED-----*******************************************
                        //++++++CASILLAS SIMpLES+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        if (Token.Tipos.casilla == tokens.ElementAt(i).GetTipos())
                        {
                            i = i + 4;

                            if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                            {
                                int x = int.Parse(tokens.ElementAt(i).getLexema());
                                i = i + 2;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y = int.Parse(tokens.ElementAt(i).getLexema());
                                    obstaculos.Add(new Cordenadas(x, y));
                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    for (int j = 0; j <= variables.Count - 1; j++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                        {
                                            obstaculos.Add(new Cordenadas(x, variables.ElementAt(j).getValor()));
                                        }
                                    }
                                }
                            }
                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                            {
                                int x = 0;
                                for (int j = 0; j <= variables.Count - 1; j++)
                                {
                                    if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                    {
                                        x = variables.ElementAt(j).getValor();
                                    }
                                }
                                i = i + 2;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y = int.Parse(tokens.ElementAt(i).getLexema());
                                    obstaculos.Add(new Cordenadas(x, y));
                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    for (int j = 0; j <= variables.Count - 1; j++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                        {
                                            obstaculos.Add(new Cordenadas(x, variables.ElementAt(j).getValor()));
                                        }
                                    }
                                }
                            }
                        }//****************************************************************************************************

                        //CUANDO VIENE DE LA FORMA (1..3,1)*****************************************************************
                        if (Token.Tipos.Varias_casillas == tokens.ElementAt(i).GetTipos())
                        {
                            int x1 = 0;
                            int pos = i;
                            pos = pos + 4;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                            {
                                x1 = int.Parse(tokens.ElementAt(pos).getLexema());
                                pos++;
                                if (Token.Tipos.PUNTO == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    if (Token.Tipos.PUNTO == tokens.ElementAt(pos).GetTipos())
                                    {
                                        pos++;
                                        ParedHorizontal(x1, pos, tokens, variables);
                                    }
                                }


                            }
                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                            {
                                //buscar la variable

                                for (int j = 0; j <= variables.Count - 1; j++)
                                {
                                    if (tokens.ElementAt(pos).getLexema().Equals(variables.ElementAt(j).getId()))
                                    {
                                        x1 = variables.ElementAt(j).getValor();
                                    }
                                }
                                pos++;
                                if (Token.Tipos.PUNTO == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    if (Token.Tipos.PUNTO == tokens.ElementAt(pos).GetTipos())
                                    {
                                        pos++;
                                        ParedHorizontal(x1, pos, tokens, variables);
                                    }
                                }



                            }

                        }//***************************************************************************************
                         //CUANDO VIENEN DE LA FORMA (1,2..4)
                        if (Token.Tipos.Varias_casillas == tokens.ElementAt(i).GetTipos())
                        {
                            int x1 = 0;
                            int pos = i;
                            pos = pos + 4;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                            {
                                x1 = int.Parse(tokens.ElementAt(pos).getLexema());
                                pos++;
                                if (Token.Tipos.COMA == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    ParedVertical(x1, pos, tokens, variables);
                                }

                            }
                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                            {
                                //buscar la variable

                                for (int j = 0; j <= variables.Count - 1; j++)
                                {
                                    if (tokens.ElementAt(pos).getLexema().Equals(variables.ElementAt(j).getId()))
                                    {
                                        x1 = variables.ElementAt(j).getValor();
                                    }
                                }
                                pos++;
                                if (Token.Tipos.COMA == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    ParedVertical(x1, pos, tokens, variables);
                                }

                            }
                        }//******************************************************************************************************************************** FIN DE LA PARED
                    }
                    aceptarPared = false;
                }


                //----------------------------------------------------------------------------------------------------------------------
                if (Token.Tipos.personaje == tokens.ElementAt(i).GetTipos() & aceptarPer)
                {
                    while (Token.Tipos.LLAVE_DER != tokens.ElementAt(i).GetTipos())
                    {
                        i++;


                        if (Token.Tipos.paso == tokens.ElementAt(i).GetTipos())
                        {
                            i = i + 4;

                            if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                            {
                                int x = int.Parse(tokens.ElementAt(i).getLexema());
                                i = i + 2;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y = int.Parse(tokens.ElementAt(i).getLexema());
                                    recorrido.Add(new Cordenadas(x, y));
                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    for (int j = 0; j <= variables.Count - 1; j++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                        {
                                            recorrido.Add(new Cordenadas(x, variables.ElementAt(j).getValor()));
                                        }
                                    }
                                }
                            }
                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                            {
                                int x = 0;
                                for (int j = 0; j <= variables.Count - 1; j++)
                                {
                                    if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                    {
                                        x = variables.ElementAt(j).getValor();
                                    }
                                }
                                i = i + 2;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y = int.Parse(tokens.ElementAt(i).getLexema());
                                    recorrido.Add(new Cordenadas(x, y));
                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    for (int j = 0; j <= variables.Count - 1; j++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                        {
                                            recorrido.Add(new Cordenadas(x, variables.ElementAt(j).getValor()));
                                        }
                                    }
                                }
                            }
                        }//cuando camina de la forma (1..1,2)
                        if (Token.Tipos.caminata == tokens.ElementAt(i).GetTipos())
                        {
                            int x1 = 0;
                            int pos = i;
                            pos = pos + 4;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                            {
                                x1 = int.Parse(tokens.ElementAt(pos).getLexema());
                                pos++;
                                if (Token.Tipos.PUNTO == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    if (Token.Tipos.PUNTO == tokens.ElementAt(pos).GetTipos())
                                    {
                                        pos++;
                                        AgregarCamintaHorizontal(x1, pos, tokens, variables);
                                    }
                                }


                            }
                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                            {
                                //buscar la variable

                                for (int j = 0; j <= variables.Count - 1; j++)
                                {
                                    if (tokens.ElementAt(pos).getLexema().Equals(variables.ElementAt(j).getId()))
                                    {
                                        x1 = variables.ElementAt(j).getValor();
                                    }
                                }
                                pos++;
                                if (Token.Tipos.PUNTO == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    if (Token.Tipos.PUNTO == tokens.ElementAt(pos).GetTipos())
                                    {
                                        pos++;
                                        AgregarCamintaHorizontal(x1, pos, tokens, variables);
                                    }
                                }



                            }
                        }
                        //CUANDO VIENE DE LA FORMA (1,2..3)
                        if (Token.Tipos.caminata == tokens.ElementAt(i).GetTipos())
                        {
                            int x1 = 0;
                            int pos = i;
                            pos = pos + 4;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                            {
                                x1 = int.Parse(tokens.ElementAt(pos).getLexema());
                                pos++;
                                if (Token.Tipos.COMA == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    RecorridoVertical(x1, pos, tokens, variables);
                                }

                            }
                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                            {
                                //buscar la variable

                                for (int j = 0; j <= variables.Count - 1; j++)
                                {
                                    if (tokens.ElementAt(pos).getLexema().Equals(variables.ElementAt(j).getId()))
                                    {
                                        x1 = variables.ElementAt(j).getValor();
                                    }
                                }
                                pos++;
                                if (Token.Tipos.COMA == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    RecorridoVertical(x1, pos, tokens, variables);
                                }

                            }

                        }
                        //manejar las variables dentro del campo de personaje·············································································
                        if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                        {
                            int pos = i;
                            String id = tokens.ElementAt(pos).getLexema();
                            int posicion = 0;
                            for (int k = 0; k <= variables.Count - 1; k++)
                            {
                                if (id.Equals(variables.ElementAt(k).getId()))
                                {
                                    posicion = k;
                                }
                            }
                            pos++;
                            if (Token.Tipos.DOS_PUNTOS == tokens.ElementAt(pos).GetTipos())
                            {
                                pos++;
                                if (Token.Tipos.IGUAL == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    //CUANDO EL PRIMER ELEMENTO ES UN NUMERO
                                    if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                    {

                                        int valor = int.Parse(tokens.ElementAt(pos).getLexema());
                                        pos++;
                                        //el caso de la forma a:=234
                                        if (Token.Tipos.PUNTO_COMA == tokens.ElementAt(pos).GetTipos())
                                        {
                                            //voy a buscar la variable
                                            for (int j = 0; j <= variables.Count - 1; j++)
                                            {
                                                if (id.Equals(variables.ElementAt(j).getId()))
                                                {
                                                    variables.ElementAt(j).setValor(valor);
                                                    i = pos;
                                                }
                                            }
                                            //caso de la forma a:=23+56,a:=23-b,a:=23*7,a:=23/b
                                        }//CUANDO SE VA A SUMAR +++++++++++++++++++++++++++++++
                                        else if (Token.Tipos.SUMA == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor2 = int.Parse(tokens.ElementAt(pos).getLexema());
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        variables.ElementAt(j).setValor(valor + valor2);
                                                        i = pos;
                                                    }
                                                }
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                string id2 = tokens.ElementAt(pos).getLexema();
                                                int pos1 = 0;
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos1 = j;
                                                    }
                                                    else if (id2.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(pos1).setValor(valor + variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }//CUANDO SE VA A RESTAR---------------------------   
                                        else if (Token.Tipos.RESTA == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor2 = int.Parse(tokens.ElementAt(pos).getLexema());
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        variables.ElementAt(j).setValor(valor - valor2);
                                                        i = pos;
                                                    }
                                                }
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                string id2 = tokens.ElementAt(pos).getLexema();
                                                int pos1 = 0;
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos1 = j;
                                                    }
                                                    else if (id2.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(pos1).setValor(valor - variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }//CUANDO SE VA MULTIPLICAR LOS NUMEROS***********
                                        else if (Token.Tipos.MULTIPLICACION == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor2 = int.Parse(tokens.ElementAt(pos).getLexema());
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        variables.ElementAt(j).setValor(valor * valor2);
                                                        i = pos;
                                                    }
                                                }
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                string id2 = tokens.ElementAt(pos).getLexema();
                                                int pos1 = 0;
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos1 = j;
                                                    }
                                                    else if (id2.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(pos1).setValor(valor * variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }
                                        else if (Token.Tipos.DIVISION == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor2 = int.Parse(tokens.ElementAt(pos).getLexema());
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        variables.ElementAt(j).setValor(valor / valor2);
                                                        i = pos;
                                                    }
                                                }
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                string id2 = tokens.ElementAt(pos).getLexema();
                                                int pos1 = 0;
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (id.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos1 = j;
                                                    }
                                                    else if (id2.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(pos1).setValor(valor / variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }
                                    }//cuando es una variable primero
                                    else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                    {
                                        string ide = tokens.ElementAt(pos).getLexema();
                                        int pos1 = 0;
                                        for (int k = 0; k <= variables.Count - 1; k++)
                                        {
                                            if (ide.Equals(variables.ElementAt(k).getId()))
                                            {
                                                pos1 = k;
                                            }
                                        }
                                        pos++;
                                        if (Token.Tipos.PUNTO_COMA == tokens.ElementAt(pos).GetTipos())
                                        {

                                            variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor());
                                            i = pos;

                                        }
                                        else if (Token.Tipos.SUMA == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor = int.Parse(tokens.ElementAt(pos).getLexema());
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() + valor);
                                                i = pos;
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (ide.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() + variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }//CUANDO SE RESTAN
                                        else if (Token.Tipos.RESTA == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor = int.Parse(tokens.ElementAt(pos).getLexema());
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() - valor);
                                                i = pos;
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (ide.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() - variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }//CUANDO SE MULTIPLICAN
                                        else if (Token.Tipos.MULTIPLICACION == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor = int.Parse(tokens.ElementAt(pos).getLexema());
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() * valor);
                                                i = pos;
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (ide.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() * variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }//CUANDO SE DIVIDEN
                                        else if (Token.Tipos.MULTIPLICACION == tokens.ElementAt(pos).GetTipos())
                                        {
                                            pos++;
                                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int valor = int.Parse(tokens.ElementAt(pos).getLexema());
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() / valor);
                                                i = pos;
                                            }
                                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(pos).GetTipos())
                                            {
                                                int pos2 = 0;
                                                for (int j = 0; j <= variables.Count - 1; j++)
                                                {
                                                    if (ide.Equals(variables.ElementAt(j).getId()))
                                                    {
                                                        pos2 = j;
                                                    }
                                                }
                                                variables.ElementAt(posicion).setValor(variables.ElementAt(pos1).getValor() / variables.ElementAt(pos2).getValor());
                                                i = pos;
                                            }
                                        }
                                    }
                                }

                            }

                        }

                    }
                    aceptarPer = false;
                }
                //---------------------------------------------------------------------------------------------------------------------------------
                //ACA ES DONDE SACAMOS A LOS ENEMIGOS 
                if (Token.Tipos.enemigo == tokens.ElementAt(i).GetTipos() & ContadorEnemigos<=3)
                {
                    int x1 =0;
                    int x2 = 0;
                    int y1 = 0;
                    int y2 = 0;
                    int pos = i;
                    pos = pos + 4;
                    while (Token.Tipos.LLAVE_DER != tokens.ElementAt(pos).GetTipos() && Token.Tipos.LLAVE_DER != tokens.ElementAt(i).GetTipos())
                    {
                        pos++;
                        if (Token.Tipos.caminata == tokens.ElementAt(pos).GetTipos() && acepta)
                        {
                            pos = pos + 4;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(pos).GetTipos())
                            {
                                x1 = int.Parse(tokens.ElementAt(pos).getLexema());
                                pos++;
                                if (Token.Tipos.PUNTO == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos = pos + 2;
                                    x2 = int.Parse(tokens.ElementAt(pos).getLexema());
                                    pos = pos + 2;
                                    y1 = int.Parse(tokens.ElementAt(pos).getLexema());
                                    Enemigo enemigo = new Enemigo();
                                    enemigo.CaminataHorizontal(x1, x2, y1);
                                    enemigos.Add(enemigo);
                                    i = pos+1;
                                    ContadorEnemigos++;
                                    acepta = false;

                                }
                                else if (Token.Tipos.COMA == tokens.ElementAt(pos).GetTipos())
                                {
                                    pos++;
                                    y1 = int.Parse(tokens.ElementAt(pos).getLexema());
                                    pos = pos + 3;
                                    y2 = int.Parse(tokens.ElementAt(pos).getLexema());
                                    Enemigo enemigo = new Enemigo();
                                    enemigo.CaminataVertical(x1, y1, y2);
                                    enemigos.Add(enemigo);
                                    i = pos+1;
                                    ContadorEnemigos++;
                                    acepta = false;
                                }
                                
                            }

                        }
                        else
                        {
                            i++;
                        }
                    }
                    acepta = true;
                   
                }
               
            }



        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public void ParedHorizontal(int x1,int posicion,List<Token> tokens,List<Variables> variables)
        {
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;
            int a = posicion;
                if (Token.Tipos.NUMERO==tokens.ElementAt(a).GetTipos())
                {
                    x2 = int.Parse(tokens.ElementAt(a).getLexema());
                    a++;
                    if (Token.Tipos.COMA == tokens.ElementAt(a).GetTipos())
                    {
                        a++;
                        if (Token.Tipos.NUMERO == tokens.ElementAt(a).GetTipos())
                        {
                        y1 = int.Parse(tokens.ElementAt(a).getLexema());

                            if (Token.Tipos.PARENTESIS_DER == tokens.ElementAt(a+1).GetTipos())
                            {
                                
                                AgregarParedHorizontal(x1, x2, y1, a);

                            }else if (Token.Tipos.PUNTO == tokens.ElementAt(a + 1).GetTipos())
                            {
                            a = a + 3;
                            y2 = DevolverValor(a,tokens,variables);
                            

                            CuadroParedes(x1,x2,y1,y2,a);
                            }
                        
                           
                        }
                        else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
                        {
                            for (int h=0;h<=variables.Count-1;h++)
                            {
                                if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(h).getId()))
                                {
                                    y1 = variables.ElementAt(h).getValor();
                                }
                            }

                            if (Token.Tipos.PARENTESIS_DER == tokens.ElementAt(a + 1).GetTipos())
                            {

                            AgregarParedHorizontal(x1, x2, y1, a);

                            }
                            else if (Token.Tipos.PUNTO == tokens.ElementAt(a + 1).GetTipos())
                            {
                            a = a + 3;
                            y2 = DevolverValor(a, tokens, variables);
                           
                            CuadroParedes(x1, x2, y1, y2,a);
                            }
                    }
                    }

                }else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
                {
                    for(int b = 0; b <= variables.Count-1; b++)
                    {
                        if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(b).getId()))
                        {
                            x2 = variables.ElementAt(b).getValor();
                        }
                    }
                    a++;
                    if (Token.Tipos.COMA == tokens.ElementAt(a).GetTipos())
                    {
                        a++;
                        if (Token.Tipos.NUMERO == tokens.ElementAt(a).GetTipos())
                        {
                            y1 = int.Parse(tokens.ElementAt(a).getLexema());
                            if (Token.Tipos.PARENTESIS_DER == tokens.ElementAt(a + 1).GetTipos())
                            {

                            AgregarParedHorizontal(x1, x2, y1, a);

                            }
                            else if (Token.Tipos.PUNTO == tokens.ElementAt(a + 1).GetTipos())
                             {
                            a = a + 3;
                            y2 = DevolverValor(a, tokens, variables);
                            

                            CuadroParedes(x1, x2, y1, y2,a);
                            }
                    }
                        else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
                        {
                            for (int h = 0; h <= variables.Count-1; h++)
                            {
                                if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(h).getId()))
                                {
                                    y1 = variables.ElementAt(h).getValor();
                                }
                            }
                        if (Token.Tipos.PARENTESIS_DER == tokens.ElementAt(a + 1).GetTipos())
                        {

                            AgregarParedHorizontal(x1, x2, y1, a);

                        }
                        else if (Token.Tipos.PUNTO == tokens.ElementAt(a + 1).GetTipos())
                        {
                            a = a + 3;
                            y2 = DevolverValor(a, tokens, variables);
                            

                            CuadroParedes(x1, x2, y1, y2,a);
                        }

                    }
                    }
                }
            
            
        }
        //METODO PARA AGREGAR CORDENAADAS PARA LA PARED HORIZONTAL
        public void AgregarParedHorizontal(int x1, int x2, int y1,int a)
        {
            if (x1 <= x2)
            {
                for (int x = x1; x <= x2; x++)
                {
                    obstaculos.Add(new Cordenadas(x, y1));
                }
                i = a;
            }
            else if (x1 >= x2)
            {
                for (int x = x1; x >= x2; x--)
                {
                    obstaculos.Add(new Cordenadas(x, y1));
                }
                i = a;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------

        //METODO PARA AGREGAR CUANDO VIENE DE LA FORMA (1,1..3) ---------------------------------------------------------------

        public void ParedVertical(int x1,int posicion,List<Token> tokens, List<Variables> variables)
        {
            int a = posicion;
            int y1 =0;
            int y2 = 0;

            if (Token.Tipos.NUMERO==tokens.ElementAt(a).GetTipos())
            {
                y1 = int.Parse(tokens.ElementAt(a).getLexema());
                a++;
                if (Token.Tipos.PUNTO == tokens.ElementAt(a).GetTipos())
                {
                    a++;
                    if (Token.Tipos.PUNTO == tokens.ElementAt(a).GetTipos())
                    {
                        a++;
                        if (Token.Tipos.NUMERO == tokens.ElementAt(a).GetTipos())
                        {
                            y2 = int.Parse(tokens.ElementAt(a).getLexema());
                            AgregarParedVertical(x1,y1,y2,a);
                        }else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
                        {
                            for (int h=0;h<=variables.Count-1;h++)
                            {
                                if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(h).getId()))
                                {
                                    y2 = variables.ElementAt(h).getValor();
                                }
                            }
                            AgregarParedVertical(x1, y1, y2,a);
                        }
                    }
                }
            }else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
            {
                for (int b=0;b<=variables.Count-1;b++)
                {
                    if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(b).getId()))
                    {
                        y1 = variables.ElementAt(b).getValor();
                    }
                }
                a++;
                if (Token.Tipos.PUNTO == tokens.ElementAt(a).GetTipos())
                {
                    a++;
                    if (Token.Tipos.PUNTO == tokens.ElementAt(a).GetTipos())
                    {
                        a++;
                        if (Token.Tipos.NUMERO == tokens.ElementAt(a).GetTipos())
                        {
                            y2 = int.Parse(tokens.ElementAt(a).getLexema());
                            AgregarParedVertical(x1, y1, y2,a);
                        }
                        else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
                        {
                            for (int h = 0; h <= variables.Count - 1; h++)
                            {
                                if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(h).getId()))
                                {
                                    y2 = variables.ElementAt(h).getValor();
                                }
                            }
                            AgregarParedVertical(x1, y1, y2,a);
                        }
                    }
                }
            }
            
        }
        
        public void AgregarParedVertical(int x1,int y1, int y2,int a)
        {
            if (y1 <= y2)
            {
                for (int y = y1; y <= y2; y++)
                {
                    obstaculos.Add(new Cordenadas(x1, y));
                }
                i = a;
            }
            else if (y1 >= y2)
            {
                for (int y = y1; y >= y2; y--)
                {
                    obstaculos.Add(new Cordenadas(x1, y));
                }
                i = a;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------

        //METODO PARA AGREGAR PARED DE LA FORMA (1..3,1..2)---------------------------------------------------------------------------------------
       public int DevolverValor(int pos,List<Token> tokens, List<Variables> variables)
        {
            int valor = 0;
            int a = pos;
            if (Token.Tipos.NUMERO==tokens.ElementAt(a).GetTipos())
            {
                valor = int.Parse(tokens.ElementAt(a).getLexema());

            }else if(Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
            {
                for (int z = 0; z <= variables.Count - 1; z++)
                {
                    if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(z).getId()))
                    {
                        valor = variables.ElementAt(z).getValor();
                    }
                }
            }
            return valor;
        }
       
        public void CuadroParedes(int x1,int x2,int y1,int y2,int pos)
        {
            if (x1<=x2)
            {
                for (int x = x1; x <= x2; x++)
                {
                    if (y1<=y2)
                    {
                        for (int y = y1; y <= y2; y++)
                        {
                            obstaculos.Add(new Cordenadas(x, y));
                        }
                    }else if (y1>=y2)
                    {
                        for (int y = y1; y >= y2; y--)
                        {
                            obstaculos.Add(new Cordenadas(x, y));
                        }
                    }
                    
                }
            }else if (x1>=x2)
            {
                for (int x = x1; x >= x2; x--)
                {
                    if (y1 <= y2)
                    {
                        for (int y = y1; y <= y2; y++)
                        {
                            obstaculos.Add(new Cordenadas(x, y));
                        }
                    }
                    else if (y1 >= y2)
                    {
                        for (int y = y1; y >= y2; y--)
                        {
                            obstaculos.Add(new Cordenadas(x, y));
                        }
                    }
                }
            }
           
            i = pos;
        }
        //---------------------------------------- AGREGAR CAMINATA (1..1,2) --------------------------------------------------------------------------------------
        
        public void AgregarCamintaHorizontal(int x1, int posicion, List<Token> tokens, List<Variables> variables)
        {
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;
            int a = posicion;
            if (Token.Tipos.NUMERO == tokens.ElementAt(a).GetTipos())
            {
                x2 = int.Parse(tokens.ElementAt(a).getLexema());
                a++;
                if (Token.Tipos.COMA == tokens.ElementAt(a).GetTipos())
                {
                    a++;
                    if (Token.Tipos.NUMERO == tokens.ElementAt(a).GetTipos())
                    {
                        y1 = int.Parse(tokens.ElementAt(a).getLexema());

                        if (Token.Tipos.PARENTESIS_DER == tokens.ElementAt(a + 1).GetTipos())
                        {

                            AgregarRecorridoHorizontal(x1, x2, y1, a);

                        }
                      


                    }
                    else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
                    {
                        for (int h = 0; h <= variables.Count - 1; h++)
                        {
                            if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(h).getId()))
                            {
                                y1 = variables.ElementAt(h).getValor();
                            }
                        }

                        if (Token.Tipos.PARENTESIS_DER == tokens.ElementAt(a + 1).GetTipos())
                        {

                            AgregarRecorridoHorizontal(x1, x2, y1, a);

                        }
                      
                    }
                }

            }
            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
            {
                for (int b = 0; b <= variables.Count - 1; b++)
                {
                    if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(b).getId()))
                    {
                        x2 = variables.ElementAt(b).getValor();
                    }
                }
                a++;
                if (Token.Tipos.COMA == tokens.ElementAt(a).GetTipos())
                {
                    a++;
                    if (Token.Tipos.NUMERO == tokens.ElementAt(a).GetTipos())
                    {
                        y1 = int.Parse(tokens.ElementAt(a).getLexema());
                        if (Token.Tipos.PARENTESIS_DER == tokens.ElementAt(a + 1).GetTipos())
                        {

                            AgregarRecorridoHorizontal(x1, x2, y1, a);

                        }
                        
                    }
                    else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
                    {
                        for (int h = 0; h <= variables.Count - 1; h++)
                        {
                            if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(h).getId()))
                            {
                                y1 = variables.ElementAt(h).getValor();
                            }
                        }
                        if (Token.Tipos.PARENTESIS_DER == tokens.ElementAt(a + 1).GetTipos())
                        {

                            AgregarRecorridoHorizontal(x1, x2, y1, a);

                        }
                       

                    }
                }
            }
        }
        public void AgregarRecorridoHorizontal(int x1, int x2, int y1, int a)
        {
            if (x1<=x2)
            {
                for (int x = x1; x <= x2; x++)
                {
                    recorrido.Add(new Cordenadas(x, y1));
                }
                i = a;
            }else if (x1 >= x2)
            {
                for (int x = x1; x >=x2; x--)
                {
                    recorrido.Add(new Cordenadas(x, y1));
                }
                i = a;
            }
            
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------- AGREGAR CAMINATA (1,3..5)--------------------------------------------------------------------------
        public void RecorridoVertical(int x1, int posicion, List<Token> tokens, List<Variables> variables)
        {
            int a = posicion;
            int y1 = 0;
            int y2 = 0;

            if (Token.Tipos.NUMERO == tokens.ElementAt(a).GetTipos())
            {
                y1 = int.Parse(tokens.ElementAt(a).getLexema());
                a++;
                if (Token.Tipos.PUNTO == tokens.ElementAt(a).GetTipos())
                {
                    a++;
                    if (Token.Tipos.PUNTO == tokens.ElementAt(a).GetTipos())
                    {
                        a++;
                        if (Token.Tipos.NUMERO == tokens.ElementAt(a).GetTipos())
                        {
                            y2 = int.Parse(tokens.ElementAt(a).getLexema());
                            Vertical(x1, y1, y2, a);
                        }
                        else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
                        {
                            for (int h = 0; h <= variables.Count - 1; h++)
                            {
                                if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(h).getId()))
                                {
                                    y2 = variables.ElementAt(h).getValor();
                                }
                            }
                            Vertical(x1, y1, y2, a);
                        }
                    }
                }
            }
            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
            {
                for (int b = 0; b <= variables.Count - 1; b++)
                {
                    if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(b).getId()))
                    {
                        y1 = variables.ElementAt(b).getValor();
                    }
                }
                a++;
                if (Token.Tipos.PUNTO == tokens.ElementAt(a).GetTipos())
                {
                    a++;
                    if (Token.Tipos.PUNTO == tokens.ElementAt(a).GetTipos())
                    {
                        a++;
                        if (Token.Tipos.NUMERO == tokens.ElementAt(a).GetTipos())
                        {
                            y2 = int.Parse(tokens.ElementAt(a).getLexema());
                           Vertical(x1, y1, y2, a);
                        }
                        else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(a).GetTipos())
                        {
                            for (int h = 0; h <= variables.Count - 1; h++)
                            {
                                if (tokens.ElementAt(a).getLexema().Equals(variables.ElementAt(h).getId()))
                                {
                                    y2 = variables.ElementAt(h).getValor();
                                }
                            }
                            Vertical(x1, y1, y2, a);
                        }
                    }
                }
            }

        }
        public void Vertical(int x1, int y1, int y2, int a)
        {
            if (y1<=y2)
            {
                for (int y = y1; y <= y2; y++)
                {
                    recorrido.Add(new Cordenadas(x1, y));
                }
                i = a;
            }else if (y1>=y2)
            {
                for (int y = y1; y >= y2; y--)
                {
                    recorrido.Add(new Cordenadas(x1, y));
                }
                i = a;
            }
            
        }

    }


}
