
package ejemplosnumeros;

public class Analizador {
    public int estado;
    public String cadena;
    
    public Analizador(){
        
    }
    
    public void escanear(String entrada){
        String entrada1=entrada;
        estado=0;
        char pares[]={'0','2','4','6','8',};
        char impares[]={'1','3','5','7','9'};
        
        char c;
        
        
        for(int i=0;i<=entrada1.length()-1;i++){
            
           c=entrada1.charAt(i);
           
           switch(estado){
               case 0:{
                   for(int j=0;j<=pares.length-1;j++){
                       if(c==pares[j]){
                           estado=1;
                       }
                       
                   }
                   for(int k=0;k<=impares.length-1;k++){
                       if(c==impares[k]){
                           estado=2;
                       }
                   }
                   
                   break;
               }
               case 1:{
                   for(int j=0;j<=pares.length-1;j++){
                    if(c==pares[j]){
                        estado=4;
                    }   
                   }
                   for(int k=0;k<=impares.length-1;k++){
                       if(c==impares[k]){
                           estado=3;
                       }
                   }
                   break;
           }
               case 3:{
                   for(int j=0;j<=pares.length-1;j++){
                       if(c==pares[j]){
                           estado=1;
                       }
                   }
                   for(int k=0;k<=impares.length-1;k++){
                       if(c==impares[k]){
                           estado=3;
                       }
                   }
                   break;
               }
               case 2:{
                   for(int j=0;j<=pares.length-1;j++){
                      if(c==pares[j]){
                          estado=1;
                      }   
                   }
                   for(int k=0;k<=impares.length-1;k++){
                       if(c==impares[k]){
                           estado=2;
                       }
                   }
                   break;
               }
           }
           
           
        }
        if(estado==3 | estado==2 | estado==1){
            System.out.println("La cadena fue aceptada");
            
        }else{
            System.out.println("La cadena no es valida");
        }
        
        
    
        
    }
    
}
