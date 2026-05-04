function SavePrice() {
    var priceValue = $("#newPrice").val();
    var priceDesc = $("#newPriceDesc").val();
    var pId = $("input[name='id']").val();

    if (priceValue == "" || priceValue <= 0) {
        alert("Lütfen geçerli bir fiyat giriniz.");
        return;
    }

    $.ajax({
        url: "/AdminPanel/ProductPriceAP/Create",
        type: "POST",
        data: { Price: priceValue, Description: priceDesc, ProductId: pId },
        success: function (res) {
            if (res.success) {
                location.reload();
            } else {
                alert("Fiyat eklenirken bir hata oluştu.");
            }
        },
        error: function () {
            alert("Sistem hatası: Controller metoduna ulaşılamadı.");
        }
    });
}

function RemovePrice(id) {
    if (confirm("Bu fiyat kaydını silmek istediğinize emin misiniz?")) {
        $.ajax({
            url: "/AdminPanel/ProductPriceAP/DeletePrice/" + id,
            type: "POST",
            success: function (res) {
                if (res.success) {
                    $("#price-row-" + id).fadeOut(300, function () { $(this).remove(); });
                } else {
                    alert("Silme işlemi başarısız.");
                }
            }
        });
    }
}