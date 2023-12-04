import webbrowser
def Pagina(listaCod =[], listaVal =[]):

    contenido = ''
    
    htmFile = open( "Pagina"+ ".html", "w")

    htmFile.write("""<!DOCTYPE HTML PUBLIC"

    <html>

    <head>
        <title>REPORTE </title>
     <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>    
    </head>
    <body style="background-color:#ECEFF1;">
    <div class="container" bgcolor ="skyblue">
  <h2>Nombre : TULIO JAFETH PIRIR SCHUMAN </h2>
  <h2> Carne : 20170068</h2>
      
    

    """)
    unir = [listaCod,listaVal]
    i = 0
    j = 0
    for c in range(len(listaVal)) :
        if type(listaVal[c]):
                v = listaVal[c]
                v = str(v).lstrip()
                v = str(v).rstrip()
        if v=='etiqueta':
            
            valor = listaVal[c+1]
            nombreEtiqueta = valor
            contenido += etiqueta(valor )
        elif  v=='texto':
            nombre = listaVal[c+1]
            fondo = listaVal[c+2]
            contenido += texto(nombre, fondo)
        elif  v=='grupo-radio':
            nombre = listaVal[c+1]
            valores = []
            valores = listaVal[c+2]
            contenido += grupo_radio(nombre,valores)
        elif v == 'grupo-option':
            nombre = listaVal[c+1]
            valores = []
            valores = listaVal[c+2]
            contenido += grupo_option(nombre,valores)
        elif type(listaVal[c]):
                v = listaVal[c]
                v = str(v).lstrip()
                v = str(v).rstrip()
                if v == "boton":
                    valor = listaVal[c+1]
                    evento = listaVal[c+2]
                    contenido += boton(valor, evento) 
    contenido +='<div id="contenido"></div>'                          
    contenido += """<script src="Actions.js"></script>"""
    
    htmFile.write(contenido)
    webbrowser.open("Pagina.html")
    
    htmFile.close
def boton(valor ,evento):

    contenido = ''
    if evento == 'info':
        contenido += '''<h1> <button size="40" id ='btn' name='''+evento+''' value='''+evento+''' class="boton" >'''+valor+'''</button></h1>'''
        
        return contenido
    elif evento == 'entrada':
        contenido += '''<h1> <button size="40" id ='btn' name='''+evento+''' value='''+evento+''' class ="boton">'''+valor+'''</button></h1>'''
        return contenido

def etiqueta(nombre):
    contenido = ""
    contenido += "<p id='etiqueta' ><h3>"+nombre+"</h3></p>"
    return contenido
def texto(nombre, fondo):
    contenido = ""
    contenido +=   '''<h3><input id='tx' type="text" name="'''+nombre+'''
    " size="40" placeholder="'''+fondo+'''" class = 'texto'></input></h3>'''
    return contenido
def grupo_radio(nombre,valores=[]):
    contenido =''
    contenido+='''<p ><h3>'''+nombre+ '''  :  '''
   
    for v in valores:
        contenido += '''<input id = 'grupo-radio' type ='radio' name = 'radio' class='radio'
           value ='''+v+''' required> '''+v+'''</input>   '''
  
    contenido += '''</h3></p>''' 
   
    return contenido
def grupo_option(nombre, valores=[]):
    continido = '''<p ><h3>'''+nombre+''''''
    
    continido +=''' <select name="menu" id = 'grupo-option'>
  <option selected >...</option>'''
    for v in valores:
        continido += '''<option value='''+v+'''>'''+v+'''</option>'''
    continido += '''</select></h3></p>'''
    
    return continido

    
