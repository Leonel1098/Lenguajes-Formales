
#librerias 
import os
import tkinter 
from tkinter import *
from tkinter import filedialog
import io
from io import *
from automatadatos import *
from mes import* 
from automata_instrucciones import *
from Reporte import *

entradaInstrucciones = automata_instrucciones()
entradaData = automatadatos()
Data =[]
Entrada = ''
Mes=[]
def menu1():
    """
	Función que limpia la pantalla y muestra nuevamente el menu
	"""
    #os.system('cls') # NOTA para windows tienes que cambiar clear por cls
    
    print ("Selecciona una opción")
    print ("\t1 -  Cargar Data  ")
    print ("\t2 - Cargar Instrucciones ")
    print ("\t3 - Analizar")
    print ("\t4 - Reportes")
    print ("\t5  - salir")
        #Menu Principal del Programaa

def MenuPrincipal(): 
    while True:
        # Mostramos el menu
        menu1()
    
        # solicituamos una opción al usuario
        opcionMenu = input("Seleccione una opcion >> ")
    
        if opcionMenu=="1":
           print("---->Carga de Datos")
           CargarData()

        elif opcionMenu=="2":
            print("---->Cargar Instrucciones")
            CargarInstrucciones()
            
        elif opcionMenu=="3":
            print("Analizar")
            global Entrada
            print(Entrada)
            entradaData.analizador(Entrada)
            global Instrucciones
            print("Entra al de instrucciones")
            entradaInstrucciones.automataInstrucciones(Instrucciones) 
            graficaYanalizar()
            
        elif opcionMenu =="4":
            print("Reportes ")
            reportehtml()
            entradaData.limpiarMes()
            entradaInstrucciones.limpliarListaInstrucciones()    
                   
                    

           
                

        elif opcionMenu=="5":
                    break
        else:
                    print ("")
                    input("No has pulsado ninguna opción correcta...\n pulsa una tecla para continuar")


#Carga del Archivo .data
def CargarData():
    entradaData.limpiarMes()
    entradaInstrucciones.limpliarListaInstrucciones()
    
    root = Tk()
        #Abre Ventana para Buscar el archivo .data 
    archivo =   filedialog.askopenfilename(initialdir = "/") 
        #Abre el achivo 
    archivo_texto = open(archivo ,'r',encoding="utf8")
        #Contenido del archivo leido 
    texto = archivo_texto.read()
    archivo_texto.close()
        #Analiza el contenido del Archivo 
    
    global Entrada
    Entrada = texto
    root.destroy()
    print("Archivo del Mes .Data ")
    print(Entrada)
    print("--------------------------------------")
    
    #Carga Instrucciones  .flp
Instrucciones = ''
    
def CargarInstrucciones():
    
    
    root=Tk()
        #Abre Ventana para Buscar el archivo .lfp 
    archivo =  filedialog.askopenfilename(initialdir = "/") 
        #Abre el achivo 
    archivo_texto = open(archivo ,'r',encoding="utf8")
        #Contenido del archivo leido 
    texto = archivo_texto.read()
    archivo_texto.close()
        #Analiza el contenido del Archivo 
    
    global Instrucciones
    Instrucciones = texto
    root.destroy()
    print("Archivo de Instrucciones .flp")
    print(Instrucciones)
    print("----------------------------")

