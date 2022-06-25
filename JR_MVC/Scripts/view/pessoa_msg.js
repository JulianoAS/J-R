$(document).ready(function () {
    

        $('#formMsg').submit(function (e) {
            e.preventDefault();
            var email = $(this).find("#email").val();
            if (validaEmail(email)) {
                limparMsg();               
              $.ajax({
                url: urlPost,
                method: "POST",
                data: {
                    "Nome": $(this).find("#nome").val(),
                    "Email": email,
                    "Mensagem": $(this).find("#mensagem").val()
                },
                error:
                    function (r) {
                        if (r.status == 400) {
                            $('#msgResult').replaceWith(
                                $('#msgResult').html(
                                    '<p class="text-center text-white font-garamond modal-result">*Ocorreu um erro!' +
                                    r.responseJSON +
                                    '</p>'
                                )
                            );
                        }
                        else if (r.status == 500)
                            $('#msgResult').replaceWith(
                                $('#msgResult').html(
                                    '<p class="text-center text-white font-garamondmodal-result">*Ocorreu um erro interno no servidor!' +
                                    r.responseJSON +
                                    '</p>'
                                )
                            );
                    },
                success:
                    function (r) {
                        $('#msgResult').replaceWith(
                            $('#msgResult').html(
                                '<p class="text-center text-white font-garamond modal-result">' + r + '</p>'
                            )
                        );

                    }
            });
            } else {
                limparMsg();
                $('#resultEbook').replaceWith(
                    $('#resultEbook').html(
                        '<p class="text-center text-white font-garamond modal-result">*Por favor informe um email válido</p>'
                    )
                );


            }
        })
 
});


function validaEmail(email) {
    var str = email;

    var er = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;

    return er.test(str);

    //if (er.test(str)) {
    //    return true;
    //} else {
    //    return false;
    //}
}

function limparMsg() {
    $('#msgResult').empty();
}


