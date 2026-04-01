

function AddCart(productId) {

    $.ajax({
        url: '/Cart/AddCart',
        type: 'POST',
        data: { id: productId },
        success: function (gelenCevap) {

            if (gelenCevap.success) {
                alert(gelenCevap.message);
                // Sepet güncellendiğinde sayfayı yenile
                location.reload();
            } else {
                alert("Ürün sepete eklenirken bir hata oluştu: " + gelenCevap.message);
            }
        },
        error: function () {

            alert("Ürün sepete eklenirken bir hata oluştu.");
        }
    });
}