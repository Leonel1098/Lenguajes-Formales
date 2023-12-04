import os
import tkinter
from tkinter import *
from tkinter import filedialog
import io
from io import*
from Alumno import alumno
from Curso import Curso

#Lista de Cursos 
Cursos  = []

 #Opciones del Menu Principal
def menu1():
	"""
	Función que limpia la pantalla y muestra nuevamente el menu
	"""
	os.system('cls') # NOTA para windows tienes que cambiar clear por cls
	print ("Selecciona una opción")
	print ("\t1 -  Cargar Archivo ")
	print ("\t2 - Mostrar Reporte en Consola ")
	print ("\t3 - Exportar Reporte ")
	print ("\t9 - salir")
 #Menu Principal del Programaa
def MenuPrincipal(): 
    while True:
        # Mostramos el menu
        menu1()
    
        # solicituamos una opción al usuario
        opcionMenu = input("Seleccione una opcion >> ")
    
        if opcionMenu=="1":
            Reporte()
            CargarArchivo()

        elif opcionMenu=="2":
            print ("")
            print("Mostrar Reporte en Consola ")
            MostrarReporte()
        elif opcionMenu=="3":
            print ("")
            input("Exportar Reporte")
            Reporte()
           
        elif opcionMenu=="9":
            break
        else:
            print ("")
            input("No has pulsado ninguna opción correcta...\npulsa una tecla para continuar")

def CargarArchivo():
    Cursos.clear()
    #Abre Ventana para Buscar el archivo .lfp 
    archivo =  filedialog.askopenfilename(initialdir = "/") 
    #Abre el achivo 
    archivo_texto = open(archivo ,'r')
    #Contenido del archivo leido 
    texto = archivo_texto.read()
    #Analiza el contenido del Archivo 
    Analizador(texto)
    

def Analizador(texto):
    print("Analizando...")
    
    longitud = len(texto)
    
    #Variables y que van a servir para separa el echivo 
    nombreCurso =''
    Alumnos = []
    Reportes = []
    nombreAlumno = ''
    nota =''

    texto=texto.lstrip()
    #Extraer el Nombre del Curso 
    nombreCurso = NombreCurso(texto,longitud)
    print("El nombre del Curso es : ")
    print(nombreCurso)
    #Obtener la lista del archivo leido 
    Alumnos=listaAlumnos(texto, longitud, nombreAlumno, nota, nombreCurso)
    #Obtener los reporte que tendra el Archivo 
    Reportes = ReportesQuePide(texto, longitud)
    nuevoCurso = Curso(nombreCurso,Alumnos,Reportes)
    Cursos.append(nuevoCurso)
    for i in range(len(Cursos)):
        print(Cursos[i].getNombre())
        for x in range(len(Cursos[i].getAlumnos())):
            Cursos[i].getAlumnos()[x].getNota()== Cursos[i].getAlumnos()[x].getNota().lstrip()
            entero = int(Cursos[i].getAlumnos()[x].getNota())

            Cursos[i].getAlumnos()[x].setNota(entero)
            print(Cursos[i].getAlumnos()[x].getNombre(),
            Cursos[i].getAlumnos()[x].getNota())
    

   # for r in range(len(Cursos[i].getReportes())):
          #   print(Cursos[i].getReportes()[r])

def NombreCurso(texto,longitud):

    nombre = ''
    for i in range(longitud):

        if texto[i] == '{' or texto[i] == '=' :
            break
        else: 
         nombre = nombre+texto[i]
    return nombre 

