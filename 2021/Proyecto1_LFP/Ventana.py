from tkinter import Tk
from tkinter import Frame
from tkinter import Button, filedialog
 

def ventana_carga():
    #Abre Ventana para Buscar el archivo .lfp 
    archivo =  filedialog.askopenfilename(initialdir = "/") 
    #Abre el achivo 
    archivo = open(archivo ,'r')
ventana = Tk()
ventana.title("Bitxelart")
ventana.geometry("%dx%d+%d+%d" % (900,500,350,100))
ventana.resizable(0,0)

p_Frame = Frame(ventana)
p_Frame.pack(side = "top")
p_Frame.place(width= "900", height ="75")
p_Frame.config(bg = "gray")



button = Button(p_Frame, text="Cargar", command = ventana_carga,  foreground = "white")
button.pack()
button.config(bg = "black")
button.place(x = 200,y = 20,width= 100, height  = 40)


button2 = Button(p_Frame, text="Analizar", foreground = "white")
button2.pack()
button2.config(bg = "black")
button2.place(x = 300,y = 20, width= 100, height  = 40 )

button3 = Button(p_Frame, text="Reportes", foreground = "white")
button3.pack()
button3.config(bg = "black")
button3.place(x =400,y= 20, width= 100, height  = 40)

button4 = Button(p_Frame, text="Salir", foreground = "white")
button4.pack()
button4.config(bg = "black")
button4.place(x =500, y = 20, width= 100, height  = 40)


s_Frame = Frame(ventana)
s_Frame.pack()
s_Frame.place(x = 0, y = 75, width = "200", height = "425")
s_Frame.config(bg = "gray")

button = Button(s_Frame, text="Original", foreground = "white")
button.pack()
button.config(bg = "black")
button.place(x = 40,y = 75,width= 100, height  = 40)

button2 = Button(s_Frame, text="Mirror X", foreground = "white")
button2.pack()
button2.config(bg = "black")
button2.place(x = 40,y = 115,width= 100, height  = 40)

button3 = Button(s_Frame, text="Mirror Y", foreground = "white")
button3.pack()
button3.config(bg = "black")
button3.place(x = 40,y = 155,width= 100, height  = 40)

button4 = Button(s_Frame, text="Double Mirror", foreground = "white")
button4.pack()
button4.config(bg = "black")
button4.place(x = 40,y = 195,width= 100, height  = 40)

c_Frame = Frame()
c_Frame.pack()
c_Frame.place(x= 200, y = 75, width = "700", height = "425")
c_Frame.config(bg = "white")

ventana.mainloop()


    

