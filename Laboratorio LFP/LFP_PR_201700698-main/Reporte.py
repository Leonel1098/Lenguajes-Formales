from automatadatos import *
import webbrowser
entradaData = automatadatos()
def reportehtml():

    contenido = ''
    contenidomasvendido = ''
    contenidomenosVendido =''
    htmFile = open( "Reporte"+ ".html", "w")

    htmFile.write("""<!DOCTYPE HTML PUBLIC"

    <html>

    <head>
        <title>REPORTE </title>
     <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.bundle.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>    
    </head>
    <body>
    <div class="container">
  <h2>Nombre : TULIO JAFETH PIRIR SCHUMAN </h2>
  <h2> Carne : 20170068</h2>
  <p> PRODUCTOS: GANANCIAS GENERADAS</p>    
  <p> ORDENAMIENTO DE MAYOR A MENOR </p>         
  <table class="table">
    <thead>
      <tr>
       
        <th>PRODUCTO</th>
        <th>PRECIO</th>
        <th>CANTIDAD</th>
        <th>GANANCIA</th>
        
      </tr>
    </thead>

    """)
    lista = []
    paraorden =[]
    ordenada = []
    for i in range(len(entradaData.listaMes)):
        
        for j in range(len(entradaData.listaMes[i].getProductos())):
            precio = entradaData.listaMes[i].getProductos()[j].getPrecio()
            cantidad= entradaData.listaMes[i].getProductos()[j].getCantidad()
            ganancia = entradaData.gananciasGeneradas(precio, cantidad)
            producto= entradaData.listaMes[i].getProductos()[j].getNombreProducto()
            
            lista.append([producto,ganancia])
            paraorden.append(ganancia)
    
    PRODUCTO = ''
    PRECIO = ''
    CANTIDAD = ''
    GANANCIA = ''      
    ordenada = bubbleSort(paraorden)
    longitud = len(ordenada)
    
    for i in range(longitud-1, -1, -1):
        for l in range(len(lista)):
            
                
                if ordenada[i] == lista[l][1]:
                   PRODUCTO = lista[l][0]
                   
                   PRECIO = buscarprecio(PRODUCTO)
                   CANTIDAD = bucarCantidad(PRODUCTO)
                   GANANCIA =    ordenada[i]

                   contenido += "<tbody>"
                   print("producotos ",PRODUCTO,PRECIO,CANTIDAD,GANANCIA)
                   contenido += "<td>"+str(PRODUCTO)+"</td>"
                   contenido += "<td>"+str(PRECIO)+"</td>"
                   contenido += "<td>"+str(CANTIDAD)+"</td>"
                   contenido += "<td>"+str(GANANCIA)+"</td>"
                   contenido += "</tbody>"

                   
                   
                   
                   
    
   
    
    contenido +=  masVendido()
    htmFile.write(contenido)
    
    
    
    htmFile.write("""
      </table>
    </div>
        </body>
        </html>""")
    webbrowser.open("Reporte.html")
    htmFile.close
def masVendido():
   
    actual = ''
    actual = int(entradaData.listaMes[0].getProductos()[0].getCantidad())
    nombre = ''
    for i in range(len(entradaData.listaMes)):
        
        for j in range(len(entradaData.listaMes[i].getProductos())):
          
            if actual <= int(entradaData.listaMes[i].getProductos()[j].getCantidad()):
                actual = int(entradaData.listaMes[i].getProductos()[j].getCantidad())
                nombre = entradaData.listaMes[i].getProductos()[j].getNombreProducto()
    
    contenido = """
    <div>
    <table class="table">
    <thead>
      <tr>
       
        <p> PRODUCTO MAS VENDIDO </p>
        <th>PRODUCTO </th>
        <th>CANTIDAD</th>
        
        
      </tr>
      </thead>
      """

    contenido+="<tbody>"
    contenido += "<td>"+str(nombre)+"</td>"
    contenido += "<td>"+str(actual)+"</td>"  
    contenido+= "</tbody>"
    contenido += """
    
       </table>
    
    """
    ac = ''
    ac = int(entradaData.listaMes[0].getProductos()[0].getCantidad())
    name = ''
    for i in range(len(entradaData.listaMes)):
        
        for j in range(len(entradaData.listaMes[i].getProductos())):
            
            if ac >= int(entradaData.listaMes[i].getProductos()[j].getCantidad()):
                ac = int(entradaData.listaMes[i].getProductos()[j].getCantidad())
                name = entradaData.listaMes[i].getProductos()[j].getNombreProducto()
                print(name)
    contenido += """
   
    <table class="table">
    <thead>
      <tr>
       
        <p> PRODUCTO MENOS VENDIDO </p>
        <th>PRODUCTO </th>
        <th>CANTIDAD</th>
        
        
      </tr>
     
      </thead>
      """
    contenido+="<tbody>"
    contenido += "<td>"+str(name)+"</td>"
    contenido += "<td>"+str(ac)+"</td>"  
    contenido+= "</tbody>"
    contenido += """
        </table>
    </div>
        """
    
    return contenido
def menosVentido():
    ac = ''
    ac = int(entradaData.listaMes[0].getProductos()[0].getCantidad())
    nm = ''
    for i in range(len(entradaData.listaMes)):
        
        for j in range(len(entradaData.listaMes[i].getProductos())):
            
            if actual > int(entradaData.listaMes[i].getProductos()[j].getCantidad()):
                ac = int(entradaData.listaMes[i].getProductos()[j].getCantidad())
                nm = entradaData.listaMes[i].getProductos()[j].getNombreProducto()
    
    contenido = """
   
    <thead>
      <tr>
       
        <p> PRODUCTO MENOS VENDIDO </p>
        <th>PRODUCTO </th>
        <th>CANTIDAD</th>
        
        
      </tr>
      </thead>
      """
    contenido+="<tbody>"
    contenido += "<td>"+str(nm)+"</td>"
    contenido += "<td>"+str(ac)+"</td>"  
    contenido+= "</tbody>"
    contenido += """
    </table>
    </div>
        
    """
    return contenido

def buscarprecio(nombre):
    precio = ''
    for i in range(len(entradaData.listaMes)):
        
        for j in range(len(entradaData.listaMes[i].getProductos())):
            if nombre == entradaData.listaMes[i].getProductos()[j].getNombreProducto():
                precio = entradaData.listaMes[i].getProductos()[j].getPrecio()
    return precio
def bucarCantidad(nombre):
    cantidad =''
    for i in range(len(entradaData.listaMes)):
        
        for j in range(len(entradaData.listaMes[i].getProductos())):
            if nombre == entradaData.listaMes[i].getProductos()[j].getNombreProducto():
                cantidad = entradaData.listaMes[i].getProductos()[j].getCantidad()
    return cantidad

   # Python program for implementation of Bubble Sort
def bubbleSort(arr):
    n = len(arr)
 
    # Traverse through all array elements
    for i in range(n-1):
    # range(n) also work but outer loop will
    # repeat one time more than needed.
 
        # Last i elements are already in place
        for j in range(0, n-i-1):
 
            # traverse the array from 0 to n-i-1
            # Swap if the element found is greater
            # than the next element
            if arr[j] > arr[j + 1] :
                arr[j], arr[j + 1] = arr[j + 1], arr[j] 
    return arr