#Analizando y Graficacndo 
import matplotlib.pyplot as plt
import numpy as np
def graficaYanalizar():
    ejeX=[]
    ejeY = []
    NOMBRE = ''
    GRAFICA = ''
    TITULOX = ''
    TITULOY = ''
    TITULO = ''
    for i in range(len(entradaData.listaMes)):
        for j in range(len(entradaData.listaMes[i].getProductos())):
            ejeX.append(entradaData.listaMes[i].getProductos()[j].getNombreProducto())
            precio = entradaData.listaMes[i].getProductos()[j].getPrecio()
            cantidad= entradaData.listaMes[i].getProductos()[j].getCantidad()
            ganancia = entradaData.gananciasGeneradas(precio, cantidad)
            ejeY.append(ganancia)
    for i in range(len(entradaInstrucciones.instrucciones)):
        
        for j in range(len(entradaInstrucciones.instrucciones[i])):
           
            if entradaInstrucciones.instrucciones[i][j] == 'NOMBRE':
                NOMBRE = entradaInstrucciones.instrucciones[i][j+1]
            elif entradaInstrucciones.instrucciones[i][j] == 'GRAFICA':
                GRAFICA=entradaInstrucciones.instrucciones[i][j+1]
                
            elif entradaInstrucciones.instrucciones[i][j]=='TITULO':
                if entradaInstrucciones.instrucciones[i][j+1] =='':
                    
                    TITULO = tituloOpcional()
                    
                elif  entradaInstrucciones.instrucciones[i][j+1]!='':

                    TITULO = entradaInstrucciones.instrucciones[i][j+1]
            elif entradaInstrucciones.instrucciones[i][j] == 'TITULOX':
                
                if entradaInstrucciones.instrucciones[i][j+1] != '':
                    TITULOX = entradaInstrucciones.instrucciones[i][j+1]
                elif entradaInstrucciones.instrucciones[i][j+1] =='':
                    TITULOX = entradaInstrucciones.instrucciones[i][j+1]

            elif entradaInstrucciones.instrucciones[i][j] == 'TITULOY':
                 if entradaInstrucciones.instrucciones[i][j+1] != '':
                    TITULOY = entradaInstrucciones.instrucciones[i][j+1]
                 elif entradaInstrucciones.instrucciones[i][j+1] =='':
                    TITULOY = entradaInstrucciones.instrucciones[i][j+1]
                    
                
    if GRAFICA =='BARRAS':
        graficaBarras(ejeX, ejeY, TITULO, TITULOX, TITULOY, NOMBRE)
    elif  GRAFICA =='PIE':
        graficaPie(ejeX, ejeY, TITULO, TITULOX, TITULOY, NOMBRE)
    elif GRAFICA =='LINEAS':
        
        graficaLineal(ejeX, ejeY, TITULO, TITULOX, TITULOY, NOMBRE)
    

def tituloOpcional():
    titluloOpcional = ''
    año = ''
    for i in range(len(entradaData.listaMes)):
       
        for j in range(len(entradaData.listaMes[i].getProductos())):
            nombremes = entradaData.listaMes[i].getNombre()
            año = entradaData.listaMes[i].getAño()
            titluloOpcional = nombremes+'-'+año

    return titluloOpcional

def graficaLineal(ejeX,ejeY,TITULO,TITULOX,TITULOY,NOMBRE):
    plt.title(TITULO)
    plt.xlabel(TITULOX)
    plt.ylabel(TITULOY)
    plt.plot(ejeX,ejeY)
    plt.savefig(NOMBRE+"1png",dpi=300, bbox_inches='tight')
   
    plt.ioff()
    plt.show()
    
def graficaBarras(ejeX,ejeY,TITULO,TITULOX,TITULOY,NOMBRE):
    plt.title(TITULO)
    plt.xlabel(TITULOX)
    plt.ylabel(TITULOY)
    plt.bar(ejeX, ejeY)
    plt.savefig(NOMBRE+"1png",dpi=300, bbox_inches='tight')
   
    plt.show()
    #plt.savefig("Plot generated using Matplotlib.png")
def graficaPie(ejeX,ejeY,TITULO,TITULOX,TITULOY,NOMBRE):
    plt.title(TITULO)
    
    plt.pie(ejeY, labels=ejeX)
    plt.savefig(NOMBRE+"1png",dpi=300, bbox_inches='tight')
    plt.show()
if __name__ == "__main__":
   MenuPrincipal()