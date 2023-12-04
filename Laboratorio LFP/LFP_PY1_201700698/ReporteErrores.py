import webbrowser
def reportehtmlERR(listaErrores=[]):
    contenido = ''
    htmFile = open("Errores.html", "w")

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
    <body>
    <div class="container">
  <h2>Nombre : TULIO JAFETH PIRIR SCHUMAN </h2>
  <h2> Carne : 20170068</h2>
      
  <table class="table">
    <thead>
      <tr>
       
        <th>TIPO</th>
        <th>LEXEMA</th>
        <th>LINEA</th>
        <th>COLUMNA</th>
      </tr>
    </thead>

    """)
    #contenido += "<tr>'"
    #Resivira la los datos o la tabla con los Datos 
    for t in listaErrores:
        contenido += '<tr>'
        contenido += "<td>"+t.tipo + "</td>\n"
        contenido += "<td>"+t.lexema+"</td>\n"
        contenido += "<td>"+str(t.linea)+"</td>\n"
        contenido += "<td>"+str(t.columna)+"</td>\n"
        contenido += '</tr>'
    
  
    #contenido += ContTabla

        
    
    #contenido  +=  "</tr>"
    htmFile.write(contenido)
    htmFile.write("""
      </table>
    </div>
        </body>
        </html>""")
    webbrowser.open("Errores.html")
    htmFile.close

