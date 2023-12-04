class alumno :
    def __init__(self,nombre,nota):
        self.nombre = nombre
        self.nota = nota 
    # METODOS GET   

    def getNombre (self):
        return self.nombre
    def getNota(self):
        return self.nota
    #METODOS SET
    
    def setNombre(self,nombre):
        self.nombre = nombre
    def setNota(self,nota):
        self.nota = nota 