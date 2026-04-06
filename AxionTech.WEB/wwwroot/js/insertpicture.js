

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
                    e.preventDefault();
                    myDropzone.processQueue(); // Butona basınca yüklemeyi başlat
                });
                debugger;
                this.on("success", function (file, response) {
                    //console.log("Başarıyla kaydedildi:", response);
                    const yeniResim = `
                               <div class="col-sm-2" id="${response.Name}">
                                <a href="#" data-toggle="lightbox" data-title="sample 1 - white" data-gallery="gallery">
                                    <img src="${response.Url}" class="img-fluid mb-2 border rounded p-1" alt="white sample">
                                </a>
                                <div class="urun-sil">
                                    <input type="hidden" name="id" value="${response.Ids}">
                                    <button onclick="DeletePicture('${response.Id}')" type="submit" class="btn btn-danger btn-sm">Sil</button>
                                </div>
                                </div>`;

                    const hedefDiv = document.getElementById("resimList");
                    hedefDiv.insertAdjacentHTML("beforeend", yeniResim);

                });
            }
        };
    }
    else {
        console.error("Dropzone kütüphanesi yüklenemedi!");
    }
});