console.log("insertpicture.js çalıştı");
document.addEventListener("DOMContentLoaded", function () {

    if (typeof Dropzone !== 'undefined') {

        Dropzone.options.myDropzone = {
            paramName: "file", // Controller'daki parametre ismiyle aynı olmalı
            maxFilesize: 5, // MB
            acceptedFiles: ".jpeg,.jpg,.png,.gif",
            autoProcessQueue: false,
            parallelUploads: 10,
            init: function (respo1) {
                debugger;
                var submitButton = document.querySelector("#resimYukle");
                var myDropzone = this;

                submitButton.addEventListener("click", function (e) {
                    console.log("butona basıldı");
                    e.preventDefault();
                    myDropzone.processQueue();
                }); // Butona basınca yüklemeyi başlat
               

                debugger;

                this.on("success", function (file, response) {
                    var productId = document.querySelector("#productId").value;

                    var request = {
                        ProductId: parseInt(productId),
                        Url: response.Url,
                        IsMain: false,
                        DisplayOrder: 1,
                        OrjinalName: response.OrjinalName,
                        Name: response.Name
                    };

                    fetch("/AdminPanel/ProductAP/CreatePicture", {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: JSON.stringify(request)
                    })
                        .then(res => res.json())
                        .then(data => {
                            const yeniResim = `
                               <div class="col-sm-2" id="${response.Name}">
                                <a href="${response.Url}" data-toggle="lightbox" data-title="${response.OrjinalName}" data-gallery="gallery">
                                    <img src="${response.Url}" class="img-fluid mb-2 border rounded p-1" alt="white sample">
                                </a>
                                </div>`;

                            const hedefDiv = document.getElementById("resimList");
                            if (hedefDiv) {
                                hedefDiv.insertAdjacentHTML("beforeend", yeniResim);
                            }
                        })
                        .catch(err => {
                            console.log("Kayıt hatası:", err);
                        });
                });
            }
        };
    }
    else {
        console.error("Dropzone kütüphanesi yüklenemedi!");
    }
});