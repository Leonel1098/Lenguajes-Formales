
package cantidades_analisis;

public class Analizador {
    public int estado;
    public Analizador(){
        
    }
    
    public void AnalizadorLexico(String entrada1){
        
         //Terminales 
         /*
         d={1,2,3,4,5,6,7,8,9,0}
         c={,}----p={.}----simbolos={-,+}
         */
         String entrada=entrada1;
         estado=0;
         char digitos[]={'1','2','3','4','5','6','7','8','9','0'};
         
         char c;
         for(int i=0;i<=entrada.length()-1;i++){
             c=entrada.charAt(i);
             switch(estado){
                 case 0:{
                     
                     if((c=='-') | (c=='+') ){
                         estado=1;
                     }else{
                         for(int j=0;j<=digitos.length-1;j++){
                             if(c==digitos[j]){
                                 estado=2;
                             }
                         }
                     }
                     break;
                 }
                 case 1:{
                     for(int j=0;j<=digitos.length-1;j++){
                             if(c==digitos[j]){
                                 estado=2;
                             }
                    }
                     break;
                 }
                 case 2:{
                     if(c=='.'){
                         estado=3;
                     }else if(c==','){
                         estado=7;
                     }
                     for(int j=0;j<=digitos.length-1;j++){
                         if(c==digitos[j]){
                             estado=5;
                         }
                     }
                     break;
                 }
                 case 3:{
                     for(int j=0;j<=digitos.length-1;j++){
                         if(c==digitos[j]){
                             estado=4;
                         }
                     }
                     break;
                 }
                 case 4:{
                     for(int j=0;j<=digitos.length-1;j++){
                         if(c==digitos[j]){
                             estado=4;
                         }
                     }
                     
                     break;
                 }
                 case 5:{
                     if(c=='.'){
                         estado=3;
                     }else if(c==','){
                         estado=7;
                     }
                     
                     for(int j=0;j<=digitos.length-1;j++){
                         if(c==digitos[j]){
                             estado=6;
                         }
                     }
                     break;
                 }
                 case 6:{
                     if(c=='.'){
                         estado=4;
                     }else if(c==','){
                         estado=7;
                     }
                     break;
                     
                 }
                 case 7:{
                     for(int j=0;j<=digitos.length-1;j++){
                         if(c==digitos[j]){
                             estado=8;
                         }
                     }
                     break;
                 }
                 case 8:{
                     for(int j=0;j<=digitos.length-1;j++){
                         if(c==digitos[j]){
                             estado=9;
                         }
                     }
                     break;
                 }
                 case 9:{
                     for(int j=0;j<=digitos.length-1;j++){
                         if(c==digitos[j]){
                             estado=6;
                         }
                     }
                     break;
                 }
                 
             }
             
         }
         
         if(estado==2 | estado==4 | estado==5 | estado==6){
             System.out.println("Cadena aceptada");
         }else{
             System.out.println("Cadena no aceptada");
         }
        
        
        
        
    }
    
    
    
}