def listaAlumnos(texto,longitud,nombreAlumno,nota,nombreCurso):
    #Variables que sirven para separar y analizar el texto de entrada
    
    alumnos =[]
    name = ''
    nombreynotas = ''
    nota = ''
    alumnox = ''
    listaOficialAlumnos= []
    #Recorriendo y separando el 
    #Condicionales para separa la lista 
    for i in range(len(nombreCurso),longitud):
        if texto[i]=='}':
            break
        else:
            if texto[i] == '{' or texto[i] == '=' :
                continue
            else:
                alumnox=alumnox+texto[i] 
    print("son:  ",len(alumnox))
    alumnox=alumnox.lstrip()
    alumnox=alumnox.lstrip(' ')   
    for i in range(len(alumnox)):

        if alumnox[i]==',' or alumnox[i] == '\n':
            for x in range(len(nombreynotas)):
                if nombreynotas[x] =='<' :
                    alumnos.append(nombreynotas)
            nombreynotas=''  
            
        else:
                
            nombreynotas=nombreynotas+alumnox[i]
    #Recorre y separa los alumnos y las notas 
    for i in range(len(alumnos)):
        nombre_alumno_actual=''
        alumno_actual=str(alumnos[i])
        for j in range(len(alumno_actual)):
                if alumno_actual[j]!='<':
                    if alumno_actual[j]!='"':
                        if alumno_actual[j].isalpha():
                            nombre_alumno_actual=nombre_alumno_actual+alumno_actual[j]
                        if alumno_actual[j]==' ':
                            nombre_alumno_actual=nombre_alumno_actual+alumno_actual[j]
                       
                        if alumno_actual[j].isdigit():
                            nota=nota+alumno_actual[j]
                        if alumno_actual[j]=='>':
                            #Crea un Objeto nuevo igual a alumno
                            nuevo= alumno(nombre_alumno_actual, nota)
                            #Guarda en lista lo el objeto 
                            listaOficialAlumnos.append(nuevo)
                            nota=''
                            nombre_alumno_actual=''
    for i in range(len(listaOficialAlumnos)):
        print(listaOficialAlumnos[i].getNombre()+' Y su nota es : '+
        listaOficialAlumnos[i].getNota())
        #Retorna una lista ya con los alumnos y las notas separadas 
    return listaOficialAlumnos

def ReportesQuePide(texto,longitud):
    #Vartiables que sirven para separa 
    texto=texto+','
    Reporte=[]
    Losrepores=''
    for i in range(longitud):
        #Condicionales para separar el texto 
        if texto[i]=='}':
            for x in range(i+1,longitud+1):
                if texto[x]!=',' :

                    Losrepores=Losrepores+texto[x]
                    
                else :
                    Reporte.append(Losrepores)
                    Losrepores=''
                
    #Retorna lista de reportes  
    return Reporte


def ordenamientoBurbuja(unaLista):
    #Ordenamiento La lista de cursos 
   
    for numPasada in range(len(unaLista.getAlumnos())-1,0,-1):

        for i in range(numPasada):

            if unaLista.getAlumnos()[i].getNota()>unaLista.getAlumnos()[i+1].getNota():
                temp = unaLista.getAlumnos()[i]
                unaLista.getAlumnos()[i] = unaLista.getAlumnos()[i+1]
                unaLista.getAlumnos()[i+1] = temp
            #if unaLista[i].getAlumnos[i].getNota()>unaLista[i+1].getAlumnos()[i].getNota():
             #   temp = unaLista[i].getAlumnos().getNota()
              #  print(temp)
                #unaLista[i] = unaLista[i+1]
                #unaLista[i+1] = temp
    return unaLista

def mostrarASC(unalista):
    #Muestra la lista de Forma Acendente
    print("-------------------------------------  ")
    print("ASC: Ordenamiento Acendente")
    print()
    global Reportando
    Reportando += "<h1><center>"+unalista.getNombre()+ "!</center></h1>"
    
    Reportando += """<h1>Ordenamiento Acendente !</h1>"""
    print(unalista.getNombre())
    Reportando += """ <center><table class="table">
        <div >
        <p>
            <thead>
            <tr>
            <th scope="col">Nombre Alumno</th>
            <th scope="col">Nota</th>
            
            </tr>
                </thead>
                 <tbody>"""
    
    
    for i in range(len (unalista.getAlumnos())):
        
        print(unalista.getAlumnos()[i].getNombre(),'\t',
        unalista.getAlumnos()[i].getNota())
        print()
        if unalista.getAlumnos()[i].getNota()>61:

            Reportando += """
                    
                        <tr>
                        <td><p class="text-primary">
                        """+unalista.getAlumnos()[i].getNombre()+ """</p></td>
                    <td><p class="text-primary">"""+str(unalista.getAlumnos()[i].getNota())+"""</p></td>
                        """
        elif unalista.getAlumnos()[i].getNota()<61:
                Reportando += """
                    
                        <tr>
                        <td><p class="text-danger">
                        """+unalista.getAlumnos()[i].getNombre()+ """</p></td>
                    <td><p class="text-danger">"""+str(unalista.getAlumnos()[i].getNota())+"""</p></td>
                        """

    Reportando += """
            </tbody>
            </p>
            </div>
            </table></center>"""
    Reportando+="adfasdf"





    print("-------------------------------------------")
