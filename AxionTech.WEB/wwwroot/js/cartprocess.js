document.addEventListener("DOMContentLoaded", function () {

    $.ajax({
        url: '/Cart/List',
        type: 'POST',
        data: { userId: 1 },
        success: function (gelenList) {
            var list = gelenList.data;
            var cartDetail = document.getElementById("cartDetail");
            cartDetail.innerHTML = "";

            var totalAll = 0;
            var totalCount = 0;

            if (list && list.length > 0) {

                list.forEach(function (item) {

                    var urunFiyat = parseInt(item.price) || 0;
                    var urunAdet = parseInt(item.quantity) || 1;
                    var rowTotal = urunFiyat * urunAdet;

                    totalAll += rowTotal;
                    totalCount += urunAdet;

                    var eklenecekUrun = `<li id="product${item.productId}">
                        <a href="#" class="photo"><img src="${item.picture}" class="cart-thumb" alt="" /></a>
                        <h6><a href="#">${item.productName}</a></h6>
                        <p id="quantity${item.productId}">${urunAdet}x - 
                            <span class="price" id="price${item.productId}">${rowTotal}</span>
                        </p>
                    </li>`;

                    cartDetail.insertAdjacentHTML("beforeend", eklenecekUrun);
                });
            }

            var newTotalTag = `<li class="total" id="deleteTag">
                <strong>Total</strong>: 
                <span class="float-right" id="totalProcess">${totalAll}</span>
                <a href="/Cart/CartItemList" class="btn btn-default hvr-bounce-to-bottom btn-cart">SEPETE GİT</a>
            </li>`;

            cartDetail.insertAdjacentHTML("beforeend", newTotalTag);

            var getProductCount = document.getElementById("cartProductCount");
            if (getProductCount) {
                getProductCount.innerHTML = totalCount;
            }
        },
        error: function () {
            alert("Liste yüklenirken bir hata oluştu.");
        }
    });
});

function AddCart(productId) {

    $.ajax({
        url: '/Cart/AddCart',
        type: 'POST',
        data: { id: productId },
        success: function (gelenCevap) {

            if (gelenCevap.success) {

                debugger;
                gelenCevap.data.forEach(function (urunler) {

                    debugger;
                    if (urunler.productId) {
                        try {
                            // var product = gelenCevap.data;
                            var unitPrice = parseInt(urunler.price) || 0;

                            var getSameProduct = document.getElementById("product" + urunler.id);

                            if (getSameProduct == null) {
                                var deleteTag = document.getElementById("deleteTag");
                                if (deleteTag) {
                                    deleteTag.remove();
                                }

                                var eklenecekUrun = `<li id="product${urunler.id}">
                                <a href="#" class="photo"><img src="${urunler.picture}" class="cart-thumb" alt="" /></a>
                                <h6><a href="#">${urunler.name}</a></h6>
                                <p id="quantity${urunler.id}">1x - 
                                    <span class="price" id="price${urunler.id}">${unitPrice}</span>
                                </p>
                            </li>`;

                                document.getElementById("cartDetail").insertAdjacentHTML("beforeend", eklenecekUrun);

                                var getTotal = document.getElementById("totalProcess");
                                var getTotalPrice = parseInt(getTotal ? getTotal.innerHTML : 0) || 0;
                                var getNewTotal = getTotalPrice + unitPrice;

                                var newTotalTag = `<li class="total" id="deleteTag">
                                <strong>Total</strong>: 
                                <span class="float-right" id="totalProcess">${getNewTotal}</span>
                                <a href="/Cart/CartItemList" class="btn btn-default hvr-bounce-to-bottom btn-cart">SEPETE GİT</a>
                            </li>`;

                                document.getElementById("cartDetail").insertAdjacentHTML("beforeend", newTotalTag);
                            }
                            else {
                                var element = document.getElementById("quantity" + product.id);
                                var text = element.childNodes[0].nodeValue.trim();
                                var quantity = parseInt(text) || 1;

                                quantity = quantity + 1;

                                element.innerHTML = quantity + `x - 
                                <span class="price" id="price${urunler.id}">${unitPrice * quantity}</span>`;

                                var getTotal = document.getElementById("totalProcess");
                                var getTotalPrice = parseInt(getTotal.innerHTML) || 0;
                                getTotal.innerText = getTotalPrice + unitPrice;
                            }

                            var getProductCount = document.getElementById("cartProductCount");
                            if (getProductCount) {
                                var getCount = parseInt(getProductCount.innerHTML) || 0;
                                getProductCount.innerHTML = getCount + 1;
                            }

                        } catch (e) {
                            console.log(e);
                        }
                    }

                    else {
                        alert("Hata: " + gelenCevap.message);
                    }

                })
            }
        },
        error: function () {
            alert("Ürün sepete eklenirken bir hata oluştu.");
        }
    });
}

function updateLineTotal(productId) {
    var unitPriceText = document.getElementById("unitPrice_" + productId).innerText;
    var quantityValue = document.getElementById("input_" + productId).value;

    var unitPrice = parseFloat(unitPriceText) || 0;
    var quantity = parseInt(quantityValue) || 1;

    var total = unitPrice * quantity;

    var totalElement = document.getElementById("lineTotal_" + productId);
    if (totalElement) {
        totalElement.innerText = total.toFixed(2);
    }

    console.log("Ürün: " + productId + " için yeni toplam: " + total);
}