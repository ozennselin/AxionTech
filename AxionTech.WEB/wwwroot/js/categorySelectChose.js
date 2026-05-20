
$(document).ready(function () {

    //var countChildCategory = parseInt(1);

    $(document).on('change', '.category-select', function () {

        //function GetChildCategoryList() {
        var selectedCategoryId = $(this).val();
        $(this).closest('.category-level').nextAll('.category-level').remove();

        $.ajax({
            url: '/AdminPanel/CategoryAP/GetChildCategoryWithId',//GetNodeList
            type: 'GET',
            data: { parentId: selectedCategoryId },

            success: function (data) {


                if (data.data.length > 0) {

                    //ountChildCategory++;
                    var newCategory = `<div class="category-level mb-2"> <select id="categoryId" name="CategoryId"  class="form-control category-select"> <option value="0">Altkategori Seçiniz</option> `;

                    $.each(data.data, function (i, item) {
                        newCategory += ` <option value="${item.id}">${item.name}</option>`;
                    })

                    newCategory += `</select></div>`;
                    $('#categoryContainer').append(newCategory);
                    //son eklenen DDL için class adı ile son indexe sahip olan DDL in Id değerini verecek
                }
            },
            error: function () {
                console.error("Alt kategoriler yüklenemdi");
            }
        });
    });
    $(document).on('change', '#isMainCategory', function () {

        if ($(this).is(":checked")) {

            $("#parentCategorySelect").attr("disabled", "disabled");
            $("#parentCategorySelect").val("0");
            $("#parentCategorySelect").closest('.category-level').nextAll('.category-level').remove();

        }
        else {

            $("#parentCategorySelect").removeAttr("disabled");

        }

    });
});