def mostrarDESC(unalista):
    #Muestra lista de Forma Decendente
    print("--------------------------------------------") 
    print("DESC : Ordenamiento Decendente")
    global Reportando
    
    Reportando += "<h1><center>"+unalista.getNombre()+ "!</center></h1>"
    Reportando += """<h1>Ordenamiento Decendente !</h1>"""

    longitud = len(unalista.getAlumnos())


    Reportando += """ <center><table class="table">
        <div >
        <p>
            <thead>
            <tr>
            <th scope="col">Nombre Alumno</th>
            <th scope="col">Nota</th>
            
            </tr>
                </thead>
                 <tbody>"""
   
    for i in range(longitud-1, -1, -1):
        print(unalista.getAlumnos()[i].getNombre(),'\t',
        unalista.getAlumnos()[i].getNota())
        print()
        if unalista.getAlumnos()[i].getNota()>61:

            Reportando += """
                    
                        <tr>
                        <td><p class="text-primary">
                        """+unalista.getAlumnos()[i].getNombre()+ """</p></td>
                    <td><p class="text-primary">"""+str(unalista.getAlumnos()[i].getNota())+"""</p></td>
                        """
        elif unalista.getAlumnos()[i].getNota()<61:
                Reportando += """
                    
                        <tr>
                        <td><p class="text-danger">
                        """+unalista.getAlumnos()[i].getNombre()+ """</p></td>
                    <td><p class="text-danger">"""+str(unalista.getAlumnos()[i].getNota())+"""</p></td>
                        """
    Reportando += """
            </tbody>
            </p>
            </div>
            </table></center>"""
    print("-------------------------------------------")           
             
def MostrarReporte():
    print()
    for i in range(len(Cursos)):
        for r in range(len(Cursos[i].getReportes())):
            print(Cursos[i].getReportes()[r])
            reporte = Cursos[i].getReportes()[r].lstrip()
            if reporte =='ASC':
                unalista = ordenamientoBurbuja(Cursos[i])
                mostrarASC(unalista)
            elif reporte =='DESC':
                unalista == ordenamientoBurbuja(Cursos[i])
                mostrarDESC(unalista)

            elif reporte =='AVG':
                print("Promedio")
                unalista == ordenamientoBurbuja(Cursos[i])
                Promedio(unalista)

            elif reporte =='MAX':
                print( "nota máxima de los estudiantes del curso")
                unalista == ordenamientoBurbuja(Cursos[i])
                maxi(unalista)
               
            elif reporte =='MIN':
                unalista == ordenamientoBurbuja(Cursos[i])
                min(unalista)
            elif reporte =='APR':
                unalista == ordenamientoBurbuja(Cursos[i])
                Aprobados(unalista)
            elif reporte =='REP':
                unalista == ordenamientoBurbuja(Cursos[i])
                Reprobados(unalista)
            

def maxi(unalista):
    global Reportando
    print("---------------------------------------")
    print("    Estudiantes con la Nota Maxima   ")
    i = (len(unalista.getAlumnos())-1) 
    print(unalista.getAlumnos()[i].getNombre(),'\t',
        unalista.getAlumnos()[i].getNota())
    Reportando+="""<div class="p-3 mb-2 bg-info text-white">"""
    Reportando += """<h1>Nota Maxima</h1>"""
   
    Reportando += """<h2>"""+unalista.getAlumnos()[i].getNombre()+": "+str(unalista.getAlumnos()[i].getNota())+"""</h2>"""
    
    
   
    Reportando += "</div>"
    print("---------------------------------------")
