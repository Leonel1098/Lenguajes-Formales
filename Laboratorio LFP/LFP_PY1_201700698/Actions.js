var radio = document.querySelectorAll('.radio')
var texto = document.querySelectorAll('.texto');
var option = document.getElementById('grupo-option') 
var btnif = document.getElementById('btnInfo')
var btn = document.querySelectorAll('.boton')
var s 
console.log(btn.value)

b()
function b(){
        btn.forEach(element => {
                if(element.value == 'info'){
                        element.addEventListener("click",()=>{
                                radio.forEach(e => {
                               
                                        if(e.checked == true){
                                                 window.s = e.value
                                                console.log( " es box" + s)
                                                
                                                
                                        }else{
                                               
                                        }
                                       
                                });
                        console.log(window.s)
                        console.log('Click')
                        var iframe = document.createElement('iframe')
                        iframe.width="500"
                        iframe.height= "500" 
                        let x ="" 
                         texto.forEach(tx =>{
                                       x += tx.value+'</br>'+''
                                })
1|                              console.log(x)    
                        var html = '<div><h2>'
                                +window.s+'<br>'+
                                option.value+'<br>'
                                +x+'</h2></div>'
                               
                                
                        
                                                        
                        
                        iframe.src = 'data:text/html;charset=utf-8,' + encodeURI(html);
                        document.getElementById('contenido').appendChild(iframe);
        
                        });
                }else if(element.value =='entrada'){
                        element.addEventListener("click", () => {
        
                                var iframe = document.createElement('iframe')
        
                                iframe.width="500"
                                iframe.height= "500"
                                iframe.src =  " infoAnalizador.txt";
                                document.getElementById('contenido').appendChild(iframe);
                                  
                        
                                
                        }); 
                }
        });
}
function f (){
  
        if(btn.value == 'info'){
                btn.addEventListener("click",()=>{
                        radio.forEach(e => {
                       
                                if(e.checked == true){
                                         window.s = e.value
                                        console.log( " es box" + s)
                                        
                                        
                                }else{
                                       
                                }
                               
                        });
                console.log(window.s)
                console.log('Click')
                var iframe = document.createElement('iframe')
                        
                var html = '<div><h2><ur>'     
                                +texto.value+'<br>'+
                                window.s+'<br>'+
                               option.value+'<br>'+
                 
                                                '</ur></h2></div>';
        
                iframe.src = 'data:text/html;charset=utf-8,' + encodeURI(html);
                document.getElementById('contenido').appendChild(iframe);

                });
        }else if(btn.value =='entrada'){
                btn.addEventListener("click", () => {

                        var iframe = document.createElement('iframe')

                        iframe.width="200"
                        iframe.height= "250"
                        iframe.src =  " infoAnalizador.txt";
                        document.getElementById('contenido').appendChild(iframe);
                          
                
                        
                }); 
        }

       
}

/*
var btn = document.getElementById('btnInfo').addEventListener("click", () => {
        
        radio.forEach(e => {
                       
                        if(e.checked == true){
                                 window.s = e.value
                                console.log( " es box" + s)
                                
                                
                        }else{
                               
                        }
                       
                });
        console.log(window.s)
        console.log('Click')
        var iframe = document.createElement('iframe')
                
        var html = '<div><h2><ur>'     
                        +texto.value+'<br>'+
                        window.s+'<br>'+
                       option.value+'<br>'+
         
                                        '</ur></h2></div>';

        iframe.src = 'data:text/html;charset=utf-8,' + encodeURI(html);
        document.getElementById('contenido').appendChild(iframe);
          

        
});*/
/*var btn2 =document.getElementById('btnEntrada').addEventListener("click", () => {

        var iframe = document.createElement('iframe')
        iframe.src = 'ejemploP1.form' ;
        document.getElementById('contenido').appendChild(iframe);
          

        
});*/
