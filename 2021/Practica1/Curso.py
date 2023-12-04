class Curso:
    alumnos = []
    notas = []
    reportes = []
    def __init__(self,nombre,alumnos=[],repotes =[]):
        self.nombre = nombre
        self.alumnos= alumnos
        
        self.reportes = repotes
    
    #METODOS GET
    def getNombre(self):
        return self.nombre
    def getAlumnos(self):
        return self.alumnos
    def getNotas(self):
        return self.notas
    def getReportes(self):
        return self.reportes

    #METODOS SET
    def setNombre(self,nombre):
        self.nombre = nombre
    def setAlumnos(self,alumnos):
        self.alumnos = alumnos
    def setNotas(self,notas):
        self.notas = notas
    def setReportes(self, Reporte):
        self.reportes = reportes
  


