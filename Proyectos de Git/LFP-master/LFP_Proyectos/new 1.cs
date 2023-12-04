 if (Token.Tipos.Varias_casillas == tokens.ElementAt(i).GetTipos())
                {
                    i = i + 4;
                    if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                    {
                        int x1 = int.Parse(tokens.ElementAt(i).getLexema());
                        i = i + 1;
                        //VERIFICIO SI VIENE PUNTO O COMA
                        // forma (2,3..4)
                        if (Token.Tipos.COMA == tokens.ElementAt(i).GetTipos())
                        {
                            i = i + 1;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                            {
                                int y1 = int.Parse(tokens.ElementAt(i).getLexema());
                                i = i + 3;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = int.Parse(tokens.ElementAt(i).getLexema());
                                    for (int k=y1;k<=y2;k++)
                                    {
                                        obstaculos.Add(new Cordenadas(x1, k));
                                    }

                                }else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = 0;
                                    for (int j=0;j<=variables.Count-1;j++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                        {
                                            y2 = variables.ElementAt(j).getValor();
                                        }
                                    }
                                    for (int k = y1; k <= y2; k++)
                                    {
                                        obstaculos.Add(new Cordenadas(x1, k));
                                    }
                                }
                                //CUANDO VIENE IDENTIFICADOR
                            }else if (Token.Tipos.IDENTIFICADOR==tokens.ElementAt(i).GetTipos())
                            {
                                int y1 = 0;
                                for (int j = 0; j <= variables.Count - 1; j++)
                                {
                                    if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                    {
                                        y1 = variables.ElementAt(j).getValor();
                                    }
                                }
                                i = i + 3;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = int.Parse(tokens.ElementAt(i).getLexema());
                                    for (int k = y1; k <= y2; k++)
                                    {
                                        obstaculos.Add(new Cordenadas(x1, k));
                                    }

                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = 0;
                                    for (int j = 0; j <= variables.Count - 1; j++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                        {
                                            y2 = variables.ElementAt(j).getValor();
                                        }
                                    }
                                    for (int k = y1; k <= y2; k++)
                                    {
                                        obstaculos.Add(new Cordenadas(x1, k));
                                    }
                                }
                            }
                        }else if (Token.Tipos.PUNTO==tokens.ElementAt(i).GetTipos())
                        {
                            i = i + 2;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                            {
                                int x2 = int.Parse(tokens.ElementAt(i).getLexema());

                                i = i + 2;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y1 = int.Parse(tokens.ElementAt(i).getLexema());

                                    for (int a=x1;x1<=x2;a++) 
                                    {
                                        obstaculos.Add(new Cordenadas(a, y1));
                                    }
                                }else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y1 = 0;
                                    for (int j = 0; j <= variables.Count - 1; j++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                        {
                                            y1 = variables.ElementAt(j).getValor();
                                        }
                                    }
                                    for (int a = x1; a <= x2; a++)
                                    {
                                        obstaculos.Add(new Cordenadas(a, y1));
                                    }
                                }

                            }else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                            {
                                int x2 = 0;
                                for (int q=0;q<=variables.Count-1;q++)
                                {
                                    if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(q).getId()))
                                    {
                                        x2 = variables.ElementAt(1).getValor();
                                    }
                                }
                                i = i + 2;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y1 = int.Parse(tokens.ElementAt(i).getLexema());

                                    for (int a = x1; x1 <= x2; a++)
                                    {
                                        obstaculos.Add(new Cordenadas(a, y1));
                                    }
                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y1 = 0;
                                    for (int j = 0; j <= variables.Count - 1; j++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                        {
                                            y1 = variables.ElementAt(j).getValor();
                                        }
                                    }
                                    for (int a = x1; a <= x2; a++)
                                    {
                                        obstaculos.Add(new Cordenadas(a, y1));
                                    }
                                }
                            }
                        }
                    }else if (Token.Tipos.IDENTIFICADOR==tokens.ElementAt(i).GetTipos())
                    {
                        int x1 = 0;
                        for (int w=0;w<=variables.Count-1;w++)
                        {
                            if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(w).getId()))
                            {
                                x1 = variables.ElementAt(w).getValor();
                            }
                        }
                        i = i + 1;
                        //VERIFICIO SI VIENE PUNTO O COMA
                        // forma (2,3..4)
                        if (Token.Tipos.COMA == tokens.ElementAt(i).GetTipos())
                        {
                            i = i + 1;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                            {
                                int y1 = int.Parse(tokens.ElementAt(i).getLexema());
                                i = i + 3;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = int.Parse(tokens.ElementAt(i).getLexema());
                                    for (int k = y1; k <= y2; k++)
                                    {
                                        obstaculos.Add(new Cordenadas(x1, k));
                                    }

                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = 0;
                                    for (int j = 0; j <= variables.Count - 1; j++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                        {
                                            y2 = variables.ElementAt(j).getValor();
                                        }
                                    }
                                    for (int k = y1; k <= y2; k++)
                                    {
                                        obstaculos.Add(new Cordenadas(x1, k));
                                    }
                                }
                                //CUANDO VIENE IDENTIFICADOR
                            }
                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                            {
                                int y1 = 0;
                                for (int j = 0; j <= variables.Count - 1; j++)
                                {
                                    if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                    {
                                        y1 = variables.ElementAt(j).getValor();
                                    }
                                }
                                i = i + 3;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = int.Parse(tokens.ElementAt(i).getLexema());
                                    for (int k = y1; k <= y2; k++)
                                    {
                                        obstaculos.Add(new Cordenadas(x1, k));
                                    }

                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = 0;
                                    for (int j = 0; j <= variables.Count - 1; j++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                        {
                                            y2 = variables.ElementAt(j).getValor();
                                        }
                                    }
                                    for (int k = y1; k <= y2; k++)
                                    {
                                        obstaculos.Add(new Cordenadas(x1, k));
                                    }
                                }
                            }
                        }
                        else if (Token.Tipos.PUNTO == tokens.ElementAt(i).GetTipos())
                        {
                            i = i + 2;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                            {
                                int x2 = int.Parse(tokens.ElementAt(i).getLexema());

                                i = i + 2;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y1 = int.Parse(tokens.ElementAt(i).getLexema());

                                    for (int a = x1; x1 <= x2; a++)
                                    {
                                        obstaculos.Add(new Cordenadas(a, y1));
                                    }
                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y1 = 0;
                                    for (int j = 0; j <= variables.Count - 1; j++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                        {
                                            y1 = variables.ElementAt(j).getValor();
                                        }
                                    }
                                    for (int a = x1; a <= x2; a++)
                                    {
                                        obstaculos.Add(new Cordenadas(a, y1));
                                    }
                                }

                            }
                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                            {
                                int x2 = 0;
                                for (int q = 0; q <= variables.Count - 1; q++)
                                {
                                    if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(q).getId()))
                                    {
                                        x2 = variables.ElementAt(1).getValor();
                                    }
                                }
                                i = i + 2;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y1 = int.Parse(tokens.ElementAt(i).getLexema());

                                    for (int a = x1; x1 <= x2; a++)
                                    {
                                        obstaculos.Add(new Cordenadas(a, y1));
                                    }
                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y1 = 0;
                                    for (int j = 0; j <= variables.Count - 1; j++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(j).getId()))
                                        {
                                            y1 = variables.ElementAt(j).getValor();
                                        }
                                    }
                                    for (int a = x1; a <= x2; a++)
                                    {
                                        obstaculos.Add(new Cordenadas(a, y1));
                                    }
                                }
                            }
                        }

                    }//CUANDO VIENE DE LA FORMA (1..3,1..3)********************************************************
                    if (Token.Tipos.NUMERO==tokens.ElementAt(i).GetTipos())
                    {
                        int x1 = int.Parse(tokens.ElementAt(i).getLexema());
                        i = i + 3;
                        if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                        {
                            int x2= int.Parse(tokens.ElementAt(i).getLexema());
                            i = i + 2;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                            {
                                int y1 = int.Parse(tokens.ElementAt(i).getLexema());

                                i = i + 3;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = int.Parse(tokens.ElementAt(i).getLexema());

                                    for (int x=x1;x<=x2;x++)
                                    {
                                        for (int y=y1;y<=y2;y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x,y));
                                        }
                                    }

                                }else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = 0;
                                    for(int s = 0; s <= variables.Count - 1; s++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(s).getId()))
                                        {
                                            y2 = variables.ElementAt(s).getValor();
                                        }
                                    }
                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }
                                }
                            }else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                            {
                                int y1 = 0;
                                for (int s = 0; s <= variables.Count - 1; s++)
                                {
                                    if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(s).getId()))
                                    {
                                        y1 = variables.ElementAt(s).getValor();
                                    }
                                }
                                ////
                                i = i + 3;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = int.Parse(tokens.ElementAt(i).getLexema());

                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }

                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = 0;
                                    for (int s = 0; s <= variables.Count - 1; s++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(s).getId()))
                                        {
                                            y2 = variables.ElementAt(s).getValor();
                                        }
                                    }
                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }
                                }

                            }
                        }else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                        {
                            int x2 = 0;
                            for (int a=0;a<=variables.Count-1;a++)
                            {
                                if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(a).getId()))
                                {
                                    x2 = variables.ElementAt(a).getValor();
                                }
                            }
                            //////  
                            i = i + 2;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                            {
                                int y1 = int.Parse(tokens.ElementAt(i).getLexema());

                                i = i + 3;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = int.Parse(tokens.ElementAt(i).getLexema());

                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }

                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = 0;
                                    for (int s = 0; s <= variables.Count - 1; s++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(s).getId()))
                                        {
                                            y2 = variables.ElementAt(s).getValor();
                                        }
                                    }
                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }
                                }
                            }
                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                            {
                                int y1 = 0;
                                for (int s = 0; s <= variables.Count - 1; s++)
                                {
                                    if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(s).getId()))
                                    {
                                        y1 = variables.ElementAt(s).getValor();
                                    }
                                }
                                ////
                                i = i + 3;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = int.Parse(tokens.ElementAt(i).getLexema());

                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }

                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = 0;
                                    for (int s = 0; s <= variables.Count - 1; s++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(s).getId()))
                                        {
                                            y2 = variables.ElementAt(s).getValor();
                                        }
                                    }
                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }
                                }

                            }
                        }

                    }else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                    {
                        int x1 = 0;
                        for(int z = 0; z <= variables.Count - 1; z++)
                        {
                            if (variables.ElementAt(z).getId().Equals(tokens.ElementAt(i).getLexema()))
                            {
                                x1 = variables.ElementAt(z).getValor();
                            }
                        }
                        i = i + 3;
                        if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                        {
                            int x2 = int.Parse(tokens.ElementAt(i).getLexema());
                            i = i + 2;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                            {
                                int y1 = int.Parse(tokens.ElementAt(i).getLexema());

                                i = i + 3;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = int.Parse(tokens.ElementAt(i).getLexema());

                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }

                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = 0;
                                    for (int s = 0; s <= variables.Count - 1; s++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(s).getId()))
                                        {
                                            y2 = variables.ElementAt(s).getValor();
                                        }
                                    }
                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }
                                }
                            }
                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                            {
                                int y1 = 0;
                                for (int s = 0; s <= variables.Count - 1; s++)
                                {
                                    if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(s).getId()))
                                    {
                                        y1 = variables.ElementAt(s).getValor();
                                    }
                                }
                                ////
                                i = i + 3;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = int.Parse(tokens.ElementAt(i).getLexema());

                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }

                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = 0;
                                    for (int s = 0; s <= variables.Count - 1; s++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(s).getId()))
                                        {
                                            y2 = variables.ElementAt(s).getValor();
                                        }
                                    }
                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }
                                }

                            }
                        }
                        else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                        {
                            int x2 = 0;
                            for (int a = 0; a <= variables.Count - 1; a++)
                            {
                                if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(a).getId()))
                                {
                                    x2 = variables.ElementAt(a).getValor();
                                }
                            }
                            //////  
                            i = i + 2;
                            if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                            {
                                int y1 = int.Parse(tokens.ElementAt(i).getLexema());

                                i = i + 3;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = int.Parse(tokens.ElementAt(i).getLexema());

                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }

                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = 0;
                                    for (int s = 0; s <= variables.Count - 1; s++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(s).getId()))
                                        {
                                            y2 = variables.ElementAt(s).getValor();
                                        }
                                    }
                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }
                                }
                            }
                            else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                            {
                                int y1 = 0;
                                for (int s = 0; s <= variables.Count - 1; s++)
                                {
                                    if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(s).getId()))
                                    {
                                        y1 = variables.ElementAt(s).getValor();
                                    }
                                }
                                ////
                                i = i + 3;
                                if (Token.Tipos.NUMERO == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = int.Parse(tokens.ElementAt(i).getLexema());

                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }

                                }
                                else if (Token.Tipos.IDENTIFICADOR == tokens.ElementAt(i).GetTipos())
                                {
                                    int y2 = 0;
                                    for (int s = 0; s <= variables.Count - 1; s++)
                                    {
                                        if (tokens.ElementAt(i).getLexema().Equals(variables.ElementAt(s).getId()))
                                        {
                                            y2 = variables.ElementAt(s).getValor();
                                        }
                                    }
                                    for (int x = x1; x <= x2; x++)
                                    {
                                        for (int y = y1; y <= y2; y++)
                                        {
                                            obstaculos.Add(new Cordenadas(x, y));
                                        }
                                    }
                                }

                            }
                        }

                    }//***************************************************************************************************
                }