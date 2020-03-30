
function GetDetails(id) {
    $.ajax({
        url: '../../OrderDetail/GetOrder/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#OrderID').text(response.OrderID);        					
            $('#OrderDate').text(moment(response.OrderDate).format('DD/MM/YYYY'));        					
            $('#RequiredDate').text(moment(response.RequiredDate).format('DD/MM/YYYY'));        					
            $('#ShippedDate').text(moment(response.ShippedDate).format('DD/MM/YYYY'));        					
            $('#Freight').text(response.Freight);        					
            $('#ShipName').text(response.ShipName);        					
            $('#ShipAddress').text(response.ShipAddress);        					
            $('#ShipCity').text(response.ShipCity);        					
            $('#ShipRegion').text(response.ShipRegion);        					
            $('#ShipPostalCode').text(response.ShipPostalCode);        					
            $('#ShipCountry').text(response.ShipCountry);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#OrderID').val();
    $('#ProductTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../OrderDetail/GetProductDataTable/' + id,
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