function createPessoa(){
    const primeiroNome = document.getElementById("firstName").value;
    const nomeMeio = document.getElementById("middlName").value;
    const ultimoNome = document.getElementById("lastName").value;
    const cpf = document.getElementById("cpf").value;

    const data ={
        primeiroNome: primeiroNome,
        nomeMeio: nomeMeio,
        ultimoNome: ultimoNome,
        cpf: cpf
    }


fetch("https://localhost:7098/api/Pessoa/Create", {

    method: "POST",
    headers: {
        "Content-Type": "application/json"
    },
    body: JSON.stringify(data)
}).then(Response => {
    if(!Response.ok){
        alert("Erro ao criar pessoa");
    }
    alert("Pessoa criada com sucesso!");
    window.location.href = "../index.html";
})    
}
    
