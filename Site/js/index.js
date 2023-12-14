document.addEventListener("DOMContentLoaded", function(){
    const pessoaList = document.getElementById("pessoa-lista");
    function renderTable(date){
        pessoaList.innerHTML = "";

        date.forEach(pessoa => {
            const row = document.createElement("tr");

            row.innerHTML = `
                <td>${pessoa.pessoaId}</td>
                <td>${pessoa.primeiroNome}</td>
                <td>${pessoa.nomeMeio}</td>
                <td>${pessoa.ultimoNome}</td>
                <td>${pessoa.cpf}</td>
                <td>
                    <button>Editar</button>
                    <button>Excluir</button>
                </td>
            `;
            pessoaList.appendChild(row);
        })
    }

    function feachPessoas(){
        fetch("https://localhost:7098/api/Pessoa/GetAll")
        .then(response => response.json())
        .then(data => renderTable(data))
        .catch(error => console.error("Error ao buscar dados da Api"))
    }
    feachPessoas();
}) 

function AbrirTelaCreate(){
    window.location.href = "pages/create.html";
}