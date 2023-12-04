
from pagina import Pagina
from interfaz import interfaz
from Token import Token
from Analizador import Analizdor
from ReporteErrores import reportehtmlERR
from ReporteToken import reportehtml
def leer(ruta):
    file = open(ruta ,  'r')
    contenido = file.read()
    return contenido
if __name__ == "__main__":
    interfaz()
    #entrada = leer('ejemploP1.form')
    #lex = Analizdor()
    #lex.analizador(entrada)
    """lex.imprimir()"""
    #lex.imprimirErrores()
    #lex.RerporteErrores()
    
    #lex.RerporteTokens()
    lex.claveValor()