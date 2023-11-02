function Apagar(element) {
    var id = $(element).data("id");
    console.log(id);

    $('#exampleModal').modal('show');
}


//$.ajax({
//    url: '/Produtos/Deletar',
//    type: 'POST',
//    dataType: 'json',
//    data: { "id": id },
//})