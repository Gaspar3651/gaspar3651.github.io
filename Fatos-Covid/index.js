    window.addEventListener("scroll", function(){
    var menu = document.querySelector("header")
    menu.classList.toggle("sticky", window.scrollY > 0)
})
//Botão Leia Mais
function leiamais(id){
    if(document.getElementById(id).style.display == "block"){
       document.getElementById(id).style.display = 'none'; 
       document.getElementById('b' + id).value = 'Mais'
    } else{
        document.getElementById(id).style.display = "block"  
        document.getElementById('b' + id).value = "Menos" 
    }
    
}

//Tempo
var tempo = document.getElementById("time")

var hora = new Date()

var agora = hora.getHours()

if (agora >= 18){
    tempo.innerHTML += ("Boa Noite, obrigado por ler em nosso site, deixe o seu feedback sobre o site nos comentários logo abaixo.")
}else if (agora < 5){
    tempo.innerHTML += ("Boa Madrugada, obrigado por ler em nosso site, deixe o seu feedback sobre o site nos comentários logo abaixo.")
}else if (agora >= 5 && agora < 12 ){
    tempo.innerHTML +=  ("Bom Dia, obrigado por ler em nosso site, deixe o seu feedback sobre o site nos comentários logo abaixo.")
}else if (agora >= 12){
    tempo.innerHTML += ("Boa Tarde, obrigado por ler em nosso site, deixe o seu feedback sobre o site nos comentários logo abaixo.")
}

//Animation em js
var alvo = document.querySelectorAll("[data-anime]")
var anime = "animate";
function animeScrool(){
    var topo = window.pageYOffset + ((window.innerHeight * 3 ) / 4)
    alvo.forEach(function(elemento){ 
        if((topo) > elemento.offsetTop){
            elemento.classList.add(anime)
        }else{
            elemento.classList.remove(anime)
        }
    })  
}
animeScrool()
if (alvo.length) {
window.addEventListener('scroll', function(){
    animeScrool();
})
} 