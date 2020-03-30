
function GetDetails(id) {
    $.ajax({
        url: '../../ProductDetail/GetProduct/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#ProductID').text(response.ProductID);        					
            $('#ProductName').text(response.ProductName);        					
            $('#QuantityPerUnit').text(response.QuantityPerUnit);        					
            $('#UnitPrice').text(response.UnitPrice);        					
            $('#UnitsInStock').text(response.UnitsInStock);        					
            $('#UnitsOnOrder').text(response.UnitsOnOrder);        					
            $('#ReorderLevel').text(response.ReorderLevel);        					
            $('#Discontinued').text(response.Discontinued);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#ProductID').val();
    $('#OrderTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../ProductDetail/GetOrderDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "OrderID" },
            { data: "OrderDate" },
            { data: "RequiredDate" },
            { data: "ShippedDate" },
            { data: "Freight" },
            { data: "ShipName" },
            { data: "ShipAddress" },
            { data: "ShipCity" },
            { data: "ShipRegion" },
            { data: "ShipPostalCode" },
            { data: "ShipCountry" }
        ]
    });    
    GetDetails(id);
});