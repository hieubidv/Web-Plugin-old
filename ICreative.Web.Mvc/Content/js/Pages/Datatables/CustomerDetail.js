
function GetDetails(id) {
    $.ajax({
        url: '../../CustomerDetail/GetCustomer/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#CustomerID').text(response.CustomerID);        					
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
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#CustomerID').val();
    $('#CustomerDemographicTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../CustomerDetail/GetCustomerDemographicDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "CustomerTypeID" },
            { data: "CustomerDesc" }
        ]
    });    
    $('#OrderTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../CustomerDetail/GetOrderDataTable/' + id,
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