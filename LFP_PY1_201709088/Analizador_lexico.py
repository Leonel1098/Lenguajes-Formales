from Clases import Token
from Clases import Error
from ErrorReporte import reporterror
from TokenReporte import reportoken
from Formulario import Formulario
import re

class Analizador_lexico:
    def __init__(self):
        self.listTokens = []
        self.listError = []
        self.listReservadas = []
        self.listValores = []

    def analizador(self,entry):
        #Reiniciar listas para que en cada análisis se reinicie y poder analizar sin reiniciar el programa
        self.listTokens = []
        self.listError = []
        self.listReservadas = []

        buffer = ""
        centinela = "$"
        entry += centinela

        linea = 1
        columna = 1

        estado = 0

        index = 0
        while index < len(entry):
            caracter = entry[index]

            if estado == 0:
                #Reconoce Signos
                if caracter == "~":
                    #Se le suma uno a la columna
                    columna += 1
                    #Se agrega el caracter al buffer
                    buffer += caracter
                    #Se crea y agrega el token a la lista de tokens
                    token = Token("VIRGULILLA",buffer,linea,columna)
                    self.listTokens.append(token)
                    #Se limpia el buffer
                    buffer = ""
                    #Se cambia de estado
                    estado = 0

                elif caracter == "<":
                    columna += 1
                    buffer += caracter
                    token = Token("MENOR QUE", buffer,linea,columna)
                    self.listTokens.append(token)
                    buffer = ""
                    estado = 0

                elif caracter == ">":
                    columna += 1
                    buffer += caracter
                    token = Token("MAYOR QUE", buffer,linea,columna)
                    self.listTokens.append(token)
                    buffer = ""
                    estado = 0
                
                elif caracter == "[":
                    columna += 1
                    buffer += caracter
                    token = Token("CORCHETE ABRE", buffer,linea,columna)
                    self.listTokens.append(token)
                    buffer = ""
                    estado = 0

                elif caracter == "]":
                    columna += 1
                    buffer += caracter
                    token = Token("CORCHETE CIERRA", buffer,linea,columna)
                    self.listTokens.append(token)
                    buffer = ""
                    estado = 0

                elif caracter == "\"":
                    columna += 1
                    buffer += caracter
                    token = Token("COMILLA DOBLE", buffer,linea,columna)
                    self.listTokens.append(token)
                    buffer = ""
                    estado = 0
                
                elif caracter == ":":
                    columna += 1
                    buffer += caracter
                    token = Token("DOS PUNTOS", buffer,linea,columna)
                    self.listTokens.append(token)
                    buffer = ""
                    estado = 0
                
                elif caracter == ",":
                    columna += 1
                    buffer += caracter
                    token = Token("COMA", buffer,linea,columna)
                    self.listTokens.append(token)
                    buffer = ""
                    estado = 0
                
                elif caracter == "\n":
                    columna = 1
                    linea += 1
                    estado = 0
                
                elif caracter == " ":
                    columna += 1
                
                elif caracter == "\t":
                    columna += 1
                
                elif re.search(r"[a-zA-Z]",caracter):
                    columna += 1
                    buffer += caracter
                    estado = 1
                else :
                    estado = 3
                    buffer += caracter

            #Palabras Reservadas
            elif estado == 1:
                if re.search(r"[a-zA-Z]",caracter) or caracter == " ":
                    if caracter == " ":
                        columna += 1
                        estado = 1

                    elif caracter == "\t":
                        columna += 1
                    
                    elif caracter == "\n":
                        linea += 1
                        columna = 1
                    
                    else:
                        buffer += caracter
                        estado = 1
                else:
                    Tokentipo = ""
                    
                    if buffer.lower() == "formulario":
                        Tokentipo = "PALABRA RESERVADA"
                        
                    elif buffer.lower() == "tipo":
                        Tokentipo = "PALABRA RESERVADA"
                        self.listReservadas.append(buffer.lower())

                    elif buffer.lower() == "valor":
                        Tokentipo = "PALABRA RESERVADA"
                        self.listReservadas.append(buffer.lower())

                    elif buffer.lower() == "fondo":
                        Tokentipo = "PALABRA RESERVADA"
                    
                    elif buffer.lower() == "nombre":
                        Tokentipo = "PALABRA RESERVADA"
                        self.listReservadas.append(buffer.lower())
                    
                    elif buffer.lower() == "valores":
                        Tokentipo = "PALABRA RESERVADA"
                        self.listReservadas.append(buffer.lower())
                    
                    elif buffer.lower() == "evento":
                        Tokentipo = "PALABRA RESERVADA"
                        self.listReservadas.append(buffer.lower())
                    
                    else:
                        Tokentipo = "IDENTIFICADOR"
                    
                    token = Token(Tokentipo,buffer,linea,columna)
                    self.listTokens.append(token)
                    buffer = ""
                    index -= 1
                    estado = 0
                    
            elif estado == 2:
                if re.search(r"[a-zA-Z]",caracter) or re.search(r"[\"]",caracter) or caracter == ' ' or caracter == '-' or caracter == '\t' or caracter  == '\n' or re.search(r"[\:]",caracter):
                    
                    if caracter == "\t":
                        columna += 1

                    elif caracter == "\n":
                        linea += 1
                        columna = 1

                    elif re.search(r"[\:]",caracter):
                        columna += 1
                        buffer += caracter
                        estado = 2
                    
                    elif caracter == '"':
                        token = Token("IDENTIFICADOR", buffer,linea,columna)
                        self.listTokens.append(token)
                        self.listValores.append(buffer)

                        token2 = Token("COMILLA DOBLE",caracter,linea,columna)
                        self.listTokens.append(token2)
                        estado = 2
                        buffer = ""
                    
                    else: 
                        columna += 1
                        estado = 2
                        buffer += caracter
                else:
                    estado = 0 
                    index -= 1

            elif estado == 3:
                errores = Error("ERROR LEXICO", buffer,linea,columna)
                self.listError.append(errores)
                buffer = ""
                estado = 0
                columna += 1
                index -= 1
            index += 1
        return entry


    
    def ErrorToken(self):
        reportoken(self.listTokens)
    
    def ErrorReporte(self):
        reporterror(self.listError)
    
    def Formulario(self):
        Formulario()

    def imprimirInfo(self):
        print("\n\n\n")
        print("======= Lista de Tokens =======")
        
        for token in self.listTokens:
            token.getInfo()

    def imprimirErrores(self):
        print("\n\n\n")
        print("======= Lista de Errores =======")
        
        i = 0
        for errores in self.listError:
            print(i+1)
            errores.getError()
            i += 1