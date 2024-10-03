$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'price', "width": "5%" },
            { data: 'description', "width": "25%" },
            { data: 'category.name', "width": "15%" }
        ]
    });
}