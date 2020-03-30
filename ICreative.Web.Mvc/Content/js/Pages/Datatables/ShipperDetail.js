
function GetDetails(id) {
    $.ajax({
        url: '../../ShipperDetail/GetShipper/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#ShipperID').text(response.ShipperID);        					
            $('#CompanyName').text(response.CompanyName);        					
            $('#Phone').text(response.Phone);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#ShipperID').val();
    $('#OrderTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../ShipperDetail/GetOrderDataTable/' + id,
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