using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorLexico
{
    class Archivos
    {
        public StreamWriter archivo_dot;
        public string nombreArchivo; //nombre del archivo dot
        public String tituloo;//titulo de los archivos
        public string imagen;//nombre de la imagen
        
        public String ArchivoDot(List<Nodos> entrada)
        {
            if (Analizador.titulo!=null)
            {
                tituloo = Analizador.titulo.Trim(new char[] { '"' });
                //quitar los espacios
                tituloo = tituloo.Replace(" ", "");
                nombreArchivo = "Orga" + tituloo + ".dot";
                archivo_dot = new StreamWriter(nombreArchivo);
            }
            else
            {
                tituloo = "Organigrama";
                archivo_dot = new StreamWriter(tituloo);
            }

            archivo_dot.WriteLine("digraph grafica{");
            archivo_dot.WriteLine("rankdir=TB;");
            archivo_dot.WriteLine("node [shape = record, style=filled, fillcolor=seashell2];");

            for(int a = 0; a <= entrada.Count-1; a++)
            {
                archivo_dot.WriteLine("nodo"+entrada.ElementAt(a).getNodo()+"[ label= "+'"'+"Cod."+entrada.ElementAt(a).getCodigo()+"|"+entrada.ElementAt(a).getNombre()+'"'+"];");
            }
            
            //crear las relaciones

            for(int b = 0; b <= entrada.Count - 1; b++)
            {
                List<int> aux=entrada.ElementAt(b).gerLista();

                if (aux != null)
                {
                    for(int c = 0; c <= entrada.Count - 1; c++)

                    {
                        int codigoaux = entrada.ElementAt(c).getCodigo();
                        for(int d = 0; d <= aux.Count - 1; d++)
                        {
                            int auxSuperior = aux.ElementAt(d);

                            if (codigoaux == auxSuperior)
                            {
                                archivo_dot.WriteLine("nodo"+entrada.ElementAt(c).getNodo()+"->" + "nodo"+entrada.ElementAt(b).getNodo());
                            }
                        }
                    }
                }
                
            }
            archivo_dot.WriteLine("}");

            archivo_dot.Close();



            MessageBox.Show("El archivo se ha creado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return nombreArchivo;
        }

        public String EjecutarConsola(string direccion)
        {

            string parametro0 = "dot ";
            string parametro1 = " -Tpng";

            string parametro2 = tituloo+".png";
            string parametro3 = " -o";
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";

            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            //ocultar pantalla negrra
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(parametro0+nombreArchivo+parametro1+parametro3+parametro2+direccion);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

            return parametro2;

        }

        public void GenerarHtml(String entrada)

        {
            string nombrehtml = tituloo+".html";
            StreamWriter paginahtml = new StreamWriter(nombrehtml);

            paginahtml.WriteLine("<!DOCTYPE html>");
            paginahtml.WriteLine("<html>");
            paginahtml.WriteLine("<head>");
            paginahtml.WriteLine("<title>"+Analizador.titulo+"</title>");
            paginahtml.WriteLine("</head>");
            paginahtml.WriteLine("<body>");
            paginahtml.WriteLine("<header><div style="+'"'+"background-color:aqua; border:groove 10px aqua;outline-offset:5px; font-family:Vineta BT; font-size:500%;text-align:center;"+'"'+">"+
                Analizador.titulo + "</div></head>");
            paginahtml.WriteLine("<center>");
            paginahtml.WriteLine("<img src= " + '"' + entrada + '"'+"width="+'"'+"1200"+'"'+" height="+'"'+"500"+'"'+">");
            paginahtml.WriteLine("</center>");

            paginahtml.WriteLine("<footer style=" + '"' + "background-color:aqua; font-family:Perpetua; text-align:center; font-size:200%;" + '"'+"><pre>Fernando Feliciano Chajon del Cid--201701089</pre></footer>");

            paginahtml.WriteLine("</body>");
            paginahtml.WriteLine("</html");

            paginahtml.Close();

            Process.Start( Path.GetFullPath(nombrehtml));
            


        }

        public void GenerarTablaToken(List<Token> auxiliar)
        {

            if (auxiliar != null )
            {
                int contador = 1;
                String nombre1 = "TablaToken" + tituloo + ".html";
                StreamWriter token = new StreamWriter(nombre1);
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
                for (int a = 0; a <= auxiliar.Count - 1; a++)
                {

                    if (auxiliar.ElementAt(a).getTipo().Equals("Desconocido"))
                    {

                    }
                    else
                    {
                        token.WriteLine(
                            "<tr>" +
                            "<td><b>" + contador + "</b></td>" +
                            "<td><b>" + auxiliar.ElementAt(a).getLexema() + "</b></td>" +
                            "<td><b>" + auxiliar.ElementAt(a).getTipo() + "</b></td>" +
                            "<td><b>" + auxiliar.ElementAt(a).getFila() + "</b></td>" +
                            "<td><b>" + auxiliar.ElementAt(a).getColumna() + "</b></td>" +
                            "</tr>"






                            );
                        contador++;
                    }
                }

                token.WriteLine("</table></body></html>");
                token.Close();
                Process.Start(Path.GetFullPath(nombre1));

            }
        }

        public void GenerarTablaErrores(List<Token> auxiliar)
        {
            //Compruebo que la lista no llegue vacia
            if ((auxiliar != null) )
            {


                int contador = 1;
                String nombre2 = "TablaErrores" + tituloo + ".html";
                StreamWriter token = new StreamWriter(nombre2);
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
                            "<th scope=" + '"' + "col" + '"' + ">Error</th>" +
                            "<th scope=" + '"' + "col" + '"' + ">Descripcion</th>" +
                            "<th scope=" + '"' + "col" + '"' + ">Fila</th>" +
                            "<th scope=" + '"' + "col" + '"' + ">Columna</th>" +



                            "</tr>"



                        );
                for (int a = 0; a <= auxiliar.Count - 1; a++)
                {

                    if (auxiliar.ElementAt(a).getTipo().Equals("Desconocido"))
                    {
                        token.WriteLine(
                            "<tr>" +
                            "<td><b>" + contador + "</b></td>" +
                            "<td><b>" + auxiliar.ElementAt(a).getLexema() + "</b></td>" +
                            "<td><b>" + auxiliar.ElementAt(a).getTipo() + "</b></td>" +
                            "<td><b>" + auxiliar.ElementAt(a).getFila() + "</b></td>" +
                            "<td><b>" + auxiliar.ElementAt(a).getColumna() + "</b></td>" +
                            "</tr>"


                            );
                        contador++;
                    }



                }
                token.WriteLine("</table></body></html>");
                token.Close();
                Process.Start(Path.GetFullPath(nombre2));

            }
        }



    }
}
