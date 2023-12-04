using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class VistaJuego : Form
    {
        //***************************************************************
        public int Intervalo;
        public int TamañoX;
        public int TamañoY;
        public int InicioX;
        public int ReiniciarX;
        public int InicioY;
        public int ReiniciarY;
        public int FinX;
        public int FinY;
        public List<Cordenadas> recorrido;
        public List<Cordenadas> obstaculos;
        public List<Enemigo> enemigos;
        public int TotalEnemigos;
        //****************************************************************
        public int[,] tablero;

        //HILOS A EJECUTAR
        //creamos un delegado para poder realizar procesos desde el hilo 
        public Thread recorer;
        public ThreadStart delegado;
        public ParameterizedThreadStart threadStart;

        //-------------- USO DE VARIABLE PARA LOS ENEMIGOS---------------------------
        public Enemigo enemigo;
        public int EneX;
        public int EneY;
        public int EneX2;
        public int EneY2;
        public int EneX3;
        public int EneY3;
        public List<Cordenadas> RecoEnemigos;
        public Thread [] ene;
        //--------------------------
        public int e1, e2, e3;
        public int final1, final2, final3;
        public int inicio1, inicio2, inicio3;
        public bool Existe1, Existe2, Existe3;
        public int pos1, pos2, pos3;

        //----------------COntrolar los enemigos
       
        //--------------------------------- Detener los ciclos
        public bool parar;
        
        public VistaJuego(int inter,int TamX,int TamY,int IniX,int IniY,int FinX, int FinY,List<Cordenadas> reco,List<Cordenadas> obs,List<Enemigo> enemigos,int total)
        {
            InitializeComponent();
            this.Intervalo = inter;
            this.TamañoX = TamX;
            this.TamañoY = TamY;
            this.InicioX = IniX;
            this.ReiniciarX = IniX;
            this.InicioY = IniY;
            this.ReiniciarY = IniY;
            this.FinX = FinX;
            this.FinY = FinY;
            this.recorrido = reco;
            this.obstaculos = obs;
            this.enemigos = enemigos;
            this.TotalEnemigos = total;

            tablero = new int[TamañoX, TamañoY];

            //Cantidad de filas de la matriz:" + mat.GetLength(0));
            //Cantidad de columnas de la matriz:" + mat.GetLength(1));
            // el valor 0 es libre 
            //el valor 1 es obstaculos
            for (int i=0;i<=tablero.GetLength(0)-1;i++)
            {
                for (int j=0;j<=tablero.GetLength(1)-1;j++)
                {

                    for (int k=0;k<=obstaculos.Count-1;k++)
                    {
                        int x = obstaculos.ElementAt(k).getX();
                        int y = obstaculos.ElementAt(k).getY();
                        if (i==x & j==y)
                        {
                            tablero[i, j] = 1;
                            
                        }
                       
                    }

                }
            }
            //e1 = e2 = e3 = 0;
            Existe1 = Existe2 = Existe3 = false;
            ObtenerInicialEnemigos();

           
        }
        public void ObtenerInicialEnemigos()
        {
            if (TotalEnemigos!=0)
            {
                for (int i = 0; i <= enemigos.Count - 1; i++)
                {

                    if (i == 0)
                    {
                        Existe1 = true;
                        e1 = i;
                        if (0 == enemigos.ElementAt(i).getTipo())
                        {

                            EneX = inicio1 = enemigos.ElementAt(i).getX1();
                            final1 =pos1= enemigos.ElementAt(i).getX2();
                            EneY = enemigos.ElementAt(i).getY1();
                        }
                        else if (1 == enemigos.ElementAt(i).getTipo())
                        {
                            EneX = enemigos.ElementAt(i).getX1();
                            final1 = pos1=enemigos.ElementAt(i).getY2();
                            EneY = inicio1 = enemigos.ElementAt(i).getY1();
                        }

                    }
                    else if (i == 1)
                    {
                        Existe2 = true;
                        e2 = i;
                        if (0 == enemigos.ElementAt(i).getTipo())
                        {
                            EneX2 = inicio2 = enemigos.ElementAt(i).getX1();
                            final2 =pos2= enemigos.ElementAt(i).getX2();
                            EneY2 = enemigos.ElementAt(i).getY1();
                        }
                        else if (1 == enemigos.ElementAt(i).getTipo())
                        {
                            EneX2 = enemigos.ElementAt(i).getX1();
                            final2 = pos2=enemigos.ElementAt(i).getY2();
                            EneY2 = inicio2 = enemigos.ElementAt(i).getY1();
                        }
                    }
                    else if (i == 2)
                    {
                        Existe3 = true;
                        e3 = i;
                        if (0 == enemigos.ElementAt(i).getTipo())
                        {
                            EneX3 = inicio3 = enemigos.ElementAt(i).getX1();
                            final3 = pos3= enemigos.ElementAt(i).getX2();
                            EneY3 = enemigos.ElementAt(i).getY1();
                        }
                        else if (1 == enemigos.ElementAt(i).getTipo())
                        {
                            EneX3 = enemigos.ElementAt(i).getX1();
                            final3 =pos3= enemigos.ElementAt(i).getY2();
                            EneY3 = inicio3 = enemigos.ElementAt(i).getY1();
                        }
                    }
                }
            }
           
        }

        private void VistaJuego_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.DoubleBuffered = true; // Seteamos doble buffer para que las imagenes no parpadeen al refrescar el Form
            this.Size = new System.Drawing.Size(TamañoX*65, TamañoY*65); // Cambiamos el tamaño 
        }

        private void VistaJuego_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap obstaculo = new Bitmap(@"C:\Users\feliciano07\Desktop\LFP\LFP_Proyectos\Laberinto\Laberinto\Imagenes\obstaculo.jpg");
            for (int i = 0; i <= tablero.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= tablero.GetLength(1) - 1; j++)
                {

                    if (tablero[i, j] == 1)
                    {
                        g.DrawImage(obstaculo, (i * 50)+50, (j * 50)+50);//
                    }
                }
            }

            //dibujamos las casillas
            Bitmap camino = new Bitmap(@"C:\Users\feliciano07\Desktop\LFP\LFP_Proyectos\Laberinto\Laberinto\Imagenes\camino.jpg");
            for (int i = 0; i <= tablero.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= tablero.GetLength(1) - 1; j++)
                {

                    if (tablero[i, j] == 0)
                    {
                        g.DrawImage(camino, (i*50)+50, (j*50)+50);//
                    }
                }
            }
            
            

            Bitmap image = new Bitmap(@"C:\Users\feliciano07\Desktop\LFP\LFP_Proyectos\Laberinto\Laberinto\Imagenes\sonic.png");
            g.DrawImage(image, (InicioX * 50)+50,(InicioY*50)+50);

            image = new Bitmap(@"C:\Users\feliciano07\Desktop\LFP\LFP_Proyectos\Laberinto\Laberinto\Imagenes\llegada.png");
            g.DrawImage(image, (FinX * 50)+50, (FinY * 50)+50);

            Bitmap ene = new Bitmap(@"C:\Users\feliciano07\Desktop\LFP\LFP_Proyectos\Laberinto\Laberinto\Imagenes\enemigo11.png");
            
                
                    if (Existe1)
                    {
                        
                            g.DrawImage(ene, (EneX * 50) + 50, (EneY * 50) + 50);
                         
                       
                    }
            if (Existe2)
                    {
                        
                        g.DrawImage(ene, (EneX2 * 50) + 50, (EneY2 * 50) + 50);
                    }
            if (Existe3)
                    {
                        g.DrawImage(ene, (EneX3 * 50) + 50, (EneY3 * 50) + 50);
                    }
                    
                

            
        }

        public void EmpezarRecorrido()
        {
            

            foreach (var c in recorrido)
            {
                InicioX = c.x;

                InicioY = c.y;

                Enemigos();

                if (InicioX==EneX && InicioY==EneY)
                {
                    parar = false;
                   
                    MessageBox.Show("Game Over", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    InicioX = ReiniciarX;
                    InicioY = ReiniciarY;
                    recorer.Suspend();

                }
                else if (InicioX == EneX2 && InicioY == EneY2)
                {
                    parar = false;
                    MessageBox.Show("Game Over", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    InicioX = ReiniciarX;
                    InicioY = ReiniciarY;
                    recorer.Suspend();

                }
                else if (InicioX == EneX3 && InicioY == EneY3)
                {
                    parar = false;
                    MessageBox.Show("Game Over", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    InicioX = ReiniciarX;
                    InicioY = ReiniciarY;
                    recorer.Suspend();

                }else if (InicioX == FinX && InicioY == FinY)
                {
                    parar = false;
                    MessageBox.Show("Nivel Completado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    InicioX = ReiniciarX;
                    InicioY = ReiniciarY;
                    recorer.Suspend();
                }

               



                Thread.Sleep(Intervalo);
                this.Refresh();
            }
        }
        public void Enemigos()
        {
            if (Existe1)
            {
                
                if (0 == enemigos.ElementAt(0).getTipo())
                {
                    if (EneX< final1)
                    {
                        final1 = pos1;
                        EneX++;
                    }
                    else if (EneX >inicio1 )
                    {
                        final1 = inicio1;
                        EneX--;
                    }
                    else
                    {
                        final1 = pos1;
                        EneX++;
                    }

                }
                else if (1 == enemigos.ElementAt(0).getTipo())
                {
                    if (EneY <final1)
                    {
                        final1 = pos1;
                        EneY++;
                    }
                    else if (EneY >inicio1)
                    {
                        final1 = inicio1;
                        EneY--;
                    }
                    else
                    {
                        final1 = pos1;
                        EneY++;
                    }
                }
            }


            if (Existe2)
            {
                
                if (0 == enemigos.ElementAt(1).getTipo())
                {
                    if (EneX2 < final2 )
                    {
                        final2 = pos2;
                        EneX2++;
                    }
                    else if (EneX2 >inicio2)
                    {
                        final2 = inicio2;
                        EneX2--;
                    }
                    else
                    {
                        final2 = pos2;
                        EneX2++;
                    }

                }
                else if (1 == enemigos.ElementAt(1).getTipo())
                {
                    if (EneY2 < final2)
                    {
                        final2 = pos2;
                        EneY2++;
                    }
                    else if (EneY2 >inicio2)
                    {
                        final2 = inicio2;
                        EneY2--;
                    }
                    else
                    {
                        final2 = pos2;
                        EneY2++;
                    }
                }
            }
            if (Existe3)
            {
                
                if (0 == enemigos.ElementAt(2).getTipo())
                {
                    if (EneX3 < final3)
                    {
                        final3 = pos3;
                        EneX3++;
                    }
                    else if (EneX3 > inicio3)
                    {
                        final3 = inicio3;
                        EneX3--;
                    }
                    else
                    {
                        final3 = pos3;
                        EneX3++;
                    }

                }
                else if (1 == enemigos.ElementAt(2).getTipo())
                {
                    if (EneY3 < final3)
                    {
                        final3 = pos3;
                        EneY3++;
                    }
                    else if (EneY3 >inicio3)
                    {
                        final3 = inicio3;
                        EneY3--;
                    }
                    else
                    {
                        final3 = pos3;
                        EneY3++;
                    }
                }
            }
                
            
            
                
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            
            delegado =new ThreadStart(EmpezarRecorrido);
            recorer = new Thread(delegado);

            
            recorer.Start();
            /*Thread[] ene = new Thread[TotalEnemigos];

            for (int i=0;i<=ene.Length-1;i++)
            {
                threadStart = new ParameterizedThreadStart(IniciarEnemigos);
                ene[i] = new Thread(threadStart);
                ene[i].Start(i);
            }*/

        }
        public void IniciarEnemigos(Object i)
        {
            /*  int contador = 0;
              int d = int.Parse(i.ToString());
              if (d==0)
              {
                  List<Cordenadas> total;
                  total = enemigos.ElementAt(0).getRecorrido();
                  do
                  {

                      if (contador <= total.Count - 1)
                      {
                          contador = 0;
                          for (int j = 0; j <= total.Count - 1; j++)
                          {
                              e1 = j;
                              EneX = total.ElementAt(e1).getX();
                              EneY = total.ElementAt(e1).getY();
                              contador++;
                              Thread.Sleep(Intervalo);
                              //this.Refresh();
                          }
                          contador++;
                      }
                      else if (contador >= total.Count - 1)
                      {
                          for (int j = total.Count - 1; j >= 0; j--)
                          {
                              e1 = j;
                              EneX = total.ElementAt(e1).getX();
                              EneY = total.ElementAt(e1).getY();
                              Thread.Sleep(Intervalo);
                              // this.Refresh();
                          }
                          contador = 0;
                      }
                  } while (parar);

              }else if (d==1)
              {
                  List<Cordenadas> total;
                  total = enemigos.ElementAt(1).getRecorrido();
                  do
                  {

                      if (contador <= total.Count - 1)
                      {
                          contador = 0;
                          for (int j = 0; j <= total.Count-1; j++)
                          {
                              e2 = j;
                              EneX2 = total.ElementAt(e2).getX();
                              EneY2 = total.ElementAt(e2).getY();
                              contador++;
                              Thread.Sleep(Intervalo);
                              this.Refresh();
                          }
                          contador++;
                      }
                      else if (contador >= total.Count - 1)
                      {
                          for (int j = total.Count - 1; j >= 0; j--)
                          {
                              e2 = j;
                              EneX2 = total.ElementAt(e2).getX();
                              EneY2 = total.ElementAt(e2).getY();
                              Thread.Sleep(Intervalo);
                              this.Refresh();
                          }
                          contador = 0;
                      }
                  }while (parar);

              }
              else if (d==2)
              {
                  List<Cordenadas> total;
                  total = enemigos.ElementAt(2).getRecorrido();
                  do
                  {

                      if (contador <= total.Count - 1)
                      {
                          contador = 0;
                          for (int j = 0; j <= total.Count - 1; j++)
                          {
                              e3 = j;
                              EneX3 = total.ElementAt(e3).getX();
                              EneY3 = total.ElementAt(e3).getY();
                              contador++;
                              Thread.Sleep(Intervalo);
                              this.Refresh();
                          }
                          contador++;
                      }
                      else if (contador >= total.Count - 1)
                      {
                          for (int j = total.Count - 1; j >= 0; j--)
                          {
                              e3 = j;
                              EneX3 = total.ElementAt(e3).getX();
                              EneY3 = total.ElementAt(e3).getY();
                              Thread.Sleep(Intervalo);
                              this.Refresh();
                          }
                          contador = 0;
                      }
                  } while (parar);

              }*/
        }
    }
}
