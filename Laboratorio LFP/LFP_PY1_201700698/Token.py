class Token:
    def __init__(self, tipo , lexema ,linea ,columna):
        self.tipo = tipo 
        self.lexema = lexema
        self.linea  = linea
        self.columna = columna

    def mostrarToken(self):
        print("\n")
        print("********")
        print('Tipo : ' ,self.tipo)
        print('lexema : ' ,self.lexema)
        print('LInea : ' ,self.linea)
        print('Columna : ' ,self.columna)
    def getTipo(self):
        return self.tipo
    def getLexems(self):
        return self.lexema
    def getLinea(self):
        return self.linea
    def getColumna(self):
        return self.columna
    
class Error:
    #en Tipo Todos van a ser Error Lexico 
    def __init__(self,tipo,lexema,linea ,columna ):
        self.tipo = tipo
        self.lexema = lexema
        self.linea = linea 
        self.columna =  columna
    def mostrarError(self):
        print("\n")
        print("********")
        print('Tipo : ' ,self.tipo)
        print('lexema : ' ,self.lexema)
        print('LInea : ' ,self.linea)
        print('Columna : ' ,self.columna)
    
