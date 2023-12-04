import re
from Token import Token
from Token import Error
from ReporteErrores import reportehtmlERR
from ReporteToken import reportehtml
from pagina import Pagina
class Analizdor:

    def __init__(self):
        self.c = []
        self.v = []
        self.listTokens = []
        self.LIstaError = []
        #Tokens
        # tipo
        # valor
        # fondo
        # nombre
        # valores
        # evento #
        
    def analizador(self, datos):
        #Lismpiar Listas
        self.listaClave_Valor =  []
        self.listTokens = []
        self.LIstaError = []
        self.c =[]
        linea = 1
        columna = 1
        lexema = ""
        vs =[]
        estado = 0
        buffer = ''
        centinela = '$'
        datos += centinela
        index = 0
        while index < len(datos):
            c = datos[index]
             #signos < >  [ ] " " , 
            if estado == 0 :
                if c == '~':
                    columna += 1
                    buffer += c   
                    token = Token("VIRGULILLA ", buffer, linea, columna)
                    self.listTokens.append(token)
                    estado = 0
                    buffer = ''
                elif c ==  '<': 
                    columna += 1
                    buffer += c   
                    token = Token("MENOR    ", buffer, linea, columna)
                    self.listTokens.append(token)
                    estado = 0
                    buffer = ''
                elif c == '>':
                    columna += 1
                    buffer += c   
                    token = Token("MAYOR ", buffer, linea, columna)
                    self.listTokens.append(token)
                    estado = 0
                    buffer = ''
                elif c == '[':
                    columna += 1
                    buffer += c   
                    token = Token("ABRE CORCHETE ", buffer, linea, columna)
                    self.listTokens.append(token)
                    estado = 0
                    buffer = ''
                elif c == ']':
                    columna += 1
                    buffer += c   
                    token = Token("CIERRA CORCHETE  ", buffer, linea, columna)
                    self.listTokens.append(token)
                    buffer = ''
                    estado = 0
                    self.v.append(vs)
                    vs = []
                elif c == '\"':
                    columna += 1
                    buffer += c   
                    token = Token("COMILLA DOBLE ", buffer, linea, columna)
                    self.listTokens.append(token)
                    estado = 4
                    buffer = ''
                    
                    
                elif c =='\'':
                    columna += 1
                    buffer += c   
                    token = Token("COMILLA SIMPLE ", buffer, linea, columna)
                    self.listTokens.append(token)
                    estado = 0
                    buffer = ''
                elif c == ',':
                    columna += 1
                    buffer += c   
                    token = Token("COMA ", buffer, linea, columna)
                    self.listTokens.append(token)
                    estado = 0
                    buffer = ''
                    
                elif c  == ':': 
                    columna += 1
                    buffer += c   
                    token = Token("DOS PUNTOS ", buffer, linea, columna)
                    self.listTokens.append(token)
                    buffer = ''
                    
                #Cambiar de estado 
                elif c == '\n':
                    columna = 1
                    linea += 1
                    estado = 0
                elif c == ' ':
                    columna += 1
                elif c == '\t':
                    columna += 1 

                elif re.search(r"[a-zA-Z]", c):
                    columna += 1
                    buffer += c 
                    estado = 1
                else :
                    estado = 5 
                    buffer += c
            #enteros y decimales
            elif estado == 1:
             #palabras Reservadas |identificadores 
             # fotmulario 
             # nombre 
             # valor 
             # tipo 
             # fondo 
             # valores 
             # evento #
                
                if re.search(r"[a-zA-Z]", c) or c==' 'or c=='\n' or c=='\t':
                    if c == ' ':
                        columna += 1
                        estado = 1
                    elif c == '\t':
                        columna += 1
                    elif c == '\n':
                        linea += 1
                        columna = 1

                    else:
                        buffer += c 
                        estado = 1
                else:
                    tipoToken = ''
                    
                    if buffer.lower()  == 'formulario':
                        tipoToken = 'RESERVADA'
                        
                    elif  buffer.lower() =='tipo':
                        tipoToken = 'RESERVADA '
                        
                        self.c.append(buffer.lower())
                    elif  buffer.lower() =='valor':
                        tipoToken = 'RESERVADA'
                        self.c.append(buffer.lower())
                        
                    elif  buffer.lower() =='nombre':
                        tipoToken = 'RESERVADA '
                        
                        self.c.append(buffer.lower())
                    elif  buffer.lower() =='fondo':
                        tipoToken = 'RESERVADA '
                        self.c.append(buffer.lower())
                    elif  buffer.lower() =='valores':
                        tipoToken = 'RESERVADA '
                        self.c.append(buffer.lower())
                    elif  buffer.lower() =='evento':
                            tipoToken = 'RESERVADA '
                            self.c.append(buffer.lower())
                    else :  
                        tipoToken = 'IDENTIFICADOR'
                        
                        vs.append(buffer)

                    token = Token(tipoToken, buffer, linea, columna)
                    self.listTokens.append(token)
                    buffer = ''
                    index -= 1 
                    estado = 0 

            elif estado == 4 :
                if re.search(r"[a-zA-Z]", c) or re.search(r"[\"]", c) or c==' ' or c=='-' or c == '\t'or c == '\n'or re.search(r"[\:]",c):
                        
                    
                        if c == '\t':
                                columna += 1
                        
                        elif c == '\n':
                                linea += 1
                                columna = 1
                        elif re.search(r"[\:]",c):
                                    
                                    columna += 1
                                    buffer += c 
                                    estado = 4
                        elif c=='"':
                                token = Token("IDENTIFICADOR",buffer, linea, columna)
                                self.listTokens.append(token) 
                                self.v.append(buffer)
                                
                                toke = Token("COMILLA DOBLE", c, linea, columna)
                                self.listTokens.append(toke)
                                estado = 4
                                buffer =''
                        else:
                            columna += 1
                            estado = 4
                            buffer += c 
                else :
                    
                    estado = 0
                    index -= 1
                    


       
             #Centinela
            
            #Errores
            elif estado == 5 :
                error = Error("Error Lexico", buffer, linea, columna)
                self.LIstaError.append(error)
                buffer = ''
                estado = 0
                columna += 1
                index-=1
            index += 1
        return datos

                    
                


     #self.listTokens.append([linea, columna, "decimal", lexema])
    #Verfificar CAracter Alfabetico
    def imprimir(self):
        print("\n\n\n")
        print("listaTokens ")
        for token  in self.listTokens:
            
            token.mostrarToken()
        
    def imprimirErrores(self):
        print("\n\n\n")
        print("listaErrores  ")
        i = 0
        for error  in self.LIstaError:
            print(i+1)
            error.mostrarError()
            i += 1
    def RerporteErrores(self):
        reportehtmlERR(self.LIstaError)
        
    def RerporteTokens(self):
        reportehtml(self.listTokens)
    
    def pag (self):
        Pagina(self.c, self.v)



    def Alfabetico(self, lex):
        if lex == 'a' or lex =='A':
            return lex
        elif lex ==  'b' or lex == 'C ':
            return lex
        elif lex == 'c ' or lex == 'C':
            return lex
        elif lex == 'd ' or lex == 'D':
            return lex
        elif lex == 'E ' or lex == 'e':
            return lex
        elif lex == 'f ' or lex == 'F':
            return lex
        elif lex == 'G' or lex == 'G':
            return lex
        elif lex == 'h ' or lex == 'H':
            return lex
        elif lex == 'i ' or lex == 'I':
            return lex
        elif lex == 'j ' or lex == 'J':
            return lex
        elif lex == 'k ' or lex == 'K':
            return lex
        elif lex == 'l ' or lex == 'L':
            return lex
        elif lex == 'm ' or lex == 'M':
            return lex
        elif lex == 'n ' or lex == 'N':
            return lex
        elif lex == 'ñ ' or lex == 'Ñ':
            return lex
        elif lex == 'o ' or lex == 'O':
            return lex
        elif lex == 'p ' or lex == 'P':
            return lex
        elif lex == 'q ' or lex == 'Q':
            return lex
        elif lex == 'r ' or lex == 'R':
            return lex
        elif lex == 's ' or lex == 'S':
            return lex
        elif lex == 't ' or lex == 'T':
            return lex
        elif lex == 'v ' or lex == 'V':
            return lex
        elif lex == 'w' or lex == 'W"':
            return lex
        elif lex == 'x ' or lex == 'Y':
            return lex
        elif lex == 'y ' or lex == 'Y':
            return lex
        elif lex == 'z ' or lex == 'Z':
            return lex
        else :
            return 'error'
    #Analizar Numeros 
    def Numeros(lex):
        if lex == '0':
            return lex
        elif lex == '1':
            return lex 
        elif lex == '2':
            return lex 
        elif lex == '3':
            return lex 
        elif lex == '4':
            return lex 
        elif lex == '5':
            return lex 
        elif lex == '6':
            return lex 
        elif lex == '7':
            return lex 
        elif lex == '8':
            return lex 
        elif lex == '9':
            return lex 
        else :
            return 'error'
    # Verificador Caracteres error 
    def signosError(self, lex):
        if lex  == '/':
            return lex
        elif lex == '\'':
            return lex
        elif lex == ';':
            return lex
        elif lex == '@':
            return lex
        elif lex == '.':
            return '@'
        else :
            return ''
    def espaciosYsaltos(self,lex):
        if lex == '\n':
            return 'salto'
        elif lex =='\t':
            return ''
        elif lex == ' ':
            return '' 
    def signos(self , lex):
        if lex == '<':
            return lex 
        elif lex =='>':
            return lex 
        elif lex == '[':
            return lex 
        elif lex == ']':
            return lex  
        elif lex == ',':
            return lex 
        elif lex == '[':
            return lex  
        elif lex == '~':
            return lex      
        elif lex == '"':
            return lex  
        elif lex == ':':
            return lex  
        elif lex == '':
            return lex  
    def verificaLexema(self, lexxe):
        if lexxe.lower() == "formulario~>>":
            return "reservada"
        else:
            return "identificador"
