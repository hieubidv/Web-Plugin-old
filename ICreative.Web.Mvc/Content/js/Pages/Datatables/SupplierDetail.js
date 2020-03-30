
function GetDetails(id) {
    $.ajax({
        url: '../../SupplierDetail/GetSupplier/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#SupplierID').text(response.SupplierID);        					
            $('#CompanyName').text(response.CompanyName);        					
            $('#ContactName').text(response.ContactName);        					
            $('#ContactTitle').text(response.ContactTitle);        					
            $('#Address').text(response.Address);        					
            $('#City').text(response.City);        					
            $('#Region').text(response.Region);        					
            $('#PostalCode').text(response.PostalCode);        					
            $('#Country').text(response.Country);        					
            $('#Phone').text(response.Phone);        					
            $('#Fax').text(response.Fax);        					
            $('#HomePage').text(response.HomePage);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#SupplierID').val();
    $('#ProductTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../SupplierDetail/GetProductDataTable/' + id,
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