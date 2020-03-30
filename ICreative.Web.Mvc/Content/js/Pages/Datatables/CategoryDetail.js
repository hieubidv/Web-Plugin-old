
function GetDetails(id) {
    $.ajax({
        url: '../../CategoryDetail/GetCategory/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#CategoryID').text(response.CategoryID);        					
            $('#CategoryName').text(response.CategoryName);        					
            $('#Description').text(response.Description);        					
            $('#Picture').text(response.Picture);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#CategoryID').val();
    $('#ProductTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../CategoryDetail/GetProductDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "ProductID" },
            { data: "ProductName" },
            { data: "QuantityPerUnit" },
            { data: "UnitPrice" },
            { data: "UnitsInStock" },
            { data: "UnitsOnOrder" },
            { data: "ReorderLevel" },
            { data: "Discontinued" }
        ]
    });    
    GetDetails(id);
});