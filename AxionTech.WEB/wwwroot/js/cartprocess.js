document.addEventListener("DOMContentLoaded", function () {


    $.ajax({
        url: '/Cart/List',
        type: 'POST',
        data: { userId: 1 },
        success: function (gelenList) {
            debugger;
            var list = gelenList.data;

            list.forEach(function (item) {

                var eklenecekUrun = `<li id="product${item.productId}">
                                    <a href="#" class="photo"><img src="${item.picture}" class="cart-thumb" alt="" /></a>
                                    <h6><a href="#">${item.productname} </a></h6>
                                    <p id="quantity${item.productId}">${item.quantity}x - <span class="price">${item.price}</span></p> </li>`;

                        document.getElementById("cartDetail").insertAdjacentHTML("beforeend", eklenecekUrun);
                        var getTotal = document.getElementById("totalProcess");
                        var getTotalPrice = parseInt(getTotal.innerHTML);
                        var getNewTotal = getTotalPrice + item.price;

                        document.getElementById("deleteTag").remove();

                        var newTotalTag = `<li class="total" id="deleteTag">
                       <strong>Total</strong>: <span class="float-right" id="totalProcess">${getNewTotal}</span>
                <a href="/Cart/List" class="btn btn-default hvr-bounce-to-bottom btn-cart">SEPETE GİT</a> </li>`;

                        document.getElementById("cartDetail").insertAdjacentHTML("beforeend", newTotalTag)

                        var getProductCount = document.getElementById("cartProductCount");
                        var getCount = parseInt(getProductCount.innerHTML);
                        getCount += 1;
                        getProductCount.innerHTML = getCount;                

                });
        },
        error: function () {

            alert("Ürün sepete eklenirken bir hata oluştu.");
        }
    });



})




function AddCart(productId) {

    $.ajax({
        url: '/Cart/AddCart',
        type: 'POST',
        data: { id: productId },
        success: function (gelenCevap) {

            if (gelenCevap.success) {

                if (gelenCevap.data.id) {

                    try {//

                        var getSameProduct = document.getElementById("product" + gelenCevap.data.id + "");

                        if (getSameProduct == undefined || getSameProduct==null) {

                            var eklenecekUrun = `<li id="product${gelenCevap.data.id}">
                                    <a href="#" class="photo"><img src="${gelenCevap.data.picture}" class="cart-thumb" alt="" /></a>
                                    <h6><a href="#">${gelenCevap.data.name} </a></h6>
                                    <p id="quantity${gelenCevap.data.id}">1x - <span class="price">${gelenCevap.data.price}</span></p> </li>`;

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
                         <a href="/Cart/List" class="btn btn-default hvr-bounce-to-bottom btn-cart">SEPETE GİT</a> </li>`;

                            document.getElementById("cartDetail").insertAdjacentHTML("beforeend", newTotalTag)

                            var getProductCount = document.getElementById("cartProductCount");
                            var getCount = parseInt(getProductCount.innerHTML);
                            getCount += 1;
                            getProductCount.innerHTML = getCount;
                        }

                        else {
                            var element = document.getElementById("quantity" + gelenCevap.data.id);
                            var text = element.childNodes[0].nodeValue.trim(); // "2x -"
                            var number = parseInt(text); // 2
                            number = number + 1;
                            document.getElementById("quantity" + gelenCevap.data.id).innerHTML = number + "x -";

                        }

                    } catch (e) {


                    }

                    

                }
                else {

                }
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