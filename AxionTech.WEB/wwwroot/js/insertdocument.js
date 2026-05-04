Dropzone.autoDiscover = false;

$(document).ready(function () {
    var docElement = document.querySelector("#documentDropzone");

    if (docElement) {
        var myDocDz = new Dropzone(docElement, {
            url: "/AdminPanel/ProductDocumentAP/UploadDocument",
            paramName: "file",
            autoProcessQueue: false,
            acceptedFiles: ".pdf,.doc,.docx,.xls,.xlsx",
            init: function () {
                var dz = this;

                $("#dokumanYukle").click(function (e) {
                    e.preventDefault();
                    dz.processQueue();
                });

                this.on("sending", function (file, xhr, formData) {
                    var pId = $("input[name='id']").val();
                    formData.append("productId", pId);
                });

                this.on("success", function (file, response) {
                    if (response.success) {
                        var d = response.data;
                        var dId = d.id || d.Id;
                        var dName = d.fileName || d.FileName;
                        var dUrl = d.url || d.Url;

                        var html = `
                            <div class="col-sm-2 text-center mb-3" id="doc-${dId}">
                                <div class="border rounded p-3 bg-light" style="min-height: 150px;">
                                    <i class="fas fa-file-pdf fa-3x text-danger mb-2"></i>
                                    <p class="text-truncate mb-2" style="font-size: 12px;" title="${dName}">
                                        ${dName}
                                    </p>
                                    <div class="btn-group w-100">
                                        <a href="${dUrl}" target="_blank" class="btn btn-xs btn-outline-primary">Aç</a>
                                        <button type="button" class="btn btn-xs btn-outline-danger" onclick="DeleteDocument(${dId})">Sil</button>
                                    </div>
                                </div>
                            </div>`;

                        $("#dokumanList").append(html);
                        $("#no-doc-msg").remove();
                        dz.removeFile(file);
                    } else {
                        alert(response.message);
                    }
                });
            }
        });
    }
});

function DeleteDocument(id) {
    if (confirm("Bu dökümanı silmek istediğinize emin misiniz?")) {
        $.ajax({
            url: "/AdminPanel/ProductDocumentAP/DeleteDocument/" + id,
            type: "POST",
            success: function (res) {
                if (res.success) {
                    $("#doc-" + id).fadeOut(300, function () { $(this).remove(); });
                } else {
                    alert(res.message);
                }
            },
            error: function () {
                alert("Sistem hatası oluştu.");
            }
        });
    }
}