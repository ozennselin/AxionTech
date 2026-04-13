

function AddCart(productId) {

    $.ajax({
        url: '/Cart/AddCart',
        type: 'POST',
        data: { id: productId },
        success: function (gelenCevap) {

            if (gelenCevap.success) {

                /*
                var total = 0;
                gelenCevap.data.foreach(function (item) {


                    var eklenecekUrun = `<li>
                                    <a href="#" class="photo"><img src="${item.picture}" class="cart-thumb" alt="" /></a>
                                    <h6><a href="#">${item.name} </a></h6>
                                    <p>${item.quantity}- <span class="price">${item.price}</span></p> </li>`;
                    document.getElementById("cartDetail").insertAdjacentHTML("beforeend", eklenecekUrun);
                    total = total + item.price * item.quantity;

                });

                var newTotalTag = `<li class="total" id="deleteTag">
                       <strong>Total</strong>: <span class="float-right" id="totalProcess">${getNewTotal}</span>
                <a href="~/Cart/List" class="btn btn-default hvr-bounce-to-bottom btn-cart">SEPETE GİT</a> </li>`;
                document.getElementById("cartDetail").insertAdjacentHTML("beforeend", newTotalTag);
                */
                // alert(gelenCevap.message);
                // Sepet güncellendiğinde sayfayı yenile
                //sepet kısmına +1  ve ürünü toggle kısmına ekle

                
                var eklenecekUrun = `<li>
                                    <a href="#" class="photo"><img src="${gelenCevap.data.picture}" class="cart-thumb" alt="" /></a>
                                    <h6><a href="#">${gelenCevap.data.name} </a></h6>
                                    <p>1x - <span class="price">${gelenCevap.data.price}</span></p> </li>`;

                document.getElementById("cartDetail").insertAdjacentHTML("beforeend", eklenecekUrun);
                //${gelenCevap.data.total}
                //totalProcess=> ilkin bu sil
                //silmeden sonra yeniSekme değişkenini aşağıdaki gibi en sona ekle
                var getTotal = document.getElementById("totalProcess");
                var getTotalPrice = parseInt(getTotal.innerHTML);
                var getNewTotal = getTotalPrice + gelenCevap.data.price;

                document.getElementById("deleteTag").remove();

                var newTotalTag = `<li class="total" id="deleteTag">
                       <strong>Total</strong>: <span class="float-right" id="totalProcess">${getNewTotal}</span>
                <a href="~/Cart/List" class="btn btn-default hvr-bounce-to-bottom btn-cart">SEPETE GİT</a> </li>`;

                document.getElementById("cartDetail").insertAdjacentHTML("beforeend", newTotalTag)

                var getProductCount = document.getElementById("cartProductCount");
                var getCount = parseInt(getProductCount.innerHTML);
                getCount += 1;
                getProductCount.innerHTML = getCount;
              

                //location.reload();
                //
            }
            else {
                alert("Ürün sepete eklenirken bir hata oluştu: " + gelenCevap.message);
            }
        },
        error: function () {

            alert("Ürün sepete eklenirken bir hata oluştu.");
        }
    });
}