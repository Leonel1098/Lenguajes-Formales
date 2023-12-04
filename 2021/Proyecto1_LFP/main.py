from tkinter import filedialog
from Ventana import ventana
def ventana_carga():
    #Abre Ventana para Buscar el archivo .lfp 
    archivo =  filedialog.askopenfilename(initialdir = "/") 
    #Abre el achivo 
    archivo = open(archivo ,'r')

