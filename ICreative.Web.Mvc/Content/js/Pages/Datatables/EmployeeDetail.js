
function GetDetails(id) {
    $.ajax({
        url: '../../EmployeeDetail/GetEmployee/' + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (response) {
            $('#EmployeeID').text(response.EmployeeID);        					
            $('#LastName').text(response.LastName);        					
            $('#FirstName').text(response.FirstName);        					
            $('#Title').text(response.Title);        					
            $('#TitleOfCourtesy').text(response.TitleOfCourtesy);        					
            $('#BirthDate').text(moment(response.BirthDate).format('DD/MM/YYYY'));        					
            $('#HireDate').text(moment(response.HireDate).format('DD/MM/YYYY'));        					
            $('#Address').text(response.Address);        					
            $('#City').text(response.City);        					
            $('#Region').text(response.Region);        					
            $('#PostalCode').text(response.PostalCode);        					
            $('#Country').text(response.Country);        					
            $('#HomePhone').text(response.HomePhone);        					
            $('#Extension').text(response.Extension);        					
            $('#Photo').text(response.Photo);        					
            $('#Notes').text(response.Notes);        					
            $('#PhotoPath').text(response.PhotoPath);        					
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return false;
}

$(document).ready(function () {     
    var id = $('#EmployeeID').val();
    $('#TerritoryTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../EmployeeDetail/GetTerritoryDataTable/' + id,
        "order": [[1, 'asc']],
        columns: [
            {
                render: function (data, type, full, meta) {
                    return meta.row;
                }
            },
            { data: "TerritoryID" },
            { data: "TerritoryDescription" }
        ]
    });    
    $('#OrderTable').DataTable({
        response: true,
        dom: '<"row"<"col-sm-3"f><"col-sm-2"><"col-sm-1"l>><"datatable-scroll"t><"row"i<"col-sm-6">p>',
        ajax: '../../EmployeeDetail/GetOrderDataTable/' + id,
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