console.log("insertpicture.js çalıştı");

Dropzone.autoDiscover = false;

document.addEventListener("DOMContentLoaded", function () {
    var myDropzoneElement = document.querySelector("#myDropzone");

    if (myDropzoneElement) {
        var myDropzone = new Dropzone(myDropzoneElement, {
            url: "/AdminPanel/ProductAP/Upload",
            paramName: "file",
            maxFilesize: 5,
            acceptedFiles: ".jpeg,.jpg,.png,.gif",
            autoProcessQueue: false,
            parallelUploads: 10,

            init: function () {
                var dzInstance = this;
                var submitButton = document.querySelector("#resimYukle");

                submitButton.addEventListener("click", function (e) {
                    e.preventDefault();
                    dzInstance.processQueue();
                });

                this.on("success", function (file, response) {
                    var hedefDiv = document.getElementById("resimList");

                    if (hedefDiv && response.success && response.data) {
                        var resimData = response.data;
                        var resimId = resimData.id || resimData.Id;
                        var resimName = resimData.name || resimData.Name;
                        var resimOrjinal = resimData.orjinalName || resimData.OrjinalName;

                        var yeniResim = `
                            <div class="col-sm-2" id="${resimName}">
                                <a href="#" data-toggle="lightbox" data-title="${resimOrjinal}" data-gallery="gallery">
                                    <img src="/picture/${resimName}" class="img-fluid mb-2 border rounded p-1" alt="AxionTech">
                                </a>
                                <div class="urun-sil">  
                                    <input type="hidden" name="id" value="${resimId}" />
                                    <button onclick="DeletePicture(${resimId})" type="button" class="btn btn-danger btn-sm">Sil</button>
                                </div>
                            </div>`;

                        hedefDiv.insertAdjacentHTML("beforeend", yeniResim);
                        this.removeFile(file);
                    }
                });
            }
        });
    }
});