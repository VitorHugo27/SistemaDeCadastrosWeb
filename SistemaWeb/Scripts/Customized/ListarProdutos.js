let id;

function Apagar(element) {
    id = $(element).data("id");
    $('#apagarModal').modal('show');
}


$("#cadastrar").on("click", function () {
    console.log(id);
    $.ajax({
        url: '/Produtos/Deletar',
        type: 'POST',
        dataType: 'json',
        data: { "id": id },
        success: function (response) {
            location.reload();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Error - ' + errorThrown);
        }
    })
});