def min(unalista):
    global Reportando
    print("----------------------------------------")
    print("     Estudiante Con la Nota Minima      ")
    i = 0
    print(unalista.getAlumnos()[i].getNombre(),'\t',
        unalista.getAlumnos()[i].getNota())

    print("---------------------------------------")
    Reportando+="""<div class="p-3 mb-2 bg-warning text-white">"""
    Reportando += """<h1>Nota Minima </h1>"""
   
    Reportando += """<h2>"""+unalista.getAlumnos()[i].getNombre()+": "+str(unalista.getAlumnos()[i].getNota())+"""</h2>"""
    
    
   
    Reportando += "</div>"
   

def Aprobados(unalista):
    print("---------------------------------------------")
    print("                  Aprobados               ")
    longitud = len(unalista.getAlumnos())
    n=0
    for i in range(longitud-1, -1, -1):
        if unalista.getAlumnos()[i].getNota()>61:

            print(unalista.getAlumnos()[i].getNombre(),'\t',
            unalista.getAlumnos()[i].getNota())
            print()
            n=n+1
    print("El Curso Tiene ",n," Alumnos Aprobados")
    print("-------------------------------------------") 
    print()
    global Reportando
    Reportando+="""<div class="p-3 mb-2 bg-primary text-white">"""
    
   
    Reportando += """<h2>Numero de Estudiantes Aprobados : """ +str(n)+"""</h2>"""
    
    
   
    Reportando += "</div>"
def Reprobados(unalista):
    print("-------------------------------------------")
    print("Reprobados")
    longitud = len(unalista.getAlumnos())
    n=0
    for i in range(longitud-1, -1, -1):
        if unalista.getAlumnos()[i].getNota()<61:

            print(unalista.getAlumnos()[i].getNombre(),'\t',
            unalista.getAlumnos()[i].getNota())
            print()
            n=n+1
    print("El Curso Tiene ",n," Alumnos Reprobados ")
    print("-------------------------------------------")
    print()
    global Reportando
    Reportando+="""<div class="p-3 mb-2 bg-danger text-white">"""
    Reportando += """<h2>Numero de Estudiantes Reprobados : """ +str(n)+"""</h2>"""
    
    
   
    Reportando += "</div>"
def Promedio(unalista):
    print("-------------------------------------------")
    print("             Promedio                      ")
    n=0
    m=0
    longitud = len(unalista.getAlumnos())
    for i in range(longitud-1, -1, -1):
         m =m+ unalista.getAlumnos()[i].getNota()

         
         n=n+1
    promedio = m/n 
    print('El Promedio de Notas del Curso es de ',promedio)
    print("-------------------------------------------------")
    print()
    global Reportando
    Reportando+="""<div class="p-3 mb-2 bg-success text-white">"""
    Reportando += """<h1>Promedio </h1>"""
   
    Reportando += """<h2>Promedio : """ +str(promedio)+"""</h2>"""
    
    
   
    Reportando += "</div>"


  
Reportando="" 
global html
def Reporte():
    global Reportando 
    Inicio  = """
        <!doctype html>
        <html lang="en">
        <head>
            <!-- Required meta tags -->
            <meta charset="utf-8">
            <meta name="viewport" content="width=device-width, initial-scale=1">

            <!-- Bootstrap CSS -->
            <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We" crossorigin="anonymous">

            <title>Reporte!</title>
        </head>
        <body>
            <h1>Reporte!</h1>

            <!-- Optional JavaScript; choose one of the two! -->

            <!-- Option 1: Bootstrap Bundle with Popper -->
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-U1DAWAznBHeqEIlVSCgzq+c9gqGAJn5c/t99JyeKa9xxaYpSvHU5awsuZVVFIhvj" crossorigin="anonymous"></script>

            <!-- Option 2: Separate Popper and Bootstrap JS -->
            <!--
            <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js" integrity="sha384-eMNCOe7tC1doHpGoWe/6oMVemdAVTMs2xqW4mwXrXsW0L84Iytr2wi5v2QjrP/xp" crossorigin="anonymous"></script>
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.min.js" integrity="sha384-cn7l7gDp0eyniUwwAZgrzD06kc/tftFf19TOAs2zVinnD/C7E91j9yyk5//jjpt/" crossorigin="anonymous"></script>
            -->
        </body>
        </html>            
                """
    html = open('Reporte.html','w')
    Repo = Inicio+Reportando
    html.write(Repo)
    html.close()


if __name__ == "__main__":
   MenuPrincipal()







   