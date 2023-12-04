from tkinter import Tk
from tkinter import * 
from tkinter import filedialog


ventana = Tk()
ventana.title("PROYECTO")
ventana.geometry("%dx%d+%d+%d" % (900,500,350,100))
ventana.resizable(0,0)

panel_Frame = Frame(ventana)
panel_Frame.pack(side = "top")
panel_Frame.place(width = "900", height = "500")
panel_Frame.config(background = "gray")


textfield = Text(panel_Frame)
textfield.pack()
textfield.place(x= "165", y = "20",width = "720", height = "470")
scrollbar = Scrollbar(ventana, command = textfield.yview)
scrollbar.pack()
scrollbar.place(x = "880", y = "20", width = "20", height = "470")
textfield.config(yscrollcommand = scrollbar)


button = Button(panel_Frame, text="Cargar",  foreground = "white")
button.pack()
button.config(bg = "black")
button.place(x = 10,y = 20,width= 150, height  = 40)

button = Button(panel_Frame, text="Analizar",  foreground = "white")
button.pack()
button.config(bg = "black")
button.place(x = 10,y = 65,width= 150, height  = 40)

combo = ttk.Combobox (panel_Frame, values = ["Reporte de Tokens","Reporte de Errores","Manual de Usuario","Manual Técnico"])
combo.pack()
combo.config(background = "black")
combo.current(0)
combo.place(x=10, y = 115, width = "150", height = "40")

buttonabrir = Button(panel_Frame, text="Seleccionar Reporte",command = Reportando, foreground = "white")
buttonabrir.pack()
buttonabrir.config(bg = "black")
buttonabrir.place(x= 10, y=160, width = "150", height = "40")



ventana.mainloop()








    