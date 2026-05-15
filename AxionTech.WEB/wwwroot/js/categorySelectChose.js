$(document).ready(function () {

    $(document).on('change', '.category-select', function () {
        var countTag = 0;
        //function GetChildCategoryList() {
        var selectedCategoryId = $(this).val();

        $.ajax({
            url: '/AdminPanel/CategoryAP/GetChildCategoryWithId',//GetNodeList
            type: 'GET',
            data: { parentId: selectedCategoryId },

            success: function (data) {

                if (data.data.length > 0) { 
                var newCategory = `<div class="category-level">
        <select id="categoryId" name="CategoryId"  class="form-control category-select">
            <option value="0">Altkategori Seçiniz</option>
                `;

                $.each(data.data, function (i, item) {
                    newCategory += ` <option value="${item.id}">${item.name}</option>`;
                })

                newCategory += `</select></div>`;
                $('#categoryContainer').append(newCategory);
            }

        },
            error: function () {
                console.error("Alt kategoriler yüklenemdi");


            }
        });
}); 

});