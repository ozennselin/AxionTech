    function DeletePicture(Id) {

        if (!confirm("Bu resmi silmek istediğinize emin misiniz??:" + Id)) {
            return;
        }

        //$=> jquery// 
        $.ajax({
            url: '/AdminPanel/ProductPictureAP/DeletePicture',
            type: 'POST',
            data: { id: Id },
            success: function (response) {
                //response => gelene data dır
                //response=  success = true, message = "Resim başarıyla silindi.",data= getPicture-> hepsini kapsar

                var silinecekTag = document.getElementById('' + response.data.name + '');
                if (silinecekTag) {
                    silinecekTag.remove();
                }
                //$("#" + response).remove(); // Silinen resmin bulunduğu div'i kaldır
                console.log("Resim başarıyla silindi:" + response);
                // alert("silindi");

            },
            Error: function () {
                // alert("Hata")
                console.log("hata");
            }


        });
    }