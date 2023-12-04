class mes :
    productos = []
    def __init__(self,nombre,año,productos=[]):
        self.nombre = nombre
        self.año = año 
        self.productos = productos
    #METODOS GET
    def getNombre(self):
        return self.nombre
    def getAño(self):
        return self.año
    def getProductos(self):
        return self.productos
    #METODOS SET
    def setNombre(self,nombre):
        self.nombre = nombre
    def setAño(self, año ):
        self.año = año
    def setProductos(self, productos):
        self.productos = productos