using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    class Reportes
    {
        public int contador;

        public void Tabla(List<Token> auxiliar)
        {
            contador = 1;
            String nombre = "TablaToken.html";
            StreamWriter token = new StreamWriter(nombre);
            token.WriteLine("<!DOCTYPE html>");
            token.WriteLine("<html>");
            token.WriteLine("<head>");
            token.WriteLine("<title>TablaTokens</title>");
            token.WriteLine("</head>");
            token.WriteLine("<body>");
            token.WriteLine(

                 "<table border=3 width=60% height=7%>" +

                            "<tr>" +
                            "<th scope=" + '"' + "col" + '"' + ">No</th>" +
                            "<th scope=" + '"' + "col" + '"' + ">Lexema</th>" +
                            "<th scope=" + '"' + "col" + '"' + ">Tipo</th>" +
                            "<th scope=" + '"' + "col" + '"' + ">Fila</th>" +
                            "<th scope=" + '"' + "col" + '"' + ">Columna</th>" +



                            "</tr>"
                );

            for (int i=0;i<=auxiliar.Count-1;i++)
            {
                if (!auxiliar.ElementAt(i).getTipo().Equals("Desconocido"))
                {
                    token.WriteLine(

                           "<tr>" +
                            "<td><b>" + contador + "</b></td>" +
                            "<td><b>" + auxiliar.ElementAt(i).getLexema() + "</b></td>" +
                            "<td><b>" + auxiliar.ElementAt(i).getTipo() + "</b></td>" +
                            "<td><b>" + auxiliar.ElementAt(i).getFila() + "</b></td>" +
                            "<td><b>" + auxiliar.ElementAt(i).getColumna() + "</b></td>" +
                            "</tr>"


                           

                        );
                    contador++;
                }
            }
            token.WriteLine("</table></body></html>");
            token.Close();
            Process.Start(Path.GetFullPath(nombre));

        }

        public void TablaErrores(List<ManejoErrores> errores)
        {
            contador = 1;
            String nombre = "TablaErrores.html";
            StreamWriter token = new StreamWriter(nombre);
            token.WriteLine("<!DOCTYPE html>");
            token.WriteLine("<html>");
            token.WriteLine("<head>");
            token.WriteLine("<title>TablaErrores</title>");
            token.WriteLine("</head>");
            token.WriteLine("<body>");
            token.WriteLine(

                 "<table border=3 width=60% height=7%>" +

                            "<tr>" +
                            "<th scope=" + '"' + "col" + '"' + ">No</th>" +
                            "<th scope=" + '"' + "col" + '"' + ">Error</th>" +
                            "<th scope=" + '"' + "col" + '"' + ">Tipo</th>" +
                            "<th scope=" + '"' + "col" + '"' + ">Descripcion</th>" +
                            "<th scope=" + '"' + "col" + '"' + ">Fila</th>" +

                            "<th scope=" + '"' + "col" + '"' + ">Columna</th>" +


                            "</tr>"
                );

            for (int i = 0; i <= errores.Count - 1; i++)
            {
                
                    token.WriteLine(

                           "<tr>" +
                            "<td><b>" + contador + "</b></td>" +
                            "<td><b>" + errores.ElementAt(i).getError() + "</b></td>" +
                            "<td><b>" + errores.ElementAt(i).getTipo() + "</b></td>" +
                            "<td><b>" + errores.ElementAt(i).getDescripcion() + "</b></td>" +
                            "<td><b>" + errores.ElementAt(i).getFila() + "</b></td>" +
                            "<td><b>" + errores.ElementAt(i).getColumna() + "</b></td>" +
                            "</tr>"




                        );
                    contador++;
                
            }
            token.WriteLine("</table></body></html>");
            token.Close();
            Process.Start(Path.GetFullPath(nombre));
        }
    }

    
}
