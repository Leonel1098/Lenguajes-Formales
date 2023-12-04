class producto :
    
    def __init__(self,nombreProducto,precio,cantidad):
        self.nombreProducto = nombreProducto
        self.precio = precio
        self.cantidad = cantidad
    #METODOS SET
    
    def setNombre(self,nombreProducto):
        self.nombreProducto = nombreProducto
    def setPrecio(self,precio):
        self.precio = precio
    def setCantidad(self,cantidad):
        self.cantidad = cantidad
    #METODOS GET    

    def getNombreProducto(self):
        return self.nombreProducto
    def getPrecio(self):
        return self.precio
    def getCantidad(self):
        return self.cantidad
        