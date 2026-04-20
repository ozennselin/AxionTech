console.log("insertdocument.js aktif");

Dropzone.autoDiscover = false;

document.addEventListener("DOMContentLoaded", function () {
    var docElement = document.querySelector("#docDropzone");

    if (docElement) {
        var myDocDropzone = new Dropzone(docElement, {
            autoProcessQueue: false,
            acceptedFiles: ".pdf,.doc,.docx,.xls,.xlsx",
            init: function () {
                var dz = this;
                var submitBtn = document.querySelector("#dokumanYukle");

                submitBtn.addEventListener("click", function (e) {
                    e.preventDefault();
                    dz.processQueue();
                });

                this.on("success", function (file, response) {
                    var hedefDiv = document.getElementById("dokumanList");

                    if (hedefDiv && response.success) {
                        var docData = response.data;

                        var html = `
                            <div class="col-md-3">
                                <div class="info-box shadow-none border">
                                    <span class="info-box-icon bg-info"><i class="far fa-file-alt"></i></span>
                                    <div class="info-box-content">
                                        <span class="info-box-text text-sm">${docData.fileName}</span>
                                        <a href="${docData.url}" target="_blank" class="btn btn-xs btn-outline-info">Görüntüle</a>
                                    </div>
                                </div>
                            </div>`;

                        hedefDiv.insertAdjacentHTML("beforeend", html);
                        this.removeFile(file);
                    }
                });
            }
        });
    }
});